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

namespace OpcClientSdk.Hda.SampleClient
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
		private System.Windows.Forms.Label MaxReturnValuesLB;
		private System.Windows.Forms.TextBox MaxReturnValuesTB;
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
			this.MaxReturnValuesLB = new System.Windows.Forms.Label();
			this.MaxReturnValuesTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartTimeTB
			// 
			this.StartTimeTB.Location = new System.Drawing.Point(104, 84);
			this.StartTimeTB.Name = "StartTimeTB";
			this.StartTimeTB.ReadOnly = true;
			this.StartTimeTB.Size = new System.Drawing.Size(128, 20);
			this.StartTimeTB.TabIndex = 12;
			this.StartTimeTB.Text = "";
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
			this.ProductVersionTB.Location = new System.Drawing.Point(104, 24);
			this.ProductVersionTB.Name = "ProductVersionTB";
			this.ProductVersionTB.ReadOnly = true;
			this.ProductVersionTB.Size = new System.Drawing.Size(128, 20);
			this.ProductVersionTB.TabIndex = 4;
			this.ProductVersionTB.Text = "";
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
			this.ServerStateTB.Location = new System.Drawing.Point(104, 44);
			this.ServerStateTB.Name = "ServerStateTB";
			this.ServerStateTB.ReadOnly = true;
			this.ServerStateTB.Size = new System.Drawing.Size(128, 20);
			this.ServerStateTB.TabIndex = 6;
			this.ServerStateTB.Text = "";
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
			this.VendorInfoTB.Location = new System.Drawing.Point(104, 4);
			this.VendorInfoTB.Name = "VendorInfoTB";
			this.VendorInfoTB.ReadOnly = true;
			this.VendorInfoTB.Size = new System.Drawing.Size(248, 20);
			this.VendorInfoTB.TabIndex = 2;
			this.VendorInfoTB.Text = "";
			// 
			// CurrentTimeTB
			// 
			this.CurrentTimeTB.Location = new System.Drawing.Point(104, 104);
			this.CurrentTimeTB.Name = "CurrentTimeTB";
			this.CurrentTimeTB.ReadOnly = true;
			this.CurrentTimeTB.Size = new System.Drawing.Size(128, 20);
			this.CurrentTimeTB.TabIndex = 14;
			this.CurrentTimeTB.Text = "";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.UpdateBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 146);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(360, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// UpdateBTN
			// 
			this.UpdateBTN.Location = new System.Drawing.Point(4, 8);
			this.UpdateBTN.Name = "UpdateBTN";
			this.UpdateBTN.TabIndex = 1;
			this.UpdateBTN.Text = "Update";
			this.UpdateBTN.Click += new System.EventHandler(this.UpdateBTN_Click);
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(280, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Close";
			// 
			// StatusInfoTB
			// 
			this.StatusInfoTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.StatusInfoTB.Location = new System.Drawing.Point(104, 64);
			this.StatusInfoTB.Name = "StatusInfoTB";
			this.StatusInfoTB.ReadOnly = true;
			this.StatusInfoTB.Size = new System.Drawing.Size(248, 20);
			this.StatusInfoTB.TabIndex = 17;
			this.StatusInfoTB.Text = "";
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
			// MaxReturnValuesLB
			// 
			this.MaxReturnValuesLB.Location = new System.Drawing.Point(4, 124);
			this.MaxReturnValuesLB.Name = "MaxReturnValuesLB";
			this.MaxReturnValuesLB.Size = new System.Drawing.Size(100, 20);
			this.MaxReturnValuesLB.TabIndex = 19;
			this.MaxReturnValuesLB.Text = "Max Return Values";
			this.MaxReturnValuesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxReturnValuesTB
			// 
			this.MaxReturnValuesTB.Location = new System.Drawing.Point(104, 124);
			this.MaxReturnValuesTB.Name = "MaxReturnValuesTB";
			this.MaxReturnValuesTB.ReadOnly = true;
			this.MaxReturnValuesTB.Size = new System.Drawing.Size(128, 20);
			this.MaxReturnValuesTB.TabIndex = 20;
			this.MaxReturnValuesTB.Text = "";
			// 
			// ServerStatusDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(360, 182);
			this.Controls.Add(this.MaxReturnValuesTB);
			this.Controls.Add(this.MaxReturnValuesLB);
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

		}
		#endregion

		/// <summary>
		/// The server used to fetch status information.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Displays the current server status in a modal dialog.
		/// </summary>
		public void ShowDialog(TsCHdaServer server)
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

				VendorInfoTB.Text      = status.VendorInfo;
				ProductVersionTB.Text  = status.ProductVersion;
				ServerStateTB.Text     = OpcClientSdk.OpcConvert.ToString(status.ServerState);
				StatusInfoTB.Text      = status.StatusInfo;
				StartTimeTB.Text       = OpcClientSdk.OpcConvert.ToString(status.StartTime);
				CurrentTimeTB.Text     = OpcClientSdk.OpcConvert.ToString(status.CurrentTime);
				MaxReturnValuesTB.Text = OpcClientSdk.OpcConvert.ToString(status.MaxReturnValues);
			}
			catch (Exception e)
			{
				VendorInfoTB.Text      = null;
				ProductVersionTB.Text  = null;
				ServerStateTB.Text     = null;
				StatusInfoTB.Text      = e.Message;
				StartTimeTB.Text       = null;
				CurrentTimeTB.Text     = null;
				MaxReturnValuesTB.Text = null;
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
