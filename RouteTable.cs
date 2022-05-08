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
/// Classe donnant accès à la table de routage du système
/// </summary>
/// <remarks></remarks>
namespace NetstatUI
{
    public class RouteTable
    {
        /// <summary>
        /// Type de route
        /// </summary>
        /// <remarks></remarks>
        public enum ForwardType
        {
            Other = 1,
            Invalid = 2,
            Direct = 3,
            Indirect = 4
        }

        /// <summary>
        /// Protocole qui a inscrit la route dans la table
        /// </summary>
        /// <remarks></remarks>
        public enum ForwardProtocol
        {
            Other = 1,
            Local = 2,
            NetMGMT = 3,
            ICMP = 4,
            EGP = 5,
            GGP = 6,
            Hello = 7,
            RIP = 8,
            IS_IS = 9,
            ES_IS = 10,
            CISCO = 11,
            BBN = 12,
            OSPF = 13,
            BGP = 14,
            NT_AUTOSTATIC = 10002,
            NT_STATIC = 10006,
            NT_STATIC_NON_DOD = 10007
        }

        //une ligne de routage
        private struct MIB_IPFORWARDROW
        {
            public UInt32 dwForwardDest;
            public UInt32 dwForwardMask;
            public int dwForwardPolicy;
            public UInt32 dwForwardNextHop;
            public int dwForwardIfIndex;
            public ForwardType dwForwardType;
            public ForwardProtocol dwForwardProto;
            public int dwForwardAge;
            public int dwForwardNextHopAS;
            public int dwForwardMetric1;
            public int dwForwardMetric2;
            public int dwForwardMetric3;
            public int dwForwardMetric4;
            public int dwForwardMetric5;
        }

        /// <summary>
        /// Une entrée de routage
        /// </summary>
        /// <remarks></remarks>
        public class ForwardEntry
        {
            private IPAddress m_Destination;
            /// <summary>
            /// Adresse du réseau de destination de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPAddress Destination
            {
                get { return m_Destination; }
            }
            private IPAddress m_Mask;
            /// <summary>
            /// Masque de sous réseau du réseau de destination de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPAddress Mask
            {
                get { return m_Mask; }
            }
            private int m_Policy;
            /// <summary>
            /// Règle de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int Policy
            {
                get { return m_Policy; }
            }
            private IPAddress m_NextHop;
            /// <summary>
            /// Adresse du prochain saut pour atteindre le réseau de destination de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IPAddress NextHop
            {
                get { return m_NextHop; }
            }
            private System.Net.NetworkInformation.NetworkInterface m_Interface;
            /// <summary>
            /// Interface qui mène vers le réseau de destination
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
            private ForwardType m_Type;
            /// <summary>
            /// Type de route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public ForwardType ForwardType
            {
                get { return m_Type; }
            }
            private ForwardProtocol m_Proto;
            /// <summary>
            /// Protocole de routage ayant fourni cette route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public ForwardProtocol Protocol
            {
                get { return m_Proto; }
            }
            private int m_Age;
            /// <summary>
            /// Age de la route dans la table de routage
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int Age
            {
                get { return m_Age; }
            }
            private int m_NextHopAS;
            /// <summary>
            /// numéro du système autonome de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int NextHopAS
            {
                get { return m_NextHopAS; }
            }
            private int m_Metric1;
            /// <summary>
            /// Première métrique de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int Metric1
            {
                get { return m_Metric1; }
            }
            private int m_Metric2;
            /// <summary>
            /// Autre métrique de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int Metric2
            {
                get { return m_Metric2; }
            }
            private int m_Metric3;
            /// <summary>
            /// Autre métrique de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int Metric3
            {
                get { return m_Metric3; }
            }
            private int m_Metric4;
            /// <summary>
            /// Autre métrique de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int Metric4
            {
                get { return m_Metric4; }
            }
            private int m_Metric5;
            /// <summary>
            /// Autre métrique de la route
            /// </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int Metric5
            {
                get { return m_Metric5; }
            }

            public ForwardEntry(UInt32 destination, UInt32 mask, int policy, UInt32 nextHop, System.Net.NetworkInformation.NetworkInterface intf, ForwardType type, ForwardProtocol proto, int age, int nextHopAS, int metric1,
            int metric2, int metric3, int metric4, int metric5)
            {
                this.m_Age = age;
                this.m_Policy = policy;
                this.m_Proto = proto;
                this.m_Type = type;

                this.m_Destination = new IPAddress(destination);
                this.m_Mask = new IPAddress(mask);
                this.m_NextHop = new IPAddress(nextHop);
                this.m_NextHopAS = nextHopAS;

                this.m_Interface = intf;

                this.m_Metric1 = metric1;
                this.m_Metric2 = metric2;
                this.m_Metric3 = metric3;
                this.m_Metric4 = metric4;
                this.m_Metric5 = metric5;

            }
        }

        //lit la table de routage
        [DllImport("IPHLPAPI")]
        private static extern int GetIpForwardTable(IntPtr pIpForwardTable, ref int pdwSize, bool bOrder);

        private List<ForwardEntry> m_ForwardEntries = new List<ForwardEntry>();
        /// <summary>
        /// Liste des entrées de la table de routage
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public IEnumerable<ForwardEntry> ForwardEntries
        {
            get { return m_ForwardEntries; }
        }

        /// <summary>
        /// Récupère la table de routage du système
        /// </summary>
        /// <remarks></remarks>
        public RouteTable(AdaptersTable adapters)
        {
            //pointeur vers la table de routage
            IntPtr ptrTable;
            //taille de la table de routage
            int outBufLen;
            //valeur de retour des appels API
            int ret;

            //demande la taille de la table de routage
            ptrTable = IntPtr.Zero;
            outBufLen = 0;
            ret = GetIpForwardTable(IntPtr.Zero, ref outBufLen, true);

            try
            {
                //alloue l'espace mémoire pour la table de routage
                ptrTable = Marshal.AllocHGlobal(outBufLen);
                //lit la table
                ret = GetIpForwardTable(ptrTable, ref outBufLen, true);
                //si réussi
                if (ret == 0)
                {
                    //pour chaque entrée de la table de routage
                    int dwNumEntries = Marshal.ReadInt32(ptrTable);
                    //le premier DWORD contient le nombre d'entrée
                    IntPtr ptr = new IntPtr(ptrTable.ToInt64() + 4);
                    for (int i = 0; i <= dwNumEntries - 1; i++)
                    {
                        //lit la ligne de la table de routage
                        MIB_IPFORWARDROW entry = (MIB_IPFORWARDROW)Marshal.PtrToStructure(ptr, typeof(MIB_IPFORWARDROW));
                        //extrait les infos
                        this.m_ForwardEntries.Add(new ForwardEntry(entry.dwForwardDest, entry.dwForwardMask, entry.dwForwardPolicy, entry.dwForwardNextHop, adapters.GetAdapter(entry.dwForwardIfIndex), entry.dwForwardType, entry.dwForwardProto, entry.dwForwardAge, entry.dwForwardNextHopAS, entry.dwForwardMetric1,
                        entry.dwForwardMetric2, entry.dwForwardMetric3, entry.dwForwardMetric4, entry.dwForwardMetric5));
                        ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(MIB_IPFORWARDROW)));
                    }
                }
                else
                {
                    //si erreur
                    throw new System.ComponentModel.Win32Exception(ret);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //libère la mémoire allouée
                Marshal.FreeHGlobal(ptrTable);
            }
        }
    }
}

