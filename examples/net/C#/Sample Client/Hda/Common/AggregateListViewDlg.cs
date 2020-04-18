//============================================================================
// TITLE: AggregateListViewDlg.cs
//
// CONTENTS:
// 
// A dialog used to display a list of server aggregates.
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
// 2003/12/30 RSA   Initial implementation.

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
	/// A dialog used to browse the address space of an OPC DA server.
	/// </summary>
	public class AggregateListViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button DoneBTN;
		private System.Windows.Forms.Panel RightPN;
		private OpcClientSdk.Hda.SampleClient.AggregateListViewCtrl AggregatesCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AggregateListViewDlg()
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
			this.RightPN = new System.Windows.Forms.Panel();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.DoneBTN = new System.Windows.Forms.Button();
			this.AggregatesCTRL = new OpcClientSdk.Hda.SampleClient.AggregateListViewCtrl();
			this.RightPN.SuspendLayout();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.AggregatesCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(0, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(792, 300);
			this.RightPN.TabIndex = 8;
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
			// AggregatesCTRL
			// 
			this.AggregatesCTRL.AllowDrop = true;
			this.AggregatesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AggregatesCTRL.Location = new System.Drawing.Point(0, 4);
			this.AggregatesCTRL.Name = "AggregatesCTRL";
			this.AggregatesCTRL.Size = new System.Drawing.Size(788, 296);
			this.AggregatesCTRL.TabIndex = 0;
			// 
			// AggregateListViewDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 336);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "AggregateListViewDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "View Aggregates";
			this.RightPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server used for viewing attributes.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Displays the address space for the specified server.
		/// </summary>
		public void ShowDialog(TsCHdaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			AggregatesCTRL.Initialize(server);

			ShowDialog();
		}
		
		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
