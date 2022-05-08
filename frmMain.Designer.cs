using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace NetstatUI
{
  partial class frmMain : System.Windows.Forms.Form
  {
    //Form overrides dispose to clean up the component list.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
      try {
        if (disposing && components != null) {
          components.Dispose();
        }
      } finally {
        base.Dispose(disposing);
      }
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.dgvTCP = new System.Windows.Forms.DataGridView();
        this.ProcessNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.LocalEndPointDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.RemoteEndPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.StateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ProcessIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.CloseConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.bsTCP = new System.Windows.Forms.BindingSource(this.components);
        this.TabControl1 = new System.Windows.Forms.TabControl();
        this.tabPorts = new System.Windows.Forms.TabPage();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.dgvUDP = new System.Windows.Forms.DataGridView();
        this.ProcessNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.LocalEndPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ProcessIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.bsUDP = new System.Windows.Forms.BindingSource(this.components);
        this.tabInterface = new System.Windows.Forms.TabPage();
        this.dgvIntfs = new System.Windows.Forms.DataGridView();
        this.InterfaceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.AddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.MaskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.FlagsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ReassembleSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.bsIntfs = new System.Windows.Forms.BindingSource(this.components);
        this.tabRoute = new System.Windows.Forms.TabPage();
        this.dgvRoute = new System.Windows.Forms.DataGridView();
        this.DestinationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.MaskDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.NextHopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.InterfaceNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ForwardTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PrototypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Metric1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Metric2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Metric3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Metric4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Metric5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.AgeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.NextHopASDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PolicyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.bsRoute = new System.Windows.Forms.BindingSource(this.components);
        this.tabArp = new System.Windows.Forms.TabPage();
        this.dgvArp = new System.Windows.Forms.DataGridView();
        this.MacAddressStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.AddressDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.InterfaceNameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.FlagsDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.bsArp = new System.Windows.Forms.BindingSource(this.components);
        this.btnExit = new System.Windows.Forms.Button();
        this.btnRefresh = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvTCP)).BeginInit();
        this.ContextMenuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.bsTCP)).BeginInit();
        this.TabControl1.SuspendLayout();
        this.tabPorts.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvUDP)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsUDP)).BeginInit();
        this.tabInterface.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvIntfs)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsIntfs)).BeginInit();
        this.tabRoute.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvRoute)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsRoute)).BeginInit();
        this.tabArp.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvArp)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsArp)).BeginInit();
        this.SuspendLayout();
        // 
        // dgvTCP
        // 
        this.dgvTCP.AllowUserToAddRows = false;
        this.dgvTCP.AllowUserToDeleteRows = false;
        this.dgvTCP.AutoGenerateColumns = false;
        this.dgvTCP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvTCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvTCP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessNameDataGridViewTextBoxColumn1,
            this.LocalEndPointDataGridViewTextBoxColumn1,
            this.RemoteEndPointDataGridViewTextBoxColumn,
            this.StateDataGridViewTextBoxColumn,
            this.ProcessIDDataGridViewTextBoxColumn1});
        this.dgvTCP.ContextMenuStrip = this.ContextMenuStrip1;
        this.dgvTCP.DataSource = this.bsTCP;
        this.dgvTCP.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvTCP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        this.dgvTCP.Location = new System.Drawing.Point(3, 16);
        this.dgvTCP.Name = "dgvTCP";
        this.dgvTCP.ReadOnly = true;
        this.dgvTCP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.dgvTCP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvTCP.ShowCellErrors = false;
        this.dgvTCP.ShowCellToolTips = false;
        this.dgvTCP.ShowEditingIcon = false;
        this.dgvTCP.ShowRowErrors = false;
        this.dgvTCP.Size = new System.Drawing.Size(504, 277);
        this.dgvTCP.TabIndex = 0;
        // 
        // ProcessNameDataGridViewTextBoxColumn1
        // 
        this.ProcessNameDataGridViewTextBoxColumn1.DataPropertyName = "ProcessName";
        this.ProcessNameDataGridViewTextBoxColumn1.HeaderText = "ProcessName";
        this.ProcessNameDataGridViewTextBoxColumn1.Name = "ProcessNameDataGridViewTextBoxColumn1";
        this.ProcessNameDataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // LocalEndPointDataGridViewTextBoxColumn1
        // 
        this.LocalEndPointDataGridViewTextBoxColumn1.DataPropertyName = "LocalEndPoint";
        this.LocalEndPointDataGridViewTextBoxColumn1.HeaderText = "LocalEndPoint";
        this.LocalEndPointDataGridViewTextBoxColumn1.Name = "LocalEndPointDataGridViewTextBoxColumn1";
        this.LocalEndPointDataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // RemoteEndPointDataGridViewTextBoxColumn
        // 
        this.RemoteEndPointDataGridViewTextBoxColumn.DataPropertyName = "RemoteEndPoint";
        this.RemoteEndPointDataGridViewTextBoxColumn.HeaderText = "RemoteEndPoint";
        this.RemoteEndPointDataGridViewTextBoxColumn.Name = "RemoteEndPointDataGridViewTextBoxColumn";
        this.RemoteEndPointDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // StateDataGridViewTextBoxColumn
        // 
        this.StateDataGridViewTextBoxColumn.DataPropertyName = "State";
        this.StateDataGridViewTextBoxColumn.HeaderText = "State";
        this.StateDataGridViewTextBoxColumn.Name = "StateDataGridViewTextBoxColumn";
        this.StateDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // ProcessIDDataGridViewTextBoxColumn1
        // 
        this.ProcessIDDataGridViewTextBoxColumn1.DataPropertyName = "ProcessID";
        this.ProcessIDDataGridViewTextBoxColumn1.HeaderText = "ProcessID";
        this.ProcessIDDataGridViewTextBoxColumn1.Name = "ProcessIDDataGridViewTextBoxColumn1";
        this.ProcessIDDataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // ContextMenuStrip1
        // 
        this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseConnectionToolStripMenuItem});
        this.ContextMenuStrip1.Name = "ContextMenuStrip1";
        this.ContextMenuStrip1.Size = new System.Drawing.Size(167, 48);
        // 
        // CloseConnectionToolStripMenuItem
        // 
        this.CloseConnectionToolStripMenuItem.Name = "CloseConnectionToolStripMenuItem";
        this.CloseConnectionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        this.CloseConnectionToolStripMenuItem.Text = "Close connection";
        this.CloseConnectionToolStripMenuItem.Click += new System.EventHandler(this.CloseConnectionToolStripMenuItem_Click);
        // 
        // bsTCP
        // 
        this.bsTCP.DataSource = typeof(NetstatUI.OpenedPortsTable.TcpEntry);
        // 
        // TabControl1
        // 
        this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.TabControl1.Controls.Add(this.tabPorts);
        this.TabControl1.Controls.Add(this.tabInterface);
        this.TabControl1.Controls.Add(this.tabRoute);
        this.TabControl1.Controls.Add(this.tabArp);
        this.TabControl1.Location = new System.Drawing.Point(0, 0);
        this.TabControl1.Name = "TabControl1";
        this.TabControl1.SelectedIndex = 0;
        this.TabControl1.Size = new System.Drawing.Size(530, 553);
        this.TabControl1.TabIndex = 1;
        // 
        // tabPorts
        // 
        this.tabPorts.Controls.Add(this.GroupBox2);
        this.tabPorts.Controls.Add(this.GroupBox1);
        this.tabPorts.Location = new System.Drawing.Point(4, 22);
        this.tabPorts.Name = "tabPorts";
        this.tabPorts.Padding = new System.Windows.Forms.Padding(3);
        this.tabPorts.Size = new System.Drawing.Size(522, 527);
        this.tabPorts.TabIndex = 0;
        this.tabPorts.Text = "Opened Ports";
        this.tabPorts.UseVisualStyleBackColor = true;
        // 
        // GroupBox2
        // 
        this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.GroupBox2.Controls.Add(this.dgvTCP);
        this.GroupBox2.Location = new System.Drawing.Point(6, 6);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(510, 296);
        this.GroupBox2.TabIndex = 3;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "Table TCP :";
        // 
        // GroupBox1
        // 
        this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.GroupBox1.Controls.Add(this.dgvUDP);
        this.GroupBox1.Location = new System.Drawing.Point(6, 308);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(510, 213);
        this.GroupBox1.TabIndex = 2;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Table UDP :";
        // 
        // dgvUDP
        // 
        this.dgvUDP.AllowUserToAddRows = false;
        this.dgvUDP.AllowUserToDeleteRows = false;
        this.dgvUDP.AutoGenerateColumns = false;
        this.dgvUDP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvUDP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvUDP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessNameDataGridViewTextBoxColumn,
            this.LocalEndPointDataGridViewTextBoxColumn,
            this.ProcessIDDataGridViewTextBoxColumn});
        this.dgvUDP.DataSource = this.bsUDP;
        this.dgvUDP.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvUDP.Location = new System.Drawing.Point(3, 16);
        this.dgvUDP.Name = "dgvUDP";
        this.dgvUDP.ReadOnly = true;
        this.dgvUDP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvUDP.Size = new System.Drawing.Size(504, 194);
        this.dgvUDP.TabIndex = 1;
        // 
        // ProcessNameDataGridViewTextBoxColumn
        // 
        this.ProcessNameDataGridViewTextBoxColumn.DataPropertyName = "ProcessName";
        this.ProcessNameDataGridViewTextBoxColumn.HeaderText = "ProcessName";
        this.ProcessNameDataGridViewTextBoxColumn.Name = "ProcessNameDataGridViewTextBoxColumn";
        this.ProcessNameDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // LocalEndPointDataGridViewTextBoxColumn
        // 
        this.LocalEndPointDataGridViewTextBoxColumn.DataPropertyName = "LocalEndPoint";
        this.LocalEndPointDataGridViewTextBoxColumn.HeaderText = "LocalEndPoint";
        this.LocalEndPointDataGridViewTextBoxColumn.Name = "LocalEndPointDataGridViewTextBoxColumn";
        this.LocalEndPointDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // ProcessIDDataGridViewTextBoxColumn
        // 
        this.ProcessIDDataGridViewTextBoxColumn.DataPropertyName = "ProcessID";
        this.ProcessIDDataGridViewTextBoxColumn.HeaderText = "ProcessID";
        this.ProcessIDDataGridViewTextBoxColumn.Name = "ProcessIDDataGridViewTextBoxColumn";
        this.ProcessIDDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // bsUDP
        // 
        this.bsUDP.DataSource = typeof(NetstatUI.OpenedPortsTable.UdpEntry);
        // 
        // tabInterface
        // 
        this.tabInterface.Controls.Add(this.dgvIntfs);
        this.tabInterface.Location = new System.Drawing.Point(4, 22);
        this.tabInterface.Name = "tabInterface";
        this.tabInterface.Padding = new System.Windows.Forms.Padding(3);
        this.tabInterface.Size = new System.Drawing.Size(522, 527);
        this.tabInterface.TabIndex = 1;
        this.tabInterface.Text = "Interfaces Table";
        this.tabInterface.UseVisualStyleBackColor = true;
        // 
        // dgvIntfs
        // 
        this.dgvIntfs.AllowUserToAddRows = false;
        this.dgvIntfs.AllowUserToDeleteRows = false;
        this.dgvIntfs.AutoGenerateColumns = false;
        this.dgvIntfs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvIntfs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InterfaceNameDataGridViewTextBoxColumn,
            this.AddressDataGridViewTextBoxColumn,
            this.MaskDataGridViewTextBoxColumn,
            this.FlagsDataGridViewTextBoxColumn,
            this.ReassembleSizeDataGridViewTextBoxColumn});
        this.dgvIntfs.DataSource = this.bsIntfs;
        this.dgvIntfs.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvIntfs.Location = new System.Drawing.Point(3, 3);
        this.dgvIntfs.Name = "dgvIntfs";
        this.dgvIntfs.ReadOnly = true;
        this.dgvIntfs.Size = new System.Drawing.Size(516, 521);
        this.dgvIntfs.TabIndex = 0;
        // 
        // InterfaceNameDataGridViewTextBoxColumn
        // 
        this.InterfaceNameDataGridViewTextBoxColumn.DataPropertyName = "InterfaceName";
        this.InterfaceNameDataGridViewTextBoxColumn.HeaderText = "InterfaceName";
        this.InterfaceNameDataGridViewTextBoxColumn.Name = "InterfaceNameDataGridViewTextBoxColumn";
        this.InterfaceNameDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // AddressDataGridViewTextBoxColumn
        // 
        this.AddressDataGridViewTextBoxColumn.DataPropertyName = "Address";
        this.AddressDataGridViewTextBoxColumn.HeaderText = "Address";
        this.AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn";
        this.AddressDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // MaskDataGridViewTextBoxColumn
        // 
        this.MaskDataGridViewTextBoxColumn.DataPropertyName = "Mask";
        this.MaskDataGridViewTextBoxColumn.HeaderText = "Mask";
        this.MaskDataGridViewTextBoxColumn.Name = "MaskDataGridViewTextBoxColumn";
        this.MaskDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // FlagsDataGridViewTextBoxColumn
        // 
        this.FlagsDataGridViewTextBoxColumn.DataPropertyName = "Flags";
        this.FlagsDataGridViewTextBoxColumn.HeaderText = "Flags";
        this.FlagsDataGridViewTextBoxColumn.Name = "FlagsDataGridViewTextBoxColumn";
        this.FlagsDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // ReassembleSizeDataGridViewTextBoxColumn
        // 
        this.ReassembleSizeDataGridViewTextBoxColumn.DataPropertyName = "ReassembleSize";
        this.ReassembleSizeDataGridViewTextBoxColumn.HeaderText = "ReassembleSize";
        this.ReassembleSizeDataGridViewTextBoxColumn.Name = "ReassembleSizeDataGridViewTextBoxColumn";
        this.ReassembleSizeDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // bsIntfs
        // 
        this.bsIntfs.DataSource = typeof(NetstatUI.InterfaceIPTable.InterfaceIPEntry);
        // 
        // tabRoute
        // 
        this.tabRoute.Controls.Add(this.dgvRoute);
        this.tabRoute.Location = new System.Drawing.Point(4, 22);
        this.tabRoute.Name = "tabRoute";
        this.tabRoute.Size = new System.Drawing.Size(522, 527);
        this.tabRoute.TabIndex = 2;
        this.tabRoute.Text = "Route table";
        this.tabRoute.UseVisualStyleBackColor = true;
        // 
        // dgvRoute
        // 
        this.dgvRoute.AllowUserToAddRows = false;
        this.dgvRoute.AllowUserToDeleteRows = false;
        this.dgvRoute.AutoGenerateColumns = false;
        this.dgvRoute.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvRoute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DestinationDataGridViewTextBoxColumn,
            this.MaskDataGridViewTextBoxColumn1,
            this.NextHopDataGridViewTextBoxColumn,
            this.InterfaceNameDataGridViewTextBoxColumn1,
            this.ForwardTypeDataGridViewTextBoxColumn,
            this.PrototypeDataGridViewTextBoxColumn,
            this.Metric1DataGridViewTextBoxColumn,
            this.Metric2DataGridViewTextBoxColumn,
            this.Metric3DataGridViewTextBoxColumn,
            this.Metric4DataGridViewTextBoxColumn,
            this.Metric5DataGridViewTextBoxColumn,
            this.AgeDataGridViewTextBoxColumn,
            this.NextHopASDataGridViewTextBoxColumn,
            this.PolicyDataGridViewTextBoxColumn});
        this.dgvRoute.DataSource = this.bsRoute;
        this.dgvRoute.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvRoute.Location = new System.Drawing.Point(0, 0);
        this.dgvRoute.Name = "dgvRoute";
        this.dgvRoute.ReadOnly = true;
        this.dgvRoute.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.dgvRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvRoute.ShowCellErrors = false;
        this.dgvRoute.ShowCellToolTips = false;
        this.dgvRoute.ShowEditingIcon = false;
        this.dgvRoute.ShowRowErrors = false;
        this.dgvRoute.Size = new System.Drawing.Size(522, 527);
        this.dgvRoute.TabIndex = 0;
        // 
        // DestinationDataGridViewTextBoxColumn
        // 
        this.DestinationDataGridViewTextBoxColumn.DataPropertyName = "Destination";
        this.DestinationDataGridViewTextBoxColumn.HeaderText = "Destination";
        this.DestinationDataGridViewTextBoxColumn.Name = "DestinationDataGridViewTextBoxColumn";
        this.DestinationDataGridViewTextBoxColumn.ReadOnly = true;
        this.DestinationDataGridViewTextBoxColumn.Width = 85;
        // 
        // MaskDataGridViewTextBoxColumn1
        // 
        this.MaskDataGridViewTextBoxColumn1.DataPropertyName = "Mask";
        this.MaskDataGridViewTextBoxColumn1.HeaderText = "Mask";
        this.MaskDataGridViewTextBoxColumn1.Name = "MaskDataGridViewTextBoxColumn1";
        this.MaskDataGridViewTextBoxColumn1.ReadOnly = true;
        this.MaskDataGridViewTextBoxColumn1.Width = 58;
        // 
        // NextHopDataGridViewTextBoxColumn
        // 
        this.NextHopDataGridViewTextBoxColumn.DataPropertyName = "NextHop";
        this.NextHopDataGridViewTextBoxColumn.HeaderText = "NextHop";
        this.NextHopDataGridViewTextBoxColumn.Name = "NextHopDataGridViewTextBoxColumn";
        this.NextHopDataGridViewTextBoxColumn.ReadOnly = true;
        this.NextHopDataGridViewTextBoxColumn.Width = 74;
        // 
        // InterfaceNameDataGridViewTextBoxColumn1
        // 
        this.InterfaceNameDataGridViewTextBoxColumn1.DataPropertyName = "InterfaceName";
        this.InterfaceNameDataGridViewTextBoxColumn1.HeaderText = "InterfaceName";
        this.InterfaceNameDataGridViewTextBoxColumn1.Name = "InterfaceNameDataGridViewTextBoxColumn1";
        this.InterfaceNameDataGridViewTextBoxColumn1.ReadOnly = true;
        this.InterfaceNameDataGridViewTextBoxColumn1.Width = 102;
        // 
        // ForwardTypeDataGridViewTextBoxColumn
        // 
        this.ForwardTypeDataGridViewTextBoxColumn.DataPropertyName = "ForwardType";
        this.ForwardTypeDataGridViewTextBoxColumn.HeaderText = "ForwardType";
        this.ForwardTypeDataGridViewTextBoxColumn.Name = "ForwardTypeDataGridViewTextBoxColumn";
        this.ForwardTypeDataGridViewTextBoxColumn.ReadOnly = true;
        this.ForwardTypeDataGridViewTextBoxColumn.Width = 94;
        // 
        // PrototypeDataGridViewTextBoxColumn
        // 
        this.PrototypeDataGridViewTextBoxColumn.DataPropertyName = "Protocol";
        this.PrototypeDataGridViewTextBoxColumn.HeaderText = "Protocol";
        this.PrototypeDataGridViewTextBoxColumn.Name = "PrototypeDataGridViewTextBoxColumn";
        this.PrototypeDataGridViewTextBoxColumn.ReadOnly = true;
        this.PrototypeDataGridViewTextBoxColumn.Width = 71;
        // 
        // Metric1DataGridViewTextBoxColumn
        // 
        this.Metric1DataGridViewTextBoxColumn.DataPropertyName = "Metric1";
        this.Metric1DataGridViewTextBoxColumn.HeaderText = "Metric1";
        this.Metric1DataGridViewTextBoxColumn.Name = "Metric1DataGridViewTextBoxColumn";
        this.Metric1DataGridViewTextBoxColumn.ReadOnly = true;
        this.Metric1DataGridViewTextBoxColumn.Width = 67;
        // 
        // Metric2DataGridViewTextBoxColumn
        // 
        this.Metric2DataGridViewTextBoxColumn.DataPropertyName = "Metric2";
        this.Metric2DataGridViewTextBoxColumn.HeaderText = "Metric2";
        this.Metric2DataGridViewTextBoxColumn.Name = "Metric2DataGridViewTextBoxColumn";
        this.Metric2DataGridViewTextBoxColumn.ReadOnly = true;
        this.Metric2DataGridViewTextBoxColumn.Width = 67;
        // 
        // Metric3DataGridViewTextBoxColumn
        // 
        this.Metric3DataGridViewTextBoxColumn.DataPropertyName = "Metric3";
        this.Metric3DataGridViewTextBoxColumn.HeaderText = "Metric3";
        this.Metric3DataGridViewTextBoxColumn.Name = "Metric3DataGridViewTextBoxColumn";
        this.Metric3DataGridViewTextBoxColumn.ReadOnly = true;
        this.Metric3DataGridViewTextBoxColumn.Width = 67;
        // 
        // Metric4DataGridViewTextBoxColumn
        // 
        this.Metric4DataGridViewTextBoxColumn.DataPropertyName = "Metric4";
        this.Metric4DataGridViewTextBoxColumn.HeaderText = "Metric4";
        this.Metric4DataGridViewTextBoxColumn.Name = "Metric4DataGridViewTextBoxColumn";
        this.Metric4DataGridViewTextBoxColumn.ReadOnly = true;
        this.Metric4DataGridViewTextBoxColumn.Width = 67;
        // 
        // Metric5DataGridViewTextBoxColumn
        // 
        this.Metric5DataGridViewTextBoxColumn.DataPropertyName = "Metric5";
        this.Metric5DataGridViewTextBoxColumn.HeaderText = "Metric5";
        this.Metric5DataGridViewTextBoxColumn.Name = "Metric5DataGridViewTextBoxColumn";
        this.Metric5DataGridViewTextBoxColumn.ReadOnly = true;
        this.Metric5DataGridViewTextBoxColumn.Width = 67;
        // 
        // AgeDataGridViewTextBoxColumn
        // 
        this.AgeDataGridViewTextBoxColumn.DataPropertyName = "Age";
        this.AgeDataGridViewTextBoxColumn.HeaderText = "Age";
        this.AgeDataGridViewTextBoxColumn.Name = "AgeDataGridViewTextBoxColumn";
        this.AgeDataGridViewTextBoxColumn.ReadOnly = true;
        this.AgeDataGridViewTextBoxColumn.Width = 51;
        // 
        // NextHopASDataGridViewTextBoxColumn
        // 
        this.NextHopASDataGridViewTextBoxColumn.DataPropertyName = "NextHopAS";
        this.NextHopASDataGridViewTextBoxColumn.HeaderText = "NextHopAS";
        this.NextHopASDataGridViewTextBoxColumn.Name = "NextHopASDataGridViewTextBoxColumn";
        this.NextHopASDataGridViewTextBoxColumn.ReadOnly = true;
        this.NextHopASDataGridViewTextBoxColumn.Width = 88;
        // 
        // PolicyDataGridViewTextBoxColumn
        // 
        this.PolicyDataGridViewTextBoxColumn.DataPropertyName = "Policy";
        this.PolicyDataGridViewTextBoxColumn.HeaderText = "Policy";
        this.PolicyDataGridViewTextBoxColumn.Name = "PolicyDataGridViewTextBoxColumn";
        this.PolicyDataGridViewTextBoxColumn.ReadOnly = true;
        this.PolicyDataGridViewTextBoxColumn.Width = 60;
        // 
        // bsRoute
        // 
        this.bsRoute.DataSource = typeof(NetstatUI.RouteTable.ForwardEntry);
        // 
        // tabArp
        // 
        this.tabArp.Controls.Add(this.dgvArp);
        this.tabArp.Location = new System.Drawing.Point(4, 22);
        this.tabArp.Name = "tabArp";
        this.tabArp.Size = new System.Drawing.Size(522, 527);
        this.tabArp.TabIndex = 3;
        this.tabArp.Text = "Arp Table";
        this.tabArp.UseVisualStyleBackColor = true;
        // 
        // dgvArp
        // 
        this.dgvArp.AllowUserToAddRows = false;
        this.dgvArp.AllowUserToDeleteRows = false;
        this.dgvArp.AutoGenerateColumns = false;
        this.dgvArp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvArp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvArp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MacAddressStringDataGridViewTextBoxColumn,
            this.AddressDataGridViewTextBoxColumn1,
            this.InterfaceNameDataGridViewTextBoxColumn2,
            this.FlagsDataGridViewTextBoxColumn1});
        this.dgvArp.DataSource = this.bsArp;
        this.dgvArp.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvArp.Location = new System.Drawing.Point(0, 0);
        this.dgvArp.Name = "dgvArp";
        this.dgvArp.ReadOnly = true;
        this.dgvArp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.dgvArp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvArp.ShowCellErrors = false;
        this.dgvArp.ShowCellToolTips = false;
        this.dgvArp.ShowEditingIcon = false;
        this.dgvArp.ShowRowErrors = false;
        this.dgvArp.Size = new System.Drawing.Size(522, 527);
        this.dgvArp.TabIndex = 1;
        // 
        // MacAddressStringDataGridViewTextBoxColumn
        // 
        this.MacAddressStringDataGridViewTextBoxColumn.DataPropertyName = "MacAddressString";
        this.MacAddressStringDataGridViewTextBoxColumn.HeaderText = "MacAddress";
        this.MacAddressStringDataGridViewTextBoxColumn.Name = "MacAddressStringDataGridViewTextBoxColumn";
        this.MacAddressStringDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // AddressDataGridViewTextBoxColumn1
        // 
        this.AddressDataGridViewTextBoxColumn1.DataPropertyName = "Address";
        this.AddressDataGridViewTextBoxColumn1.HeaderText = "IPAddress";
        this.AddressDataGridViewTextBoxColumn1.Name = "AddressDataGridViewTextBoxColumn1";
        this.AddressDataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // InterfaceNameDataGridViewTextBoxColumn2
        // 
        this.InterfaceNameDataGridViewTextBoxColumn2.DataPropertyName = "InterfaceName";
        this.InterfaceNameDataGridViewTextBoxColumn2.HeaderText = "InterfaceName";
        this.InterfaceNameDataGridViewTextBoxColumn2.Name = "InterfaceNameDataGridViewTextBoxColumn2";
        this.InterfaceNameDataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // FlagsDataGridViewTextBoxColumn1
        // 
        this.FlagsDataGridViewTextBoxColumn1.DataPropertyName = "Flags";
        this.FlagsDataGridViewTextBoxColumn1.HeaderText = "Flags";
        this.FlagsDataGridViewTextBoxColumn1.Name = "FlagsDataGridViewTextBoxColumn1";
        this.FlagsDataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // bsArp
        // 
        this.bsArp.DataSource = typeof(NetstatUI.ArpTable.ArpEntry);
        // 
        // btnExit
        // 
        this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnExit.Location = new System.Drawing.Point(451, 559);
        this.btnExit.Name = "btnExit";
        this.btnExit.Size = new System.Drawing.Size(75, 23);
        this.btnExit.TabIndex = 2;
        this.btnExit.Text = "Exit";
        this.btnExit.UseVisualStyleBackColor = true;
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        // 
        // btnRefresh
        // 
        this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnRefresh.Location = new System.Drawing.Point(4, 559);
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Size = new System.Drawing.Size(75, 23);
        this.btnRefresh.TabIndex = 3;
        this.btnRefresh.Text = "Refresh";
        this.btnRefresh.UseVisualStyleBackColor = true;
        this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
        // 
        // frmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(530, 585);
        this.Controls.Add(this.btnRefresh);
        this.Controls.Add(this.btnExit);
        this.Controls.Add(this.TabControl1);
        this.Name = "frmMain";
        this.Text = "Network Info";
        this.Load += new System.EventHandler(this.Form1_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvTCP)).EndInit();
        this.ContextMenuStrip1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.bsTCP)).EndInit();
        this.TabControl1.ResumeLayout(false);
        this.tabPorts.ResumeLayout(false);
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvUDP)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsUDP)).EndInit();
        this.tabInterface.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvIntfs)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsIntfs)).EndInit();
        this.tabRoute.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvRoute)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsRoute)).EndInit();
        this.tabArp.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvArp)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.bsArp)).EndInit();
        this.ResumeLayout(false);

    }
    private System.Windows.Forms.DataGridView dgvTCP;
    internal System.Windows.Forms.TabControl TabControl1;
    internal System.Windows.Forms.TabPage tabPorts;
    internal System.Windows.Forms.GroupBox GroupBox2;
    internal System.Windows.Forms.GroupBox GroupBox1;
    internal System.Windows.Forms.DataGridView dgvUDP;
    internal System.Windows.Forms.Button btnExit;
    internal System.Windows.Forms.Button btnRefresh;
    internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
    internal System.Windows.Forms.ToolStripMenuItem CloseConnectionToolStripMenuItem;
    private System.Windows.Forms.TabPage tabInterface;
    internal System.Windows.Forms.DataGridView dgvIntfs;
    private System.Windows.Forms.BindingSource bsTCP;
    private System.Windows.Forms.BindingSource bsUDP;
    private System.Windows.Forms.BindingSource bsIntfs;
    internal System.Windows.Forms.TabPage tabRoute;
    private System.Windows.Forms.DataGridView dgvRoute;
    internal System.Windows.Forms.TabPage tabArp;
    private System.Windows.Forms.DataGridView dgvArp;
    internal System.Windows.Forms.BindingSource bsRoute;
    internal System.Windows.Forms.DataGridViewTextBoxColumn ProcessNameDataGridViewTextBoxColumn1;
    internal System.Windows.Forms.DataGridViewTextBoxColumn LocalEndPointDataGridViewTextBoxColumn1;
    internal System.Windows.Forms.DataGridViewTextBoxColumn RemoteEndPointDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn StateDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn ProcessIDDataGridViewTextBoxColumn1;
    internal System.Windows.Forms.DataGridViewTextBoxColumn ProcessNameDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn LocalEndPointDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn ProcessIDDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn InterfaceNameDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn AddressDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn MaskDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn FlagsDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn ReassembleSizeDataGridViewTextBoxColumn;
    internal System.Windows.Forms.BindingSource bsArp;
    internal System.Windows.Forms.DataGridViewTextBoxColumn MacAddressStringDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn AddressDataGridViewTextBoxColumn1;
    internal System.Windows.Forms.DataGridViewTextBoxColumn InterfaceNameDataGridViewTextBoxColumn2;
    internal System.Windows.Forms.DataGridViewTextBoxColumn FlagsDataGridViewTextBoxColumn1;
    internal System.Windows.Forms.DataGridViewTextBoxColumn DestinationDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn MaskDataGridViewTextBoxColumn1;
    internal System.Windows.Forms.DataGridViewTextBoxColumn NextHopDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn InterfaceNameDataGridViewTextBoxColumn1;
    internal System.Windows.Forms.DataGridViewTextBoxColumn ForwardTypeDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn PrototypeDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn Metric1DataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn Metric2DataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn Metric3DataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn Metric4DataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn Metric5DataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn AgeDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn NextHopASDataGridViewTextBoxColumn;
    internal System.Windows.Forms.DataGridViewTextBoxColumn PolicyDataGridViewTextBoxColumn;

  }
}

