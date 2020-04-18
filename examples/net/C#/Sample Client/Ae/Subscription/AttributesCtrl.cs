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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Ae.SampleClient
{
	/// <summary>
	/// A control used to select a valid value for any bit mask expressed as an enumeration.
	/// </summary>
	public class AttributesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView AttributesTV;
		private System.Windows.Forms.GroupBox AttributesGB;
		private System.ComponentModel.IContainer components = null;

		public AttributesCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			AttributesTV.ImageList = Resources.Instance.ImageList;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
		
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AttributesTV = new System.Windows.Forms.TreeView();
			this.AttributesGB = new System.Windows.Forms.GroupBox();
			this.AttributesGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// AttributesTV
			// 
			this.AttributesTV.CheckBoxes = true;
			this.AttributesTV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesTV.ImageIndex = -1;
			this.AttributesTV.Location = new System.Drawing.Point(3, 16);
			this.AttributesTV.Name = "AttributesTV";
			this.AttributesTV.SelectedImageIndex = -1;
			this.AttributesTV.Size = new System.Drawing.Size(394, 285);
			this.AttributesTV.TabIndex = 0;
			this.AttributesTV.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.AttributesTV_AfterCheck);
			this.AttributesTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.AttributesTV_BeforeExpand);
			// 
			// AttributesGB
			// 
			this.AttributesGB.Controls.Add(this.AttributesTV);
			this.AttributesGB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesGB.Location = new System.Drawing.Point(0, 0);
			this.AttributesGB.Name = "AttributesGB";
			this.AttributesGB.Size = new System.Drawing.Size(400, 304);
			this.AttributesGB.TabIndex = 1;
			this.AttributesGB.TabStop = false;
			this.AttributesGB.Text = "Attributes";
			// 
			// AttributesCtrl
			// 
			this.Controls.Add(this.AttributesGB);
			this.Name = "AttributesCtrl";
			this.Size = new System.Drawing.Size(400, 304);
			this.AttributesGB.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region Private Members
		private TsCAeServer m_server = null;
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Displays the available attributes in a heirarchy. 
		/// </summary>
		public void ShowAttributes(TsCAeServer server)
		{
			m_server = server;

			AttributesTV.Nodes.Clear();

			// nothing more to do if no server provided.
			if (m_server == null)
			{
				return;
			}

			// display all event categories
			ShowEventCategories(AttributesTV.Nodes, TsCAeEventType.Simple);
			ShowEventCategories(AttributesTV.Nodes, TsCAeEventType.Tracking);
			ShowEventCategories(AttributesTV.Nodes, TsCAeEventType.Condition);
		}

		/// <summary>
		/// Returns currently selected attributes
		/// </summary>
		public OpcClientSdk.Ae.TsCAeAttributeDictionary GetSelectedAttributes()
		{
			OpcClientSdk.Ae.TsCAeAttributeDictionary attributes = new OpcClientSdk.Ae.TsCAeAttributeDictionary();

			foreach (TreeNode child in AttributesTV.Nodes)
			{
				GetSelectedCategories(child, attributes);
			}

			return attributes;
		}

		/// <summary>
		/// Sets the currently selected attributes.
		/// </summary>
		public void SetSelectedAttributes(OpcClientSdk.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in AttributesTV.Nodes)
			{
				SetSelectedCategories(child, attributes);
			}
		}

		/// <summary>
		/// Checks or unchecks all attributes for the specified category id.
		/// </summary>
		public void SelectCategory(int categoryID, bool picked)
		{
			foreach (TreeNode child in AttributesTV.Nodes)
			{
				SelectCategory(child, categoryID, picked);
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Checks or unchecks all attributes for the specified category id.
		/// </summary>
		public void SelectCategory(TreeNode parent, int categoryID, bool picked)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(OpcClientSdk.Ae.TsCAeCategory).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				// find the matching category id.
				OpcClientSdk.Ae.TsCAeCategory category = (OpcClientSdk.Ae.TsCAeCategory)child.Tag;

				if (categoryID == category.ID)
				{
					// ensure node is visible if state changes.
					if (child.Checked != picked)
					{				
						// fetch attributes if a dummy mode exists.
						if (child.Nodes.Count == 1 && child.Nodes[0].Text.Length == 0)
						{
							child.Nodes.Clear();
							ShowEventAttributes(child.Nodes, category);
						}

						child.EnsureVisible();
					}

					if (picked)
					{
						child.Checked = true;
					}
					else
					{
						child.Checked = false;
					}
				}			
			}
		}

		/// <summary>
		/// Adds categories with selected attributes to dictionary.
		/// </summary>
		private void GetSelectedCategories(TreeNode parent, OpcClientSdk.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(OpcClientSdk.Ae.TsCAeCategory).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				GetSelectedAttributes(child, (OpcClientSdk.Ae.TsCAeCategory)child.Tag, attributes);
			}
        }

		/// <summary>
		/// Adds selected attributes to the dictionary.
		/// </summary>
		private void GetSelectedAttributes(TreeNode parent, OpcClientSdk.Ae.TsCAeCategory category, OpcClientSdk.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(OpcClientSdk.Ae.TsCAeAttribute).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				if (child.Checked)
				{
					OpcClientSdk.Ae.TsCAeAttributeCollection collection = attributes[category.ID];

					if (collection == null)
					{
						attributes.Add(category.ID, null);
						collection = attributes[category.ID];
					}
				
					collection.Add(((OpcClientSdk.Ae.TsCAeAttribute)child.Tag).ID);
				}
			}
		}

		/// <summary>
		/// Updates categories with selected attributes to dictionary.
		/// </summary>
		private void SetSelectedCategories(TreeNode parent, OpcClientSdk.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(OpcClientSdk.Ae.TsCAeCategory).IsInstanceOfType(child.Tag))
				{
					continue;
				}

				// check if category exists.
				OpcClientSdk.Ae.TsCAeCategory category = (OpcClientSdk.Ae.TsCAeCategory)child.Tag;

				if (!attributes.Contains(category.ID))
				{
					child.Checked = false;
					continue;
				}

				// check if attributes need to be fetched.
				if (child.Nodes.Count == 1 && child.Nodes[0].Text.Length == 0)
				{
					child.Nodes.Clear();
					ShowEventAttributes(child.Nodes, category);
				}

				// update individual attributes.
				SetSelectedAttributes(child, category, attributes);
			}
		}

		/// <summary>
		/// Updates the selected attributes to the dictionary.
		/// </summary>
		private void SetSelectedAttributes(TreeNode parent, OpcClientSdk.Ae.TsCAeCategory category, OpcClientSdk.Ae.TsCAeAttributeDictionary attributes)
		{
			foreach (TreeNode child in parent.Nodes)
			{
				if (!typeof(TsCAeAttribute).IsInstanceOfType(child.Tag))
				{
					continue;
				}
				
				OpcClientSdk.Ae.TsCAeAttribute attribute = (OpcClientSdk.Ae.TsCAeAttribute)child.Tag;

				if (attributes[category.ID].Contains(attribute.ID))
				{
					child.Checked = true;
				}
				else
				{
					child.Checked = false;
				}
			}
		}

		/// <summary>
		/// Populates the tree with the event categories supported by the server.
		/// </summary>
		private void ShowEventCategories(TreeNodeCollection nodes, TsCAeEventType eventType)
		{
			OpcClientSdk.Ae.TsCAeCategory[] categories = null;

			// fetch categories.
			try
			{
				categories = m_server.QueryEventCategories((int)eventType);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}

			// check for trivial case.
			if (categories.Length == 0)
			{
				return;
			}

			// create event type node.
			TreeNode root = new TreeNode(eventType.ToString());

			root.ImageIndex         = Resources.IMAGE_OPEN_YELLOW_FOLDER;
			root.SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
			root.Tag                = eventType;

			nodes.Add(root);

			// add categories to tree.
			foreach (OpcClientSdk.Ae.TsCAeCategory category in categories)
			{
				// create node.
				TreeNode node = new TreeNode(category.Name);

				node.ImageIndex         = Resources.IMAGE_ENVELOPE;
				node.SelectedImageIndex = Resources.IMAGE_ENVELOPE;
				node.Tag                = category;

				// add dummy child to ensure '+' sign is visible.
				node.Nodes.Add(new TreeNode());

				// add to tree.
				root.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the event attributes supported by the category.
		/// </summary>
		private void ShowEventAttributes(TreeNodeCollection nodes, OpcClientSdk.Ae.TsCAeCategory category)
		{
			OpcClientSdk.Ae.TsCAeAttribute[] attributes = null;

			// fetch attributes.
			try
			{
				attributes = m_server.QueryEventAttributes(category.ID);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}

			// add attributes to tree.
			foreach (OpcClientSdk.Ae.TsCAeAttribute attribute in attributes)
			{
				// create node.
				TreeNode node = new TreeNode(attribute.Name);

				node.ImageIndex         = Resources.IMAGE_EXPLODING_BOX;
				node.SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX;
				node.Tag                = attribute;

				// add to tree.
				nodes.Add(node);
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Fetches the child nodes before expanding a node.
		/// </summary>
		private void AttributesTV_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			try
			{
				// check if a dummy node is present.
				if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text.Length != 0)
				{
					return;
				}

				// check for category.
				if (typeof(OpcClientSdk.Ae.TsCAeCategory).IsInstanceOfType(e.Node.Tag))
				{
					e.Node.Nodes.Clear();
					ShowEventAttributes(e.Node.Nodes, (OpcClientSdk.Ae.TsCAeCategory)e.Node.Tag);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Changes the check state of all children to match the parent that was checked.
		/// </summary>
		private void AttributesTV_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				// check for event type.
				if (typeof(TsCAeEventType).IsInstanceOfType(e.Node.Tag))
				{
					// check all attributes.
					foreach (TreeNode child in e.Node.Nodes)
					{
						child.Checked = e.Node.Checked;
					}

					// ensure changes are visible.
					e.Node.ExpandAll();
				}
			
					// check for category.
				else if (typeof(OpcClientSdk.Ae.TsCAeCategory).IsInstanceOfType(e.Node.Tag))
				{					
					// fetch the attributes if necessary.
					if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text.Length != 0)
					{
						e.Node.Nodes.Clear();
						ShowEventAttributes(e.Node.Nodes, (OpcClientSdk.Ae.TsCAeCategory)e.Node.Tag);
					}

					// check if any attributes are already checked.
					bool checkall = true;

					foreach (TreeNode child in e.Node.Nodes)
					{
						if (child.Checked)
						{
							checkall = false;
						}
					}

					// check all attributes.
					if (checkall || !e.Node.Checked)
					{
						foreach (TreeNode child in e.Node.Nodes)
						{
							child.Checked = e.Node.Checked;
						}
					}

					// ensure changes are visible.
					e.Node.ExpandAll();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion
	}
}
  