//============================================================================
// TITLE: BrowseTreeCtrl.cs
//
// CONTENTS:
// 
// A tree control use to navigate the address space of an HDA server.
//
// (c) Copyright 2003-2004 The OPC Foundation
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
// 2004/01/05 RSA   Initial implementation.

using System;
using System.Net;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{

	/// <summary>
	/// A tree control use to navigate the address space of an HDA server.
	/// </summary>
	public class BrowseTreeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView BrowseTV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem RefreshMI;
		private System.Windows.Forms.MenuItem EditFiltersMI;
		private System.Windows.Forms.MenuItem Separator01;
		private System.Windows.Forms.MenuItem PickMI;
		private System.Windows.Forms.MenuItem PickChildrenMI;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BrowseTreeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			BrowseTV.ImageList = Resources.Instance.ImageList;
			Clear();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				// ensure the filters dialog is disposed properly.
				if (m_filtersDialog != null && !m_filtersDialog.IsDisposed)
				{
					m_filtersDialog.Close();
					m_filtersDialog = null;
				}

				// ensure browser object is disposed.
				if (m_browser != null)
				{
					m_browser.Dispose();
					m_browser = null;
				}

				// release all server objects.
				Clear();

				if (components != null)
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
			this.PickMI = new System.Windows.Forms.MenuItem();
			this.PickChildrenMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.EditFiltersMI = new System.Windows.Forms.MenuItem();
			this.RefreshMI = new System.Windows.Forms.MenuItem();
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
			this.BrowseTV.Size = new System.Drawing.Size(400, 400);
			this.BrowseTV.TabIndex = 0;
			this.BrowseTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseTV_MouseDown);
			this.BrowseTV.DoubleClick += new System.EventHandler(this.BrowseTV_DoubleClick);
			this.BrowseTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrowseTV_AfterSelect);
			this.BrowseTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BrowseTV_BeforeExpand);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.PickMI,
																					  this.PickChildrenMI,
																					  this.Separator01,
																					  this.EditFiltersMI,
																					  this.RefreshMI});
			// 
			// PickMI
			// 
			this.PickMI.Index = 0;
			this.PickMI.Text = "&Select";
			this.PickMI.Click += new System.EventHandler(this.PickMI_Click);
			// 
			// PickChildrenMI
			// 
			this.PickChildrenMI.Index = 1;
			this.PickChildrenMI.Text = "Select Chil&dren";
			this.PickChildrenMI.Click += new System.EventHandler(this.PickChildrenMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 2;
			this.Separator01.Text = "-";
			// 
			// EditFiltersMI
			// 
			this.EditFiltersMI.Index = 3;
			this.EditFiltersMI.Text = "Set &Filters...";
			this.EditFiltersMI.Click += new System.EventHandler(this.EditFiltersMI_Click);
			// 
			// RefreshMI
			// 
			this.RefreshMI.Index = 4;
			this.RefreshMI.Text = "&Refresh";
			// 
			// BrowseTreeCtrl
			// 
			this.Controls.Add(this.BrowseTV);
			this.Name = "BrowseTreeCtrl";
			this.Size = new System.Drawing.Size(400, 400);
			this.ResumeLayout(false);

		}
		#endregion
				
		#region Public Interface
		/// <summary>
		/// A delegate to receive item picked events.
		/// </summary>
		public delegate void ItemPickedEventHandler(OpcItem[] items);

		/// <summary>
		/// Fired when one or more items are explicitly picked within the tree control.
		/// </summary>
		public event ItemPickedEventHandler ItemPicked;

		/// <summary>
		/// A delegate to receive item selected events.
		/// </summary>
		public delegate void ItemSelectedEventHandler(OpcItem item);

		/// <summary>
		/// Fired when an item node is selected in the tree.
		/// </summary>
		public event ItemSelectedEventHandler ItemSelected;

		/// <summary>
		/// Browses the address space for a single server.
		/// </summary>
		public void Browse(TsCHdaServer server, TsCHdaBrowseFilter[] filters)
		{
			if (server == null) throw new ArgumentNullException("server");

			Clear();
			
			// create the initial browser.
			try
			{
				OpcResult[] results = null;
				m_browser = server.CreateBrowser(filters, out results);
				m_server  = server;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}

			// create the root node.
            TreeNode root = new TreeNode(server.ServerName);
			root.ImageIndex         = Resources.IMAGE_LOCAL_SERVER;
			root.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			root.Tag                = server;

			// browse for top level nodes.
			Browse(root, null);	

			// add new node to tree view.
			BrowseTV.Nodes.Add(root);	
			root.Expand();
		}

		/// <summary>
		/// Removes all nodes and releases all resources.
		/// </summary>
		public void Clear()
		{		
			// recursively searches the tree and free objects.
			foreach (TreeNode child in BrowseTV.Nodes)
			{
				Clear(child);
			}

			// clear the tree.
			BrowseTV.Nodes.Clear();
		}
		
		/// <summary>
		/// Clears the current selection in the tree control
		/// </summary>
		public void ClearSelection()
		{		
			BrowseTV.SelectedNode = null;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// The server which is being browsed.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// The object used to browse the server address space.
		/// </summary>
		private ITsCHdaBrowser m_browser = null;

		/// <summary>
		/// The maximum number of elements to return in a single browse operation.
		/// </summary>
		private int m_maxElements = 0;
		
		/// <summary>
		/// The non-model dialog used to change the browse filters.
		/// </summary>
		private BrowseFiltersDlg m_filtersDialog = new BrowseFiltersDlg();

		/// <summary>
		/// Recursively searches the tree and free objects.
		/// </summary>
		private void Clear(TreeNode parent)
		{		
			// search children.
			foreach (TreeNode child in parent.Nodes)
			{
				Clear(child);
			}
		}

		/// <summary>
		/// Browses for child nodes and populates the tree.
		/// </summary>
		private void Browse(TreeNode parent, TsCHdaBrowseElement branch)
		{
			// clear existing children.
			parent.Nodes.Clear();

			// browse for the children of the node.
			TsCHdaBrowseElement[] children = null;
			
			IOpcBrowsePosition position = null;

			do
			{
				// fetch next batch of elements from the server.
				try
				{
					if (position == null)
					{
						children = m_browser.Browse(branch, m_maxElements, out position);
					}
					else
					{
						children = m_browser.BrowseNext(m_maxElements, ref position);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
					break;
				}

				// nothing more to do.
				if (children == null)
				{
					break;
				}

				// create a tree node for each child.
				foreach (TsCHdaBrowseElement child in children)
				{
					// create new node.
					TreeNode node = new TreeNode(child.Name);

					// set node icon.
					if (child.IsItem)
					{						
						node.ImageIndex         = Resources.IMAGE_GREEN_SCROLL;
						node.SelectedImageIndex = Resources.IMAGE_GREEN_SCROLL;
					}
					else
					{
						node.ImageIndex         = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
						node.SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
					}
				
					// save element.
					node.Tag = child;

					// add dummy child node for branches.
					if (child.HasChildren)
					{
						node.Nodes.Add(new TreeNode());
					}

					// add top level node to root node.
					parent.Nodes.Add(node);
				}

				// prompt use to continue browse operation.
				if (position != null)
				{
					if (MessageBox.Show("More items exist. Continue browsing?", "Browse Items", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						break;
					}
				}
			}
			while (position != null);		

			// release browse position object if browse halted.
			if (position != null)
			{
				position.Dispose();
				position = null;
			}
		}
		#endregion

		/// <summary>
		/// Called before a node is about to expand.
		/// </summary>
		private void BrowseTV_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;

			if (node == null || node.Tag == null)
			{
				return;
			}

			if (node.Tag.GetType() == typeof(TsCHdaBrowseElement))
			{
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)node.Tag;

				// fetch children if they have not already been fetched.
				if (element.HasChildren && node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
				{
					Browse(node, element);	
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
			PickMI.Enabled            = false;
			PickChildrenMI.Enabled    = false;
			EditFiltersMI.Enabled     = false;
			RefreshMI.Enabled         = false;

			// setup menu for browse element nodes.
			if (typeof(TsCHdaBrowseElement).IsInstanceOfType(clickedNode.Tag))
			{
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)clickedNode.Tag;

				PickMI.Enabled            = element.IsItem;
				PickChildrenMI.Enabled    = element.HasChildren;
				EditFiltersMI.Enabled     = element.HasChildren;
				RefreshMI.Enabled         = element.HasChildren;

				return;
			}
			
			// setup menu for server nodes.
			if (typeof(TsCHdaServer).IsInstanceOfType(clickedNode.Tag))
			{
				PickMI.Enabled            = false;
				PickChildrenMI.Enabled    = true;
				EditFiltersMI.Enabled     = true;
				RefreshMI.Enabled         = true;

				return;
			}
		}	
		
		/// <summary>
		/// Called when the browse filters have changed.
		/// </summary>
		private void OnBrowseFiltersChanged(int maxElements, TsCHdaBrowseFilter[] filters)
		{
			try
			{
				// release existing browser.
				if (m_browser != null)
				{
					m_browser.Dispose();
					m_browser = null;
				}

				// create a new browser.
				OpcResult[] results = null;
				m_browser = m_server.CreateBrowser(filters, out results);

				// save maximum elements to return in a single call.
				m_maxElements = maxElements;

				// update chidren of selected node.
				TreeNode node = BrowseTV.SelectedNode;

				if (node != null)
				{
					TsCHdaBrowseElement branch = null;

					if (node.Tag != null && node.Tag.GetType() == typeof(TsCHdaBrowseElement))
					{
						branch = (TsCHdaBrowseElement)node.Tag;
					}

					Browse(node, branch);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
			
		/// <summary>
		/// Causes an item selected event to be sent for the current node.
		/// </summary>
		private void PickMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check if current selection is valid.
				TreeNode node = BrowseTV.SelectedNode;

				if (node == null || node.Tag == null || node.Tag.GetType() != typeof(TsCHdaBrowseElement))
				{
					return;
				}

				// raise event if selected element is an item.
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)node.Tag;

				if (element.IsItem)
				{
					if (ItemPicked != null)
					{
						ItemPicked(new OpcItem[] { element });
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Causes an item selected event to be sent for each child of of the current node.
		/// </summary>
		private void PickChildrenMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check if current selection is valid.
				TreeNode node = BrowseTV.SelectedNode;

				if (node == null || node.Nodes.Count == 0)
				{
					return;
				}

				// build list of items contained in the selected branch.
				ArrayList items = new ArrayList();

				foreach (TreeNode child in node.Nodes)
				{
					if (typeof(TsCHdaBrowseElement).IsInstanceOfType(child.Tag))
					{
						TsCHdaBrowseElement element = (TsCHdaBrowseElement)child.Tag;

						if (element.IsItem)
						{
							items.Add(element);
						}
					}
				}

				// raise event at least one child item was found.
				if (items.Count > 0)
				{
					if (ItemPicked != null)
					{
						ItemPicked((OpcItem[])items.ToArray(typeof(OpcItem)));
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Displays the edit browse filters dialog.
		/// </summary>
		private void EditFiltersMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create new dialog if required.
				if (m_filtersDialog == null || m_filtersDialog.IsDisposed)
				{
					m_filtersDialog = new BrowseFiltersDlg();
				}

				// show the dialog.
				m_filtersDialog.Show(
					FindForm(), 
					m_server, 
					m_browser, 
					m_maxElements,
					new BrowseFiltersChangedCallback(OnBrowseFiltersChanged));
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
        
		/// <summary>
		/// Updates the contents of the current selection.
		/// </summary>
		private void RefreshMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// TBD
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Sends an item picked event.
		/// </summary>
		private void BrowseTV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				// check if current selection is valid.
				TreeNode node = BrowseTV.SelectedNode;

				if (node == null || !typeof(TsCHdaBrowseElement).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// check if selection is an item.
				TsCHdaBrowseElement element = (TsCHdaBrowseElement)node.Tag;

				if (element.IsItem)
				{
					if (ItemPicked != null)
					{
						ItemPicked(new OpcItem[] { element });
					}				
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Sends an item selected event.
		/// </summary>
		private void BrowseTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				// ignore event if no listeners.
				if (ItemSelected == null)
				{
					return;
				}	

				// check if the current selection is an item.
				TsCHdaBrowseElement element = null;

				TreeNode node = BrowseTV.SelectedNode;

				if (node != null && typeof(TsCHdaBrowseElement).IsInstanceOfType(node.Tag))
				{
					if (((TsCHdaBrowseElement)node.Tag).IsItem)
					{
						element = (TsCHdaBrowseElement)node.Tag;
					}
				}

				// fire the event.
				ItemSelected(element);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
