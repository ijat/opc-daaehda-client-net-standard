//============================================================================
// TITLE: OptionsEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to edit the default options for a server or subscription.
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
using OpcClientSdk;
using OpcClientSdk.Controls;
using OpcClientSdk.Da;

namespace Client
{	
	/// <summary>
	/// // A dialog used to edit the default options for a server or subscription.
	/// </summary>
	public class OptionsEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Label ItemTimeLB;
		private System.Windows.Forms.Label ItemNameLB;
		private System.Windows.Forms.Label ItemPathLB;
		private System.Windows.Forms.Label ErrorTextLB;
		private System.Windows.Forms.CheckBox ErrorTextCB;
		private System.Windows.Forms.Label DiagnosticInfoLB;
		private System.Windows.Forms.CheckBox DiagnosticInfoCB;
		private System.Windows.Forms.CheckBox ItemNameCB;
		private System.Windows.Forms.CheckBox ItemPathCB;
		private System.Windows.Forms.CheckBox ItemTimeCB;
		private System.Windows.Forms.CheckBox ClientHandleCB;
		private System.Windows.Forms.Label ClientHandleLB;
		private OpcClientSdk.Controls.LocaleCtrl LocaleCTRL;
		private System.Windows.Forms.Label LocaleLB;
		private System.Windows.Forms.CheckBox LocaleSpecifiedCB;
		private System.ComponentModel.IContainer components = null;

