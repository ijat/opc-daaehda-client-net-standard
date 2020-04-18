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
using OpcClientSdk.Ae;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Ae.SampleClient
{
	/// <summary>
	/// A control used to select a valid value for any bit mask expressed as an enumeration.
	/// </summary>
	public class BrowseCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView BrowseTV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem ApplyFiltersMI;
		private System.Windows.Forms.MenuItem SelectNodeMI;
		private System.Windows.Forms.MenuItem Separator01;
		private System.Windows.Forms.MenuItem Separator02;
		private System.Windows.Forms.MenuItem Separator03;
		private System.Windows.Forms.MenuItem GetEnabledStateMI;
		private System.Windows.Forms.MenuItem GetConditionStateMI;
		private System.Windows.Forms.MenuItem GetDAItemIDsMI;
		private System.Windows.Forms.MenuItem SetEnabledStateMI;
		private System.ComponentModel.IContainer components = null;

		public BrowseCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			BrowseTV.ImageList = Resources.Instance.ImageList;
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
			this.BrowseTV = new System.Windows.Forms.TreeView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.ApplyFiltersMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.SelectNodeMI = new System.Windows.Forms.MenuItem();
			this.Separator02 = new System.Windows.Forms.MenuItem();
			this.SetEnabledStateMI = new System.Windows.Forms.MenuItem();
			this.GetEnabledStateMI = new System.Windows.Forms.MenuItem();
			this.Separator03 = new System.Windows.Forms.MenuItem();
			this.GetConditionStateMI = new System.Windows.Forms.MenuItem();
			this.GetDAItemIDsMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// BrowseTV
			// 
			this.BrowseTV.ContextMenu = this.PopupMenu;
			this.BrowseTV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseTV.ImageIndex = -1;
			this.BrowseTV.Location = new System.Drawing.Point(0, 0);
			this.BrowseTV.Name = "BrowseTV";
			this.BrowseTV.SelectedImageIndex = -1;
			this.BrowseTV.Size = new System.Drawing.Size(400, 304);
			this.BrowseTV.TabIndex = 0;
			this.BrowseTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseTV_MouseDown);
			this.BrowseTV.DoubleClick += new System.EventHandler(this.BrowseTV_DoubleClick);
			this.BrowseTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrowseTV_AfterSelect);
			this.BrowseTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BrowseTV_BeforeExpand);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ApplyFiltersMI,
																					  this.Separator01,
																					  this.SelectNodeMI,
																					  this.Separator02,
																					  this.GetEnabledStateMI,
																					  this.SetEnabledStateMI,
																					  this.Separator03,
																					  this.GetConditionStateMI,
																					  this.GetDAItemIDsMI});
			// 
			// ApplyFiltersMI
			// 
			this.ApplyFiltersMI.Index = 0;
			this.ApplyFiltersMI.Text = "Apply Filters...";
			this.ApplyFiltersMI.Click += new System.EventHandler(this.ApplyFiltersMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 1;
			this.Separator01.Text = "-";
			// 
			// SelectNodeMI
			// 
			this.SelectNodeMI.Index = 2;
			this.SelectNodeMI.Text = "Select";
			this.SelectNodeMI.Click += new System.EventHandler(this.SelectNodeMI_Click);
			// 
			// Separator02
			// 
			this.Separator02.Index = 3;
			this.Separator02.Text = "-";
			// 
			// SetEnabledStateMI
			// 
			this.SetEnabledStateMI.Index = 5;
			this.SetEnabledStateMI.Text = "Set Enabled State...";
			this.SetEnabledStateMI.Click += new System.EventHandler(this.SetEnabledStateMI_Click);
			// 
			// GetEnabledStateMI
			// 
			this.GetEnabledStateMI.Index = 4;
			this.GetEnabledStateMI.Text = "Get Enabled State...";
			this.GetEnabledStateMI.Click += new System.EventHandler(this.GetEnabledStateMI_Click);
			// 
			// Separator03
			// 
			this.Separator03.Index = 6;
			this.Separator03.Text = "-";
			// 
			// GetConditionStateMI
			// 
			this.GetConditionStateMI.Index = 7;
			this.GetConditionStateMI.Text = "Get Condition State...";
			this.GetConditionStateMI.Click += new System.EventHandler(this.GetConditionStateMI_Click);
			// 
			// GetDAItemIDsMI
			// 
			this.GetDAItemIDsMI.Index = 8;
			this.GetDAItemIDsMI.Text = "Get DA ItemIDs...";
			this.GetDAItemIDsMI.Click += new System.EventHandler(this.GetDAItemIDsMI_Click);
			// 
			// BrowseCtrl
			// 
			this.Controls.Add(this.BrowseTV);
			this.Name = "BrowseCtrl";
			this.Size = new System.Drawing.Size(400, 304);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region Private Members
		private TsCAeServer m_server = null;
		private string m_browseFilter = null;
		private int m_maxElements = 0;
		private bool m_recursive = false;
		private event NodeSelectedEventHandler m_NodeSelected = null;

		private const string EVENTS = "Events";
		private const string AREAS  = "Areas";
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Raised when a area or source node in the tree is selected.
		/// </summary>
		public event NodeSelectedEventHandler NodeSelected
		{
			add    { m_NodeSelected += value; }
			remove { m_NodeSelected += value; }
		}

		/// <summary>
		/// A delegate to receive notifications when categories are selected.
		/// </summary>
		public delegate void NodeSelectedEventHandler(OpcClientSdk.Ae.TsCAeBrowseElement element, bool picked);

		/// <summary>
		/// Displays the area hierarchy for the server.
		/// </summary>
		public void ShowAreas(TsCAeServer server)
		{
			m_server = server;

			BrowseTV.Nodes.Clear();

			// nothing more to do if no server provided.
			if (m_server == null)
			{
				return;
			}

			// create root node.
			TreeNode root = new TreeNode(m_server.ServerName);

			root.ImageIndex         = Resources.IMAGE_LOCAL_SERVER;
			root.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			root.Tag                = m_server;

			BrowseTV.Nodes.Add(root);	

			// browse top level areas.
			BrowseArea(root.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Area, null);

			// browse top level sources.
			BrowseArea(root.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Source, null);

			// expand root node.
			root.Expand();
		}

		/// <summary>
		/// Displays the area and event hierarchies for the server.
		/// </summary>
		/// <param name="server"></param>
		public void ShowEventsAndAreas(TsCAeServer server)
		{
			m_server = server;

			BrowseTV.Nodes.Clear();

			// nothing more to do if no server provided.
			if (m_server == null)
			{
				return;
			}

			// create root node.
            TreeNode root = new TreeNode(m_server.ServerName);

			root.ImageIndex         = Resources.IMAGE_LOCAL_SERVER;
			root.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			root.Tag                = m_server;

			BrowseTV.Nodes.Add(root);

			// create events node.
			TreeNode events = new TreeNode(EVENTS);

			events.ImageIndex         = Resources.IMAGE_OPEN_YELLOW_FOLDER;
			events.SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
			events.Tag                = EVENTS;

			// browse event categories
			BrowseEvents(events.Nodes, TsCAeEventType.Simple);
			BrowseEvents(events.Nodes, TsCAeEventType.Tracking);
			BrowseEvents(events.Nodes, TsCAeEventType.Condition);

			root.Nodes.Add(events);

			// create areas node.
			TreeNode areas = new TreeNode(AREAS);

			areas.ImageIndex         = Resources.IMAGE_OPEN_YELLOW_FOLDER;
			areas.SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
			areas.Tag                = AREAS;

			root.Nodes.Add(areas);

			// browse top level areas.
			BrowseArea(areas.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Area, null);

			// browse top level sources.
			BrowseArea(areas.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Source, null);

			// expand root node.
			root.Expand();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Recursively finds all browse elements in the tree starting with the specified node.
		/// </summary>
		private void FindBrowseElements(TreeNode node, ArrayList elements)
		{	
			if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
			{
				elements.Add(node.Tag);
			}

			if (node != null)
			{
				// check if a dummy node is present.
				if (node.Nodes.Count == 1 && node.Nodes[0].Text.Length == 0)
				{
					FetchChildren(node);
				}	

				// find children.
				foreach (TreeNode child in node.Nodes)
				{
					FindBrowseElements(child, elements);
				}
			}
		}

		/// <summary>
		/// Fetches the children for the specified node.
		/// </summary>
		private void FetchChildren(TreeNode node)
		{
			// check for element.
			if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
			{
				// get the element.
				OpcClientSdk.Ae.TsCAeBrowseElement element = (OpcClientSdk.Ae.TsCAeBrowseElement)node.Tag;

				node.Nodes.Clear();

				// browse area.
				if (element.NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)
				{
					BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Area,   element);
					BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Source, element);
				}

				// browse source
				else
				{
					BrowseSource(node.Nodes, element);
				}
			}

			// check for category.
			else if (typeof(OpcClientSdk.Ae.TsCAeCategory).IsInstanceOfType(node.Tag))
			{
				node.Nodes.Clear();
				BrowseCategory(node.Nodes, (OpcClientSdk.Ae.TsCAeCategory)node.Tag);
			}

			// check for conditions.
			else if (typeof(Condition).IsInstanceOfType(node.Tag))
			{
				node.Nodes.Clear();
				BrowseCondition(node.Nodes, (Condition)node.Tag);
			}
		}

		/// <summary>
		/// A wrapper for a condition name.
		/// </summary>
		private struct Condition
		{
			public string Name;
			public Condition(string name) {	Name = name; }
		}

		/// <summary>
		/// Populates the tree with the event categories supported by the server.
		/// </summary>
		private void BrowseEvents(TreeNodeCollection nodes, TsCAeEventType eventType)
		{
			// fetch categories.
			OpcClientSdk.Ae.TsCAeCategory[] categories = m_server.QueryEventCategories((int)eventType);

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
				if (eventType == TsCAeEventType.Condition)
				{
					node.Nodes.Add(new TreeNode());
				}

				// add to tree.
				root.Nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the elements within the specified area.
		/// </summary>
		private void BrowseArea(TreeNodeCollection nodes, OpcClientSdk.Ae.TsCAeBrowseType browseType, OpcClientSdk.Ae.TsCAeBrowseElement area)
		{
			IOpcBrowsePosition position = null;

			try
			{
				// fetch first batch of elements.
                OpcClientSdk.Ae.TsCAeBrowseElement[] elements = m_server.Browse(
                    (area != null) ? area.QualifiedName : null,
                    browseType,
                    m_browseFilter,
                    m_maxElements,
                    out position);


				do
				{
					// add elements to tree.
					for (int ii = 0; ii < elements.Length; ii++)
					{
						// create node.
						TreeNode node = new TreeNode(elements[ii].Name);

						node.ImageIndex         = (browseType == OpcClientSdk.Ae.TsCAeBrowseType.Area)?Resources.IMAGE_CLOSED_BLUE_FOLDER:Resources.IMAGE_GREEN_SCROLL;
						node.SelectedImageIndex = (browseType == OpcClientSdk.Ae.TsCAeBrowseType.Area)?Resources.IMAGE_OPEN_BLUE_FOLDER:Resources.IMAGE_GREEN_SCROLL;
						node.Tag                = elements[ii];

						// add dummy child to ensure '+' sign is visible.
						node.Nodes.Add(new TreeNode());

						// add to tree.
						nodes.Add(node);
					}

					// check if browse is complete.
					if (position == null)
					{
						break;
					}

					// prompt to continue browse.
					DialogResult result = MessageBox.Show(
						"More elements meeting search criteria exist. Continue browse?", 
						"Browse " + browseType + "s", 
						MessageBoxButtons.YesNo);
				
					if (result == DialogResult.No)
					{
						break;
					}
					
					// continue browse.
					elements = m_server.BrowseNext(m_maxElements, ref position);
				}
				while (true);
			}
			finally
			{
				// dipose position object on exit.
				if (position != null)
				{
					position.Dispose();
					position = null;
				}
			}
		}
		
		/// <summary>
		/// Populates the tree with the conditions for the source.
		/// </summary>
		private void BrowseSource(TreeNodeCollection nodes, OpcClientSdk.Ae.TsCAeBrowseElement source)
		{
			// fetch conditions.
			string[] conditions = m_server.QueryConditionNames(source.QualifiedName);

			// add conditions to tree.
			for (int ii = 0; ii < conditions.Length; ii++)
			{
				// create node.
				TreeNode node = new TreeNode(conditions[ii]);

				node.ImageIndex         = Resources.IMAGE_EXPLODING_BOX;
				node.SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX;
				node.Tag                = new Condition(conditions[ii]);

				// add dummy child to ensure '+' sign is visible.
				node.Nodes.Add(new TreeNode());

				// add to tree.
				nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the sub-conditions for the condition.
		/// </summary>
		private void BrowseCondition(TreeNodeCollection nodes, Condition condition)
		{
			// fetch subconditions.
			string[] subconditions = m_server.QuerySubConditionNames(condition.Name);

			// add conditions to tree.
			for (int ii = 0; ii < subconditions.Length; ii++)
			{
				// create node.
				TreeNode node = new TreeNode(subconditions[ii]);

				node.ImageIndex         = Resources.IMAGE_LIST_BOX;
				node.SelectedImageIndex = Resources.IMAGE_LIST_BOX;
				node.Tag                = subconditions[ii];

				// add to tree.
				nodes.Add(node);
			}
		}

		/// <summary>
		/// Populates the tree with the conditions for the category.
		/// </summary>
		private void BrowseCategory(TreeNodeCollection nodes, OpcClientSdk.Ae.TsCAeCategory category)
		{
			// fetch conditions.
			string[] conditions = m_server.QueryConditionNames(category.ID);

			// add conditions to tree.
			for (int ii = 0; ii < conditions.Length; ii++)
			{
				// create node.
				TreeNode node = new TreeNode(conditions[ii]);

				node.ImageIndex         = Resources.IMAGE_EXPLODING_BOX;
				node.SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX;
				node.Tag                = new Condition(conditions[ii]);

				// add dummy child to ensure '+' sign is visible.
				node.Nodes.Add(new TreeNode());

				// add to tree.
				nodes.Add(node);
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Fetches the child nodes before expanding a node.
		/// </summary>
		private void BrowseTV_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			try
			{
				// check if a dummy node is present.
				if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text.Length == 0)
				{
					FetchChildren(e.Node);
				}				
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Refreshes the current node with the current filter settings.
		/// </summary>
		private void ApplyFiltersMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				TreeNode node = BrowseTV.SelectedNode;

				if (!typeof(TsCAeServer).IsInstanceOfType(node.Tag) && !typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// diplay dialog.
				bool result = new BrowseFiltersDlg().ShowDialog(
					ref m_browseFilter, 
					ref m_maxElements, 
					new EventHandler(FiltersChanged));

				// update display.
				if (result)
				{
					node.Nodes.Clear();

					if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
					{
						BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Area,   (OpcClientSdk.Ae.TsCAeBrowseElement)node.Tag);
						BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Source, (OpcClientSdk.Ae.TsCAeBrowseElement)node.Tag);
					}
					else
					{
						BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Area,   null);
						BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Source, null);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Called when the apply button in the browse filters dialog is clicked.
		/// </summary>
		private void FiltersChanged(object sender, System.EventArgs e)
		{
			TreeNode node = BrowseTV.SelectedNode;

			if (node != null)
			{
				m_browseFilter = ((BrowseFiltersDlg)sender).Filter;
				m_maxElements  = ((BrowseFiltersDlg)sender).MaxElements;

				node.Nodes.Clear();

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(node.Tag))
				{
					BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Area,   (OpcClientSdk.Ae.TsCAeBrowseElement)node.Tag);
					BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Source, (OpcClientSdk.Ae.TsCAeBrowseElement)node.Tag);
				}
				else
				{
					BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Area,   null);
					BrowseArea(node.Nodes, OpcClientSdk.Ae.TsCAeBrowseType.Source, null);
				}
			}
		}

		/// <summary>
		/// Updates the state of context menus based on the current selection.
		/// </summary>
		private void BrowseTV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// selects the item that was right clicked on.
			TreeNode clickedNode = BrowseTV.GetNodeAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedNode == null) return;

			// force selection to clicked node.
			BrowseTV.SelectedNode = clickedNode;

			// disable everything.
			ApplyFiltersMI.Enabled      = false;
			SelectNodeMI.Enabled        = m_NodeSelected != null;
			GetEnabledStateMI.Enabled   = false;
			SetEnabledStateMI.Enabled   = false;
			GetConditionStateMI.Enabled = false;
			GetDAItemIDsMI.Enabled      = false;

			// check for server node.
			if (typeof(TsCAeServer).IsInstanceOfType(clickedNode.Tag))
			{
				ApplyFiltersMI.Enabled    = true;
				GetEnabledStateMI.Enabled = true;
				SetEnabledStateMI.Enabled = true;
				return;
			}

			// check for area or source node.
			if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(clickedNode.Tag))
			{
				if (((OpcClientSdk.Ae.TsCAeBrowseElement)clickedNode.Tag).NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)
				{
					ApplyFiltersMI.Enabled  = true;
				}
				
				GetEnabledStateMI.Enabled = true;
				SetEnabledStateMI.Enabled = true;
				return;
			}

			// check for condition node.
			if (typeof(Condition).IsInstanceOfType(clickedNode.Tag))
			{
				GetConditionStateMI.Enabled = true;
				GetDAItemIDsMI.Enabled      = true;
			}

			// check for sub-condition node.
			if (typeof(string).IsInstanceOfType(clickedNode.Tag))
			{
				if (typeof(Condition).IsInstanceOfType(clickedNode.Parent.Tag))
				{
					GetDAItemIDsMI.Enabled = true;
				}
			}
		}	

		/// <summary>
		/// Sends notifications after a node is selected.
		/// </summary>
		private void BrowseTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{		
			try
			{
				if (m_NodeSelected == null || BrowseTV.SelectedNode == null)
				{
					return;
				}

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					m_NodeSelected((OpcClientSdk.Ae.TsCAeBrowseElement)BrowseTV.SelectedNode.Tag, false);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Sends notifications after a node is picked.
		/// </summary>
		private void BrowseTV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (m_NodeSelected == null || BrowseTV.SelectedNode == null)
				{
					return;
				}

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					m_NodeSelected((OpcClientSdk.Ae.TsCAeBrowseElement)BrowseTV.SelectedNode.Tag, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Sends notifications after a node is picked.
		/// </summary>
		private void SelectNodeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_NodeSelected == null || BrowseTV.SelectedNode == null)
				{
					return;
				}

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					m_NodeSelected((OpcClientSdk.Ae.TsCAeBrowseElement)BrowseTV.SelectedNode.Tag, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}			
		}

		/// <summary>
		/// Enables condition based notifications for the area or source.
		/// </summary>
		private void SetEnabledStateMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				// find current selection.
				OpcClientSdk.Ae.TsCAeBrowseElement selection = null;

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					selection = (OpcClientSdk.Ae.TsCAeBrowseElement)BrowseTV.SelectedNode.Tag;
				}
				else if (!typeof(TsCAeServer).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					return;
				}

				// prompt user.
				bool enabled = false;

				bool result = new SetEnabledStateDlg().ShowDialog(
					m_server,
					selection,
					out enabled, 
					ref m_recursive);

				if (!result)
				{
					return;
				}

				// apply changes.	
				ArrayList elements = new ArrayList();

				if (m_recursive)
				{
					FindBrowseElements(BrowseTV.SelectedNode, elements);
				}
				else
				{
					elements.Add(selection);
				}

				// seperate into areas and sources.
				ArrayList areas   = new ArrayList();
				ArrayList sources = new ArrayList();

				foreach (OpcClientSdk.Ae.TsCAeBrowseElement element in elements)
				{
					if (element.NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)
					{
						areas.Add(element.QualifiedName);
					}
					else
					{
						sources.Add(element.QualifiedName);
					}
				}

				// call server.
				if (enabled)
				{
					m_server.EnableConditionByArea((string[])areas.ToArray(typeof(string)));
					m_server.EnableConditionBySource((string[])sources.ToArray(typeof(string)));
				}
				else
				{
					m_server.DisableConditionByArea((string[])areas.ToArray(typeof(string)));
					m_server.DisableConditionBySource((string[])sources.ToArray(typeof(string)));
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Gets the enabled state for all elements in the hierarchy.
		/// </summary>
		private void GetEnabledStateMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				ArrayList elements = new ArrayList();

				FindBrowseElements(BrowseTV.SelectedNode, elements);

				new GetEnabledStateDlg().ShowDialog(m_server, (OpcClientSdk.Ae.TsCAeBrowseElement[])elements.ToArray(typeof(OpcClientSdk.Ae.TsCAeBrowseElement)));
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}

		/// <summary>
		/// Gets the current state for the selected condition.
		/// </summary>
		private void GetConditionStateMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				if (typeof(Condition).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					Condition condition = (Condition)BrowseTV.SelectedNode.Tag;
					OpcClientSdk.Ae.TsCAeBrowseElement source = (OpcClientSdk.Ae.TsCAeBrowseElement)BrowseTV.SelectedNode.Parent.Tag;

					new ConditionStateDlg().ShowDialog(m_server, source.QualifiedName, condition.Name);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void GetDAItemIDsMI_Click(object sender, System.EventArgs e)
		{	
			try
			{
				if (typeof(Condition).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					OpcClientSdk.Ae.TsCAeBrowseElement source    = (OpcClientSdk.Ae.TsCAeBrowseElement)BrowseTV.SelectedNode.Parent.Tag;
					Condition     condition = (Condition)BrowseTV.SelectedNode.Tag;

					new ItemIDsViewDlg().ShowDialog(m_server, source.QualifiedName, condition.Name, null);
				}

				if (typeof(string).IsInstanceOfType(BrowseTV.SelectedNode.Tag))
				{
					OpcClientSdk.Ae.TsCAeBrowseElement source       = (OpcClientSdk.Ae.TsCAeBrowseElement)BrowseTV.SelectedNode.Parent.Parent.Tag;
					Condition     condition    = (Condition)BrowseTV.SelectedNode.Parent.Tag;
					string        subcondition = (string)BrowseTV.SelectedNode.Tag;

					new ItemIDsViewDlg().ShowDialog(m_server, source.QualifiedName, condition.Name, subcondition);
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
  