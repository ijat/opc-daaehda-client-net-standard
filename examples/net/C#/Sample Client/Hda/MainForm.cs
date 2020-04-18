//============================================================================
// TITLE: MainForm.cs
//
// CONTENTS:
// 
// The main application window for the OPC .NET API Sample Application Sample Application.
//
// (c) Copyright 2003-2004 The OPC Foundation
// ALL RIGHTS RESERVED.
//
// DISCLAIMER:
//  This code is provided by the OPC Foundation solely to assist in 
//  understanding and use of the appropriate OPC Specification(s) and may be 
//  used as set forth in the License Grant section of the OPC Specification.
//  This code is provided as-is and without warranty or support of any sort
//  and is subject to the Warranty and Liability Disclaimers which appear
//  in the printed OPC Specification.
//
// MODIFICATION LOG:
//
// Date       By    Notes
// ---------- ---   -----
// 2003/12/19 RSA   Initial implementation.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// The main application window for the OPC .NET API Sample Application.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu MainMenu;
		private System.Windows.Forms.MenuItem FileMI;
		private System.Windows.Forms.ToolBar ToolBar;
		private System.Windows.Forms.Panel BottomPN;
		private System.Windows.Forms.RichTextBox OutputCTRL;
		private System.Windows.Forms.Splitter SplitterH;
		private System.Windows.Forms.Splitter SplitterV;
		private System.Windows.Forms.Panel LeftPN;
		private System.Windows.Forms.Panel RightPN;
		private SelectServerCtrl SelectServerCTRL;
		private OpcClientSdk.Hda.SampleClient.ServerStatusCtrl StatusCTRL;
		private System.Windows.Forms.MenuItem ExitMI;
		private System.Windows.Forms.MenuItem ServerMI;
		private System.Windows.Forms.MenuItem ConnectMI;
		private System.Windows.Forms.MenuItem DisconnecMI;
		private System.Windows.Forms.MenuItem ViewStatusMI;
		private System.Windows.Forms.MenuItem SeparatorS1;
		private System.Windows.Forms.MenuItem HelpMI;
		private System.Windows.Forms.MenuItem AboutMI;
		private System.Windows.Forms.ImageList ToolBarImageList;
		private System.Windows.Forms.ToolBarButton ConnectBTN;
		private System.Windows.Forms.ToolBarButton DisconnectBTN;
		private System.Windows.Forms.ToolBarButton ViewStatusBTN;
		private System.Windows.Forms.ToolBarButton BrowseBTN;
		private System.Windows.Forms.ToolBarButton SeparatorT2;
		private System.Windows.Forms.ToolBarButton AboutBTN;
		private System.Windows.Forms.MenuItem OutputMI;
		private System.Windows.Forms.MenuItem OutputClearMI;
		private System.Windows.Forms.MenuItem OptionsMI;
		private System.Windows.Forms.MenuItem ClearHistoryMI;
		private System.Windows.Forms.MenuItem ViewAttributesMI;
		private System.Windows.Forms.MenuItem ViewAggregatesMI;
		private System.Windows.Forms.MenuItem BrowseItemsMI;
		private OpcClientSdk.Hda.SampleClient.TrendTreeCtrl TrendsCTRL;
		private OpcClientSdk.Hda.SampleClient.ItemValuesCtrl ValuesCTRL;
        private Timer updateTimerControl_;
		private System.ComponentModel.IContainer components;
		
		[STAThread]
		static void Main() 
		{
			try
			{
				SecurityPermission permission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
				
				if (!SecurityManager.IsGranted(permission))
				{
					string msg = "";

					msg += "This application requires permission to access unmanaged code ";
					msg += "in order to connect to COM-DA servers directly.\r\n\r\n";
					msg += "Connections to XML-DA servers will not be affected.";

                    MessageBox.Show(msg, "OPC HDA Client SDK .NET Standard Sample Application");
				}

                if (IntPtr.Size > 4)
                {
                    System.Text.StringBuilder buffer = new System.Text.StringBuilder();
                    buffer.Append(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));
                    buffer.Append("\\OPC Foundation\\Bin\\opcproxy.dll");

                    if (!File.Exists(buffer.ToString()))
                    {
                        buffer.Length = 0;
                        buffer.Append("This application is running in x64 mode.\r\n");
                        buffer.Append("Please install the 'OPC Core Components Redistributable (x64)' package.\r\n");
                        buffer.Append("It can be downloaded from the OPC Foundation website.\r\n");

                        MessageBox.Show(buffer.ToString(), "OPC HDA Client SDK .NET Standard Sample Application");
                    }
                }

                Application.Run(new MainForm());
			}
			catch (Exception e)
			{
                MessageBox.Show("An unexpected exception occurred. Application exiting.\r\n\r\n" + e.Message, "OPC HDA Client SDK .NET Standard Sample Application");
			}
		}

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

                        Icon = ClientUtils.GetAppIcon();

			//OpcClientSdk.Utilities.Interop.PreserveUTC = true;
 	
