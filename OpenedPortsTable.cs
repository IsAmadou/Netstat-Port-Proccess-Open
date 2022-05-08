using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Collections.Generic;
/// <summary>
/// Classe donnant accès à la liste des ports ouverts/connectés du système
/// </summary>
/// <remarks></remarks>
namespace NetstatUI
{
    public class OpenedPortsTable
    {
        //IPv4
        private const Int32 AF_INET = 2;

        /// <summary>
        /// Etat d'une connexion TCP
        /// </summary>
        /// <remarks></remarks>
        public enum TcpState
        {
            CLOSE_WAIT = 8,
            CLOSED = 1,
            CLOSING = 9,
            DELETE_TCB = 12,
            ESTAB = 5,
            FIN_WAIT1 = 6,
            FIN_WAIT2 = 7,
            LAST_ACK = 10,
            LISTEN = 2,
            SYN_RCVD = 4,
            SYN_SENT = 3,
            TIME_WAIT = 11
        }

        /// <summary>
        /// Une connexion TCP
        /// </summary>
        /// <remarks></remarks>
        public class TcpEntry : IComparable<TcpEntry>
        {
            private TcpState m_State;
            /// <summary>
            /// Etat de la connexion
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public TcpState State
            {
                get { return m_State; }
            }
            private IPEndPoint m_RemoteEndPoint;
            /// <summary>
            /// Adresse IP et port distants
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPEndPoint RemoteEndPoint
            {
                get { return m_RemoteEndPoint; }
            }
            private IPEndPoint m_LocalEndPoint;
            /// <summary>
            /// Adresse IP et port locaux
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPEndPoint LocalEndPoint
            {
                get { return m_LocalEndPoint; }
            }
            private int m_ProcessID;
            /// <summary>
            /// PID du processus qui a initié cette connexion
            /// </summary>
            /// <remarks></remarks>
            public int ProcessID
            {
                get { return m_ProcessID; }
            }
            private string m_ProcessName = null;
            /// <summary>
            /// Nom du processus qui a initié la connexion
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public string ProcessName
            {
                get
                {
                    if (string.IsNullOrEmpty(this.m_ProcessName))
                    {
                        this.m_ProcessName = System.Diagnostics.Process.GetProcessById(this.ProcessID).ProcessName;
                    }
                    return this.m_ProcessName;
                }
            }

            public TcpEntry(TcpState state, UInt32 remoteAddr, int remotePort, UInt32 localAddress, int localPort, int processID)
            {
                this.m_State = state;
                this.m_RemoteEndPoint = new IPEndPoint(remoteAddr, remotePort);
                this.m_ProcessID = processID;
                this.m_LocalEndPoint = new IPEndPoint(localAddress, localPort);
            }

            /// <summary>
            /// Ferme la connexion de force
            /// </summary>
            /// <remarks></remarks>
            public void Close()
            {
                MIB_TCPROW_EX tcpEntry = new MIB_TCPROW_EX();
                //reremplit chacune des infos identifiant la connexion
                tcpEntry.dwLocalAddr = BitConverter.ToUInt32(this.LocalEndPoint.Address.GetAddressBytes(), 0);
                tcpEntry.dwLocalPort = this.LocalEndPoint.Port;
                tcpEntry.dwRemoteAddr = BitConverter.ToUInt32(this.RemoteEndPoint.Address.GetAddressBytes(), 0);
                tcpEntry.dwRemotePort = this.RemoteEndPoint.Port;
                //la définie comme supprimée
                tcpEntry.dwState = TcpState.DELETE_TCB;

                //envoie la demande de close
                int ret = SetTcpEntry(ref tcpEntry);
                if (ret != 0)
                    throw new System.ComponentModel.Win32Exception(ret);
            }

            /// <summary>
            /// Compare deux connections TCP
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            /// <remarks></remarks>
            public int CompareTo(TcpEntry other)
            {
                //d'abord par processus
                if (this.ProcessName.Equals(other.ProcessName))
                {
                    //puis par état
                    if (this.State.Equals(other.State))
                    {
                        //puis par machine distante
                        return this.RemoteEndPoint.Port.CompareTo(other.RemoteEndPoint.Port);
                    }
                    else
                    {
                        return this.State.CompareTo(other.State);
                    }
                }
                else
                {
                    return this.ProcessName.CompareTo(other.ProcessName);
                }
            }
        }