		public OptionsEditDlg()
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
			this.ItemTimeLB = new System.Windows.Forms.Label();
			this.ItemNameLB = new System.Windows.Forms.Label();
			this.ItemTimeCB = new System.Windows.Forms.CheckBox();
			this.ItemPathLB = new System.Windows.Forms.Label();
			this.TopPN = new System.Windows.Forms.Panel();
			this.LocaleSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.LocaleCTRL = new OpcClientSdk.Controls.LocaleCtrl();
			this.LocaleLB = new System.Windows.Forms.Label();
			this.ClientHandleCB = new System.Windows.Forms.CheckBox();
			this.ItemPathCB = new System.Windows.Forms.CheckBox();
			this.ItemNameCB = new System.Windows.Forms.CheckBox();
			this.DiagnosticInfoCB = new System.Windows.Forms.CheckBox();
			this.ErrorTextCB = new System.Windows.Forms.CheckBox();
			this.ClientHandleLB = new System.Windows.Forms.Label();
			this.DiagnosticInfoLB = new System.Windows.Forms.Label();
			this.ErrorTextLB = new System.Windows.Forms.Label();
			this.ButtonsPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(5, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(176, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 170);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(256, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// ItemTimeLB
			// 
			this.ItemTimeLB.Location = new System.Drawing.Point(4, 100);
			this.ItemTimeLB.Name = "ItemTimeLB";
			this.ItemTimeLB.Size = new System.Drawing.Size(128, 23);
			this.ItemTimeLB.TabIndex = 8;
			this.ItemTimeLB.Text = "Return Timestamp";
			this.ItemTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameLB
			// 
			this.ItemNameLB.Location = new System.Drawing.Point(4, 28);
			this.ItemNameLB.Name = "ItemNameLB";
			this.ItemNameLB.Size = new System.Drawing.Size(128, 23);
			this.ItemNameLB.TabIndex = 0;
			this.ItemNameLB.Text = "Return Item Name";
			this.ItemNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemTimeCB
			// 
			this.ItemTimeCB.Checked = true;
			this.ItemTimeCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ItemTimeCB.Location = new System.Drawing.Point(132, 100);
			this.ItemTimeCB.Name = "ItemTimeCB";
			this.ItemTimeCB.Size = new System.Drawing.Size(96, 24);
			this.ItemTimeCB.TabIndex = 9;
			// 
			// ItemPathLB
			// 
			this.ItemPathLB.Location = new System.Drawing.Point(4, 52);
			this.ItemPathLB.Name = "ItemPathLB";
			this.ItemPathLB.Size = new System.Drawing.Size(128, 23);
			this.ItemPathLB.TabIndex = 2;
			this.ItemPathLB.Text = "Return Item Path";
			this.ItemPathLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.LocaleSpecifiedCB);
			this.TopPN.Controls.Add(this.LocaleCTRL);
			this.TopPN.Controls.Add(this.LocaleLB);
			this.TopPN.Controls.Add(this.ClientHandleCB);
			this.TopPN.Controls.Add(this.ItemPathCB);
			this.TopPN.Controls.Add(this.ItemNameCB);
			this.TopPN.Controls.Add(this.DiagnosticInfoCB);
			this.TopPN.Controls.Add(this.ErrorTextCB);
			this.TopPN.Controls.Add(this.ItemTimeCB);
			this.TopPN.Controls.Add(this.ClientHandleLB);
			this.TopPN.Controls.Add(this.DiagnosticInfoLB);
			this.TopPN.Controls.Add(this.ErrorTextLB);
			this.TopPN.Controls.Add(this.ItemTimeLB);
			this.TopPN.Controls.Add(this.ItemPathLB);
			this.TopPN.Controls.Add(this.ItemNameLB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPN.DockPadding.Left = 4;
			this.TopPN.DockPadding.Right = 4;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(256, 460);
			this.TopPN.TabIndex = 1;
			// 
			// LocaleSpecifiedCB
			// 
			this.LocaleSpecifiedCB.Location = new System.Drawing.Point(236, 4);
			this.LocaleSpecifiedCB.Name = "LocaleSpecifiedCB";
			this.LocaleSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.LocaleSpecifiedCB.TabIndex = 16;
			this.LocaleSpecifiedCB.CheckedChanged += new System.EventHandler(this.LocaleSpecifiedCB_CheckedChanged);
			// 
			// LocaleCTRL
			// 
			this.LocaleCTRL.Enabled = false;
			this.LocaleCTRL.Locale = "";
			this.LocaleCTRL.Location = new System.Drawing.Point(132, 4);
			this.LocaleCTRL.Name = "LocaleCTRL";
			this.LocaleCTRL.Size = new System.Drawing.Size(96, 24);
			this.LocaleCTRL.TabIndex = 15;
			// 
			// LocaleLB
			// 
			this.LocaleLB.Location = new System.Drawing.Point(4, 4);
			this.LocaleLB.Name = "LocaleLB";
			this.LocaleLB.Size = new System.Drawing.Size(128, 23);
			this.LocaleLB.TabIndex = 14;
			this.LocaleLB.Text = "Locale";
			this.LocaleLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ClientHandleCB
			// 
			this.ClientHandleCB.Checked = true;
			this.ClientHandleCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ClientHandleCB.Location = new System.Drawing.Point(132, 76);
			this.ClientHandleCB.Name = "ClientHandleCB";
			this.ClientHandleCB.Size = new System.Drawing.Size(96, 24);
			this.ClientHandleCB.TabIndex = 5;
			// 
			// ItemPathCB
			// 
			this.ItemPathCB.Checked = true;
			this.ItemPathCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ItemPathCB.Location = new System.Drawing.Point(132, 52);
			this.ItemPathCB.Name = "ItemPathCB";
			this.ItemPathCB.Size = new System.Drawing.Size(96, 24);
			this.ItemPathCB.TabIndex = 3;
			// 
			// ItemNameCB
			// 
			this.ItemNameCB.Checked = true;
			this.ItemNameCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ItemNameCB.Location = new System.Drawing.Point(132, 28);
			this.ItemNameCB.Name = "ItemNameCB";
			this.ItemNameCB.Size = new System.Drawing.Size(96, 24);
			this.ItemNameCB.TabIndex = 1;
			// 
			// DiagnosticInfoCB
			// 
			this.DiagnosticInfoCB.Checked = true;
			this.DiagnosticInfoCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DiagnosticInfoCB.Location = new System.Drawing.Point(132, 148);
			this.DiagnosticInfoCB.Name = "DiagnosticInfoCB";
			this.DiagnosticInfoCB.Size = new System.Drawing.Size(96, 24);
			this.DiagnosticInfoCB.TabIndex = 13;
			// 
			// ErrorTextCB
			// 
			this.ErrorTextCB.Checked = true;
			this.ErrorTextCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ErrorTextCB.Location = new System.Drawing.Point(132, 124);
			this.ErrorTextCB.Name = "ErrorTextCB";
			this.ErrorTextCB.Size = new System.Drawing.Size(96, 24);
			this.ErrorTextCB.TabIndex = 11;
			// 
			// ClientHandleLB
			// 
			this.ClientHandleLB.Location = new System.Drawing.Point(4, 76);
			this.ClientHandleLB.Name = "ClientHandleLB";
			this.ClientHandleLB.Size = new System.Drawing.Size(128, 23);
			this.ClientHandleLB.TabIndex = 4;
			this.ClientHandleLB.Text = "Return Client Handle";
			this.ClientHandleLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DiagnosticInfoLB
			// 
			this.DiagnosticInfoLB.Location = new System.Drawing.Point(4, 148);
			this.DiagnosticInfoLB.Name = "DiagnosticInfoLB";
			this.DiagnosticInfoLB.Size = new System.Drawing.Size(128, 23);
			this.DiagnosticInfoLB.TabIndex = 12;
			this.DiagnosticInfoLB.Text = "Return Diagnostic Info";
			this.DiagnosticInfoLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ErrorTextLB
			// 
			this.ErrorTextLB.Location = new System.Drawing.Point(4, 124);
			this.ErrorTextLB.Name = "ErrorTextLB";
			this.ErrorTextLB.Size = new System.Drawing.Size(128, 23);
			this.ErrorTextLB.TabIndex = 10;
			this.ErrorTextLB.Text = "Return Error Text";
			this.ErrorTextLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OptionsEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 206);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.TopPN);
			this.Name = "OptionsEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Options";
			this.ButtonsPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts user to edit request option parameters in a modal dialog.
		/// </summary>
		public void ShowDialog(TsCDaServer server)
		{
			ShowDialog(server, null);
		}

