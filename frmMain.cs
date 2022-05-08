using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace NetstatUI
{
    public partial class frmMain
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.RefreshAll();
        }

        private void RefreshAll()
        {
            try
            {
                AdaptersTable adpts = new AdaptersTable();

                OpenedPortsTable openedPorts = new OpenedPortsTable();
                bsTCP.DataSource = openedPorts.TCPTable;
                bsUDP.DataSource = openedPorts.UDPTable;
                InterfaceIPTable intfs = new InterfaceIPTable(adpts);
                bsIntfs.DataSource = intfs.InterfacesIPs;
                RouteTable route = new RouteTable(adpts);
                bsRoute.DataSource = route.ForwardEntries;
                ArpTable arp = new ArpTable(adpts);
                bsArp.DataSource = arp.ArpEntries;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            this.RefreshAll();
        }

        private void CloseConnectionToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            OpenedPortsTable.TcpEntry tcpEntry = null;
            if (tcpEntry != null)
            {
                try
                {
                    tcpEntry.Close();
                    MessageBox.Show("Port successfully closed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