        /// <summary>
        /// Une connexion UDP
        /// </summary>
        /// <remarks></remarks>
        public class UdpEntry : IComparable<UdpEntry>
        {
            private IPEndPoint m_LocalEndPoint;
            /// <summary>
            /// Adresse IP et port d'écoute local
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPEndPoint LocalEndPoint
            {
                get { return m_LocalEndPoint; }
            }
            private int m_ProcessID;
            /// <summary>
            /// PID du processus ayant initié l'ouverture du port UDP
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int ProcessID
            {
                get { return m_ProcessID; }
            }
            private string m_ProcessName = null;
            /// <summary>
            /// Processus ayant initié l'ouverture du port UDP
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public string ProcessName
            {
                get
                {
                    if (string.IsNullOrEmpty(this.m_ProcessName))
                    {
                        this.m_ProcessName = System.Diagnostics.Process.GetProcessById(this.ProcessID).ProcessName;
                    }
                    return this.m_ProcessName;
                }
            }

            public UdpEntry(UInt32 localAddress, int localPort, int processID)
            {
                this.m_ProcessID = processID;
                this.m_LocalEndPoint = new IPEndPoint(localAddress, localPort);
            }

            /// <summary>
            /// Compare deux connexions UDP
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            /// <remarks></remarks>
            public int CompareTo(UdpEntry other)
            {
                //d'abord par processus
                if (this.ProcessName.Equals(other.ProcessName))
                {
                    //puis par port local
                    return this.LocalEndPoint.Port.CompareTo(other.LocalEndPoint.Port);
                }
                else
                {
                    return this.ProcessName.CompareTo(other.ProcessName);
                }
            }
        }

        //une entrée TCP
        private struct MIB_TCPROW_EX
        {
            public TcpState dwState;
            public UInt32 dwLocalAddr;
            public int dwLocalPort;
            public UInt32 dwRemoteAddr;
            public int dwRemotePort;
            public int dwProcessId;
        }

        //une entrée UDP
        private struct MIB_UDPROW_EX
        {
            public UInt32 dwLocalAddr;
            public int dwLocalPort;
            public int dwProcessId;
        }

        private const Int32 ERROR_INSUFFICIENT_BUFFER = 122;
        //récupère le handle du tas du processus
        [DllImport("kernel32")]
        private static extern IntPtr GetProcessHeap();
        //libère une zone mémoire du tas
        [DllImport("kernel32")]
        private static extern int HeapFree(IntPtr hHeap, int dwFlags, IntPtr lpMem);
        //2000/XP
        //récupère la table TCP
        [DllImport("IPHLPAPI")]
        private static extern Int32 AllocateAndGetTcpExTableFromStack(ref IntPtr ppTCPTable, [MarshalAs(UnmanagedType.Bool)] bool bOrder, IntPtr hHeap, IntPtr dwFlags, Int32 dwFamily);
        //et UDP
        [DllImport("IPHLPAPI")]
        private static extern Int32 AllocateAndGetUdpExTableFromStack(ref IntPtr ppUDPTable, [MarshalAs(UnmanagedType.Bool)] bool bOrder, IntPtr hHeap, IntPtr dwFlags, Int32 dwFamily);


        //type de structure à récupérer
        private enum TCP_TABLE_CLASS
        {
            TCP_TABLE_BASIC_LISTENER,
            TCP_TABLE_BASIC_CONNECTIONS,
            TCP_TABLE_BASIC_ALL,
            TCP_TABLE_OWNER_PID_LISTENER,
            TCP_TABLE_OWNER_PID_CONNECTIONS,
            TCP_TABLE_OWNER_PID_ALL,
            TCP_TABLE_OWNER_MODULE_LISTENER,
            TCP_TABLE_OWNER_MODULE_CONNECTIONS,
            TCP_TABLE_OWNER_MODULE_ALL
        }
        //type de structure à récupérer
        private enum UDP_TABLE_CLASS
        {
            UDP_TABLE_BASIC,
            UDP_TABLE_OWNER_PID,
            UDP_TABLE_OWNER_MODULE
        }

