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
/// Classe donnant accès la table ARP
/// </summary>
/// <remarks></remarks>
namespace NetstatUI
{
    public class ArpTable
    {
        /// <summary>
        /// Type d'entrée de la table ARP
        /// </summary>
        /// <remarks></remarks>
        public enum ArpFlags
        {
            Static = 4,
            Dynamic = 3,
            Invalid = 2,
            Other = 1
        }
        //taille d'une adresse MAC en mémoire
        private const int MAXLEN_PHYSADDR = 8;
        //une entrée de la table ARP
        private struct MIB_IPNETROW
        {
            public int dwIndex;
            public int dwPhysAddrLen;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_PHYSADDR)]
            public byte[] bPhysAddr;
            public UInt32 dwAddr;
            public ArpFlags dwType;
        }

        /// <summary>
        /// Une entrée de la table ARP
        /// </summary>
        /// <remarks></remarks>
        public class ArpEntry
        {
            private IPAddress m_Address;
            /// <summary>
            /// Adresse IP distante
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPAddress Address
            {
                get { return m_Address; }
            }

            private System.Net.NetworkInformation.NetworkInterface m_Interface;
            /// <summary>
            /// Interface sur laquelle les adresses IP et MAC sont accessibles directement
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public System.Net.NetworkInformation.NetworkInterface RelatedInterface
            {
                get { return m_Interface; }
            }
            public string InterfaceName
            {
                get
                {
                    if (this.RelatedInterface == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return this.RelatedInterface.Name;
                    }
                }
            }
            private byte[] m_MacAddress;
            /// <summary>
            /// Adresse MAC distante
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public byte[] MacAddress
            {
                get { return m_MacAddress; }
            }
            public string MacAddressString
            {
                get { return string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", this.MacAddress[0], this.MacAddress[1], this.MacAddress[2], this.MacAddress[3], this.MacAddress[4], this.MacAddress[5]); }
            }
            private ArpFlags m_Flags;
            /// <summary>
            /// Type d'entrée ARP
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public ArpFlags Flags
            {
                get { return m_Flags; }
            }

            public ArpEntry(System.Net.NetworkInformation.NetworkInterface intf, byte[] macAddress, UInt32 address, ArpFlags flags)
            {
                this.m_MacAddress = macAddress;
                this.m_Flags = flags;
                this.m_Address = new IPAddress(address);

                this.m_Interface = intf;
            }
        }

        //Private Declare Function SendARP Lib "IPHLPAPI.dll" (ByVal DestIP As Integer, ByVal SrcIP As Integer, ByVal pMacAddr As IntPtr, ByRef pdwPhyAddrLen As Integer) As Integer

        //lit la table ARP
        [DllImport("IPHLPAPI")]
        private static extern int GetIpNetTable(IntPtr pIpNetTable, ref int pdwSize, bool bOrder);


        private List<ArpEntry> m_ArpEntries = new List<ArpEntry>();
        /// <summary>
        /// Liste des entrées de la table ARP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public IEnumerable<ArpEntry> ArpEntries
        {
            get { return m_ArpEntries; }
        }

        /// <summary>
        /// Lit la table ARP
        /// </summary>
        /// <remarks></remarks>
        public ArpTable(AdaptersTable adapters)
        {
            //pointeur vers la table ARP
            IntPtr ptrTable;
            //taille de la table ARP
            int outBufLen;
            //valeur de retour des appels API
            int ret;

            //récupère la taille de table ARP
            ptrTable = IntPtr.Zero;
            outBufLen = 0;
            ret = GetIpNetTable(IntPtr.Zero, ref outBufLen, true);

            try
            {
                //alloue la mémoire pour la table ARP
                ptrTable = Marshal.AllocHGlobal(outBufLen);
                //lit la table
                ret = GetIpNetTable(ptrTable, ref outBufLen, true);
                //si réussi
                if (ret == 0)
                {
                    //récupère le nombre d'entrées dans le premier DWORD
                    int dwNumEntries = Marshal.ReadInt32(ptrTable);
                    IntPtr ptr = new IntPtr(ptrTable.ToInt64() + 4);
                    //pour chaque entrée
                    for (int i = 0; i <= dwNumEntries - 1; i++)
                    {
                        //lit l'entrée
                        MIB_IPNETROW entry = (MIB_IPNETROW)Marshal.PtrToStructure(ptr, typeof(MIB_IPNETROW));
                        //extrait les infos
                        this.m_ArpEntries.Add(new ArpEntry(adapters.GetAdapter(entry.dwIndex), entry.bPhysAddr, entry.dwAddr, entry.dwType));
                        ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(MIB_IPNETROW)));
                    }
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
    }
}

