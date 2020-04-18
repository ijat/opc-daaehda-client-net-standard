//============================================================================
// TITLE: LocaleSelectDlg.cs
//
// CONTENTS:
// 
// A dialog used select a locale from a list of supported locales.
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
using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace OpcClientSdk.Controls
{	
	/// <summary>
	/// A dialog used select a locale from a list of supported locales.
	/// </summary>
	public class LocaleSelectDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.ListBox SupportedLocalesLB;
		private System.ComponentModel.IContainer components = null;

		public LocaleSelectDlg()
		{
			// Required for Windows Form Designer support
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
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.TopPN = new System.Windows.Forms.Panel();
			this.SupportedLocalesLB = new System.Windows.Forms.ListBox();
			this.ButtonsPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBTN.Location = new System.Drawing.Point(71, 3);
			this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(152, 4);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 118);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(232, 32);
			this.ButtonsPN.TabIndex = 0;
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.SupportedLocalesLB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.TopPN.Size = new System.Drawing.Size(232, 118);
			this.TopPN.TabIndex = 1;
			// 
			// SupportedLocalesLB
			// 
			this.SupportedLocalesLB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SupportedLocalesLB.Location = new System.Drawing.Point(4, 4);
			this.SupportedLocalesLB.Name = "SupportedLocalesLB";
            this.SupportedLocalesLB.Size = new System.Drawing.Size(224, 114);
			this.SupportedLocalesLB.TabIndex = 6;
            this.SupportedLocalesLB.SelectedIndexChanged += new System.EventHandler(this.SupportedLocalesLB_SelectedIndexChanged);
			this.SupportedLocalesLB.DoubleClick += new System.EventHandler(this.SupportedLocalesLB_DoubleClick);
			// 
			// LocaleSelectDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 150);
			this.Controls.Add(this.TopPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "LocaleSelectDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Locale";
			this.ButtonsPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// Prompts user to select a locale in a modal dialog.
		/// </summary>
		public int ShowDialog(CultureInfo[] locales)
		{
			SupportedLocalesLB.Items.Clear();

			if (locales != null)
			{
				foreach (CultureInfo locale in locales)
				{
					SupportedLocalesLB.Items.Add(locale.DisplayName);
				}
			}

			OkBTN.Enabled = false;

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return -1;
			}

			return SupportedLocalesLB.SelectedIndex;
		}

		/// <summary>
		/// Toggles enabled state of the OK button based on the selected item.
		/// </summary>
		private void SupportedLocalesLB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OkBTN.Enabled = (SupportedLocalesLB.SelectedIndex != -1);
		}

		/// <summary>
		/// Toggles enabled state of the OK button based on the selected item.
		/// </summary>
		private void SupportedLocalesLB_DoubleClick(object sender, System.EventArgs e)
		{
			if (OkBTN.Enabled)
			{
				DialogResult = DialogResult.OK;
			}
		}
	}
}
