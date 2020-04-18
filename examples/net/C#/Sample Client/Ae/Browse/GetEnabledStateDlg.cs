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
	public class GetEnabledStateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Panel LeftPN;
		private System.Windows.Forms.ListView ResultsLV;
		private System.Windows.Forms.Button RefreshBTN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GetEnabledStateDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			AddHeader(ResultsLV, "Name", false);
			AddHeader(ResultsLV, "Enabled", true);
			AddHeader(ResultsLV, "Effectively Enabled", true);
			AddHeader(ResultsLV, "Result", false);
			
			AdjustColumns(ResultsLV);

			ResultsLV.SmallImageList = Resources.Instance.ImageList;
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
			this.ResultsLV = new System.Windows.Forms.ListView();
			this.ButtonsPN.SuspendLayout();
			this.LeftPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.RefreshBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 234);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(392, 36);
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
			this.CancelBTN.Location = new System.Drawing.Point(312, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Close";
			this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.ResultsLV);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Right = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(392, 234);
			this.LeftPN.TabIndex = 2;
			// 
			// ResultsLV
			// 
			this.ResultsLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsLV.FullRowSelect = true;
			this.ResultsLV.Location = new System.Drawing.Point(4, 4);
			this.ResultsLV.Name = "ResultsLV";
			this.ResultsLV.Size = new System.Drawing.Size(384, 230);
			this.ResultsLV.TabIndex = 0;
			this.ResultsLV.View = System.Windows.Forms.View.Details;
			// 
			// GetEnabledStateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(392, 270);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "GetEnabledStateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enable States";
			this.ButtonsPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		TsCAeServer m_server = null;
		ArrayList m_areas = new ArrayList();
		ArrayList m_sources = new ArrayList();
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the enabled states for the specified browse elements.
		/// </summary>
		public void ShowDialog(TsCAeServer server, OpcClientSdk.Ae.TsCAeBrowseElement[] elements)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			// sort elements in areas and sources.
			m_areas.Clear();
			m_sources.Clear();

			for (int ii = 0; ii < elements.Length; ii++)
			{
				if (elements[ii].NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)
				{
					if (!m_areas.Contains(elements[ii].QualifiedName))
					{
						m_areas.Add(elements[ii].QualifiedName);
					}
				}
				else
				{
					if (!m_sources.Contains(elements[ii].QualifiedName))
					{
						m_sources.Add(elements[ii].QualifiedName);
					}
				}
			}
			
			// get the current enabled state.
			GetEnabledState();

			// show the dialog.
			Show();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Fetches the enabled state for the areas and sources.
		/// </summary>
		private void GetEnabledState()
		{
			ResultsLV.Items.Clear();

			// get state for areas
			try
			{
				TsCAeEnabledStateResult[] results = m_server.GetEnableStateByArea((string[])m_areas.ToArray(typeof(string)));

				for (int ii = 0; ii < results.Length; ii++)
				{
					ListViewItem item = new ListViewItem((string)m_areas[ii], Resources.IMAGE_CLOSED_BLUE_FOLDER);

					item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(results[ii].Enabled));
					item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(results[ii].EffectivelyEnabled));
					item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(results[ii].Result));

					item.Tag = results[ii];

					ResultsLV.Items.Add(item);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetEnableStateByArea");
			}

			// get state for sources
			try
			{
				TsCAeEnabledStateResult[] results = m_server.GetEnableStateBySource((string[])m_sources.ToArray(typeof(string)));

				for (int ii = 0; ii < results.Length; ii++)
				{
					ListViewItem item = new ListViewItem((string)m_sources[ii], Resources.IMAGE_GREEN_SCROLL);

					item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(results[ii].Enabled));
					item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(results[ii].EffectivelyEnabled));
					item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(results[ii].Result));

					item.Tag = results[ii];

					ResultsLV.Items.Add(item);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "GetEnableStateBySource");
			}			

			// adjust columns.
			AdjustColumns(ResultsLV);
		}

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(ListView listview, string name, bool center)
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = name;

			if (center)
			{
				header.TextAlign = HorizontalAlignment.Center;
			}

			listview.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns(ListView listview)
		{
			// adjust column widths.
			for (int ii = 0; ii < listview.Columns.Count; ii++)
			{
				listview.Columns[ii].Width = -2;
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
				GetEnabledState();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

	}
}