#if (DEBUG)

			// initialize the set of known servers.
			OpcUrl[] knownURLs = new OpcUrl[] 
			{
				new OpcUrl("opchda://localhost/OPCSample.OpcHdaServer")
			};

#else
			// initialize the set of known servers.
			OpcUrl[] knownURLs = new OpcUrl[] 
			{
				new OpcUrl("opchda://localhost/OPCSample.OpcHdaServer")
			};
#endif
            // set the UTC flag.
			// OpcCom.Interop.PreserveUTC = true;
			
			SelectServerCTRL.Initialize(knownURLs, 0, OpcSpecification.OPC_HDA_10);
			LoadSettings();
			
			// register for server connected callbacks.
			SelectServerCTRL.ConnectServer += new ConnectServer_EventHandler(OnConnect); 
            UpdateTitle();
            updateTimerControl_.Enabled = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.FileMI = new System.Windows.Forms.MenuItem();
			this.ExitMI = new System.Windows.Forms.MenuItem();
			this.ServerMI = new System.Windows.Forms.MenuItem();
			this.ConnectMI = new System.Windows.Forms.MenuItem();
			this.DisconnecMI = new System.Windows.Forms.MenuItem();
			this.SeparatorS1 = new System.Windows.Forms.MenuItem();
			this.ViewStatusMI = new System.Windows.Forms.MenuItem();
			this.ViewAttributesMI = new System.Windows.Forms.MenuItem();
			this.ViewAggregatesMI = new System.Windows.Forms.MenuItem();
			this.BrowseItemsMI = new System.Windows.Forms.MenuItem();
			this.OutputMI = new System.Windows.Forms.MenuItem();
			this.OutputClearMI = new System.Windows.Forms.MenuItem();
			this.OptionsMI = new System.Windows.Forms.MenuItem();
			this.ClearHistoryMI = new System.Windows.Forms.MenuItem();
			this.HelpMI = new System.Windows.Forms.MenuItem();
			this.AboutMI = new System.Windows.Forms.MenuItem();
			this.ToolBar = new System.Windows.Forms.ToolBar();
			this.ConnectBTN = new System.Windows.Forms.ToolBarButton();
			this.DisconnectBTN = new System.Windows.Forms.ToolBarButton();
			this.ViewStatusBTN = new System.Windows.Forms.ToolBarButton();
			this.BrowseBTN = new System.Windows.Forms.ToolBarButton();
			this.SeparatorT2 = new System.Windows.Forms.ToolBarButton();
			this.AboutBTN = new System.Windows.Forms.ToolBarButton();
			this.ToolBarImageList = new System.Windows.Forms.ImageList(this.components);
			this.BottomPN = new System.Windows.Forms.Panel();
			this.OutputCTRL = new System.Windows.Forms.RichTextBox();
			this.SplitterH = new System.Windows.Forms.Splitter();
			this.SplitterV = new System.Windows.Forms.Splitter();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.TrendsCTRL = new OpcClientSdk.Hda.SampleClient.TrendTreeCtrl();
			this.RightPN = new System.Windows.Forms.Panel();
			this.ValuesCTRL = new OpcClientSdk.Hda.SampleClient.ItemValuesCtrl();
			this.SelectServerCTRL = new SelectServerCtrl();
			this.StatusCTRL = new OpcClientSdk.Hda.SampleClient.ServerStatusCtrl();
            this.updateTimerControl_ = new System.Windows.Forms.Timer(this.components);
			this.BottomPN.SuspendLayout();
			this.LeftPN.SuspendLayout();
			this.RightPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.FileMI,
																					 this.ServerMI,
																					 this.OutputMI,
																					 this.OptionsMI,
																					 this.HelpMI});
			// 
			// FileMI
			// 
			this.FileMI.Index = 0;
			this.FileMI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.ExitMI});
			this.FileMI.Text = "&File";
			// 
			// ExitMI
			// 
            this.ExitMI.Index = 0;
			this.ExitMI.Text = "&Exit";
			this.ExitMI.Click += new System.EventHandler(this.ExitMI_Click);
			// 
			// ServerMI
			// 
			this.ServerMI.Index = 1;
			this.ServerMI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.ConnectMI,
																					 this.DisconnecMI,
																					 this.SeparatorS1,
																					 this.ViewStatusMI,
																					 this.ViewAttributesMI,
																					 this.ViewAggregatesMI,
																					 this.BrowseItemsMI});
			this.ServerMI.Text = "&Server";
			// 
			// ConnectMI
			// 
			this.ConnectMI.Index = 0;
			this.ConnectMI.Text = "&Connect";
			this.ConnectMI.Click += new System.EventHandler(this.ConnectMI_Click);
			// 
			// DisconnecMI
			// 
			this.DisconnecMI.Index = 1;
			this.DisconnecMI.Text = "&Disconnect";
			this.DisconnecMI.Click += new System.EventHandler(this.DisconnectMI_Click);
			// 
			// SeparatorS1
			// 
			this.SeparatorS1.Index = 2;
			this.SeparatorS1.Text = "-";
			// 
			// ViewStatusMI
			// 
			this.ViewStatusMI.Index = 3;
			this.ViewStatusMI.Text = "&View Status...";
			this.ViewStatusMI.Click += new System.EventHandler(this.ViewStatusMI_Click);
			// 
			// ViewAttributesMI
			// 
			this.ViewAttributesMI.Index = 4;
			this.ViewAttributesMI.Text = "View &Attributes...";
			this.ViewAttributesMI.Click += new System.EventHandler(this.ViewAttributesMI_Click);
			// 
			// ViewAggregatesMI
			// 
			this.ViewAggregatesMI.Index = 5;
			this.ViewAggregatesMI.Text = "View A&ggregates...";
			this.ViewAggregatesMI.Click += new System.EventHandler(this.ViewAggregatesMI_Click);
			// 
			// BrowseItemsMI
			// 
			this.BrowseItemsMI.Index = 6;
			this.BrowseItemsMI.Text = "&Browse Items...";
			this.BrowseItemsMI.Click += new System.EventHandler(this.BrowseMI_Click);
			// 
			// OutputMI
			// 
            this.OutputMI.Index = 2;
			this.OutputMI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.OutputClearMI});
			this.OutputMI.Text = "&Output";
			// 
			// OutputClearMI
			// 
			this.OutputClearMI.Index = 0;
			this.OutputClearMI.Text = "&Clear";
			this.OutputClearMI.Click += new System.EventHandler(this.OutputClearMI_Click);
			// 
			// OptionsMI
			// 
            this.OptionsMI.Index = 3;
			this.OptionsMI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ClearHistoryMI});
			this.OptionsMI.Text = "O&ptions";
			// 
			// ClearHistoryMI
			// 
            this.ClearHistoryMI.Index = 0;
			this.ClearHistoryMI.Text = "&Clear History";
			this.ClearHistoryMI.Click += new System.EventHandler(this.ClearHistoryMI_Click);
			// 
			// HelpMI
			// 
            this.HelpMI.Index = 4;
			this.HelpMI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.AboutMI});
			this.HelpMI.Text = "&Help";
			// 
			// AboutMI
			// 
			this.AboutMI.Index = 0;
			this.AboutMI.Text = "&About...";
			this.AboutMI.Click += new System.EventHandler(this.AboutMI_Click);
			// 
			// ToolBar
			// 
			this.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.ToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.ConnectBTN,
																					   this.DisconnectBTN,
																					   this.ViewStatusBTN,
																					   this.BrowseBTN,
																					   this.SeparatorT2,
																					   this.AboutBTN});
			this.ToolBar.ButtonSize = new System.Drawing.Size(16, 16);
			this.ToolBar.DropDownArrows = true;
			this.ToolBar.ImageList = this.ToolBarImageList;
			this.ToolBar.Location = new System.Drawing.Point(3, 0);
			this.ToolBar.Name = "ToolBar";
			this.ToolBar.ShowToolTips = true;
			this.ToolBar.Size = new System.Drawing.Size(1010, 30);
			this.ToolBar.TabIndex = 0;
			this.ToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar_ButtonClick);
			// 
			// ConnectBTN
			// 
			this.ConnectBTN.ImageIndex = 0;
            this.ConnectBTN.Name = "ConnectBTN";
			this.ConnectBTN.ToolTipText = "Connect to Server";
			// 
			// DisconnectBTN
			// 
			this.DisconnectBTN.ImageIndex = 1;
            this.DisconnectBTN.Name = "DisconnectBTN";
			this.DisconnectBTN.ToolTipText = "Disconnect from Server";
			// 
			// ViewStatusBTN
			// 
			this.ViewStatusBTN.ImageIndex = 4;
            this.ViewStatusBTN.Name = "ViewStatusBTN";
			this.ViewStatusBTN.ToolTipText = "View Server Status";
			// 
			// BrowseBTN
			// 
			this.BrowseBTN.ImageIndex = 6;
            this.BrowseBTN.Name = "BrowseBTN";
			this.BrowseBTN.ToolTipText = "Browse Address Space";
			// 
			// SeparatorT2
			// 
            this.SeparatorT2.Name = "SeparatorT2";
			this.SeparatorT2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// AboutBTN
			// 
			this.AboutBTN.ImageIndex = 13;
            this.AboutBTN.Name = "AboutBTN";
			this.AboutBTN.ToolTipText = "About";
			// 
			// ToolBarImageList
			// 
			this.ToolBarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ToolBarImageList.ImageStream")));
			this.ToolBarImageList.TransparentColor = System.Drawing.Color.Teal;
            this.ToolBarImageList.Images.SetKeyName(0, "");
            this.ToolBarImageList.Images.SetKeyName(1, "");
            this.ToolBarImageList.Images.SetKeyName(2, "");
            this.ToolBarImageList.Images.SetKeyName(3, "");
            this.ToolBarImageList.Images.SetKeyName(4, "");
            this.ToolBarImageList.Images.SetKeyName(5, "");
            this.ToolBarImageList.Images.SetKeyName(6, "");
            this.ToolBarImageList.Images.SetKeyName(7, "");
            this.ToolBarImageList.Images.SetKeyName(8, "");
            this.ToolBarImageList.Images.SetKeyName(9, "");
            this.ToolBarImageList.Images.SetKeyName(10, "");
            this.ToolBarImageList.Images.SetKeyName(11, "");
            this.ToolBarImageList.Images.SetKeyName(12, "");
            this.ToolBarImageList.Images.SetKeyName(13, "");
			// 
			// BottomPN
			// 
			this.BottomPN.Controls.Add(this.OutputCTRL);
			this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomPN.Location = new System.Drawing.Point(3, 597);
			this.BottomPN.Name = "BottomPN";
			this.BottomPN.Size = new System.Drawing.Size(1010, 100);
			this.BottomPN.TabIndex = 3;
			// 
			// OutputCTRL
			// 
			this.OutputCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputCTRL.Location = new System.Drawing.Point(0, 0);
			this.OutputCTRL.Name = "OutputCTRL";
			this.OutputCTRL.Size = new System.Drawing.Size(1010, 100);
			this.OutputCTRL.TabIndex = 0;
			this.OutputCTRL.Text = "";
			// 
			// SplitterH
			// 
			this.SplitterH.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.SplitterH.Location = new System.Drawing.Point(3, 594);
			this.SplitterH.Name = "SplitterH";
			this.SplitterH.Size = new System.Drawing.Size(1010, 3);
			this.SplitterH.TabIndex = 4;
			this.SplitterH.TabStop = false;
			// 
			// SplitterV
			// 
			this.SplitterV.Location = new System.Drawing.Point(267, 52);
			this.SplitterV.Name = "SplitterV";
			this.SplitterV.Size = new System.Drawing.Size(3, 542);
			this.SplitterV.TabIndex = 5;
			this.SplitterV.TabStop = false;
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.TrendsCTRL);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPN.Location = new System.Drawing.Point(3, 52);
			this.LeftPN.Name = "LeftPN";
            this.LeftPN.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.LeftPN.Size = new System.Drawing.Size(264, 542);
			this.LeftPN.TabIndex = 6;
			// 
			// TrendsCTRL
			// 
			this.TrendsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TrendsCTRL.Location = new System.Drawing.Point(0, 3);
			this.TrendsCTRL.Name = "TrendsCTRL";
			this.TrendsCTRL.Size = new System.Drawing.Size(264, 539);
			this.TrendsCTRL.TabIndex = 0;
			this.TrendsCTRL.TrendChanged += new OpcClientSdk.Hda.SampleClient.TrendTreeCtrl.TrendChangedEventHandler(this.TrendsCTRL_TrendChanged);
			this.TrendsCTRL.TrendSelected += new OpcClientSdk.Hda.SampleClient.TrendTreeCtrl.TrendSelectedEventHandler(this.TrendsCTRL_TrendSelected);
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.ValuesCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.Location = new System.Drawing.Point(270, 52);
			this.RightPN.Name = "RightPN";
            this.RightPN.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.RightPN.Size = new System.Drawing.Size(743, 542);
			this.RightPN.TabIndex = 7;
			// 
			// ValuesCTRL
			// 
			this.ValuesCTRL.DisplayGraph = true;
			this.ValuesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ValuesCTRL.Location = new System.Drawing.Point(0, 3);
			this.ValuesCTRL.Name = "ValuesCTRL";
			this.ValuesCTRL.ReadOnly = false;
			this.ValuesCTRL.Size = new System.Drawing.Size(743, 539);
			this.ValuesCTRL.TabIndex = 0;
			// 
			// SelectServerCTRL
			// 
			this.SelectServerCTRL.Dock = System.Windows.Forms.DockStyle.Top;
			this.SelectServerCTRL.Label = "Server";
			this.SelectServerCTRL.Location = new System.Drawing.Point(3, 30);
			this.SelectServerCTRL.Name = "SelectServerCTRL";
            this.SelectServerCTRL.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.SelectServerCTRL.Size = new System.Drawing.Size(1010, 22);
			this.SelectServerCTRL.TabIndex = 0;
			// 
			// StatusCTRL
			// 
			this.StatusCTRL.Location = new System.Drawing.Point(3, 697);
			this.StatusCTRL.Name = "StatusCTRL";
			this.StatusCTRL.Size = new System.Drawing.Size(1010, 16);
			this.StatusCTRL.TabIndex = 8;
			// 
            // updateTimerControl_
            // 
            this.updateTimerControl_.Interval = 10000;
            this.updateTimerControl_.Tick += new System.EventHandler(this.UpdateTimerCtrlTick);
            // 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1016, 713);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.SplitterV);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.SplitterH);
			this.Controls.Add(this.BottomPN);
			this.Controls.Add(this.StatusCTRL);
			this.Controls.Add(this.SelectServerCTRL);
			this.Controls.Add(this.ToolBar);
			this.Menu = this.MainMenu;
			this.Name = "MainForm";
			this.Text = "OPC HDA Client SDK .NET Standard Sample Application";
			this.BottomPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.RightPN.ResumeLayout(false);
			this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// A class that stores the user's application settings.
		/// </summary>
		[Serializable]
		public class UserAppData
		{
			public OpcUrl[]  KnownUrls   = null;
			public int    SelectedURL = -1;
			public string ProxyServer = null;
		}

		/// <summary>
		/// The application configuration file path.
		/// </summary>
		private string ConfigFilePath
		{
			get { return Application.StartupPath + "\\OpcClientSdk.Hda.SampleClient.config"; }
		}

		/// <summary>
		/// The default web proxy for the application - uses IE settings if null.
		/// </summary>
		private WebProxy m_proxy = null;

		/// <summary>
		/// The currently active server object.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// The path of the current configuration file.
		/// </summary>
		private string m_configFile = null;

		/// <summary>
		/// A table of item results indexed by client handle.
		/// </summary>
		private Hashtable m_cache = new Hashtable();

		/// <summary>
		/// The client handle of the currently selected item.
		/// </summary>
		private object m_selectedItem = null;

		/// <summary>
		/// Called to connect to a server.
		/// </summary>
		public void OnConnect(OpcServer server)
		{
			// disconnect from the current server.
			OnDisconnect();

			// create a default file name for the server.
            m_configFile = server.ServerName + ".config";

			// load server object from config file if it exists. 
			if (File.Exists(m_configFile))
			{
				if (OnLoad(false, server.Url)) return;
			}

			// use the specified server object directly.
			m_server = (TsCHdaServer)server;

			// connect with an empty configuration.
			OnConnect();	
		}
		
		/// <summary>
		/// Called to connect to a server.
		/// </summary>
		public void OnConnect()
		{
			Cursor = Cursors.WaitCursor;
			
			try
			{
				OpcUserIdentity credentials = null;

				do
				{
					try
					{
						m_server.Connect(new OpcConnectData(credentials, m_proxy));
						break;
					}
					catch (Exception e)
					{
						MessageBox.Show(e.Message);
					}

					credentials = new NetworkCredentialsDlg().ShowDialog(credentials);
				}
				while (credentials != null);
	
				// initialize controls.
				StatusCTRL.Start(m_server);
				SelectServerCTRL.OnConnect(m_server);
				TrendsCTRL.Initialize(m_server);

				// register for shutdown events.
				m_server.ServerShutdownEvent += new OpcServerShutdownEventHandler(Server_ServerShutdown);

				// save settings.
				SaveSettings();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				m_server = null;
			}

			Cursor = Cursors.Default;
		}

		/// <summary>
		/// Called to disconnect from a server.
		/// </summary>
		public void OnDisconnect()
		{
			// disconnect server.
			if (m_server != null)
			{
				try	  { m_server.Disconnect(); }
				catch {}

				m_server.Dispose();
				m_server = null;
			}

			// clear cache.
			m_cache = new Hashtable();

			// initialize controls.
			StatusCTRL.Start(null);
			TrendsCTRL.Initialize(null);
			ValuesCTRL.Initialize(null, null);
			OutputCTRL.Text = "";
		}

		/// <summary>
		/// Displays the about dialog for the application.
		/// </summary>
		private void OnAbout()
		{
        }

		/// <summary>
		/// Saves the configuration for the current server.
		/// </summary>
		private void OnSave()
		{
			Stream stream = null;

			try
			{
				Cursor = Cursors.WaitCursor;

				// ensure a valid server object exists.
                if (m_server == null) throw new OpcResultException(OpcResult.E_FAIL, "The server is not currently connected.");

				// create the configuartion file.
				stream = new FileStream(m_configFile, FileMode.Create, FileAccess.Write, FileShare.None);

				// serialize the server object.
				new BinaryFormatter().Serialize(stream, m_server);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				// close the stream.
				if (stream != null) stream.Close();

				Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Loads the configuration for the current server.
		/// </summary>
		private bool OnLoad(bool prompt, OpcClientSdk.OpcUrl url)
		{
			Stream stream = null;

			try
			{				
				Cursor = Cursors.WaitCursor;

				// prompt user to select a configuration file.
				if (prompt)
				{
					OpenFileDialog dialog = new OpenFileDialog();

					dialog.CheckFileExists = true;
					dialog.CheckPathExists = true;
					dialog.DefaultExt      = ".config";
					dialog.Filter          = "Config Files (*.config)|*.config|All Files (*.*)|*.*";
					dialog.Multiselect     = false;
					dialog.ValidateNames   = true;
					dialog.Title           = "Open Server Configuration File";
					dialog.FileName        = m_configFile;

					if (dialog.ShowDialog() != DialogResult.OK)
					{
						return false;
					}			

					// save the new config file name.
					m_configFile = dialog.FileName;
				}

				// disconnect from current server.
				OnDisconnect();

				// open configuration file.
				stream = new FileStream(m_configFile, FileMode.Open, FileAccess.Read, FileShare.Read);
				
				// deserialize the server object.
				m_server = (TsCHdaServer)new BinaryFormatter().Deserialize(stream);

				// overrided default url.
				if (url != null)
				{
					m_server.Url = url;
				}

				// connect to new server.
				OnConnect();

				// load succeeded.
				return true;
			}
			catch (Exception e)
			{
				if (prompt) MessageBox.Show(e.Message);
				return false;
			}
			finally
			{
				// close the stream.
				if (stream != null) stream.Close();

				Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Saves the user's application settings.
		/// </summary>
		private void SaveSettings()
		{
			Stream stream = null;

			try
			{
				Cursor = Cursors.WaitCursor;

				// create the configuartion file.
				stream = new FileStream(ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

				// populate the user settings object.
				UserAppData settings = new UserAppData();

				settings.KnownUrls = SelectServerCTRL.GetKnownURLs(out settings.SelectedURL);

				if (m_proxy != null)
				{
					settings.ProxyServer = m_proxy.Address.ToString();
				}

				// serialize the user settings object.
				new BinaryFormatter().Serialize(stream, settings);
			}
			catch
			{
				// ignore errors.
			}
			finally
			{
				// close the stream.
				if (stream != null) stream.Close();
				Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Loads the user's application settings.
		/// </summary>
		private void LoadSettings()
		{
			Stream stream = null;

			try
			{				
				Cursor = Cursors.WaitCursor;
				
				// open configuration file.
				stream = new FileStream(ConfigFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
				
				// deserialize the server object.
				UserAppData settings = (UserAppData)new BinaryFormatter().Deserialize(stream);

				// overrided the current settings.
				if (settings != null)
				{					
					// known urls.
					SelectServerCTRL.Initialize(settings.KnownUrls, settings.SelectedURL, OpcSpecification.OPC_HDA_10);

					// proxy server.
					if (settings.ProxyServer != null)
					{
						m_proxy = new WebProxy(settings.ProxyServer);
					}
				}
			}
			catch
			{
				// ignore errors.
			}
			finally
			{
				// close the stream.
				if (stream != null) stream.Close();
				Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Called when a tool bar button is clicked.
		/// </summary>
		private void ToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == ConnectBTN)    { OnConnect();                   return; }	
			if (e.Button == DisconnectBTN) { OnDisconnect();                return; }	
			if (e.Button == ViewStatusBTN) { ViewStatusMI_Click(sender, e); return; }	
			if (e.Button == BrowseBTN)     { BrowseMI_Click(sender, e);     return; }	
			if (e.Button == AboutBTN)      { OnAbout();                     return; }	
		}

		/// <summary>
		/// Called when the File | Load menu item is clicked.
		/// </summary>
		private void LoadMI_Click(object sender, System.EventArgs e)
		{
			OnLoad(true, null); 
		}

		/// <summary>
		/// Called when the File | Save menu item is clicked.
		/// </summary>
		private void SaveMI_Click(object sender, System.EventArgs e)
		{
			OnSave();
		}

		/// <summary>
		/// Called when the File | Exit menu item is clicked.
		/// </summary>
		private void ExitMI_Click(object sender, System.EventArgs e)
		{
			OnDisconnect();
			Close();
		}

		/// <summary>
		/// Called when the Server | Connect menu item is clicked.
		/// </summary>
		private void ConnectMI_Click(object sender, System.EventArgs e)
		{
			OnConnect();
		}

		/// <summary>
		/// Called when the Server | Disconnect menu item is clicked.
		/// </summary>
		private void DisconnectMI_Click(object sender, System.EventArgs e)
		{
			OnDisconnect();
		}

		/// <summary>
		/// Called when the Server | Browse menu item is clicked.
		/// </summary>
		private void ViewStatusMI_Click(object sender, System.EventArgs e)
		{
			if (m_server != null) new ServerStatusDlg().ShowDialog(m_server);
		}

		/// <summary>
		/// Called when the Server | Browse menu item is clicked.
		/// </summary>
		private void BrowseMI_Click(object sender, System.EventArgs e)
		{
			if (m_server != null) new BrowseItemsDlg().ShowDialog(m_server);
		}

		/// <summary>
		/// Called when the Help | About menu item is clicked.
		/// </summary>
		private void AboutMI_Click(object sender, System.EventArgs e)
		{
			OnAbout();
		}

		/// <summary>
		/// Called when the Output | Clear menu item is clicked.
		/// </summary>
		private void OutputClearMI_Click(object sender, System.EventArgs e)
		{
			OutputCTRL.Text = "";
		}

		/// <summary>
		/// Handles changes to the proxy server settings.
		/// </summary>
		private void ProxyServerMI_Click(object sender, System.EventArgs e)
		{
			WebProxy proxy = new ProxyServerDlg().ShowDialog(m_proxy);

			if (proxy != m_proxy)
			{
				m_proxy = proxy;
				SaveSettings();
			}
		}

		/// <summary>
		/// Clears the URL history in the drop down menu.
		/// </summary>
		private void ClearHistoryMI_Click(object sender, System.EventArgs e)
		{
			SelectServerCTRL.Initialize(null, 0, OpcSpecification.OPC_HDA_10);
			SaveSettings();
		}

		/// <summary>
		/// Displays the set of item attributes for the current server.
		/// </summary>
		private void ViewAttributesMI_Click(object sender, System.EventArgs e)
		{		
			if (m_server != null) new AttributesViewDlg().ShowDialog(m_server);	
		}

		/// <summary>
		/// Displays the set of aggregates for the current server.
		/// </summary>
		private void ViewAggregatesMI_Click(object sender, System.EventArgs e)
		{
			if (m_server != null) new AggregateListViewDlg().ShowDialog(m_server);	
		}

		/// <summary>
		/// Displays data for the current selection in the right pane.
		/// </summary>
		private void TrendsCTRL_TrendSelected(TsCHdaTrend trend, TsCHdaItem item)
		{
			if (trend != null && trend.Items.Count > 0)
			{
				if (item == null)
				{
					item = trend.Items[0];
				}

				if (item.ClientHandle != null)
				{
					ValuesCTRL.Initialize(m_server, (TsCHdaItemValueCollection)m_cache[item.ClientHandle]);
					m_selectedItem = item.ClientHandle;
					return;
				}
			}

			ValuesCTRL.Initialize(m_server, null);
			m_selectedItem = null;
		}

		/// <summary>
		/// Updates the cached values for the items.
		/// </summary>
		private void TrendsCTRL_TrendChanged(TsCHdaTrend trend, TsCHdaItemValueCollection[] values, bool replace)
		{
			// add new values to cache.
			if (values != null && values.Length > 0)
			{
				foreach (TsCHdaItemValueCollection value in values)
				{
					// ignore results without a client handle.
					if (value.ClientHandle == null)
					{
						continue;
					}
					
					// check if results for the item already exist.
					TsCHdaItemValueCollection existingValues = (TsCHdaItemValueCollection)m_cache[value.ClientHandle];

					if (!replace && existingValues != null)
					{
						existingValues.AddRange(value);
					}

					// replace existing or insert new results for the item.
					else
					{
						m_cache[value.ClientHandle] = value;
					}
				}
				
				// update values display if nothing is selected.
				if (m_selectedItem == null)
				{
					m_selectedItem = values[0].ClientHandle;
					ValuesCTRL.Initialize(m_server, (TsCHdaItemValueCollection)m_cache[m_selectedItem]);
				}

				// onluy update values display if current selection changed.
				else
				{
					foreach (OpcItem item in values)
					{
						if (m_selectedItem.Equals(item.ClientHandle))
						{							
							ValuesCTRL.Initialize(m_server, (TsCHdaItemValueCollection)m_cache[m_selectedItem]);
						}
					}
				}
			}

			// clear items from the cache.
			else if (replace)
			{
				foreach (TsCHdaItem item in trend.Items)
				{
					if (item.ClientHandle != null)
					{
						if (item.ClientHandle.Equals(m_selectedItem))
						{
							ValuesCTRL.Initialize(m_server, null);
							m_selectedItem = null;
						}

						m_cache.Remove(item.ClientHandle);
					}
				}
			}
		}


		/// <summary>
		/// Runs the raw data test on the current server.
		/// </summary>
		private void RawDataTestMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_server != null) new RunTestDlg().ShowDialog(m_server, "Raw Data 1.xml", "Sample Data/Raw Data 1");	
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Runs the first processed data test on the current server.
		/// </summary>
		private void ProcessedDataTest1MI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				if (m_server != null) new RunTestDlg().ShowDialog(m_server, "Aggregate Data 1.xml", "Sample Data/Aggregate Data 1");	
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Runs the second processed data test on the current server.
		/// </summary>
		private void ProcessedTest2MI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_server != null) new RunTestDlg().ShowDialog(m_server, "Aggregate Data 2.xml", "Sample Data/Aggregate Data 2");	
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Called when the server sends a shutdown event.
		/// </summary>
		private void Server_ServerShutdown(string reason)
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new OpcServerShutdownEventHandler(Server_ServerShutdown), new object[] { reason });
				return;
			}

			MessageBox.Show(reason, "Server Shutdown");
			OnDisconnect();
		}

        #region Event Handlers

        private void UpdateTitle()
        {
            Text = String.Format("{0}", "OPC HDA Client SDK .NET Standard Sample Application");
        }

        private void UpdateTimerCtrlTick(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        #endregion
	}
}
