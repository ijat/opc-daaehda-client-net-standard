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

namespace OpcClientSdk.Ae.SampleClient
{
	/// <summary>
	/// A dialog that displays the current status of an OPC server.
	/// </summary>
	public class QualifiedNameEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Label QualifiedNameLB;
		private System.Windows.Forms.TextBox QualifiedNameTB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public QualifiedNameEditDlg()
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
			this.QualifiedNameLB = new System.Windows.Forms.Label();
			this.QualifiedNameTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// QualifiedNameLB
			// 
			this.QualifiedNameLB.Location = new System.Drawing.Point(4, 4);
			this.QualifiedNameLB.Name = "QualifiedNameLB";
			this.QualifiedNameLB.Size = new System.Drawing.Size(100, 20);
			this.QualifiedNameLB.TabIndex = 1;
			this.QualifiedNameLB.Text = "Qualified Name";
			this.QualifiedNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualifiedNameTB
			// 
			this.QualifiedNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.QualifiedNameTB.Location = new System.Drawing.Point(88, 4);
			this.QualifiedNameTB.Name = "QualifiedNameTB";
			this.QualifiedNameTB.Size = new System.Drawing.Size(232, 20);
			this.QualifiedNameTB.TabIndex = 2;
			this.QualifiedNameTB.Text = "";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 26);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(328, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(4, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(248, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// QualifiedNameEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(328, 62);
			this.Controls.Add(this.QualifiedNameTB);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.QualifiedNameLB);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(312, 0);
			this.Name = "QualifiedNameEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Qualified Name";
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to change the browse filter settings.
		/// </summary>
		public string ShowDialog(string filter)
		{
			QualifiedNameTB.Text = filter;

			if (ShowDialog() == DialogResult.OK)
			{
				return QualifiedNameTB.Text;
			}

			return null;
		}
		#endregion
	}
}