        //XP SP2, Vista et supérieurs
        //récupère la table TCP
        [DllImport("IPHLPAPI")]
        private static extern int GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool bOrder, int dwFamily, TCP_TABLE_CLASS dwClass, int dwReserved);
        //et UDP
        [DllImport("IPHLPAPI")]
        private static extern int GetExtendedUdpTable(IntPtr pUdpTable, ref int dwOutBufLen, bool bOrder, int dwFamily, UDP_TABLE_CLASS dwClass, int dwReserved);
        //permet de fermer une connexion TCP
        [DllImport("IPHLPAPI")]
        private static extern int SetTcpEntry(ref MIB_TCPROW_EX pTcpRow);

        private List<TcpEntry> m_TcpTable = new List<TcpEntry>();
        /// <summary>
        /// Liste des entrées de la table TCP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public IEnumerable<TcpEntry> TCPTable
        {
            get { return m_TcpTable; }
        }
        private List<UdpEntry> m_UdpTable = new List<UdpEntry>();
        /// <summary>
        /// Liste des entrées de la table UDP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public IEnumerable<UdpEntry> UDPTable
        {
            get { return m_UdpTable; }
        }

        //indique s'il s'agit de Vista
        private bool IsWindowsVista()
        {
            return ((Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version.Major == 6) && (Environment.OSVersion.Version.Minor == 0));
        }

        public OpenedPortsTable()
        {
            //pointeur vers la table
            IntPtr ptrTable;
            //taille de la table
            int outBufLen;
            //valeur de retour des appels API
            int ret;
            //si vista et supérieur
            //if (IsWindowsVista())
            //{
                //récupère la taille de la table TCP avec les nouvelles API
                ptrTable = IntPtr.Zero;
                outBufLen = 0;
                ret = GetExtendedTcpTable(IntPtr.Zero, ref outBufLen, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, 0);

                try
                {
                    //alloue la mémoire pour la table
                    ptrTable = Marshal.AllocHGlobal(outBufLen);
                    ret = GetExtendedTcpTable(ptrTable, ref outBufLen, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, 0);
                    //si réussi
                    if (ret == 0)
                    {
                        //récupère le nombre d'entrées
                        int dwNumEntries = Marshal.ReadInt32(ptrTable);
                        IntPtr ptr = new IntPtr(ptrTable.ToInt64() + 4);
                        //pour chaque entrée
                        for (int i = 0; i <= dwNumEntries - 1; i++)
                        {
                            //lit l'entrée
                            MIB_TCPROW_EX entry = (MIB_TCPROW_EX)Marshal.PtrToStructure(ptr, typeof(MIB_TCPROW_EX));
                            //extrait les infos
                            this.m_TcpTable.Add(new TcpEntry(entry.dwState, entry.dwRemoteAddr, entry.dwRemotePort, entry.dwLocalAddr, entry.dwLocalPort, entry.dwProcessId));
                            ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(MIB_TCPROW_EX)));
                        }
                        //tri la table
                        this.m_TcpTable.Sort();
                    }
                    else
                    {
                        throw new System.ComponentModel.Win32Exception(ret);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    //libère la mémoire
                    Marshal.FreeHGlobal(ptrTable);
                }

                //récupère la taille de la table UDP avec les nouvelles API
                ptrTable = IntPtr.Zero;
                outBufLen = 0;
                ret = GetExtendedUdpTable(IntPtr.Zero, ref outBufLen, true, AF_INET, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0);

