#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;
using OpcClientSdk.SampleClient;

namespace OpcClientSdk.Ae.SampleClient
{
	/// <summary>
	/// A dialog that displays the current status of an OPC server.
	/// </summary>
	public class BrowseDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private OpcClientSdk.Ae.SampleClient.BrowseCtrl BrowseCTRL;
		private System.Windows.Forms.Panel LeftPN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BrowseDlg()
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
            this.ButtonsPN = new System.Windows.Forms.Panel();
            this.CancelBTN = new System.Windows.Forms.Button();
			this.BrowseCTRL = new BrowseCtrl();
            this.LeftPN = new System.Windows.Forms.Panel();
            this.ButtonsPN.SuspendLayout();
            this.LeftPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 290);
            this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(512, 36);
            this.ButtonsPN.TabIndex = 0;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.CancelBTN.Location = new System.Drawing.Point(219, 8);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // BrowseCTRL
            // 
            this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseCTRL.Location = new System.Drawing.Point(4, 4);
            this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(504, 286);
            this.BrowseCTRL.TabIndex = 0;
            // 
            // LeftPN
            // 
            this.LeftPN.Controls.Add(this.BrowseCTRL);
            this.LeftPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Right = 4;
			this.LeftPN.DockPadding.Top = 4;
            this.LeftPN.Location = new System.Drawing.Point(0, 0);
            this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(512, 290);
            this.LeftPN.TabIndex = 2;
            // 
            // BrowseDlg
            // 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.CancelBTN;
            this.ClientSize = new System.Drawing.Size(512, 326);
            this.Controls.Add(this.LeftPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
            this.Name = "BrowseDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browse Address Space";
            this.ButtonsPN.ResumeLayout(false);
            this.LeftPN.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event conditions supported by the server.
		/// </summary>
		public void ShowDialog(TsCAeServer server, bool modal)
		{
			if (server == null) throw new ArgumentNullException("server");

			BrowseCTRL.ShowAreas(server);

			if (modal)
			{
				ShowDialog();
			}
			else
			{
				Show();
			}
		}
		#endregion

		#region Private Methods
		#endregion

		#region Event Handlers
		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
		#endregion
	}
}
