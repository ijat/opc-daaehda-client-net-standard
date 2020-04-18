//============================================================================
// TITLE: SelectServerCtrl.cs
//
// CONTENTS:
// 
// A control used browse and select a single OPC server. 
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
	/// A control used browse and select a single OPC server. 
	/// </summary>
	public class SelectServerDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private Client.BrowseTreeCtrl ServersCTRL;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Label SpecificationLB;
		private System.Windows.Forms.ComboBox SpecificationCB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectServerDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			SpecificationCB.Items.Add(OpcSpecification.OPC_DA_20);
			SpecificationCB.Items.Add(OpcSpecification.OPC_DA_30);	
			SpecificationCB.SelectedItem = null;

			ServersCTRL.ServerPicked += new ServerPicked_EventHandler(OnServerPicked);
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
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.OkBTN = new System.Windows.Forms.Button();
			this.SpecificationLB = new System.Windows.Forms.Label();
			this.ServersCTRL = new Client.BrowseTreeCtrl();
			this.TopPN = new System.Windows.Forms.Panel();
			this.SpecificationCB = new System.Windows.Forms.ComboBox();
			this.ButtonsPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 202);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(280, 36);
			this.ButtonsPN.TabIndex = 1;
			// 
			// CancelBTN
			// 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(200, 8);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// OkBTN
			// 
            this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBTN.Location = new System.Drawing.Point(119, 8);
			this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// SpecificationLB
			// 
			this.SpecificationLB.Location = new System.Drawing.Point(4, 4);
			this.SpecificationLB.Name = "SpecificationLB";
            this.SpecificationLB.Size = new System.Drawing.Size(73, 23);
			this.SpecificationLB.TabIndex = 2;
			this.SpecificationLB.Text = "Specification";
			this.SpecificationLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ServersCTRL
			// 
			this.ServersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ServersCTRL.Location = new System.Drawing.Point(0, 32);
			this.ServersCTRL.Name = "ServersCTRL";
            this.ServersCTRL.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ServersCTRL.Size = new System.Drawing.Size(280, 170);
			this.ServersCTRL.TabIndex = 4;
			// 
			// TopPN
			// 
            this.TopPN.Controls.Add(this.SpecificationCB);
            this.TopPN.Controls.Add(this.SpecificationLB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(280, 32);
			this.TopPN.TabIndex = 5;
			// 
			// SpecificationCB
			// 
            this.SpecificationCB.Location = new System.Drawing.Point(73, 4);
			this.SpecificationCB.Name = "SpecificationCB";
            this.SpecificationCB.Size = new System.Drawing.Size(203, 21);
			this.SpecificationCB.TabIndex = 3;
			this.SpecificationCB.SelectedIndexChanged += new System.EventHandler(this.SpecificationCB_SelectedIndexChanged);
			// 
			// SelectServerDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(280, 238);
            this.Controls.Add(this.ServersCTRL);
            this.Controls.Add(this.TopPN);
            this.Controls.Add(this.ButtonsPN);
			this.Name = "SelectServerDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Server";
			this.ButtonsPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the use to select a server with the specified specification.
		/// </summary>
		public TsCDaServer ShowDialog(OpcSpecification specification)
		{
			SpecificationCB.SelectedItem = specification;

			if (ShowDialog() != DialogResult.OK)
			{
				ServersCTRL.Clear();
				return null;
			}

			TsCDaServer server = ServersCTRL.SelectedServer;
			ServersCTRL.Clear();
			return server;
		}

		/// <summary>
		/// Called when a server is picked in the browse control.
		/// </summary>
		private void OnServerPicked(TsCDaServer server)
		{
			if (server != null)	DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Updates the specification of servers displayed in the browse control.
		/// </summary>
		private void SpecificationCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ServersCTRL.ShowAllServers((OpcSpecification)SpecificationCB.SelectedItem, null);
		}
	}
}