                try
                {
                    //alloue la mémoire pour la table
                    ptrTable = Marshal.AllocHGlobal(outBufLen);
                    ret = GetExtendedUdpTable(ptrTable, ref outBufLen, true, AF_INET, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0);
                    //si réussi
                    if (ret == 0)
                    {
                        //récupère le nombre d'entrées
                        int dwNumEntries = Marshal.ReadInt32(ptrTable);
                        IntPtr ptr = new IntPtr(ptrTable.ToInt64() + 4);
                        //pour chaque entrée
                        for (int i = 0; i <= dwNumEntries - 1; i++)
                        {
                            //lit l'entrée
                            MIB_UDPROW_EX entry = (MIB_UDPROW_EX)Marshal.PtrToStructure(ptr, typeof(MIB_UDPROW_EX));
                            //extrait les infos
                            this.m_UdpTable.Add(new UdpEntry(entry.dwLocalAddr, entry.dwLocalPort, entry.dwProcessId));
                            ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(MIB_UDPROW_EX)));
                        }
                        //tri la table
                        this.m_UdpTable.Sort();
                    }
                    else
                    {
                        throw new System.ComponentModel.Win32Exception(ret);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    //libère la mémoire
                    Marshal.FreeHGlobal(ptrTable);
                }
            }
        //    else
        //    {
        //        //si 2000/XP

        //        //récupère un pointeur vers la table TCP allouée dans le tas
        //        ptrTable = IntPtr.Zero;
        //        outBufLen = 0;
        //        ret = AllocateAndGetTcpExTableFromStack(ref ptrTable, true, GetProcessHeap(), IntPtr.Zero, AF_INET);
        //        if (ret == 0 && ptrTable != IntPtr.Zero)
        //        {
        //            //lit le nombre d'entrées de la table
        //            int dwNumEntries = Marshal.ReadInt32(ptrTable);
        //            IntPtr ptr = new IntPtr(ptrTable.ToInt32() + 4);
        //            //pour chaque entrée
        //            for (int i = 0; i <= dwNumEntries - 1; i++)
        //            {
        //                //lit et extrait les infos de la connexion TCP
        //                MIB_TCPROW_EX entry = (MIB_TCPROW_EX)Marshal.PtrToStructure(ptr, typeof(MIB_TCPROW_EX));
        //                this.m_TcpTable.Add(new TcpEntry(entry.dwState, entry.dwRemoteAddr, entry.dwRemotePort, entry.dwLocalAddr, entry.dwLocalPort, entry.dwProcessId));
        //                ptr = new IntPtr(ptr.ToInt32() + Marshal.SizeOf(typeof(MIB_TCPROW_EX)));
        //            }
        //            //tri les connexions
        //            this.m_TcpTable.Sort();
        //            //libère la zone mémoire allouée dans le tas par l'API AllocateAndGetTcpExTableFromStack
        //            HeapFree(GetProcessHeap(), 0, ptrTable);
        //        }
        //        else
        //        {
        //            throw new System.ComponentModel.Win32Exception(ret);
        //        }

        //        //récupère un pointeur vers la table UDP allouée dans le tas
        //        ptrTable = IntPtr.Zero;
        //        outBufLen = 0;
        //        ret = AllocateAndGetUdpExTableFromStack(ref ptrTable, true, GetProcessHeap(), IntPtr.Zero, AF_INET);
        //        if (ret == 0 && ptrTable != IntPtr.Zero)
        //        {
        //            //lit le nombre d'entrées de la table
        //            int dwNumEntries = Marshal.ReadInt32(ptrTable);
        //            IntPtr ptr = new IntPtr(ptrTable.ToInt32() + 4);
        //            //pour chaque entrée
        //            for (int i = 0; i <= dwNumEntries - 1; i++)
        //            {
        //                //lit et extrait les infos de la connexion UDP
        //                MIB_UDPROW_EX entry = (MIB_UDPROW_EX)Marshal.PtrToStructure(ptr, typeof(MIB_UDPROW_EX));
        //                this.m_UdpTable.Add(new UdpEntry(entry.dwLocalAddr, entry.dwLocalPort, entry.dwProcessId));
        //                ptr = new IntPtr(ptr.ToInt32() + Marshal.SizeOf(typeof(MIB_UDPROW_EX)));
        //            }
        //            //tri les connexions
        //            this.m_UdpTable.Sort();
        //            //libère la zone mémoire allouée dans le tas par l'API AllocateAndGetUdpExTableFromStack
        //            HeapFree(GetProcessHeap(), 0, ptrTable);
        //        }
        //        else
        //        {
        //            throw new System.ComponentModel.Win32Exception(ret);
        //        }
        //    }
        //}
    }
}

