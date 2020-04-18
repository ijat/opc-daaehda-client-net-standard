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
	/// A dialog used to create a new subscription.
	/// </summary>
	public class SubscriptionEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button BackBTN;
		private System.Windows.Forms.Button NextBTN;
		private System.Windows.Forms.Button DoneBTN;
		private System.Windows.Forms.Panel LeftPN;
		private System.Windows.Forms.Panel RightPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Splitter SplitterV;
		private OpcClientSdk.Ae.SampleClient.AttributesCtrl AttributesCTRL;
		private OpcClientSdk.Ae.SampleClient.SubscriptionStateEditCtrl StateCTRL;
		private OpcClientSdk.Ae.SampleClient.SubscriptionFiltersEditCtrl FiltersCTRL;
		private System.Windows.Forms.GroupBox StateGB;
		private System.Windows.Forms.GroupBox FiltersGB;
		private OpcClientSdk.Ae.SampleClient.CategoriesCtrl CategoriesCTRL;
		private OpcClientSdk.Ae.SampleClient.BrowseCtrl BrowseCTRL;
		private System.Windows.Forms.Panel StateFiltersPN;
		private OpcClientSdk.Ae.SampleClient.AreaSourceListCtrl AreaSourcesListCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SubscriptionEditDlg()
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
			this.AreaSourcesListCTRL = new OpcClientSdk.Ae.SampleClient.AreaSourceListCtrl();
			this.AttributesCTRL = new OpcClientSdk.Ae.SampleClient.AttributesCtrl();
			this.StateFiltersPN = new System.Windows.Forms.Panel();
			this.CategoriesCTRL = new OpcClientSdk.Ae.SampleClient.CategoriesCtrl();
			this.FiltersGB = new System.Windows.Forms.GroupBox();
			this.FiltersCTRL = new OpcClientSdk.Ae.SampleClient.SubscriptionFiltersEditCtrl();
			this.StateGB = new System.Windows.Forms.GroupBox();
			this.StateCTRL = new OpcClientSdk.Ae.SampleClient.SubscriptionStateEditCtrl();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.BrowseCTRL = new OpcClientSdk.Ae.SampleClient.BrowseCtrl();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.BackBTN = new System.Windows.Forms.Button();
			this.NextBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.DoneBTN = new System.Windows.Forms.Button();
			this.SplitterV = new System.Windows.Forms.Splitter();
			this.RightPN.SuspendLayout();
			this.StateFiltersPN.SuspendLayout();
			this.FiltersGB.SuspendLayout();
			this.StateGB.SuspendLayout();
			this.LeftPN.SuspendLayout();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.AreaSourcesListCTRL);
			this.RightPN.Controls.Add(this.AttributesCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(283, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(509, 490);
			this.RightPN.TabIndex = 6;
			// 
			// AreaSourcesListCTRL
			// 
			this.AreaSourcesListCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AreaSourcesListCTRL.Location = new System.Drawing.Point(0, 4);
			this.AreaSourcesListCTRL.Name = "AreaSourcesListCTRL";
			this.AreaSourcesListCTRL.Size = new System.Drawing.Size(505, 486);
			this.AreaSourcesListCTRL.TabIndex = 1;
			// 
			// AttributesCTRL
			// 
			this.AttributesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesCTRL.Location = new System.Drawing.Point(0, 4);
			this.AttributesCTRL.Name = "AttributesCTRL";
			this.AttributesCTRL.Size = new System.Drawing.Size(505, 486);
			this.AttributesCTRL.TabIndex = 0;
			// 
			// StateFiltersPN
			// 
			this.StateFiltersPN.Controls.Add(this.CategoriesCTRL);
			this.StateFiltersPN.Controls.Add(this.FiltersGB);
			this.StateFiltersPN.Controls.Add(this.StateGB);
			this.StateFiltersPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StateFiltersPN.Location = new System.Drawing.Point(4, 4);
			this.StateFiltersPN.Name = "StateFiltersPN";
			this.StateFiltersPN.Size = new System.Drawing.Size(272, 486);
			this.StateFiltersPN.TabIndex = 1;
			// 
			// CategoriesCTRL
			// 
			this.CategoriesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CategoriesCTRL.Location = new System.Drawing.Point(0, 284);
			this.CategoriesCTRL.Name = "CategoriesCTRL";
			this.CategoriesCTRL.Size = new System.Drawing.Size(272, 202);
			this.CategoriesCTRL.TabIndex = 1;
			this.CategoriesCTRL.CategoryChecked += new OpcClientSdk.Ae.SampleClient.CategoriesCtrl.CategoryCheckedEventHandler(this.CategoriesCTRL_CategorySelected);
			// 
			// FiltersGB
			// 
			this.FiltersGB.Controls.Add(this.FiltersCTRL);
			this.FiltersGB.Dock = System.Windows.Forms.DockStyle.Top;
			this.FiltersGB.Location = new System.Drawing.Point(0, 140);
			this.FiltersGB.Name = "FiltersGB";
			this.FiltersGB.Size = new System.Drawing.Size(272, 144);
			this.FiltersGB.TabIndex = 0;
			this.FiltersGB.TabStop = false;
			this.FiltersGB.Text = "Filtering Parameters";
			// 
			// FiltersCTRL
			// 
			this.FiltersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FiltersCTRL.Location = new System.Drawing.Point(3, 16);
			this.FiltersCTRL.Name = "FiltersCTRL";
			this.FiltersCTRL.Size = new System.Drawing.Size(266, 125);
			this.FiltersCTRL.TabIndex = 1;
			// 
			// StateGB
			// 
			this.StateGB.Controls.Add(this.StateCTRL);
			this.StateGB.Dock = System.Windows.Forms.DockStyle.Top;
			this.StateGB.Location = new System.Drawing.Point(0, 0);
			this.StateGB.Name = "StateGB";
			this.StateGB.Size = new System.Drawing.Size(272, 140);
			this.StateGB.TabIndex = 0;
			this.StateGB.TabStop = false;
			this.StateGB.Text = "State Parameters";
			// 
			// StateCTRL
			// 
			this.StateCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StateCTRL.Location = new System.Drawing.Point(3, 16);
			this.StateCTRL.Name = "StateCTRL";
			this.StateCTRL.Size = new System.Drawing.Size(266, 121);
			this.StateCTRL.TabIndex = 0;
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.StateFiltersPN);
			this.LeftPN.Controls.Add(this.BrowseCTRL);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Right = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(280, 490);
			this.LeftPN.TabIndex = 11;
			// 
			// BrowseCTRL
			// 
			this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseCTRL.Location = new System.Drawing.Point(4, 4);
			this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(272, 486);
			this.BrowseCTRL.TabIndex = 1;
			this.BrowseCTRL.NodeSelected += new OpcClientSdk.Ae.SampleClient.BrowseCtrl.NodeSelectedEventHandler(this.BrowseCTRL_NodeSelected);
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.BackBTN);
			this.ButtonsPN.Controls.Add(this.DoneBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.NextBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 490);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(792, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// BackBTN
			// 
			this.BackBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BackBTN.Location = new System.Drawing.Point(552, 8);
			this.BackBTN.Name = "BackBTN";
			this.BackBTN.TabIndex = 3;
			this.BackBTN.Text = "< Back";
			this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
			// 
			// NextBTN
			// 
			this.NextBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NextBTN.Location = new System.Drawing.Point(632, 8);
			this.NextBTN.Name = "NextBTN";
			this.NextBTN.TabIndex = 2;
			this.NextBTN.Text = "Next >";
			this.NextBTN.Click += new System.EventHandler(this.NextBTN_Click);
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(712, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 4;
			this.CancelBTN.Text = "Cancel";
			// 
			// DoneBTN
			// 
			this.DoneBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DoneBTN.Location = new System.Drawing.Point(632, 8);
			this.DoneBTN.Name = "DoneBTN";
			this.DoneBTN.TabIndex = 0;
			this.DoneBTN.Text = "Done";
			this.DoneBTN.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// SplitterV
			// 
			this.SplitterV.Location = new System.Drawing.Point(280, 0);
			this.SplitterV.Name = "SplitterV";
			this.SplitterV.Size = new System.Drawing.Size(3, 490);
			this.SplitterV.TabIndex = 12;
			this.SplitterV.TabStop = false;
			// 
			// SubscriptionEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 526);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.SplitterV);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "SubscriptionEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Subscription";
			this.RightPN.ResumeLayout(false);
			this.StateFiltersPN.ResumeLayout(false);
			this.FiltersGB.ResumeLayout(false);
			this.StateGB.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private TsCAeServer m_server = null;
		private Ae.TsCAeSubscription m_subscription = null;		
		private Ae.TsCAeSubscriptionState m_state = new Ae.TsCAeSubscriptionState();
		private Ae.TsCAeSubscriptionFilters m_filters = new Ae.TsCAeSubscriptionFilters();
		private OpcClientSdk.Ae.TsCAeAttributeDictionary m_attributes = new OpcClientSdk.Ae.TsCAeAttributeDictionary();
		private string[] m_areas = null;
		private string[] m_sources = null;
		private int m_stage = 0;

		private static int m_count = 0;
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts a user to create a new subscription with a modal dialog. 
		/// </summary>
		public Ae.TsCAeSubscription ShowDialog(TsCAeServer server, Ae.TsCAeSubscription subscription)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server       = server;
			m_subscription = subscription;

			// go to the initial stage.
			m_stage = 0;
			ChangeStage(0);

			// initialize controls.
			StateCTRL.SetDefaults();
			FiltersCTRL.SetDefaults();
			CategoriesCTRL.ShowCategories(m_server);
			AttributesCTRL.ShowAttributes(m_server);
			BrowseCTRL.ShowAreas(m_server);

			if (m_subscription != null)
			{
				m_state      = m_subscription.GetState();
				m_filters    = m_subscription.GetFilters();
				m_attributes = m_subscription.GetAttributes();
				m_areas      = m_subscription.Areas.ToArray();
				m_sources    = m_subscription.Sources.ToArray();
			}
			else
			{
				m_state.Name = String.Format("Subscription{0,3:000}", ++m_count);
			}

			// set current values.
			StateCTRL.Set(m_state);
			FiltersCTRL.Set(m_filters);
			CategoriesCTRL.SetSelectedCategories(m_filters.Categories.ToArray());
			AttributesCTRL.SetSelectedAttributes(m_attributes);
			AreaSourcesListCTRL.AddAreas(m_areas);
			AreaSourcesListCTRL.AddSources(m_sources);

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return updated/created subscription.
			return m_subscription;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Toggles the states of the buttons and controls based on the stage.
		/// </summary>
		private void ChangeStage(int stage)
		{
			switch (stage)
			{
				case 0:
				{
					BackBTN.Enabled   = false;
					NextBTN.Enabled   = true;
					NextBTN.Visible   = true;
					CancelBTN.Visible = true;
					DoneBTN.Visible   = false;

					StateFiltersPN.Visible      = true;
					AttributesCTRL.Visible      = true;
					BrowseCTRL.Visible          = false;
					AreaSourcesListCTRL.Visible = false;
					break;
				}

				case 1:
				{
					BackBTN.Enabled   = true;
					NextBTN.Enabled   = false;
					NextBTN.Visible   = false;
					CancelBTN.Visible = true;
					DoneBTN.Visible   = true;

					StateFiltersPN.Visible      = false;
					AttributesCTRL.Visible      = false;
					BrowseCTRL.Visible          = true;
					AreaSourcesListCTRL.Visible = true;
					break;
				}
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Called when the back button is clicked.
		/// </summary>
		private void BackBTN_Click(object sender, System.EventArgs e)
		{
			ChangeStage(--m_stage);

			if (m_stage == 0)
			{
				StateCTRL.Set(m_state);
				FiltersCTRL.Set(m_filters);
				CategoriesCTRL.SetSelectedCategories(m_filters.Categories.ToArray());
				AttributesCTRL.SetSelectedAttributes(m_attributes);
			}
		}

		/// <summary>
		/// Called when the next button is clicked.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			if (m_stage == 0)
			{
				m_state   = (Ae.TsCAeSubscriptionState)StateCTRL.Get();
				m_filters = (Ae.TsCAeSubscriptionFilters)FiltersCTRL.Get();

				m_filters.Categories.Clear();
				m_filters.Categories.AddRange(CategoriesCTRL.GetSelectedCategories());
	
				m_attributes = AttributesCTRL.GetSelectedAttributes();
			}

			ChangeStage(++m_stage);
		}

		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_areas   = AreaSourcesListCTRL.GetAreas();
				m_sources = AreaSourcesListCTRL.GetSources();

				// don't activate until all the filters are applied.
				bool active = m_state.Active;
				bool update = m_subscription != null;

				// create new subscription.
				if (m_subscription == null)
				{
					m_state.Active       = false;
					m_state.ClientHandle = Guid.NewGuid().ToString();
					m_subscription = (Ae.TsCAeSubscription)m_server.CreateSubscription(m_state);
				}

				// update existing subscription.
				else
				{
					m_subscription.ModifyState(((int)TsCAeStateMask.All & ~(int)TsCAeStateMask.Active), m_state); 
				}

				// select filters.
				m_filters.Areas.Clear();
				m_filters.Areas.AddRange(m_areas);
				m_filters.Sources.Clear();
				m_filters.Sources.AddRange(m_sources);

				m_subscription.SetFilters(m_filters);

				// select attributes.
				IDictionaryEnumerator enumerator = m_attributes.GetEnumerator();

				while (enumerator.MoveNext())
				{
					int categoryID = (int)enumerator.Key;
					OpcClientSdk.Ae.TsCAeAttributeCollection attributeIDs = (OpcClientSdk.Ae.TsCAeAttributeCollection)enumerator.Value;

					m_subscription.SelectReturnedAttributes(categoryID, attributeIDs.ToArray());
				}

				// activate the subscription.
				if (active || update)
				{
					m_state.Active = active;
					m_subscription.ModifyState((int)TsCAeStateMask.Active, m_state); 
				}

				// close the dialog.
                DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception exception)
			{				
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Updates the attribute control after a category is selected.
		/// </summary>
		private void CategoriesCTRL_CategorySelected(int categoryID, bool picked)
		{
			AttributesCTRL.SelectCategory(categoryID, picked);
		}

		/// <summary>
		/// Sends notifications when a node is selected.
		/// </summary>
		private void BrowseCTRL_NodeSelected(OpcClientSdk.Ae.TsCAeBrowseElement element, bool picked)
		{
			if (picked)
			{
				if (element.NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)
				{
					AreaSourcesListCTRL.AddAreas(new string[] { element.QualifiedName });
				}
				else
				{
					AreaSourcesListCTRL.AddSources(new string[] { element.QualifiedName });
				}
			}
		}
		#endregion
	}
}
