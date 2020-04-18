//============================================================================
// TITLE: ItemEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to modify the parameters of an item.
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
// 2003/12/31 RSA   Initial implementation.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Data;

using OpcClientSdk.Hda;
using OpcClientSdk.Hda.Test;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class TimestampEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.Label TimestampLB;
		private System.Windows.Forms.DateTimePicker TimestampCTRL;
		private System.Windows.Forms.CheckBox TimestampSpecifiedCB;
		private System.ComponentModel.IContainer components = null;

		public TimestampEditDlg()
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
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OkBTN = new System.Windows.Forms.Button();
			this.MainPN = new System.Windows.Forms.Panel();
			this.TimestampCTRL = new System.Windows.Forms.DateTimePicker();
			this.TimestampLB = new System.Windows.Forms.Label();
			this.TimestampSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(168, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 26);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(248, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(4, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 0;
			this.OkBTN.Text = "OK";
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.TimestampSpecifiedCB);
			this.MainPN.Controls.Add(this.TimestampCTRL);
			this.MainPN.Controls.Add(this.TimestampLB);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Left = 4;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(248, 26);
			this.MainPN.TabIndex = 33;
			// 
			// TimestampCTRL
			// 
			this.TimestampCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TimestampCTRL.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.TimestampCTRL.Enabled = false;
			this.TimestampCTRL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TimestampCTRL.Location = new System.Drawing.Point(72, 4);
			this.TimestampCTRL.Name = "TimestampCTRL";
			this.TimestampCTRL.Size = new System.Drawing.Size(152, 20);
			this.TimestampCTRL.TabIndex = 40;
			// 
			// TimestampLB
			// 
			this.TimestampLB.Location = new System.Drawing.Point(4, 4);
			this.TimestampLB.Name = "TimestampLB";
			this.TimestampLB.Size = new System.Drawing.Size(68, 23);
			this.TimestampLB.TabIndex = 39;
			this.TimestampLB.Text = "Timestamp";
			this.TimestampLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TimestampSpecifiedCB
			// 
			this.TimestampSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TimestampSpecifiedCB.Location = new System.Drawing.Point(228, 3);
			this.TimestampSpecifiedCB.Name = "TimestampSpecifiedCB";
			this.TimestampSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.TimestampSpecifiedCB.TabIndex = 41;
			this.TimestampSpecifiedCB.CheckedChanged += new System.EventHandler(this.TimestampSpecifiedCB_CheckedChanged);
			// 
			// TimestampEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 62);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "TimestampEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Timestamp";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit a timestamp.
		/// </summary>
		public bool ShowDialog(ref DateTime timestamp)
		{
			TimestampSpecifiedCB.Checked = (TimestampCTRL.MinDate < timestamp);

			// initialize controls.
			if (TimestampSpecifiedCB.Checked)
			{
				TimestampCTRL.Value = timestamp;
			}

			// display dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update object.
			if (TimestampSpecifiedCB.Checked)
			{
				timestamp = TimestampCTRL.Value;
			}
			else
			{
				timestamp = DateTime.MinValue;
			}

			return true;
		}

		/// <summary>
		/// Toggles the enabled state of the value control.
		/// </summary>
		private void TimestampSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			 TimestampCTRL.Enabled = TimestampSpecifiedCB.Checked;
		}
	}
}
