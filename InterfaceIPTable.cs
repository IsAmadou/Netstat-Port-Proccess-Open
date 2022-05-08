using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections.Generic;
/// <summary>
/// Table des adresses IP des interfaces
/// </summary>
/// <remarks></remarks>
namespace NetstatUI
{
    public class InterfaceIPTable
    {
        /// <summary>
        /// Type d'adresse
        /// </summary>
        /// <remarks></remarks>
        [Flags()]
        public enum InterfaceAddressFlag : short
        {
            Primary = 0x1,
            Unk1 = 0x2,
            Dynamic = 0x4,
            Disconnected = 0x8,
            Unk2 = 0x10,
            Unk3 = 0x20,
            Deleted = 0x40,
            Transient = 0x80
        }

        /// <summary>
        /// Une entrée d'adresse IP des interfaces
        /// </summary>
        /// <remarks></remarks>
        public class InterfaceIPEntry
        {
            private IPAddress m_Address;
            /// <summary>
            /// Adresse IP de l'interface
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPAddress Address
            {
                get { return m_Address; }
            }
            private IPAddress m_Mask;
            /// <summary>
            /// Masque du sous réseau de l'adresse IP
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPAddress Mask
            {
                get { return m_Mask; }
            }

            private InterfaceAddressFlag m_Flags;
            /// <summary>
            /// Type d'adresse IP
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public InterfaceAddressFlag Flags
            {
                get { return m_Flags; }
            }
            private int m_ReasmSize;
            /// <summary>
            /// Taille de la fenêtre de réassemblage des paquets reçu par cette IP
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int ReassembleSize
            {
                get { return m_ReasmSize; }
            }
            private System.Net.NetworkInformation.NetworkInterface m_Interface;
            /// <summary>
            /// Interface relative de cette adresse IP
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

            public InterfaceIPEntry(UInt32 address, UInt32 mask, InterfaceAddressFlag flags, int reasmsize, System.Net.NetworkInformation.NetworkInterface intf)
            {
                this.m_Address = new IPAddress(address);
                this.m_Flags = flags;
                this.m_Interface = intf;
                this.m_Mask = new IPAddress(mask);
                this.m_ReasmSize = reasmsize;
            }
        }

        //une entrée de la table des adresses IP des interfaces
        private struct MIB_IPADDRROW
        {
            public UInt32 dwAddr;
            public int dwIndex;
            public UInt32 dwMask;
            public UInt32 dwBCastAddr;
            public int dwReasmSize;
            public short unused1;
            public InterfaceAddressFlag wType;
        }

        //lit la table des adresses IP des interfaces
        [DllImport("IPHLPAPI")]
        private static extern int GetIpAddrTable(IntPtr pIpAddrTable, ref Int32 pdwSize, bool bOrder);

        private List<InterfaceIPEntry> m_InterfacesIPs = new List<InterfaceIPEntry>();
        /// <summary>
        /// Liste des adresses IP des interfaces
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public IEnumerable<InterfaceIPEntry> InterfacesIPs
        {
            get { return m_InterfacesIPs; }
        }

        /// <summary>
        /// Lit la table des adresses IP des interfaces
        /// </summary>
        /// <remarks></remarks>
        public InterfaceIPTable(AdaptersTable adapters)
        {
            //pointeur vers la table des adresses IP des interfaces
            IntPtr ptrTable;
            //taille de cette table
            int outBufLen;
            //valeur de retour des appels API
            int ret;

            //récupère la taille de la table
            ptrTable = IntPtr.Zero;
            outBufLen = 0;
            ret = GetIpAddrTable(IntPtr.Zero, ref outBufLen, true);

            try
            {
                //alloue la mémoire pour la table
                ptrTable = Marshal.AllocHGlobal(outBufLen);
                //lit la table
                ret = GetIpAddrTable(ptrTable, ref outBufLen, true);
                //si réussi
                if (ret == 0)
                {
                    //récupère le nombre d'entrée dans la table dans le premier DWORD
                    int dwNumEntries = Marshal.ReadInt32(ptrTable);
                    IntPtr ptr = new IntPtr(ptrTable.ToInt64() + 4);
                    //pour chaque entrée
                    for (int i = 0; i <= dwNumEntries - 1; i++)
                    {
                        //lit l'entrée
                        MIB_IPADDRROW entry = (MIB_IPADDRROW)Marshal.PtrToStructure(ptr, typeof(MIB_IPADDRROW));
                        //extrait les infos
                        this.m_InterfacesIPs.Add(new InterfaceIPEntry(entry.dwAddr, entry.dwMask, entry.wType, entry.dwReasmSize, adapters.GetAdapter(entry.dwIndex)));
                        ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(MIB_IPADDRROW)));
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

