using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
/// <summary>
/// Classe donnant accès à la liste des interfaces réseaux
/// </summary>
/// <remarks></remarks>
namespace NetstatUI
{
    public class AdaptersTable
    {
        private const int MAX_INTERFACE_NAME_LEN = 256;
        private const int MAXLEN_IFDESCR = 256;
        private const int MAXLEN_PHYSADDR = 8;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct MIB_IFROW
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_INTERFACE_NAME_LEN)]
            public string wszName;
            public int dwIndex;
            public int dwType;
            public int dwMtu;
            public int dwSpeed;
            public int dwPhysAddrLen;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_PHYSADDR)]
            public byte[] bPhysAddr;
            public int dwAdminStatus;
            public int dwOperStatus;
            public int dwLastChange;
            public int dwInOctets;
            public int dwInUcastPkts;
            public int dwInNUcastPkts;
            public int dwInDiscards;
            public int dwInErrors;
            public int dwInUnknownProtos;
            public int dwOutOctets;
            public int dwOutUcastPkts;
            public int dwOutNUcastPkts;
            public int dwOutDiscards;
            public int dwOutErrors;
            public int dwOutQLen;
            public int dwDescrLen;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_IFDESCR)]
            public byte[] bDescr;
        }
        [DllImport("IPHLPAPI")]
        private static extern int GetIfTable(IntPtr pIfTable, ref int pdwSize, bool bOrder);
        [DllImport("IPHLPAPI")]
        private static extern int GetIfEntry(ref MIB_IFROW pIfRow);

        private Dictionary<int, System.Net.NetworkInformation.NetworkInterface> m_Adapters = new Dictionary<int, System.Net.NetworkInformation.NetworkInterface>();
        /// <summary>
        /// Liste des interfaces réseaux
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public IDictionary<int, System.Net.NetworkInformation.NetworkInterface> Adapters
        {
            get { return m_Adapters; }
        }

        /// <summary>
        /// Renvoie une interface à partir de son Index (qui n'est pas forcément consécutif)
        /// </summary>
        /// <param name="dwIndex"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public System.Net.NetworkInformation.NetworkInterface GetAdapter(int dwIndex)
        {
            System.Net.NetworkInformation.NetworkInterface ni = null;
            m_Adapters.TryGetValue(dwIndex, out ni);
            return ni;
        }

        /// <summary>
        /// Lit la table des adresses
        /// </summary>
        /// <remarks></remarks>
        public AdaptersTable()
        {
            //pointeur vers la table des interfaces
            IntPtr ptrTable;
            //taille de cette table
            int outBufLen;
            //valeur de retour des appels API
            int ret;

            //récupère la taille de la table
            ptrTable = IntPtr.Zero;
            outBufLen = 0;
            ret = GetIfTable(IntPtr.Zero, ref outBufLen, true);

            System.Net.NetworkInformation.NetworkInterface[] intfs = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            try
            {
                //alloue la mémoire pour la table
                ptrTable = Marshal.AllocHGlobal(outBufLen);
                //lit la table
                ret = GetIfTable(ptrTable, ref outBufLen, true);
                //si réussi
                if (ret == 0)
                {
                    //récupère le nombre d'entrée dans la table dans le premier DWORD
                    int dwNumEntries = Marshal.ReadInt32(ptrTable);
                    IntPtr ptr = new IntPtr(ptrTable.ToInt64()+4);
                    //pour chaque entrée
                    for (int i = 0; i <= dwNumEntries - 1; i++)
                    {
                        //lit l'entrée
                        MIB_IFROW entry = (MIB_IFROW)Marshal.PtrToStructure(ptr, typeof(MIB_IFROW));

                        //A noter que la structure de la table MIB_IFTABLE a visiblement une structure non égale à sa définition dans MSDN
                        //par exemple, wszName se trouve remplit "au hasard"

                        //lit vraiment l'entrée à partir de son index
                        MIB_IFROW e = new MIB_IFROW();
                        e.dwIndex = entry.dwIndex;
                        if (GetIfEntry(ref e) == 0)
                        {
                            //récupère la description
                            string desc = System.Text.Encoding.ASCII.GetString(entry.bDescr, 0, e.dwDescrLen - 1);
                            //essaie de faire correspondre l'interface à celle de .Net
                            foreach (System.Net.NetworkInformation.NetworkInterface ni in intfs)
                            {
                                if (ni.Description == desc)
                                {
                                    this.m_Adapters.Add(entry.dwIndex, ni);
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }
                        }
                        ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(MIB_IFROW)));
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