		/// <summary>
		/// Toggles the state of the locale selection control.
		/// </summary>
		private void LocaleSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			LocaleCTRL.Enabled = LocaleSpecifiedCB.Checked;	
		}

		/// <summary>
		/// Prompts user to edit request option parameters in a modal dialog.
		/// </summary>
		public void ShowDialog(TsCDaSubscription subscription)
		{
			ShowDialog(subscription.Server, subscription);
		}
		
		/// <summary>
		/// Prompts user to edit request option parameters in a modal dialog.
		/// </summary>
		private void ShowDialog(TsCDaServer server, TsCDaSubscription subscription)
		{
			if (server == null) throw new ArgumentNullException("server");

			// get supported locales.
			LocaleCTRL.SetSupportedLocales(server.SupportedLocales);

			// set locale.
			string locale = (subscription == null)?server.Locale:subscription.Locale;

			LocaleCTRL.Locale = locale;
			LocaleSpecifiedCB.Checked = locale != null;

			// get filters.
			int filters = (subscription == null)?server.Filters:subscription.Filters;

			ItemNameCB.Checked       = ((filters & (int)TsCDaResultFilter.ItemName)       != 0);
			ItemPathCB.Checked       = ((filters & (int)TsCDaResultFilter.ItemPath)       != 0);
			ClientHandleCB.Checked   = ((filters & (int)TsCDaResultFilter.ClientHandle)   != 0);
			ItemTimeCB.Checked       = ((filters & (int)TsCDaResultFilter.ItemTime)       != 0);
			ErrorTextCB.Checked      = ((filters & (int)TsCDaResultFilter.ErrorText)      != 0);
			DiagnosticInfoCB.Checked = ((filters & (int)TsCDaResultFilter.DiagnosticInfo) != 0);

			// show dialog.
			while (ShowDialog() == DialogResult.OK)
			{
				// update locale.
				try
				{
					locale = null;

					if (LocaleSpecifiedCB.Checked)
					{
						locale = LocaleCTRL.Locale;
					}

					if (subscription == null)
					{
						server.SetLocale(locale);
					}
					else
					{
						TsCDaSubscriptionState state = new TsCDaSubscriptionState();
						state.Locale = locale;
						subscription.ModifyState((int)TsCDaStateMask.Locale, state);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
					continue;
				}

				// update filters.
				filters = 0;

				filters |= (ItemNameCB.Checked)?(int)TsCDaResultFilter.ItemName:0;
				filters |= (ItemPathCB.Checked)?(int)TsCDaResultFilter.ItemPath:0;
				filters |= (ClientHandleCB.Checked)?(int)TsCDaResultFilter.ClientHandle:0;
				filters |= (ItemTimeCB.Checked)?(int)TsCDaResultFilter.ItemTime:0;
				filters |= (ErrorTextCB.Checked)?(int)TsCDaResultFilter.ErrorText:0;
				filters |= (DiagnosticInfoCB.Checked)?(int)TsCDaResultFilter.DiagnosticInfo:0;

				try
				{
					if (subscription == null)
					{
						server.SetResultFilters(filters);
					}
					else
					{
						subscription.SetResultFilters(filters);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
					continue;
				}

				// break out of loop if no error.
				break;
			}
		}
	}
}
