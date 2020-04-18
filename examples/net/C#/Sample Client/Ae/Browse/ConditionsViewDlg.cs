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
	public class ConditionsViewDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.TreeView ConditionsTV;
		private System.Windows.Forms.Panel LeftPN;
		private System.Windows.Forms.Splitter Splitter01;
		private System.Windows.Forms.Panel RightPN;
		private OpcClientSdk.Ae.SampleClient.ConditionStateCtrl ConditionCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConditionsViewDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			ConditionsTV.ImageList = Resources.Instance.ImageList;
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
			this.ConditionsTV = new System.Windows.Forms.TreeView();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.Splitter01 = new System.Windows.Forms.Splitter();
			this.RightPN = new System.Windows.Forms.Panel();
			this.ConditionCTRL = new OpcClientSdk.Ae.SampleClient.ConditionStateCtrl();
			this.ButtonsPN.SuspendLayout();
			this.LeftPN.SuspendLayout();
			this.RightPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 458);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(712, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(319, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Close";
			// 
			// ConditionsTV
			// 
			this.ConditionsTV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConditionsTV.ImageIndex = -1;
			this.ConditionsTV.Location = new System.Drawing.Point(4, 4);
			this.ConditionsTV.Name = "ConditionsTV";
			this.ConditionsTV.SelectedImageIndex = -1;
			this.ConditionsTV.ShowRootLines = false;
			this.ConditionsTV.Size = new System.Drawing.Size(192, 454);
			this.ConditionsTV.TabIndex = 1;
			this.ConditionsTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConditionsTV_AfterSelect);
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.ConditionsTV);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Right = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(200, 458);
			this.LeftPN.TabIndex = 2;
			// 
			// Splitter01
			// 
			this.Splitter01.Location = new System.Drawing.Point(200, 0);
			this.Splitter01.Name = "Splitter01";
			this.Splitter01.Size = new System.Drawing.Size(3, 458);
			this.Splitter01.TabIndex = 3;
			this.Splitter01.TabStop = false;
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.ConditionCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(203, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(509, 458);
			this.RightPN.TabIndex = 4;
			// 
			// ConditionCTRL
			// 
			this.ConditionCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConditionCTRL.Location = new System.Drawing.Point(0, 4);
			this.ConditionCTRL.Name = "ConditionCTRL";
			this.ConditionCTRL.Size = new System.Drawing.Size(505, 454);
			this.ConditionCTRL.TabIndex = 0;
			// 
			// ConditionsViewDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(712, 494);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.Splitter01);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(0, 180);
			this.Name = "ConditionsViewDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Event Conditions";
			this.ButtonsPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.RightPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the event conditions supported by the server.
		/// </summary>
		public void ShowDialog(TsCAeServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			// clear tree view.
			ConditionsTV.Nodes.Clear();	

			// fetch and populate conditions and sub-conditions.
			try
			{
				TreeNode root = new TreeNode("Categories");

				root.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
				root.SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER;

				ConditionsTV.Nodes.Add(root);
				root.Expand();

				// add categories.
				OpcClientSdk.Ae.TsCAeCategory[] categories = server.QueryEventCategories((int)TsCAeEventType.Condition);
			
				foreach (OpcClientSdk.Ae.TsCAeCategory category in categories)
				{
					TreeNode node = new TreeNode(category.Name);

					node.ImageIndex         = Resources.IMAGE_LIST_BOX;
					node.SelectedImageIndex = Resources.IMAGE_LIST_BOX;
					node.Tag                = category;

					// add conditions.
					TreeNode folder = new TreeNode("Conditions");

					folder.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
					folder.SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER;

					node.Nodes.Add(folder);

					FetchConditions(folder, server, category.ID);

					// add attributes.
					folder = new TreeNode("Attributes");

					folder.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
					folder.SelectedImageIndex = Resources.IMAGE_OPEN_YELLOW_FOLDER;

					node.Nodes.Add(folder);

					FetchAttributes(folder, server, category.ID);

					// add category to tree.
					root.Nodes.Add(node);
				}
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
		/// Populates the tree view with the conditions.
		/// </summary>
		private void FetchConditions(TreeNode parent, TsCAeServer server, int categoryID)
		{
			string[] conditions = server.QueryConditionNames(categoryID);
            
			for (int ii = 0; ii < conditions.Length; ii++)
			{
				TreeNode node = new TreeNode(conditions[ii]);
				
				node.ImageIndex         = Resources.IMAGE_YELLOW_SCROLL;
				node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;
				node.Tag                = conditions[ii];

				// add sub-conditions.
				FetchSubConditions(node, server, conditions[ii]);

				parent.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree view with the attributes.
		/// </summary>
		private void FetchAttributes(TreeNode parent, TsCAeServer server, int categoryID)
		{
			OpcClientSdk.Ae.TsCAeAttribute[] attributes = server.QueryEventAttributes(categoryID);
            
			foreach (OpcClientSdk.Ae.TsCAeAttribute attribute in attributes)
			{
				string label = String.Format(
					"[{0}] {1} ({2})", 
					attribute.ID, 
					attribute.Name, 
					OpcClientSdk.OpcConvert.ToString(attribute.DataType));

				TreeNode node = new TreeNode(label);
				
				node.ImageIndex         = Resources.IMAGE_EXPLODING_BOX;
				node.SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX;
				node.Tag                = attribute;

				parent.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree view with the sub-conditions.
		/// </summary>
		private void FetchSubConditions(TreeNode parent, TsCAeServer server, string conditionName)
		{
			string[] subconditions = server.QuerySubConditionNames(conditionName);
            
			for (int ii = 0; ii < subconditions.Length; ii++)
			{
				TreeNode node = new TreeNode(subconditions[ii]);

				node.ImageIndex         = Resources.IMAGE_YELLOW_SCROLL;
				node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;
				node.Tag                = subconditions[ii];

				parent.Nodes.Add(node);
			}
		}
		#endregion

		#region Event Handlers
		private void ConditionsTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion
	}
}
