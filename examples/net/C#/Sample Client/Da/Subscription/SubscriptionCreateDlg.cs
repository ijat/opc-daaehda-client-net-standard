//============================================================================
// TITLE: SubscriptionCreateDlg.cs
//
// CONTENTS:
// 
// A dialog used to create a new subscription.
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
using System.ComponentModel;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;
using OpcClientSdk.Da;

namespace Client
{
	/// <summary>
	/// A dialog used to create a new subscription.
	/// </summary>
	public class SubscriptionCreateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button BackBTN;
		private System.Windows.Forms.Button NextBTN;
		private System.Windows.Forms.Button DoneBTN;
		private System.Windows.Forms.Panel LeftPN;
		private Client.BrowseTreeCtrl BrowseCTRL;
		private Client.SubscriptionEditCtrl SubscriptionCTRL;
		private System.Windows.Forms.Panel RightPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Splitter SplitterV;
		private System.Windows.Forms.Button OptionsBTN;
		private Client.ResultListViewCtrl ResultsCTRL;
		private Client.ItemListEditCtrl ItemsCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SubscriptionCreateDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			BrowseCTRL.ItemPicked += new ItemPicked_EventHandler(OnItemPicked);
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
			this.ItemsCTRL = new Client.ItemListEditCtrl();
			this.ResultsCTRL = new Client.ResultListViewCtrl();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.SubscriptionCTRL = new Client.SubscriptionEditCtrl();
			this.BrowseCTRL = new Client.BrowseTreeCtrl();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OptionsBTN = new System.Windows.Forms.Button();
			this.BackBTN = new System.Windows.Forms.Button();
			this.NextBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.DoneBTN = new System.Windows.Forms.Button();
			this.SplitterV = new System.Windows.Forms.Splitter();
			this.RightPN.SuspendLayout();
			this.LeftPN.SuspendLayout();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.ItemsCTRL);
			this.RightPN.Controls.Add(this.ResultsCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(253, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(539, 272);
			this.RightPN.TabIndex = 6;
			// 
			// ItemsCTRL
			// 
			this.ItemsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemsCTRL.Location = new System.Drawing.Point(0, 4);
			this.ItemsCTRL.Name = "ItemsCTRL";
			this.ItemsCTRL.Size = new System.Drawing.Size(535, 268);
			this.ItemsCTRL.TabIndex = 1;
			// 
			// ResultsCTRL
			// 
			this.ResultsCTRL.AllowDrop = true;
			this.ResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsCTRL.Location = new System.Drawing.Point(0, 4);
			this.ResultsCTRL.Name = "ResultsCTRL";
			this.ResultsCTRL.Size = new System.Drawing.Size(535, 268);
			this.ResultsCTRL.TabIndex = 0;
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.SubscriptionCTRL);
			this.LeftPN.Controls.Add(this.BrowseCTRL);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(250, 272);
			this.LeftPN.TabIndex = 11;
			// 
			// SubscriptionCTRL
			// 
			this.SubscriptionCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SubscriptionCTRL.Location = new System.Drawing.Point(4, 4);
			this.SubscriptionCTRL.Name = "SubscriptionCTRL";
			this.SubscriptionCTRL.Size = new System.Drawing.Size(246, 268);
			this.SubscriptionCTRL.TabIndex = 1;
			// 
			// BrowseCTRL
			// 
			this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseCTRL.Location = new System.Drawing.Point(4, 4);
			this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(246, 268);
			this.BrowseCTRL.TabIndex = 0;
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OptionsBTN);
			this.ButtonsPN.Controls.Add(this.BackBTN);
			this.ButtonsPN.Controls.Add(this.NextBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.DoneBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 272);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(792, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// OptionsBTN
			// 
			this.OptionsBTN.Location = new System.Drawing.Point(5, 8);
			this.OptionsBTN.Name = "OptionsBTN";
			this.OptionsBTN.TabIndex = 8;
			this.OptionsBTN.Text = "Options...";
			this.OptionsBTN.Click += new System.EventHandler(this.OptionsBTN_Click);
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
			this.CancelBTN.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// DoneBTN
			// 
			this.DoneBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.DoneBTN.Location = new System.Drawing.Point(712, 8);
			this.DoneBTN.Name = "DoneBTN";
			this.DoneBTN.TabIndex = 0;
			this.DoneBTN.Text = "Done";
			this.DoneBTN.Click += new System.EventHandler(this.DoneBTN_Click);
			// 
			// SplitterV
			// 
			this.SplitterV.Location = new System.Drawing.Point(250, 0);
			this.SplitterV.Name = "SplitterV";
			this.SplitterV.Size = new System.Drawing.Size(3, 272);
			this.SplitterV.TabIndex = 12;
			this.SplitterV.TabStop = false;
			// 
			// SubscriptionCreateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 308);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.SplitterV);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "SubscriptionCreateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Subscription";
			this.RightPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The server which processes the subscription.
		/// </summary>
		private TsCDaServer m_server = null;

		/// <summary>
		/// The subscription being created.
		/// </summary>
		private TsCDaSubscription m_subscription = null;

		/// <summary>
		/// The items being added.
		/// </summary>
		private TsCDaItemResult[] m_items = null;

		/// <summary>
		/// Prompts a user to create a new subscription with a modal dialog. 
		/// </summary>
		public TsCDaSubscription ShowDialog(TsCDaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server       = server;
			m_subscription = null;
			m_items        = null;

			BackBTN.Enabled          = false;
			NextBTN.Enabled          = true;
			CancelBTN.Visible        = true;
			DoneBTN.Visible          = false;
			OptionsBTN.Visible       = false;
			SubscriptionCTRL.Visible = true;
			BrowseCTRL.Visible       = false;
			ItemsCTRL.Visible        = true;
			ResultsCTRL.Visible      = false;

			SubscriptionCTRL.Server = m_server;
			SubscriptionCTRL.Set(null);
			BrowseCTRL.ShowSingleServer(m_server, null);
			ItemsCTRL.Initialize((TsCDaItem)null);

			ShowDialog();

			// ensure server connection in the browse control are closed.
			BrowseCTRL.Clear();

			return m_subscription;
		}

		/// <summary>
		/// Creates a subscription with the specified parameters.
		/// </summary>
		private void DoCreate()
		{
			try
			{
				// assign a globally unique handle to the subscription.
				TsCDaSubscriptionState state = (TsCDaSubscriptionState)SubscriptionCTRL.Get();

				state.ClientHandle = Guid.NewGuid().ToString();

				// create the subscription.
				m_subscription = (TsCDaSubscription)m_server.CreateSubscription(state);

				// move to add items panel.
				BackBTN.Enabled          = true;
				NextBTN.Enabled          = true;
				CancelBTN.Visible        = false;
				DoneBTN.Visible          = true;
				OptionsBTN.Visible       = true;
				SubscriptionCTRL.Visible = false;
				BrowseCTRL.Visible       = true;
				ItemsCTRL.Visible        = true;
				ResultsCTRL.Visible      = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Removes a previously created subscription.
		/// </summary>
		private void UndoCreate()
		{
			try
			{
				m_server.CancelSubscription(m_subscription);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				if (m_subscription != null) m_subscription.Dispose();
				m_subscription = null;
			}

			// move to edit subscription panel.
			BackBTN.Enabled          = false;
			NextBTN.Enabled          = true;
			CancelBTN.Visible        = true;
			DoneBTN.Visible          = false;
			OptionsBTN.Visible       = false;
			SubscriptionCTRL.Visible = true;
			BrowseCTRL.Visible       = false;
			ItemsCTRL.Visible        = true;
			ResultsCTRL.Visible      = false;
		}

		/// <summary>
		/// Adds a set of items to a subscription.
		/// </summary>
		private void DoAddItems()
		{
			try
			{
				// assign globally unique client handle.
				TsCDaItem[] items = ItemsCTRL.GetItems();

				foreach (TsCDaItem item in items)
				{
					item.ClientHandle = Guid.NewGuid().ToString();
				}

				// add items to subscription.
				m_items = m_subscription.AddItems(items);

				// move to add items panel.
				BackBTN.Enabled          = true;
				NextBTN.Enabled          = false;
				CancelBTN.Visible        = false;
				DoneBTN.Visible          = true;
				OptionsBTN.Visible       = false;
				SubscriptionCTRL.Visible = true;
				BrowseCTRL.Visible       = false;
				ItemsCTRL.Visible        = false;
				ResultsCTRL.Visible      = true;

				// update controls with actual values.
				SubscriptionCTRL.Set(m_subscription.State);
				ResultsCTRL.Initialize(m_server, null, m_items);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Removes a previously added items from a subscription.
		/// </summary>
		private void UndoAddItems()
		{
			try
			{
				m_subscription.RemoveItems(m_items);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				m_items = null;
			}

			// move to add items panel.
			BackBTN.Enabled          = true;
			NextBTN.Enabled          = true;
			CancelBTN.Visible        = false;
			DoneBTN.Visible          = true;
			OptionsBTN.Visible       = true;
			SubscriptionCTRL.Visible = false;
			BrowseCTRL.Visible       = true;
			ItemsCTRL.Visible        = true;
			ResultsCTRL.Visible      = false;
		}

		/// <summary>
		/// Called when a server is picked in the browse control.
		/// </summary>
		private void OnItemPicked(OpcItem itemID)
		{
			ItemsCTRL.AddItem(new TsCDaItem(itemID));
		}

		/// <summary>
		/// Called when the back button is clicked.
		/// </summary>
		private void BackBTN_Click(object sender, System.EventArgs e)
		{
			if (m_items != null)        { UndoAddItems(); return; }
			if (m_subscription != null) { UndoCreate();   return; }
		}

		/// <summary>
		/// Called when the next button is clicked.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			if (m_subscription == null) { DoCreate();   return; }
			if (m_items == null)        { DoAddItems(); return; }
		}

		/// <summary>
		/// Called when the close button is clicked.
		/// </summary>
		private void DoneBTN_Click(object sender, System.EventArgs e)
		{
			if (sender == CancelBTN)
			{
				try   { m_server.CancelSubscription(m_subscription); }
				catch {}
				m_subscription = null;
			}

			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Updates the result filters used for the request.
		/// </summary>
		private void OptionsBTN_Click(object sender, System.EventArgs e)
		{
			new OptionsEditDlg().ShowDialog(m_subscription);
		}
	}
}
