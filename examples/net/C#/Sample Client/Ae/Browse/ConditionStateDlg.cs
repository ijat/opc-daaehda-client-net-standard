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
	public class ConditionStateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Panel LeftPN;
		private System.Windows.Forms.Button RefreshBTN;
		private OpcClientSdk.Ae.SampleClient.ConditionStateCtrl ConditionCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConditionStateDlg()
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
			this.RefreshBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.ConditionCTRL = new OpcClientSdk.Ae.SampleClient.ConditionStateCtrl();
			this.ButtonsPN.SuspendLayout();
			this.LeftPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.RefreshBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 474);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(552, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// RefreshBTN
			// 
			this.RefreshBTN.Location = new System.Drawing.Point(4, 8);
			this.RefreshBTN.Name = "RefreshBTN";
			this.RefreshBTN.TabIndex = 1;
			this.RefreshBTN.Text = "Refresh";
			this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(472, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Close";
			this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.ConditionCTRL);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Right = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(552, 474);
			this.LeftPN.TabIndex = 2;
			// 
			// ConditionCTRL
			// 
			this.ConditionCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConditionCTRL.Location = new System.Drawing.Point(4, 4);
			this.ConditionCTRL.Name = "ConditionCTRL";
			this.ConditionCTRL.Size = new System.Drawing.Size(544, 470);
			this.ConditionCTRL.TabIndex = 0;
			// 
			// ConditionStateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(552, 510);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "ConditionStateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "View Condition State";
			this.ButtonsPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer m_server = null;
		private string m_source = null;
		private string m_condition = null;
		private OpcClientSdk.Ae.TsCAeAttribute[] m_attributes = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the condition state for specified source and condition.
		/// </summary>
		public void ShowDialog(TsCAeServer server, string source, string condition)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server    = server;
			m_source    = source;
			m_condition = condition;
			
			// find attributes for condition.
			FindAttributes();
			
			// get the current enabled state.
			ShowCondition();

			// show the dialog.
			Show();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Fetches the condition state
		/// </summary>
		private void ShowCondition()
		{
			try
			{
				// build attribute list.
				int[] attributeIDs = new int[m_attributes.Length];

				for (int ii = 0; ii < m_attributes.Length; ii++)
				{
					attributeIDs[ii] = m_attributes[ii].ID;
				}

				// fetch condition state.
				Ae.TsCAeCondition condition = m_server.GetConditionState(m_source, m_condition, attributeIDs);
					
				// show condition.
				ConditionCTRL.ShowCondition(m_attributes, condition);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetConditionState");
			}
		}

		/// <summary>
		/// Find attributes for condition by searching all categories.
		/// </summary>
		private void FindAttributes()
		{
			try
			{
				OpcClientSdk.Ae.TsCAeCategory[] categories = m_server.QueryEventCategories((int)TsCAeEventType.Condition);

				for (int ii = 0; ii < categories.Length; ii++)
				{
					// fetch conditions for category.
					string[] conditions = m_server.QueryConditionNames(categories[ii].ID);

					// check if this is the category containing the current condition.
					bool found = false;

					for (int jj = 0; jj < conditions.Length; jj++)
					{
						if (conditions[jj] == m_condition)
						{
							found = true;
							break;
						}
					}

					// fetch the attributes when found.
					if (found)
					{
						m_attributes = m_server.QueryEventAttributes(categories[ii].ID);
						break;
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Closes the window.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Re-reads the enabled states for the areas and sources.
		/// </summary>
		private void RefreshBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				ShowCondition();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

	}
}
