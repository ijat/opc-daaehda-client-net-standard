//============================================================================
// TITLE: BrowseItemsDlg.cs
//
// CONTENTS:
// 
// A dialog used to browse the address space of an OPC DA server.
//
// (c) Copyright 2003 The OPC Foundation
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
// 2003/06/11 RSA   Initial implementation.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;
using OpcClientSdk.Da;

namespace Client
{
	/// <summary>
	/// A dialog used to browse the address space of an OPC DA server.
	/// </summary>
	public class BrowseItemsDlg : System.Windows.Forms.Form
	{
		private Client.BrowseTreeCtrl BrowseCTRL;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button DoneBTN;
		private System.Windows.Forms.Panel LeftPN;
		private System.Windows.Forms.Panel RightPN;
		private System.Windows.Forms.Splitter SplitterV;
		private Client.PropertyListViewCtrl PropertiesCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BrowseItemsDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			BrowseCTRL.ElementSelected += new ElementSelected_EventHandler(OnElementSelected);
			BrowseCTRL.ItemPicked += new ItemPicked_EventHandler(BrowseCTRL_ItemPicked);
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
			this.BrowseCTRL = new Client.BrowseTreeCtrl();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.RightPN = new System.Windows.Forms.Panel();
			this.PropertiesCTRL = new Client.PropertyListViewCtrl();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.DoneBTN = new System.Windows.Forms.Button();
			this.SplitterV = new System.Windows.Forms.Splitter();
			this.LeftPN.SuspendLayout();
			this.RightPN.SuspendLayout();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// BrowseCTRL
			// 
			this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseCTRL.Location = new System.Drawing.Point(4, 4);
			this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(220, 296);
			this.BrowseCTRL.TabIndex = 1;
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.BrowseCTRL);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(224, 300);
			this.LeftPN.TabIndex = 6;
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.PropertiesCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(228, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(564, 300);
			this.RightPN.TabIndex = 8;
			// 
			// PropertiesCTRL
			// 
			this.PropertiesCTRL.AllowDrop = true;
			this.PropertiesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertiesCTRL.Location = new System.Drawing.Point(0, 4);
			this.PropertiesCTRL.Name = "PropertiesCTRL";
			this.PropertiesCTRL.Size = new System.Drawing.Size(560, 296);
			this.PropertiesCTRL.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.DoneBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 300);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(792, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// DoneBTN
			// 
			this.DoneBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.DoneBTN.Location = new System.Drawing.Point(359, 8);
			this.DoneBTN.Name = "DoneBTN";
			this.DoneBTN.TabIndex = 0;
			this.DoneBTN.Text = "Done";
			this.DoneBTN.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// SplitterV
			// 
			this.SplitterV.Location = new System.Drawing.Point(224, 0);
			this.SplitterV.Name = "SplitterV";
			this.SplitterV.Size = new System.Drawing.Size(4, 300);
			this.SplitterV.TabIndex = 9;
			this.SplitterV.TabStop = false;
			// 
			// BrowseItemsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 336);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.SplitterV);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "BrowseItemsDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse Address Space";
			this.LeftPN.ResumeLayout(false);
			this.RightPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used to process read request.
		/// </summary>
		private TsCDaServer m_server = null;

		private OpcItem m_itemID = null;

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public OpcItem ShowDialog(TsCDaServer server)
		{
			try
			{
				if (server == null) throw new ArgumentNullException("server");

				m_server = server;
				m_itemID = null;

				TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

				filters.ReturnAllProperties  = false;
				filters.ReturnPropertyValues = false;

				BrowseCTRL.ShowSingleServer(m_server, filters);
				PropertiesCTRL.Initialize(null);

				if (ShowDialog() != DialogResult.OK)
				{
					return null;
				}

				return m_itemID;
			}
			finally
			{
				// ensure server connection in the browse control are closed.
				BrowseCTRL.Clear();
			}
		}

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public void Initialize(OpcClientSdk.Da.TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

			filters.ReturnAllProperties  = true;
			filters.ReturnPropertyValues = true;

			BrowseCTRL.ShowSingleServer(m_server, filters);
			PropertiesCTRL.Initialize(null);

			ShowDialog();

			// ensure server connection in the browse control are closed.
			BrowseCTRL.Clear();
		}
		
		/// <summary>
		/// Called when a server is picked in the browse control.
		/// </summary>
		private void OnElementSelected(TsCDaBrowseElement element)
		{
			PropertiesCTRL.Initialize(element);
		}
		
		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Called when an item is explicitly picked.
		/// </summary>
		private void BrowseCTRL_ItemPicked(OpcItem itemID)
		{
			m_itemID = itemID;
			DialogResult = DialogResult.OK;
		}
	}
}
