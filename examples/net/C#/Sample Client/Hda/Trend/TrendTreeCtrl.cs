//============================================================================
// TITLE: TrendTreeCtrl.cs
//
// CONTENTS:
// 
// A tree control used to manager a set of trends acquired from an HDA server.
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
	/// A tree control used to manager a set of trends acquired from an HDA server.
	/// </summary>
	public class TrendTreeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView TrendTV;
		private System.Windows.Forms.MenuItem AddTrendMI;
		private System.Windows.Forms.MenuItem RemoveTrendMI;
		private System.Windows.Forms.MenuItem EditTrendMI;
		private System.Windows.Forms.MenuItem EditItemMI;
		private System.Windows.Forms.MenuItem RemoveItemMI;
		private System.Windows.Forms.MenuItem ReadAtTimeMI;
		private System.Windows.Forms.MenuItem ReadModifiedMI;
		private System.Windows.Forms.MenuItem ReadAttributesMI;
		private System.Windows.Forms.MenuItem ReadAnnotationsMI;
		private System.Windows.Forms.MenuItem AddItemsMI;
		private System.Windows.Forms.MenuItem Separator01;
		private System.Windows.Forms.MenuItem InsertMI;
		private System.Windows.Forms.MenuItem InsertReplaceMI;
		private System.Windows.Forms.MenuItem ReplaceMI;
		private System.Windows.Forms.MenuItem DeleteAtTimeMI;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem DeleteRawMI;
		private System.Windows.Forms.MenuItem ReadRawMI;
		private System.Windows.Forms.MenuItem ReadProcessedMI;
		private System.Windows.Forms.MenuItem PlaybackRawMI;
		private System.Windows.Forms.MenuItem SubscribeProcessedMI;
		private System.Windows.Forms.MenuItem PlaybackProcessedMI;
		private System.Windows.Forms.MenuItem Separator02;
		private System.Windows.Forms.MenuItem Separator03;
		private System.Windows.Forms.MenuItem Separator04;
		private System.Windows.Forms.MenuItem SubscribeRawMI;
		private System.Windows.Forms.MenuItem Separator05;
		private System.Windows.Forms.MenuItem SubscribeCancelMI;
		private System.Windows.Forms.MenuItem PlaybackCancelMI;
		private System.Windows.Forms.MenuItem UseAsyncMI;
		private System.Windows.Forms.MenuItem Separator06;
		private System.Windows.Forms.MenuItem InsertAnnotationsMI;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TrendTreeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			TrendTV.ImageList = Resources.Instance.ImageList;
			Clear();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
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
			this.TrendTV = new System.Windows.Forms.TreeView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.AddTrendMI = new System.Windows.Forms.MenuItem();
			this.EditTrendMI = new System.Windows.Forms.MenuItem();
			this.RemoveTrendMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.AddItemsMI = new System.Windows.Forms.MenuItem();
			this.EditItemMI = new System.Windows.Forms.MenuItem();
			this.RemoveItemMI = new System.Windows.Forms.MenuItem();
			this.Separator02 = new System.Windows.Forms.MenuItem();
			this.UseAsyncMI = new System.Windows.Forms.MenuItem();
			this.Separator03 = new System.Windows.Forms.MenuItem();
			this.ReadRawMI = new System.Windows.Forms.MenuItem();
			this.ReadProcessedMI = new System.Windows.Forms.MenuItem();
			this.ReadModifiedMI = new System.Windows.Forms.MenuItem();
			this.ReadAtTimeMI = new System.Windows.Forms.MenuItem();
			this.ReadAttributesMI = new System.Windows.Forms.MenuItem();
			this.ReadAnnotationsMI = new System.Windows.Forms.MenuItem();
			this.Separator04 = new System.Windows.Forms.MenuItem();
			this.InsertMI = new System.Windows.Forms.MenuItem();
			this.InsertReplaceMI = new System.Windows.Forms.MenuItem();
			this.ReplaceMI = new System.Windows.Forms.MenuItem();
			this.DeleteRawMI = new System.Windows.Forms.MenuItem();
			this.DeleteAtTimeMI = new System.Windows.Forms.MenuItem();
			this.InsertAnnotationsMI = new System.Windows.Forms.MenuItem();
			this.Separator05 = new System.Windows.Forms.MenuItem();
			this.SubscribeRawMI = new System.Windows.Forms.MenuItem();
			this.SubscribeProcessedMI = new System.Windows.Forms.MenuItem();
			this.SubscribeCancelMI = new System.Windows.Forms.MenuItem();
			this.Separator06 = new System.Windows.Forms.MenuItem();
			this.PlaybackRawMI = new System.Windows.Forms.MenuItem();
			this.PlaybackProcessedMI = new System.Windows.Forms.MenuItem();
			this.PlaybackCancelMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// TrendTV
			// 
			this.TrendTV.ContextMenu = this.PopupMenu;
			this.TrendTV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TrendTV.ImageIndex = -1;
			this.TrendTV.Location = new System.Drawing.Point(0, 0);
			this.TrendTV.Name = "TrendTV";
			this.TrendTV.SelectedImageIndex = -1;
			this.TrendTV.Size = new System.Drawing.Size(400, 400);
			this.TrendTV.TabIndex = 0;
			this.TrendTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrendTV_MouseDown);
			this.TrendTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrendTV_AfterSelect);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddTrendMI,
																					  this.EditTrendMI,
																					  this.RemoveTrendMI,
																					  this.Separator01,
																					  this.AddItemsMI,
																					  this.EditItemMI,
																					  this.RemoveItemMI,
																					  this.Separator02,
																					  this.UseAsyncMI,
																					  this.Separator03,
																					  this.ReadRawMI,
																					  this.ReadProcessedMI,
																					  this.ReadModifiedMI,
																					  this.ReadAtTimeMI,
																					  this.ReadAttributesMI,
																					  this.ReadAnnotationsMI,
																					  this.Separator04,
																					  this.InsertMI,
																					  this.InsertReplaceMI,
																					  this.ReplaceMI,
																					  this.DeleteRawMI,
																					  this.DeleteAtTimeMI,
																					  this.InsertAnnotationsMI,
																					  this.Separator05,
																					  this.SubscribeRawMI,
																					  this.SubscribeProcessedMI,
																					  this.SubscribeCancelMI,
																					  this.Separator06,
																					  this.PlaybackRawMI,
																					  this.PlaybackProcessedMI,
																					  this.PlaybackCancelMI});
			// 
			// AddTrendMI
			// 
			this.AddTrendMI.Index = 0;
			this.AddTrendMI.Text = "&Add Trend...";
			this.AddTrendMI.Click += new System.EventHandler(this.AddTrendMI_Click);
			// 
			// EditTrendMI
			// 
			this.EditTrendMI.Index = 1;
			this.EditTrendMI.Text = "&Edit Trend...";
			this.EditTrendMI.Click += new System.EventHandler(this.EditTrendMI_Click);
			// 
			// RemoveTrendMI
			// 
			this.RemoveTrendMI.Index = 2;
			this.RemoveTrendMI.Text = "&Remove Trend";
			this.RemoveTrendMI.Click += new System.EventHandler(this.RemoveTrendMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 3;
			this.Separator01.Text = "-";
			// 
			// AddItemsMI
			// 
			this.AddItemsMI.Index = 4;
			this.AddItemsMI.Text = "&Add Items...";
			this.AddItemsMI.Click += new System.EventHandler(this.AddItemsMI_Click);
			// 
			// EditItemMI
			// 
			this.EditItemMI.Index = 5;
			this.EditItemMI.Text = "&Edit Item...";
			this.EditItemMI.Click += new System.EventHandler(this.EditItemMI_Click);
			// 
			// RemoveItemMI
			// 
			this.RemoveItemMI.Index = 6;
			this.RemoveItemMI.Text = "&Remove Item";
			this.RemoveItemMI.Click += new System.EventHandler(this.RemoveItemMI_Click);
			// 
			// Separator02
			// 
			this.Separator02.Index = 7;
			this.Separator02.Text = "-";
			// 
			// UseAsyncMI
			// 
			this.UseAsyncMI.Index = 8;
			this.UseAsyncMI.Text = "Asynchronous";
			this.UseAsyncMI.Click += new System.EventHandler(this.UseAsyncMI_Click);
			// 
			// Separator03
			// 
			this.Separator03.Index = 9;
			this.Separator03.Text = "-";
			// 
			// ReadRawMI
			// 
			this.ReadRawMI.Index = 10;
			this.ReadRawMI.Text = "&Read Raw...";
			this.ReadRawMI.Click += new System.EventHandler(this.ReadRawMI_Click);
			// 
			// ReadProcessedMI
			// 
			this.ReadProcessedMI.Index = 11;
			this.ReadProcessedMI.Text = "Read Processed...";
			this.ReadProcessedMI.Click += new System.EventHandler(this.ReadProcessedMI_Click);
			// 
			// ReadModifiedMI
			// 
			this.ReadModifiedMI.Index = 12;
			this.ReadModifiedMI.Text = "Read &Modified...";
			this.ReadModifiedMI.Click += new System.EventHandler(this.ReadModifiedMI_Click);
			// 
			// ReadAtTimeMI
			// 
			this.ReadAtTimeMI.Index = 13;
			this.ReadAtTimeMI.Text = "Read At &Time...";
			this.ReadAtTimeMI.Click += new System.EventHandler(this.ReadAtTimeMI_Click);
			// 
			// ReadAttributesMI
			// 
			this.ReadAttributesMI.Index = 14;
			this.ReadAttributesMI.Text = "Read &Attributes...";
			this.ReadAttributesMI.Click += new System.EventHandler(this.ReadAttributesMI_Click);
			// 
			// ReadAnnotationsMI
			// 
			this.ReadAnnotationsMI.Index = 15;
			this.ReadAnnotationsMI.Text = "Read A&nnotations...";
			this.ReadAnnotationsMI.Click += new System.EventHandler(this.ReadAnnotationsMI_Click);
			// 
			// Separator04
			// 
			this.Separator04.Index = 16;
			this.Separator04.Text = "-";
			// 
			// InsertMI
			// 
			this.InsertMI.Index = 17;
			this.InsertMI.Text = "&Insert...";
			this.InsertMI.Click += new System.EventHandler(this.InsertMI_Click);
			// 
			// InsertReplaceMI
			// 
			this.InsertReplaceMI.Index = 18;
			this.InsertReplaceMI.Text = "I&nsert/Replace...";
			this.InsertReplaceMI.Click += new System.EventHandler(this.InsertReplaceMI_Click);
			// 
			// ReplaceMI
			// 
			this.ReplaceMI.Index = 19;
			this.ReplaceMI.Text = "&Replace...";
			this.ReplaceMI.Click += new System.EventHandler(this.ReplaceMI_Click);
			// 
			// DeleteRawMI
			// 
			this.DeleteRawMI.Index = 20;
			this.DeleteRawMI.Text = "&Delete...";
			this.DeleteRawMI.Click += new System.EventHandler(this.DeleteRawMI_Click);
			// 
			// DeleteAtTimeMI
			// 
			this.DeleteAtTimeMI.Index = 21;
			this.DeleteAtTimeMI.Text = "Delete At &Time...";
			this.DeleteAtTimeMI.Click += new System.EventHandler(this.DeleteAtTimeMI_Click);
			// 
			// InsertAnnotationsMI
			// 
			this.InsertAnnotationsMI.Index = 22;
			this.InsertAnnotationsMI.Text = "Insert Annotations...";
			this.InsertAnnotationsMI.Click += new System.EventHandler(this.InsertAnnotationsMI_Click);
			// 
			// Separator05
			// 
			this.Separator05.Index = 23;
			this.Separator05.Text = "-";
			// 
			// SubscribeRawMI
			// 
			this.SubscribeRawMI.Index = 24;
			this.SubscribeRawMI.Text = "Subscribe Raw...";
			this.SubscribeRawMI.Click += new System.EventHandler(this.SubscribeRawMI_Click);
			// 
			// SubscribeProcessedMI
			// 
			this.SubscribeProcessedMI.Index = 25;
			this.SubscribeProcessedMI.Text = "Subscribe Processed...";
			this.SubscribeProcessedMI.Click += new System.EventHandler(this.SubscribeProcessedMI_Click);
			// 
			// SubscribeCancelMI
			// 
			this.SubscribeCancelMI.Index = 26;
			this.SubscribeCancelMI.Text = "Cancel Subscription";
			this.SubscribeCancelMI.Click += new System.EventHandler(this.SubscribeCancelMI_Click);
			// 
			// Separator06
			// 
			this.Separator06.Index = 27;
			this.Separator06.Text = "-";
			// 
			// PlaybackRawMI
			// 
			this.PlaybackRawMI.Index = 28;
			this.PlaybackRawMI.Text = "Playback Raw...";
			this.PlaybackRawMI.Click += new System.EventHandler(this.PlaybackRawMI_Click);
			// 
			// PlaybackProcessedMI
			// 
			this.PlaybackProcessedMI.Index = 29;
			this.PlaybackProcessedMI.Text = "Playback Processed...";
			this.PlaybackProcessedMI.Click += new System.EventHandler(this.PlaybackProcessedMI_Click);
			// 
			// PlaybackCancelMI
			// 
			this.PlaybackCancelMI.Index = 30;
			this.PlaybackCancelMI.Text = "Cancel Playback";
			this.PlaybackCancelMI.Click += new System.EventHandler(this.PlaybackCancelMI_Click);
			// 
			// TrendTreeCtrl
			// 
			this.Controls.Add(this.TrendTV);
			this.Name = "TrendTreeCtrl";
			this.Size = new System.Drawing.Size(400, 400);
			this.ResumeLayout(false);

		}
		#endregion
				
		#region Public Interface
		/// <summary>
		/// Called when new data is read for a trend.
		/// </summary>
		public delegate void TrendChangedEventHandler(TsCHdaTrend trend, TsCHdaItemValueCollection[] values, bool replace);

		/// <summary>
		/// Fired when new data is read for a trend.
		/// </summary>
		public event TrendChangedEventHandler TrendChanged;

		/// <summary>
		/// Called when a trend or item is selected in the tree.
		/// </summary>
		public delegate void TrendSelectedEventHandler(TsCHdaTrend trend, TsCHdaItem item);

		/// <summary>
		/// Fired when a trend or item is selected in the tree.
		/// </summary>
		public event TrendSelectedEventHandler TrendSelected;

		/// <summary>
		/// Initializes the control with the specified HDA server.
		/// </summary>
		public void Initialize(TsCHdaServer server)
		{
			m_server = server;

			Clear();

			// nothing more to do server is null.
			if (server == null)
			{
				return;
			}
						
			// create the root node.
            TreeNode root = new TreeNode(server.ServerName);
			root.ImageIndex         = Resources.IMAGE_LOCAL_SERVER;
			root.SelectedImageIndex = Resources.IMAGE_LOCAL_SERVER;
			root.Tag                = server;

			// add the current set of items.
			foreach (TsCHdaTrend trend in server.Trends)
			{
				AddTrend(root, trend, false);
			}

			// add new node to tree view.
			TrendTV.Nodes.Add(root);	
			root.Expand();
		}

		/// <summary>
		/// Removes all nodes and releases all resources.
		/// </summary>
		public void Clear()
		{		
			// recursively searches the tree and free objects.
			foreach (TreeNode child in TrendTV.Nodes)
			{
				Clear(child);
			}

			// clear the tree.
			TrendTV.Nodes.Clear();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// The server which is the source for the trend data.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Adds a trend to the tree view.
		/// </summary>
		private void AddTrend(TreeNode parent, TsCHdaTrend trend, bool expand)
		{
			TreeNode node = new TreeNode(trend.Name);

			node.ImageIndex         = Resources.IMAGE_LIST_BOX;
			node.SelectedImageIndex = Resources.IMAGE_LIST_BOX;
			node.Tag                = trend;

			foreach (TsCHdaItem item in trend.Items)
			{
				AddItem(node, item);
			}

			parent.Nodes.Add(node);

			// ensure items are visible.
			if (expand)
			{
				node.Expand();
			}
		}

		/// <summary>
		/// Adds an item to the tree view.
		/// </summary>
		private void AddItem(TreeNode parent, TsCHdaItem item)
		{
			TreeNode node = new TreeNode();

			node.ImageIndex         = Resources.IMAGE_YELLOW_SCROLL;
			node.SelectedImageIndex = Resources.IMAGE_YELLOW_SCROLL;

			UpdateItem(node, item);

			parent.Nodes.Add(node);
		}

		/// <summary>
		/// Sets the text of the trend node.
		/// </summary>
		private void UpdateTrend(TreeNode node, TsCHdaTrend trend, TsCHdaItemValueCollection[] values)
		{
			node.Text = trend.Name;
			node.Tag  = trend;

			// update cache entries for all trend items.
			if (TrendChanged != null)
			{
				TrendChanged(trend, values, true);
			}
		}

		/// <summary>
		/// Sets the text of the item node.
		/// </summary>
		private void UpdateItem(TreeNode node, TsCHdaItem item)
		{
			TsCHdaAggregate aggregate = m_server.Aggregates.Find(item.Aggregate);

			if (aggregate != null)
			{
				node.Text = String.Format("{0} ({1})", item.ItemName, aggregate.Name);
			}
			else
			{
				node.Text = item.ItemName;
			}

			node.Tag = item;
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
		}

		/// <summary>
		/// Checks is the node is a server node.
		/// </summary>
		private bool IsServerNode(TreeNode node)
		{
			if (node != null)
			{
				if (typeof(TsCHdaServer).IsInstanceOfType(node.Tag))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Checks is the node is a trend node.
		/// </summary>
		private bool IsTrendNode(TreeNode node)
		{
			if (node != null)
			{
				if (typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Checks is the node is an item node.
		/// </summary>
		private bool IsItemNode(TreeNode node)
		{
			if (node != null)
			{
				if (typeof(TsCHdaItem).IsInstanceOfType(node.Tag))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Handles an operation on a server node.
		/// </summary>
		private void HandleRequest(TsCHdaServer server, RequestType type)
		{
			switch (type)
			{
				case RequestType.ReadRaw:
				case RequestType.ReadProcessed:
				case RequestType.ReadModified:
				case RequestType.ReadAtTime:
				{
					new ReadValuesDlg().ShowDialog(server, type, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.ReadAttributes:
				{
					new ReadAttributesDlg().ShowDialog(m_server, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.ReadAnnotations:
				{
					new ReadAnnotationsDlg().ShowDialog(m_server, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.InsertAnnotations:
				{
					new InsertAnnotationsDlg().ShowDialog(m_server, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.Insert:
				{
					new InsertValuesDlg().ShowDialog(m_server, false, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.InsertReplace:
				{
					new InsertValuesDlg().ShowDialog(m_server, true, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.Replace:
				{
					new ReplaceValuesDlg().ShowDialog(m_server, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.DeleteRaw:
				case RequestType.DeleteAtTime:
				{
					new DeleteValuesDlg().ShowDialog(m_server, type, !UseAsyncMI.Checked);
					break;
				}
			}
		}

		/// <summary>
		/// Handles an operation on n trend node.
		/// </summary>
		private void HandleRequest(TsCHdaTrend trend, RequestType type)
		{
			// used only if the request reads a new data set from the server.
			TsCHdaItemValueCollection[] results = null;
			
			// dispatch request.
			switch (type)
			{
				case RequestType.ReadRaw:
				case RequestType.ReadProcessed:
				case RequestType.ReadModified:
				case RequestType.ReadAtTime:
				{
					results = new ReadValuesDlg().ShowDialog(trend, type, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.AdviseRaw:
				case RequestType.AdviseProcessed:
				{
					// prompt user to specified subscription parameters.
					if (!new SubscriptionEditDlg().ShowDialog(trend, type))
					{
						return;
					}

					// create a subscription.
					trend.Subscribe(trend, new TsCHdaDataUpdateEventHandler(OnDataChanged));

					// clear cached results.
					if (TrendChanged != null)
					{
						TrendChanged(trend, null, true);
					}
                    
					// all done.
					break;
				}

				case RequestType.PlaybackRaw:
				case RequestType.PlaybackProcessed:
				{
					// prompt user to specified subscription parameters.
					if (!new SubscriptionEditDlg().ShowDialog(trend, type))
					{
						return;
					}

					// create a subscription.
					trend.Playback(trend, new TsCHdaDataUpdateEventHandler(OnDataChanged));

					// clear cached results.
					if (TrendChanged != null)
					{
						TrendChanged(trend, null, true);
					}
                    
					// all done.
					break;
				}

				case RequestType.ReadAnnotations:
				{
					new ReadAnnotationsDlg().ShowDialog(trend, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.DeleteRaw:
				case RequestType.DeleteAtTime:
				{
					if (new DeleteValuesDlg().ShowDialog(trend, type, !UseAsyncMI.Checked) != null)
					{
						results = trend.ReadRaw();
					}

					break;
				}
			}

			// send notification that the trend data set changed.
			if (results != null)
			{
				if (TrendChanged != null)
				{
					TrendChanged(trend, results, true);
				}
			}
		}

		/// <summary>
		/// Handles an operation on an item node.
		/// </summary>
		private void HandleRequest(TsCHdaTrend trend, TsCHdaItem item, RequestType type)
		{
			// used only if the request reads a new data set from the server.
			TsCHdaItemValueCollection[] results = null;
			
			// dispatch request.
			switch (type)
			{
				case RequestType.ReadRaw:
				{
					results = trend.ReadRaw(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadProcessed:
				{
					results = trend.ReadProcessed(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadModified:
				{
					results = trend.ReadModified(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadAtTime:
				{
					results = trend.ReadAtTime(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.ReadAttributes:
				{
					new ReadAttributesDlg().ShowDialog(
						m_server,
						item,
						trend.StartTime,
						trend.EndTime,
						!UseAsyncMI.Checked);

					break;
				}

				case RequestType.ReadAnnotations:
				{
					trend.ReadAnnotations(new TsCHdaItem[] { item });
					break;
				}

				case RequestType.InsertAnnotations:
				{
					new InsertAnnotationsDlg().ShowDialog(m_server, item, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.Insert:
				{
					new InsertValuesDlg().ShowDialog(m_server, item, false, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.InsertReplace:
				{
					new InsertValuesDlg().ShowDialog(m_server, item, true, !UseAsyncMI.Checked);
					break;
				}

				case RequestType.Replace:
				{
					new ReplaceValuesDlg().ShowDialog(m_server, item, !UseAsyncMI.Checked);
					break;
				}
			}

			// send notification that the trend data set changed.
			if (results != null)
			{
				if (TrendChanged != null)
				{
					TrendChanged(trend, results, true);
				}
			}
		}

		/// <summary>
		/// Called when new data arrives from the server.
		/// </summary>
		public void OnDataChanged(IOpcRequest request, TsCHdaItemValueCollection[] results)
		{	
			// check if control has closed.
			if (IsDisposed)
			{
				return;
			}
			
			// check if invoke is required.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCHdaDataUpdateEventHandler(OnDataChanged), new object[] { request, results });
				return;
			}
			
			try
			{
				// send notification that the trend data set changed.
				if (results != null)
				{
					// check if a playback request has completed.
					TsCHdaTrend trend = (TsCHdaTrend)request.Handle;

					if (trend != null)
					{
						if (trend.PlaybackActive)
						{
							// check if any data came back for any item.
							bool done = true;

							foreach (TsCHdaItemValueCollection result in results)
							{
								if (result.Count > 0)
								{
									done = false;
									break;
								}
							}

							// cancel the playback request and return.
							if (done)
							{
								trend.PlaybackCancel();
								return;
							}
						}
					}

					// send notification.
					if (TrendChanged != null)
					{
						TrendChanged(trend, results, false);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		/// <summary>
		/// Updates the state of context menus based on the current selection.
		/// </summary>
		private void TrendTV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// selects the item that was right clicked on.
			TreeNode clickedNode = TrendTV.GetNodeAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedNode == null) return;

			// force selection to clicked node.
			TrendTV.SelectedNode = clickedNode;

			// disable everything.
			AddTrendMI.Enabled           = false;
			EditTrendMI.Enabled          = false;
			RemoveTrendMI.Enabled        = false;
			AddItemsMI.Enabled           = false;
			EditItemMI.Enabled           = false;
			RemoveItemMI.Enabled         = false;
			ReadRawMI.Enabled            = false;
			ReadProcessedMI.Enabled      = false;
			ReadAtTimeMI.Enabled         = false;
			ReadModifiedMI.Enabled       = false;
			ReadAttributesMI.Enabled     = false;
			ReadAnnotationsMI.Enabled    = false;
			InsertAnnotationsMI.Enabled  = false;
			InsertMI.Enabled             = false;
			InsertReplaceMI.Enabled      = false;
			ReplaceMI.Enabled            = false;
			DeleteRawMI.Enabled          = false;
			DeleteAtTimeMI.Enabled       = false;
			SubscribeRawMI.Enabled       = false;
			SubscribeProcessedMI.Enabled = false;
			SubscribeCancelMI.Enabled    = false;
			PlaybackRawMI.Enabled        = false;
			PlaybackProcessedMI.Enabled  = false;
			PlaybackCancelMI.Enabled     = false;


			// setup menu for server nodes.
			if (typeof(TsCHdaServer).IsInstanceOfType(clickedNode.Tag))
			{
				AddTrendMI.Enabled           = true;
				ReadRawMI.Enabled            = true;
				ReadProcessedMI.Enabled      = true;
				ReadAtTimeMI.Enabled         = true;
				ReadModifiedMI.Enabled       = true;
				ReadAttributesMI.Enabled     = true;
				ReadAnnotationsMI.Enabled    = true;		
				InsertAnnotationsMI.Enabled  = true;	
				InsertMI.Enabled             = true;
				InsertReplaceMI.Enabled      = true;
				ReplaceMI.Enabled            = true;
				DeleteRawMI.Enabled          = true;
				DeleteAtTimeMI.Enabled       = true;
                return;
			}

			// setup menu for trend nodes.
			if (typeof(TsCHdaTrend).IsInstanceOfType(clickedNode.Tag))
			{
				TsCHdaTrend trend = (TsCHdaTrend)clickedNode.Tag;

				EditTrendMI.Enabled          = true;
				RemoveTrendMI.Enabled        = true;
				AddItemsMI.Enabled           = true;
				ReadRawMI.Enabled            = true;
				ReadProcessedMI.Enabled      = true;
				ReadAtTimeMI.Enabled         = true;
				ReadModifiedMI.Enabled       = true;
				ReadAttributesMI.Enabled     = true;
				ReadAnnotationsMI.Enabled    = true;		
				InsertAnnotationsMI.Enabled  = false;
				InsertMI.Enabled             = false;
				InsertReplaceMI.Enabled      = false;
				ReplaceMI.Enabled            = false;
				DeleteRawMI.Enabled          = true;
				DeleteAtTimeMI.Enabled       = true;
				SubscribeRawMI.Enabled       = !trend.SubscriptionActive && !trend.PlaybackActive;
				SubscribeProcessedMI.Enabled = !trend.SubscriptionActive && !trend.PlaybackActive;
				SubscribeCancelMI.Enabled    = trend.SubscriptionActive;
				PlaybackRawMI.Enabled        = !trend.SubscriptionActive && !trend.PlaybackActive;
				PlaybackProcessedMI.Enabled  = !trend.SubscriptionActive && !trend.PlaybackActive;
				PlaybackCancelMI.Enabled     = trend.PlaybackActive;
				return;
			}

			// setup menu for item nodes.
			if (typeof(TsCHdaItem).IsInstanceOfType(clickedNode.Tag))
			{
				EditItemMI.Enabled           = true;
				RemoveItemMI.Enabled         = true;
				ReadRawMI.Enabled            = true;
				ReadProcessedMI.Enabled      = true;
				ReadAtTimeMI.Enabled         = true;
				ReadModifiedMI.Enabled       = true;
				ReadAttributesMI.Enabled     = true;
				ReadAnnotationsMI.Enabled    = true;
				InsertAnnotationsMI.Enabled  = true;
				InsertMI.Enabled             = true;
				InsertReplaceMI.Enabled      = true;
				ReplaceMI.Enabled            = true;
				DeleteRawMI.Enabled          = false;
				DeleteAtTimeMI.Enabled       = false;
				return;
			}			
		}	

		/// <summary>
		/// Fires events indicating trends or items have been selected.  
		/// </summary>
		private void TrendTV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				// check for regisitered sinks.
				if (TrendSelected == null)
				{
					return;
				}

				// check type of selection.
				if (TrendTV.SelectedNode != null)
				{
					object selection = TrendTV.SelectedNode.Tag;

					if (typeof(TsCHdaTrend).IsInstanceOfType(selection))
					{
						TrendSelected((TsCHdaTrend)selection, null);
						return;
					}

					if (typeof(TsCHdaItem).IsInstanceOfType(selection))
					{
						TrendSelected((TsCHdaTrend)TrendTV.SelectedNode.Parent.Tag, (TsCHdaItem)selection);
						return;
					}
				}
					
				// nothing of interest selected.
				TrendSelected(null, null);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		#region Trend Event Handlers
		/// <summary>
		/// Adds a new trend to the control.
		/// </summary>
		private void AddTrendMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = TrendTV.SelectedNode;

				if (node == null || !typeof(TsCHdaServer).IsInstanceOfType(node.Tag))
				{
					return;
				}	

				// create trend.
				TsCHdaTrend trend = new TrendCreateDlg().ShowDialog(m_server);

				if (trend == null)
				{
					return;
				}

				// add trend to server.
				m_server.Trends.Add(trend);

				// add trend to tree.
				AddTrend(node, trend, true);

				// ensure new node is visible.
				node.Expand();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}		

		/// <summary>
		/// Edits the parameters of a trend.
		/// </summary>
		private void EditTrendMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = TrendTV.SelectedNode;

				if (node == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// edit trend.
				TsCHdaTrend trend = (TsCHdaTrend)node.Tag;
				
				if (!new TrendEditDlg().ShowDialog(trend))
				{
					return;
				}

				// update display.
				UpdateTrend(node, trend, null);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes a trend from the control.
		/// </summary>
		private void RemoveTrendMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = TrendTV.SelectedNode;

				if (node == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return;
				}

				TsCHdaTrend trend = (TsCHdaTrend)node.Tag;

				// release item server handles.
				OpcItem[] itemIDs = new OpcItem[trend.Items.Count];

				for (int ii = 0; ii < itemIDs.Length; ii++)
				{
					itemIDs[ii] = new OpcItem(trend.Items[ii]);
				}

				m_server.ReleaseItems(itemIDs);

				// remove trend.
				m_server.Trends.Remove(trend);

				// remove node.
				node.Remove();

				// send notification.
				if (TrendChanged != null)
				{
					TrendChanged(trend, null, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Adds new items to the control.
		/// </summary>
		private void AddItemsMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = TrendTV.SelectedNode;

				if (node == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Tag))
				{
					return;
				}	

				// create trend.
				TsCHdaTrend trend = (TsCHdaTrend)node.Tag;

				OpcItem[] items = new TrendCreateDlg().ShowDialog(trend);

				if (items == null)
				{
					return;
				}

				// add items to control.
				node.Nodes.Clear();

				foreach (TsCHdaItem item in trend.Items)
				{
					AddItem(node, item);
				}

				// ensure new node is visible.
				node.Expand();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}		

		/// <summary>
		/// Edits a item in a trend.
		/// </summary>
		private void EditItemMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// verify selection.
				TreeNode node = TrendTV.SelectedNode;

				if (node == null || !typeof(TsCHdaItem).IsInstanceOfType(node.Tag))
				{
					return;
				}

				// prompt user to edit the item.
				TsCHdaItem item = (TsCHdaItem)node.Tag;

				if (new ItemEditDlg().ShowDialog(m_server, item))
				{
					UpdateItem(node, item);
				}

				TsCHdaTrend trend = (TsCHdaTrend)node.Parent.Tag;

				// update the cache with the new values.
				if (TrendChanged != null)
				{
					TrendChanged(trend, trend.Read(), true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes an item from a trend.
		/// </summary>
		private void RemoveItemMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				// verify selection.
				TreeNode node = TrendTV.SelectedNode;

				if (node == null || !typeof(TsCHdaItem).IsInstanceOfType(node.Tag))
				{
					return;
				}

				if (node.Parent == null || !typeof(TsCHdaTrend).IsInstanceOfType(node.Parent.Tag))
				{
					return;
				}

				// remove item from trend.
				TsCHdaTrend trend = (TsCHdaTrend)node.Parent.Tag;

				trend.RemoveItem((TsCHdaItem)node.Tag);

				// remove node.
				node.Remove();

				// send notification to clear cache.
				if (TrendChanged != null)
				{
					TrendChanged(trend, null, true);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Toggles between synchronous and asynchronous communications.
		/// </summary>
		private void UseAsyncMI_Click(object sender, System.EventArgs e)
		{
			UseAsyncMI.Checked = !UseAsyncMI.Checked;
		}
		#endregion

		#region Read Event Handlers
		/// <summary>
		/// Reads raw values for a trend.
		/// </summary>
		private void ReadRawMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadRaw);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadRaw);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Reads processed values for a trend.
		/// </summary>
		private void ReadProcessedMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadProcessed);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadProcessed);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadProcessed);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Reads the modified values for a trend within the specified interval.
		/// </summary>
		private void ReadModifiedMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadModified);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadModified);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadModified);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Reads the values for a trend at the specified times.
		/// </summary>
		private void ReadAtTimeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadAtTime);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadAtTime);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadAtTime);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Reads the attributes for an item within the specified interval.
		/// </summary>
		private void ReadAttributesMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadAttributes);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadAttributes);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Reads the annotations for a trend within the specified interval.
		/// </summary>
		private void ReadAnnotationsMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.ReadAnnotations);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.ReadAnnotations);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.ReadAnnotations);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		#region Update Event Handlers
		/// <summary>
		/// Prompts the user to insert new values for an item.
		/// </summary>
		private void InsertMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.Insert);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.Insert);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.Insert);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to insert or replace values for an item.
		/// </summary>
		private void InsertReplaceMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.InsertReplace);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.InsertReplace);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.InsertReplace);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to replace existing values for an item.
		/// </summary>
		private void ReplaceMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.Replace);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.Replace);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.Replace);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to delete existing values for an item.
		/// </summary>
		private void DeleteAtTimeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.DeleteAtTime);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.DeleteAtTime);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.DeleteAtTime);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to delete existing values for an item.
		/// </summary>
		private void DeleteRawMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.DeleteRaw);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.DeleteRaw);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.DeleteRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to insert annotations for an item.
		/// </summary>
		private void InsertAnnotationsMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsServerNode(node))
				{
					HandleRequest((TsCHdaServer)node.Tag, RequestType.InsertAnnotations);
					return;
				}

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.InsertAnnotations);
					return;
				}

				if (IsItemNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Parent.Tag, (TsCHdaItem)node.Tag, RequestType.InsertAnnotations);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		#region Subscribe Event Handlers
		/// <summary>
		/// Creates or modifies a subscription for raw values.
		/// </summary>
		private void SubscribeRawMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.AdviseRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Creates or modifies a subscription for processed values.
		/// </summary>
		private void SubscribeProcessedMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.AdviseProcessed);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Cancels an existing subscription.
		/// </summary>
		private void SubscribeCancelMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					((TsCHdaTrend)node.Tag).SubscribeCancel();
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion

		#region Playback Event Handlers
		/// <summary>
		/// Creates or modifies a playback request for raw values.
		/// </summary>
		private void PlaybackRawMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.PlaybackRaw);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Creates or modifies a playback request for processed values.
		/// </summary>
		private void PlaybackProcessedMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					HandleRequest((TsCHdaTrend)node.Tag, RequestType.PlaybackProcessed);
					return;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Cancels an existing playback request.
		/// </summary>
		private void PlaybackCancelMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				TreeNode node = TrendTV.SelectedNode;

				if (IsTrendNode(TrendTV.SelectedNode))
				{
					((TsCHdaTrend)node.Tag).PlaybackCancel();
					return;
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
