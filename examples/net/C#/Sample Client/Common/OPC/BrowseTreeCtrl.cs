//============================================================================
// TITLE: BrowseTreeCtrl.cs
//
// CONTENTS:
// 
// A tree control use to navigate the address space of an OPC DA server.
//
// (c) Copyright 2002-2003 The OPC Foundation
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
// 2002/11/16 RSA   First release.
// 2003/03/23 RSA   Add support for complex data type property viewing.
// 2003/06/11 RSA   Updated to support unified DA interface.

using System;
using System.Net;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpcClientSdk;
using OpcClientSdk.Da;
using OpcClientSdk.Cpx;

namespace OpcClientSdk.Controls
{
	/// <summary>
	/// Use to receive notifications when a server node is 'picked'.
	/// </summary>
	public delegate void ServerPicked_EventHandler(OpcServer server);

	/// <summary>
	/// Use to receive notifications when a item node is 'picked'.
	/// </summary>
	public delegate void ItemPicked_EventHandler(OpcItem itemID);
	
	/// <summary>
	/// Use to receive notifications when a tree node is selected.
	/// </summary>
	public delegate void ElementSelected_EventHandler(TsCDaBrowseElement element);

	/// <summary>
	/// A tree control use to navigate the address space of an OPC DA server.
	/// </summary>
	public class BrowseTreeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView BrowseTV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem ConnectMI;
		private System.Windows.Forms.MenuItem DisconnectMI;
		private System.Windows.Forms.MenuItem RefreshMI;
		private System.Windows.Forms.MenuItem EditFiltersMI;
		private System.Windows.Forms.MenuItem Separator02;
		private System.Windows.Forms.MenuItem SetLoginMI;
		private System.Windows.Forms.MenuItem Separator01;
		private System.Windows.Forms.MenuItem PickMI;
		private System.Windows.Forms.MenuItem PickChildrenMI;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem ViewComplexTypeMI;

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
			if( disposing )
			{
				// release all server objects.
				Clear();

				if(components != null)
				{
					components.Dispose();
				}
			}
			
