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
	public class SetEnabledStateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Label EnabledLB;
		private System.Windows.Forms.CheckBox EnabledCHK;
		private System.Windows.Forms.CheckBox RecursiveCHK;
		private System.Windows.Forms.Label RecursiveLB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SetEnabledStateDlg()
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
			this.EnabledLB = new System.Windows.Forms.Label();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.EnabledCHK = new System.Windows.Forms.CheckBox();
			this.RecursiveCHK = new System.Windows.Forms.CheckBox();
			this.RecursiveLB = new System.Windows.Forms.Label();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// EnabledLB
			// 
			this.EnabledLB.Location = new System.Drawing.Point(4, 4);
			this.EnabledLB.Name = "EnabledLB";
			this.EnabledLB.Size = new System.Drawing.Size(68, 20);
			this.EnabledLB.TabIndex = 1;
			this.EnabledLB.Text = "Enabled";
			this.EnabledLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 50);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(216, 36);
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
			this.CancelBTN.Location = new System.Drawing.Point(136, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// EnabledCHK
			// 
			this.EnabledCHK.Location = new System.Drawing.Point(80, 2);
			this.EnabledCHK.Name = "EnabledCHK";
			this.EnabledCHK.Size = new System.Drawing.Size(24, 24);
			this.EnabledCHK.TabIndex = 2;
			// 
			// RecursiveCHK
			// 
			this.RecursiveCHK.Location = new System.Drawing.Point(80, 26);
			this.RecursiveCHK.Name = "RecursiveCHK";
			this.RecursiveCHK.Size = new System.Drawing.Size(24, 24);
			this.RecursiveCHK.TabIndex = 4;
			// 
			// RecursiveLB
			// 
			this.RecursiveLB.Location = new System.Drawing.Point(4, 28);
			this.RecursiveLB.Name = "RecursiveLB";
			this.RecursiveLB.Size = new System.Drawing.Size(68, 20);
			this.RecursiveLB.TabIndex = 3;
			this.RecursiveLB.Text = "Recursive";
			this.RecursiveLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SetEnabledStateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(216, 86);
			this.Controls.Add(this.RecursiveCHK);
			this.Controls.Add(this.RecursiveLB);
			this.Controls.Add(this.EnabledCHK);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.EnabledLB);
			this.MaximizeBox = false;
			this.Name = "SetEnabledStateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Enabled State";
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer m_server = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to select the enabled state.
		/// </summary>
		public bool ShowDialog(
			TsCAeServer server, 
			OpcClientSdk.Ae.TsCAeBrowseElement element, 
			out bool      enabled, 
			ref bool      recursive)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			// get current enabled state.
			EnabledCHK.Checked = enabled = GetEnabledState(element);

			if (element != null)
			{
				RecursiveCHK.Checked = recursive;	
				RecursiveCHK.Enabled = true;
			}
			else
			{
				RecursiveCHK.Checked = true;	
				RecursiveCHK.Enabled = false;
			}

			// show dialog.
			if (ShowDialog() == DialogResult.OK)
			{
				enabled   = EnabledCHK.Checked;
				recursive = RecursiveCHK.Checked;
				return true;
			}

			return false;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Fetches the enabled state for an area or source.
		/// </summary>
		private bool GetEnabledState(OpcClientSdk.Ae.TsCAeBrowseElement element)
		{
			try
			{
				// check for root.
				if (element == null)
				{
					return true;
				}

				// construct arguments.
				string[] names = new string[] { element.QualifiedName };
				
				TsCAeEnabledStateResult[] results = null;
				
				// get current enabled state.
				if (element.NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)
				{
					results = m_server.GetEnableStateByArea(names);
				}
				else
				{
					results = m_server.GetEnableStateBySource(names);
				}
				
				// check return code and result.
				if (results != null && results.Length == 1)
				{
					if (results[0].Result.Failed())
					{
						return false;
					}

					return results[0].Enabled;
				}

				// should never happen.
				return false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetEnabledState");
				return false;
			}	
		}
		#endregion
	}
}
