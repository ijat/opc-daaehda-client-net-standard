//============================================================================
// TITLE: ServerStatusDlg.cs
//
// CONTENTS:
// 
// A dialog that displays the current status of an OPC server.
//
// (c) Copyright 2002-2003 The OPC Foundation
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
// 2002/11/16 RSA   First release.

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
	/// A dialog that displays the current status of an OPC server.
	/// </summary>
	public class ServerStatusDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox StartTimeTB;
		private System.Windows.Forms.Label StartTimeLB;
		private System.Windows.Forms.Label ServerStateLB;
		private System.Windows.Forms.TextBox ServerStateTB;
		private System.Windows.Forms.Label VendorInfoLB;
		private System.Windows.Forms.Label CurrentTimeLB;
		private System.Windows.Forms.TextBox VendorInfoTB;
		private System.Windows.Forms.TextBox CurrentTimeTB;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button UpdateBTN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Label ProductVersionLB;
		private System.Windows.Forms.TextBox ProductVersionTB;
		private System.Windows.Forms.TextBox StatusInfoTB;
		private System.Windows.Forms.Label StatusInfoLB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox LastUpdateTimeTB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ServerStatusDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
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
			this.StartTimeTB = new System.Windows.Forms.TextBox();
			this.StartTimeLB = new System.Windows.Forms.Label();
			this.ProductVersionLB = new System.Windows.Forms.Label();
			this.ProductVersionTB = new System.Windows.Forms.TextBox();
			this.ServerStateLB = new System.Windows.Forms.Label();
			this.ServerStateTB = new System.Windows.Forms.TextBox();
			this.VendorInfoLB = new System.Windows.Forms.Label();
			this.CurrentTimeLB = new System.Windows.Forms.Label();
			this.VendorInfoTB = new System.Windows.Forms.TextBox();
			this.CurrentTimeTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.UpdateBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.StatusInfoTB = new System.Windows.Forms.TextBox();
			this.StatusInfoLB = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LastUpdateTimeTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartTimeTB
			// 
			this.StartTimeTB.Location = new System.Drawing.Point(100, 84);
			this.StartTimeTB.Name = "StartTimeTB";
			this.StartTimeTB.ReadOnly = true;
			this.StartTimeTB.Size = new System.Drawing.Size(136, 20);
			this.StartTimeTB.TabIndex = 12;
			// 
			// StartTimeLB
			// 
			this.StartTimeLB.Location = new System.Drawing.Point(4, 84);
			this.StartTimeLB.Name = "StartTimeLB";
			this.StartTimeLB.Size = new System.Drawing.Size(96, 20);
			this.StartTimeLB.TabIndex = 11;
			this.StartTimeLB.Text = "Start Time";
			this.StartTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProductVersionLB
			// 
			this.ProductVersionLB.Location = new System.Drawing.Point(4, 24);
			this.ProductVersionLB.Name = "ProductVersionLB";
			this.ProductVersionLB.Size = new System.Drawing.Size(96, 20);
			this.ProductVersionLB.TabIndex = 3;
			this.ProductVersionLB.Text = "Product Version";
			this.ProductVersionLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProductVersionTB
			// 
			this.ProductVersionTB.Location = new System.Drawing.Point(100, 24);
			this.ProductVersionTB.Name = "ProductVersionTB";
			this.ProductVersionTB.ReadOnly = true;
			this.ProductVersionTB.Size = new System.Drawing.Size(136, 20);
			this.ProductVersionTB.TabIndex = 4;
			// 
			// ServerStateLB
			// 
			this.ServerStateLB.Location = new System.Drawing.Point(4, 44);
			this.ServerStateLB.Name = "ServerStateLB";
			this.ServerStateLB.Size = new System.Drawing.Size(96, 20);
			this.ServerStateLB.TabIndex = 5;
			this.ServerStateLB.Text = "Server State";
			this.ServerStateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ServerStateTB
			// 
			this.ServerStateTB.Location = new System.Drawing.Point(100, 44);
			this.ServerStateTB.Name = "ServerStateTB";
			this.ServerStateTB.ReadOnly = true;
			this.ServerStateTB.Size = new System.Drawing.Size(136, 20);
			this.ServerStateTB.TabIndex = 6;
			// 
			// VendorInfoLB
			// 
			this.VendorInfoLB.Location = new System.Drawing.Point(4, 4);
			this.VendorInfoLB.Name = "VendorInfoLB";
			this.VendorInfoLB.Size = new System.Drawing.Size(96, 20);
			this.VendorInfoLB.TabIndex = 1;
			this.VendorInfoLB.Text = "Vendor Info";
			this.VendorInfoLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CurrentTimeLB
			// 
			this.CurrentTimeLB.Location = new System.Drawing.Point(4, 104);
			this.CurrentTimeLB.Name = "CurrentTimeLB";
			this.CurrentTimeLB.Size = new System.Drawing.Size(96, 20);
			this.CurrentTimeLB.TabIndex = 13;
			this.CurrentTimeLB.Text = "Current Time";
			this.CurrentTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorInfoTB
			// 
            this.VendorInfoTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.VendorInfoTB.Location = new System.Drawing.Point(100, 4);
			this.VendorInfoTB.Name = "VendorInfoTB";
			this.VendorInfoTB.ReadOnly = true;
			this.VendorInfoTB.Size = new System.Drawing.Size(238, 20);
			this.VendorInfoTB.TabIndex = 2;
			// 
			// CurrentTimeTB
			// 
			this.CurrentTimeTB.Location = new System.Drawing.Point(100, 104);
			this.CurrentTimeTB.Name = "CurrentTimeTB";
			this.CurrentTimeTB.ReadOnly = true;
			this.CurrentTimeTB.Size = new System.Drawing.Size(136, 20);
			this.CurrentTimeTB.TabIndex = 14;
			// 
			// ButtonsPN
			// 
            this.ButtonsPN.Controls.Add(this.UpdateBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 142);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(342, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// UpdateBTN
			// 
            this.UpdateBTN.Location = new System.Drawing.Point(181, 8);
			this.UpdateBTN.Name = "UpdateBTN";
            this.UpdateBTN.Size = new System.Drawing.Size(75, 23);
			this.UpdateBTN.TabIndex = 1;
			this.UpdateBTN.Text = "Update";
			this.UpdateBTN.Click += new System.EventHandler(this.UpdateBTN_Click);
			// 
			// CancelBTN
			// 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(262, 8);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Close";
			// 
			// StatusInfoTB
			// 
            this.StatusInfoTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StatusInfoTB.Location = new System.Drawing.Point(100, 64);
			this.StatusInfoTB.Name = "StatusInfoTB";
			this.StatusInfoTB.ReadOnly = true;
			this.StatusInfoTB.Size = new System.Drawing.Size(238, 20);
			this.StatusInfoTB.TabIndex = 17;
			// 
			// StatusInfoLB
			// 
			this.StatusInfoLB.Location = new System.Drawing.Point(4, 64);
			this.StatusInfoLB.Name = "StatusInfoLB";
			this.StatusInfoLB.Size = new System.Drawing.Size(96, 20);
			this.StatusInfoLB.TabIndex = 18;
			this.StatusInfoLB.Text = "Status Info";
			this.StatusInfoLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 124);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 20);
			this.label1.TabIndex = 19;
			this.label1.Text = "Last Update Time";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LastUpdateTimeTB
			// 
			this.LastUpdateTimeTB.Location = new System.Drawing.Point(100, 124);
			this.LastUpdateTimeTB.Name = "LastUpdateTimeTB";
			this.LastUpdateTimeTB.ReadOnly = true;
			this.LastUpdateTimeTB.Size = new System.Drawing.Size(136, 20);
			this.LastUpdateTimeTB.TabIndex = 20;
			// 
			// ServerStatusDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
            this.ClientSize = new System.Drawing.Size(342, 178);
            this.Controls.Add(this.LastUpdateTimeTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusInfoLB);
            this.Controls.Add(this.StatusInfoTB);
            this.Controls.Add(this.ButtonsPN);
            this.Controls.Add(this.StartTimeTB);
            this.Controls.Add(this.StartTimeLB);
            this.Controls.Add(this.ProductVersionLB);
            this.Controls.Add(this.ProductVersionTB);
            this.Controls.Add(this.ServerStateLB);
            this.Controls.Add(this.ServerStateTB);
            this.Controls.Add(this.VendorInfoLB);
            this.Controls.Add(this.CurrentTimeLB);
            this.Controls.Add(this.VendorInfoTB);
            this.Controls.Add(this.CurrentTimeTB);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 216);
			this.MinimumSize = new System.Drawing.Size(350, 216);
			this.Name = "ServerStatusDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Server Status";
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The server used to fetch status information.
		/// </summary>
		private TsCDaServer m_server = null;

		/// <summary>
		/// Displays the current server status in a modal dialog.
		/// </summary>
		public void ShowDialog(TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;
			GetStatus();
			ShowDialog();
		}

		/// <summary>
		/// Get the status of the server.
		/// </summary>
		private void GetStatus()
		{
			try
			{
				OpcServerStatus status = m_server.GetServerStatus();

				VendorInfoTB.Text     = status.VendorInfo;
				ProductVersionTB.Text = status.ProductVersion;
				ServerStateTB.Text    = OpcClientSdk.OpcConvert.ToString(status.ServerState);
				StatusInfoTB.Text     = status.StatusInfo;
				StartTimeTB.Text      = OpcClientSdk.OpcConvert.ToString(status.StartTime);
				CurrentTimeTB.Text    = OpcClientSdk.OpcConvert.ToString(status.CurrentTime);
				LastUpdateTimeTB.Text = OpcClientSdk.OpcConvert.ToString(status.LastUpdateTime);
			}
			catch (Exception e)
			{
				VendorInfoTB.Text     = null;
				ProductVersionTB.Text = null;
				ServerStateTB.Text    = null;
				StatusInfoTB.Text     = e.Message;
				StartTimeTB.Text      = null;
				CurrentTimeTB.Text    = null;
				LastUpdateTimeTB.Text = null;
			}
		}

		/// <summary>
		/// Updates the status when the update button is clicked.
		/// </summary>
		private void UpdateBTN_Click(object sender, System.EventArgs e)
        {
                GetStatus();
		}
	}
}