			base.Dispose( disposing );
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
			this.Separator02 = new System.Windows.Forms.MenuItem();
			this.SetLoginMI = new System.Windows.Forms.MenuItem();
			this.ConnectMI = new System.Windows.Forms.MenuItem();
			this.DisconnectMI = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.ViewComplexTypeMI = new System.Windows.Forms.MenuItem();
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
			this.BrowseTV.DoubleClick += new System.EventHandler(this.PickMI_Click);
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
																					  this.RefreshMI,
																					  this.Separator02,
																					  this.SetLoginMI,
																					  this.ConnectMI,
																					  this.DisconnectMI,
																					  this.menuItem1,
																					  this.ViewComplexTypeMI});
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
			// RefreshMI
			// 
			this.RefreshMI.Index = 4;
			this.RefreshMI.Text = "&Refresh";
			// 
			// Separator02
			// 
			this.Separator02.Index = 5;
			this.Separator02.Text = "-";
			// 
			// SetLoginMI
			// 
			this.SetLoginMI.Index = 6;
			this.SetLoginMI.Text = "Set &Login...";
			this.SetLoginMI.Click += new System.EventHandler(this.SetLoginMI_Click);
			// 
			// ConnectMI
			// 
			this.ConnectMI.Index = 7;
			this.ConnectMI.Text = "&Connect...";
			this.ConnectMI.Click += new System.EventHandler(this.ConnectMI_Click);
			// 
			// DisconnectMI
			// 
			this.DisconnectMI.Index = 8;
			this.DisconnectMI.Text = "&Disconnect";
			this.DisconnectMI.Click += new System.EventHandler(this.DisconnectMI_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 9;
			this.menuItem1.Text = "-";
			// 
			// ViewComplexTypeMI
			// 
			this.ViewComplexTypeMI.Index = 10;
			this.ViewComplexTypeMI.Text = "&View Complex Type...";
			this.ViewComplexTypeMI.Click += new System.EventHandler(this.ViewComplexTypeMI_Click);
			// 
			// BrowseTreeCtrl
			// 
			this.Controls.Add(this.BrowseTV);
			this.Name = "BrowseTreeCtrl";
			this.Size = new System.Drawing.Size(400, 400);
			this.ResumeLayout(false);

		}
		#endregion
				
		/// <summary>
		/// The underlying tree view. 
		/// </summary>
		public TreeView View {get{return BrowseTV;}}

		/// <summary>
		/// The server associated with the currently selected node.
		/// </summary>
		public OpcServer SelectedServer 
		{
			get
			{
				OpcServer server = FindServer(BrowseTV.SelectedNode); 

				if (server != null)
				{
					return (OpcServer)server.Duplicate();
				}

				return null;
			}
		}

		/// <summary>
		/// The currently selected item.
		/// </summary>
		public OpcItem SelectedItem 
		{
			get
			{			
				TreeNode node = BrowseTV.SelectedNode;

				if (IsBrowseElementNode(node))
				{
					TsCDaBrowseElement element = (TsCDaBrowseElement)node.Tag;

					if (element.IsItem)
					{
						return new OpcItem(element.ItemPath, element.ItemName);
					}
				}

				if (IsItemPropertyNode(node))
				{
					TsCDaItemProperty property = (TsCDaItemProperty)node.Tag;

					if (property.ItemName != null && ItemPicked != null)
					{
						return new OpcItem(property.ItemPath, property.ItemName);
					}
				}

				return null;
			}
		}
		
		/// <summary>
		/// The connectData associated with the currently selected node.
		/// </summary>
		public OpcConnectData SelectedConnectData {get{ return FindConnectData(BrowseTV.SelectedNode); }}

		/// <summary>
		/// Use to receive notifications when a server node is 'picked'.
		/// </summary>
		public event ServerPicked_EventHandler ServerPicked;

		/// <summary>
		/// Use to receive notifications when a item node is 'picked'.
		/// </summary>
		public event ItemPicked_EventHandler ItemPicked;

		/// <summary>
		/// Use to receive notifications when an element is selected.
		/// </summary>
		public event ElementSelected_EventHandler ElementSelected;

		/// <summary>
		/// The specification of the servers being displayed in the control.
		/// </summary>
		private OpcSpecification m_specification;

		/// <summary>
		/// The current filters to apply when expanding nodes.
		/// </summary>
		private TsCDaBrowseFilters m_filters = null;

		/// <summary>
		/// References to well-known root nodes.
		/// </summary>
		private TreeNode m_localServers = null;
		private TreeNode m_localNetwork = null;
		private TreeNode m_singleServer = null;

		/// <summary>
		/// Displays all servers that support the specified specification.
		/// </summary>
		public void ShowAllServers(OpcSpecification specification, TsCDaBrowseFilters filters)
		{
			Clear();

            m_specification = specification;
			m_filters       = (filters == null)?new TsCDaBrowseFilters():filters;
	
			BrowseTV.ContextMenu = PopupMenu;

			m_localServers                    = new TreeNode("Local Servers");
			m_localServers.ImageIndex         = Resources.IMAGE_LOCAL_COMPUTER;
			m_localServers.SelectedImageIndex = Resources.IMAGE_LOCAL_COMPUTER;
			m_localServers.Tag                = null;		

			BrowseServers(m_localServers);
			BrowseTV.Nodes.Add(m_localServers);

			m_localNetwork                    = new TreeNode("Local Network");
			m_localNetwork.ImageIndex         = Resources.IMAGE_LOCAL_NETWORK;
			m_localNetwork.SelectedImageIndex = Resources.IMAGE_LOCAL_NETWORK;
			m_localNetwork.Tag                = null;

			//BrowseNetwork(_localNetwork);
			//BrowseTV.Nodes.Add(_localNetwork);
		}

		/// <summary>
		/// Browses the address space for a single server.
		/// </summary>
		public void ShowSingleServer(OpcServer server, TsCDaBrowseFilters filters)
		{
			if (server == null) throw new ArgumentNullException("server");

			Clear();

			m_filters   = (filters == null)?new TsCDaBrowseFilters():filters;

			BrowseTV.ContextMenu = PopupMenu;

			m_singleServer                    = new TreeNode(server.ServerName);
			m_singleServer.ImageIndex         = Resources.IMAGE_LOCAL_SERVER;
			m_singleServer.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			m_singleServer.Tag                = server.Duplicate();

			Connect(m_singleServer);
			BrowseTV.Nodes.Add(m_singleServer);	
		}

		/// <summary>
		/// Connects to the server and browses for top level nodes.
		/// </summary>
		private void Connect(TreeNode node)
		{
			try
			{
				if (!IsServerNode(node)) return;

				// get the server for the current node.
				OpcServer server = (OpcServer)node.Tag;

				// connect to server if not already connected.
				if (!server.IsConnected)
				{
					server.Connect(FindConnectData(node));
				}

				// browse for top level elements.
				Browse(node);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Disconnects from the server and clear all children.
		/// </summary>
		private void Disconnect(TreeNode node)
		{
			try
			{
				if (!IsServerNode(node)) return;

				// get the server for the current node.
				OpcServer server = (OpcServer)node.Tag;

				// connect to server if not already connected.
				if (server.IsConnected)
				{
					server.Disconnect();
				}
				
				node.Nodes.Clear();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Finds the network connectData for the specified node.
		/// </summary>
		private OpcConnectData FindConnectData(TreeNode node)
		{
			if (node != null)
			{
				if (node.Tag != null && node.Tag.GetType() == typeof(OpcConnectData))
				{
					return (OpcConnectData)node.Tag;
				}

				return FindConnectData(node.Parent);
			}

			if (BrowseTV.Tag != null && BrowseTV.Tag.GetType() == typeof(OpcConnectData))
			{
				return (OpcConnectData)BrowseTV.Tag;
			}

			return null;
		}

		/// <summary>
		/// Browses for computers on the network.
		/// </summary>
		private void BrowseNetwork(TreeNode node)
		{
			try
			{
				// clear current contents.
				node.Nodes.Clear();

                IOpcDiscovery discovery = new OpcClientSdk.Com.ServerEnumerator();
                string[] hosts = discovery.EnumerateHosts();

                // add children.
                if (hosts != null)
				{
					foreach (string host in hosts)
					{
						TreeNode child = new TreeNode(host);
						child.ImageIndex = child.SelectedImageIndex = Resources.IMAGE_LOCAL_COMPUTER;	
						child.Tag = null;
						child.Nodes.Add(new TreeNode());

						node.Nodes.Add(child);
					}
					
					node.Expand();
				}
			}
			catch (Exception e)
			{
				//MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Browses for servers a computer.
		/// </summary>
		private void BrowseServers(TreeNode node)
		{
			try
			{
				// clear current contents.
				node.Nodes.Clear();

				// get the host name.
				string host = null;

				if (node != m_localServers)
				{
					host = node.Text;
				}

				// get default login information.
				OpcConnectData connectData = FindConnectData(node);

                // find the servers.
                IOpcDiscovery discovery = new Com.ServerEnumerator();
                OpcServer[] servers = discovery.GetAvailableServers(m_specification, host, connectData);

				// add children.
				if (servers != null)
				{
					foreach (OpcServer server in servers)
					{
						TreeNode child   = new TreeNode(server.ServerName);
						child.ImageIndex = child.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;	
						child.Tag        = server;

						node.Nodes.Add(child);
					}
					
					node.Expand();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Browses for children of the element at the current node.
		/// </summary>
		private void Browse(TreeNode node)
		{
			try
			{
				// get the server for the current node.
				OpcServer selection = FindServer(node);

				if (!typeof(TsCDaServer).IsInstanceOfType(selection))
				{
					return;
				}

				TsCDaServer server = (TsCDaServer)selection;

				// get the current element to use for a browse.
				TsCDaBrowseElement  parent = null;
				OpcItem itemID = null;

				if (node.Tag != null && node.Tag.GetType() == typeof(TsCDaBrowseElement))
				{
					parent = (TsCDaBrowseElement)node.Tag;
					itemID = new OpcItem(parent.ItemPath, parent.ItemName);
				}

				// clear the node children.
				node.Nodes.Clear();

				// add properties
				if (parent != null && parent.Properties != null)
				{
					foreach (TsCDaItemProperty property in parent.Properties)
					{
						AddItemProperty(node, property);
					}
				}

				// begin a browse.
				Da.TsCDaBrowsePosition position = null;
				TsCDaBrowseElement[] elements = server.Browse(itemID, m_filters, out position);

				// add children.
				if (elements != null)
				{
					foreach (TsCDaBrowseElement element in elements)
					{
						AddBrowseElement(node, element);
					}
					
					node.Expand();
				}

				// loop until all elements have been fetched.
				while (position != null)
				{
					DialogResult result = MessageBox.Show(
						"More items meeting search criteria exist. Continue browse?", 
						"Browse Items", 
						MessageBoxButtons.YesNo);
					
					if (result == DialogResult.No)
					{
						break;
					}

					// fetch next batch of elements,.
					elements = server.BrowseNext(ref position);
				
					// add children.
					if (elements != null)
					{
						foreach (TsCDaBrowseElement element in elements)
						{
							AddBrowseElement(node, element);
						}

						node.Expand();
					}
				}

				// send notification that property list changed.
				if (ElementSelected != null)
				{
					if (node.Tag.GetType() == typeof(TsCDaBrowseElement))
					{
						ElementSelected((TsCDaBrowseElement)node.Tag);
					}
					else
					{
						ElementSelected(null);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Browses for children of the element at the current node.
		/// </summary>
		private void GetProperties(TreeNode node)
		{
			try
			{
				// get the server for the current node.
				OpcServer selection = FindServer(node);

				if (!typeof(TsCDaServer).IsInstanceOfType(selection))
				{
					return;
				}

				TsCDaServer server = (TsCDaServer)selection;

				// get the current element to use for a get properties.
				TsCDaBrowseElement element = null;

				if (node.Tag != null && node.Tag.GetType() == typeof(TsCDaBrowseElement))
				{
					element = (TsCDaBrowseElement)node.Tag;
				}

				// can only get properties for an item.
				if (!element.IsItem)
				{
					return;
				}
				
				// clear the node children.
				node.Nodes.Clear();

				// begin a browse.			
				OpcItem itemID = new OpcItem(element.ItemPath, element.ItemName);

				TsCDaItemPropertyCollection[] propertyLists = server.GetProperties(
					new OpcItem[] { itemID },
					m_filters.PropertyIDs,
					m_filters.ReturnPropertyValues);

				if (propertyLists != null)
				{
					foreach (TsCDaItemPropertyCollection propertyList in propertyLists)
					{
						foreach (TsCDaItemProperty property in propertyList)
						{
							AddItemProperty(node, property);
						}

						// update element properties.
						element.Properties = (TsCDaItemProperty[])propertyList.ToArray(typeof(TsCDaItemProperty));
					}
				}

				node.Expand();

				// send notification that property list changed.
				if (ElementSelected != null)
				{
					ElementSelected(element);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Checks if the current node is a host or network node.
		/// </summary>
		private bool IsHostNode(TreeNode node)
		{
			if (node == null) return false;
			if (node == m_localServers || node == m_singleServer) return true;
			if (node.Parent == m_localNetwork) return true;
			return false;
		}

		/// <summary>
		/// Checks if the current node is a server node.
		/// </summary>
		private bool IsServerNode(TreeNode node)
		{
			if (node == null ||node.Tag == null) return false;
			return typeof(OpcServer).IsInstanceOfType(node.Tag);
		}

		/// <summary>
		/// Checks if the current node is a browse element node.
		/// </summary>
		private bool IsBrowseElementNode(TreeNode node)
		{
			if (node == null || node.Tag == null) return false;
			return (node.Tag.GetType() == typeof(TsCDaBrowseElement));
		}

		/// <summary>
		/// Checks if the current node is an item property node.
		/// </summary>
		private bool IsItemPropertyNode(TreeNode node)
		{
			if (node == null || node.Tag == null) return false;
			return (node.Tag.GetType() == typeof(TsCDaItemProperty));
		}

		/// <summary>
		/// Finds the server for the specified node.
		/// </summary>
		private OpcServer FindServer(TreeNode node)
		{
			if (node != null)
			{
				if (IsServerNode(node))
				{
					return (OpcServer)node.Tag;
				}

				return FindServer(node.Parent);
			}

			return null;
		}

		/// <summary>
		/// Sends a server or item pciked depending on the node.
		/// </summary>
		private void PickNode(TreeNode node)
		{
			if (IsServerNode(node))
			{
				if (ServerPicked != null)
				{
					ServerPicked((OpcServer)node.Tag);
				}
			}

			else if (IsBrowseElementNode(node))
			{
				TsCDaBrowseElement element = (TsCDaBrowseElement)node.Tag;

				if (element.IsItem && ItemPicked != null)
				{
					ItemPicked(new OpcItem(element.ItemPath, element.ItemName));
				}
			}

			else if (IsItemPropertyNode(node))
			{
				TsCDaItemProperty property = (TsCDaItemProperty)node.Tag;

				if (property.ItemName != null && ItemPicked != null)
				{
					ItemPicked(new OpcItem(property.ItemPath, property.ItemName));
				}
			}
		}

		/// <summary>
		/// Displays a dialog with the complex type information.
		/// </summary>
		private void ViewComplexType(TreeNode node)
		{
			if (!IsBrowseElementNode(node))
			{
				return;
			}

			try
			{
				TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem((TsCDaBrowseElement)node.Tag);

				if (complexItem != null)
				{
					new EditComplexValueDlg().ShowDialog(complexItem, null, true, true);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Adds the specified browse element into the tree.
		/// </summary>
		private void AddBrowseElement(TreeNode parent, TsCDaBrowseElement element)
		{
			// create the new node.
			TreeNode node = new TreeNode(element.Name);
			
			// select the icon.
			if (element.IsItem)
			{
				node.ImageIndex = node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;
			}
			else
			{
				node.ImageIndex = node.SelectedImageIndex = Resources.IMAGE_CLOSED_YELLOW_FOLDER;
			}
	
			node.Tag = element;

			// add a dummy node to force display of '+' symbol.
			if (element.HasChildren)
			{
				node.Nodes.Add(new TreeNode());
			}

			// add properties
			if (element.Properties != null)
			{
				foreach (TsCDaItemProperty property in element.Properties)
				{
					AddItemProperty(node, property);
				}
			}

			// add to parent.
			parent.Nodes.Add(node);
		}

		/// <summary>
		/// Adds the specified item property into the tree.
		/// </summary>
		private void AddItemProperty(TreeNode parent, TsCDaItemProperty property)
		{
			if (property.Result.Succeeded())
			{
				// create the new node.
				TreeNode node = new TreeNode(property.Description);
			
				// select the icon.
				if (property.ItemName != null && property.ItemName != "")
				{
					node.ImageIndex = node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;
				}
				else
				{
					node.ImageIndex = node.SelectedImageIndex = Resources.IMAGE_EXPLODING_BOX;
				}

				node.Tag = property;

				if (property.Value != null)
				{
					TreeNode child = new TreeNode(OpcClientSdk.OpcConvert.ToString(property.Value));
					child.ImageIndex = child.SelectedImageIndex = Resources.IMAGE_LIST_BOX;
					child.Tag = property.Value;
					node.Nodes.Add(child);

					if (property.Value.GetType().IsArray)
					{
						foreach (object element in (Array)property.Value)
						{
							TreeNode arrayChild = new TreeNode(OpcClientSdk.OpcConvert.ToString(element));
							arrayChild.ImageIndex = arrayChild.SelectedImageIndex = Resources.IMAGE_LIST_BOX;
							arrayChild.Tag = element;
							child.Nodes.Add(arrayChild);
						}
					}
				}
	
				// add to parent.
				parent.Nodes.Add(node);
			}
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

			m_localServers = null;
			m_localNetwork = null;
			m_singleServer = null;
		}

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

			// disconnect servers.
			if (IsServerNode(parent))
			{
				OpcServer server = (OpcServer)parent.Tag;
				if (server.IsConnected) server.Disconnect();
			}
		}

		/// <summary>
		/// Called before a node is about to expand.
		/// </summary>
		private void BrowseTV_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;

			if (node != null && node.Parent == m_localNetwork)
			{
				// browse server if not already done.
				if (node.Nodes.Count == 1 && node.Nodes[0].Text == "")
				{
					BrowseServers(node);
				}
			}

			if (IsServerNode(node))
			{
				// connect to server if not already connected.
				if (node.Nodes.Count == 1 && node.Nodes[0].Text == "")
				{
					Connect(node);
				}

				return;
			}

			if (IsBrowseElementNode(node))
			{
				// browse for children if not already fetched.
				if (node.Nodes.Count >= 1 && node.Nodes[0].Text == "")
				{
					Browse(node);
				}

				return;
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
			EditFiltersMI.Enabled     = false;
			RefreshMI.Enabled         = false;
			SetLoginMI.Enabled        = false;
			ConnectMI.Enabled         = false;
			DisconnectMI.Enabled      = false;
			ViewComplexTypeMI.Enabled = false;

			if (clickedNode == m_localNetwork || IsHostNode(clickedNode))
			{
				RefreshMI.Enabled  = true;
				SetLoginMI.Enabled = true;
				return;
			}

			if (IsServerNode(clickedNode))
			{
				PickMI.Enabled        = true;
				ConnectMI.Enabled = !((OpcServer)clickedNode.Tag).IsConnected;
				DisconnectMI.Enabled = ((OpcServer)clickedNode.Tag).IsConnected;
				EditFiltersMI.Enabled = true;
				RefreshMI.Enabled     = true;
				return;
			}

			if (IsBrowseElementNode(clickedNode))
			{
				PickMI.Enabled            = true;
				EditFiltersMI.Enabled     = true;
				RefreshMI.Enabled         = true;
                ViewComplexTypeMI.Enabled = (TsCCpxComplexTypeCache.GetComplexItem((TsCDaBrowseElement)clickedNode.Tag) != null);
				return;
			}
		}	
		
		/// <summary>
		/// Called when the browse filters have changed.
		/// </summary>
		private void OnBrowseFiltersChanged(TsCDaBrowseFilters filters)
		{
			m_filters = filters;

			if (IsBrowseElementNode(BrowseTV.SelectedNode))
			{
				TsCDaBrowseElement element = (TsCDaBrowseElement)BrowseTV.SelectedNode.Tag;

				if (!element.HasChildren)
				{
					GetProperties(BrowseTV.SelectedNode);
					return;
				}
			}

			Browse(BrowseTV.SelectedNode);
		}
		
		/// <summary>
		/// Connects to the selected server.
		/// </summary>
		private void ConnectMI_Click(object sender, System.EventArgs e)
		{
			Connect(BrowseTV.SelectedNode);		
		}

		/// <summary>
		/// Connects to the selected server.
		/// </summary>
		private void DisconnectMI_Click(object sender, System.EventArgs e)
		{
			Disconnect(BrowseTV.SelectedNode);		
		}
		
		/// <summary>
		/// Updates the contents of the current selection.
		/// </summary>
		private void RefreshMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = BrowseTV.SelectedNode;

			if (node == m_localNetwork) { BrowseNetwork(node); return; }	
			if (IsHostNode(node))       { BrowseServers(node); return; }

			Browse(node);
		}

		/// <summary>
		/// Prompts the user to set the network connectData for the node.
		/// </summary>
		private void SetLoginMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = BrowseTV.SelectedNode;

			if (node == m_localNetwork | IsHostNode(node))       
			{ 
				OpcConnectData connectData = (OpcConnectData)node.Tag;

				if (connectData == null)
				{
					node.Tag = connectData = new OpcConnectData(null);
				}

				connectData.UserIdentity = new NetworkCredentialsDlg().ShowDialog(connectData.UserIdentity);
			}
		}

		/// <summary>
		/// Sends a server or item selected event.
		/// </summary>
		private void PickMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = BrowseTV.SelectedNode;

			if (node != null)
			{
				PickNode(node);
			}
		}

		/// <summary>
		/// Sends a server or item selected event for all node children.
		/// </summary>
		private void PickChildrenMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = BrowseTV.SelectedNode;
			
			if (node != null)
			{
				foreach (TreeNode child in node.Nodes)
				{
					PickNode(child);
				}
			}
		}

		/// <summary>
		/// Called when a tree node is selected.
		/// </summary>
		private void BrowseTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode node = BrowseTV.SelectedNode;

			if (ElementSelected != null)
			{
				if (IsBrowseElementNode(node))
				{
					ElementSelected((TsCDaBrowseElement)node.Tag);
				}
				else
				{
					ElementSelected(null);
				}
			}
		}

		/// <summary>
		/// Called to view complex type information for an item.
		/// </summary>
		private void ViewComplexTypeMI_Click(object sender, System.EventArgs e)
		{
			TreeNode node = BrowseTV.SelectedNode;

			if (node != null)
			{
				ViewComplexType(node);
			}
		}
	}
}
