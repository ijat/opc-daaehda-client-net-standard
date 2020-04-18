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
	public class ItemIDsViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.ListView ItemUrlsLV;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemIDsViewDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			// add columns.
			AddHeader("Attribute");
			AddHeader("ItemID");
			AddHeader("URL");
			
			// adjust column widths.
			AdjustColumns();
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
			this.ItemUrlsLV = new System.Windows.Forms.ListView();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 258);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(592, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(259, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Close";
			// 
			// ItemUrlsLV
			// 
			this.ItemUrlsLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemUrlsLV.Location = new System.Drawing.Point(0, 0);
			this.ItemUrlsLV.Name = "ItemUrlsLV";
			this.ItemUrlsLV.Size = new System.Drawing.Size(592, 258);
			this.ItemUrlsLV.TabIndex = 1;
			this.ItemUrlsLV.View = System.Windows.Forms.View.Details;
			// 
			// ItemIDsViewDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(592, 294);
			this.Controls.Add(this.ItemUrlsLV);
			this.Controls.Add(this.ButtonsPN);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 400);
			this.MinimumSize = new System.Drawing.Size(300, 180);
			this.Name = "ItemIDsViewDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Translate Item IDs";
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer m_server = null;
		private string m_source = null;
		private int m_categoryID = 0;
		private string m_condition = null;
		private OpcClientSdk.Ae.TsCAeAttribute[] m_attributes = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event categories supported by the server.
		/// </summary>
		public void ShowDialog(
			TsCAeServer server,
			string        source, 
			string        condition,
			string        subcondition)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server    = server;
			m_source    = source;
			m_condition = condition;
			
			// find attributes for condition.
			FindAttributes();

			// clear list view.
			ItemUrlsLV.Items.Clear();	

			try
			{
				// build attribute list.
				int[] attributeIDs = new int[m_attributes.Length];

				for (int ii = 0; ii < m_attributes.Length; ii++)
				{
					attributeIDs[ii] = m_attributes[ii].ID;
				}

				// translate item ids
				TsCAeItemUrl[] itemUrls = m_server.TranslateToItemIDs(
					m_source, 
					m_categoryID, 
					m_condition, 
					subcondition,
					attributeIDs);

				// add to list.
				for (int ii = 0; ii < itemUrls.Length; ii++)
				{
					ListViewItem item = new ListViewItem(m_attributes[ii].Name);

					item.SubItems.Add(itemUrls[ii].ItemName);
					item.SubItems.Add(itemUrls[ii].Url.ToString());
					item.Tag = itemUrls[ii];

					ItemUrlsLV.Items.Add(item);					
				}

				// adjust column widths.
				AdjustColumns();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}

			// show dialog.
			ShowDialog();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(string name)
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = name;
			ItemUrlsLV.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < ItemUrlsLV.Columns.Count; ii++)
			{
				ItemUrlsLV.Columns[ii].Width = -2;
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
							m_categoryID = categories[ii].ID;
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
	}
}
