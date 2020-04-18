//============================================================================
// TITLE: ItemListCtrl.cs
//
// CONTENTS:
// 
// A control used to display a list of server items.
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
// 2003/12/30 RSA   Initial implementation.

using System;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// A control used to display a list of item properties.
	/// </summary>
	public class TrendItemsCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ItemsLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem CopyDataMI;
		private System.Windows.Forms.MenuItem Separator01;
		private System.Windows.Forms.MenuItem AddMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem RemoveMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TrendItemsCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			ItemsLV.SmallImageList = Resources.Instance.ImageList;
			SetColumns(ColumnNames);
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ItemsLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.AddMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.CopyDataMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// ItemsLV
			// 
			this.ItemsLV.ContextMenu = this.PopupMenu;
			this.ItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemsLV.FullRowSelect = true;
			this.ItemsLV.Location = new System.Drawing.Point(0, 0);
			this.ItemsLV.MultiSelect = false;
			this.ItemsLV.Name = "ItemsLV";
			this.ItemsLV.Size = new System.Drawing.Size(432, 272);
			this.ItemsLV.TabIndex = 0;
			this.ItemsLV.View = System.Windows.Forms.View.Details;
			this.ItemsLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemsLV_MouseDown);
			this.ItemsLV.DoubleClick += new System.EventHandler(this.ItemsLV_DoubleClick);
			this.ItemsLV.SelectedIndexChanged += new System.EventHandler(this.ItemsLV_SelectedIndexChanged);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddMI,
																					  this.EditMI,
																					  this.RemoveMI,
																					  this.Separator01,
																					  this.CopyDataMI});
			// 
			// AddMI
			// 
			this.AddMI.Index = 0;
			this.AddMI.Text = "Add...";
			this.AddMI.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// EditMI
			// 
			this.EditMI.Index = 1;
			this.EditMI.Text = "Edit...";
			this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// RemoveMI
			// 
			this.RemoveMI.Index = 2;
			this.RemoveMI.Text = "Remove...";
			this.RemoveMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 3;
			this.Separator01.Text = "-";
			// 
			// CopyDataMI
			// 
			this.CopyDataMI.Index = 4;
			this.CopyDataMI.Text = "Copy Data...";
			this.CopyDataMI.Click += new System.EventHandler(this.CopyDataMI_Click);
			// 
			// TrendItemsCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.ItemsLV);
			this.Name = "TrendItemsCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// A delegate to receive item picked events.
		/// </summary>
		public delegate void ItemPickedEventHandler(TsCHdaItem[] items);

		/// <summary>
		/// Fired when one or more items are explicitly picked within the tree control.
		/// </summary>
		public event ItemPickedEventHandler ItemPicked;

		/// <summary>
		/// A delegate to receive item selected events.
		/// </summary>
		public delegate void ItemSelectedEventHandler(TsCHdaItem item);

		/// <summary>
		/// Fired when an item node is selected in the tree.
		/// </summary>
		public event ItemSelectedEventHandler ItemSelected;

		/// <summary>
		/// Initializes the control with the set of items in a trend.
		/// </summary>
		public void Initialize(TsCHdaTrend trend, bool update, ArrayList excludeList)
		{
			if (trend == null) throw new ArgumentNullException("trend");

			m_trend = trend;

			ItemsLV.Items.Clear();
			
			// add trend items.
			foreach (TsCHdaItem item in trend.Items)
			{
				// ignore items in the exclude list.
				if (excludeList != null)
				{
					if (excludeList.Contains(item))
					{
						continue;
					}
				}

				// create empty item value collections for each item.
				if (update)
				{
					AddListItem(new TsCHdaItemValueCollection(item));
				}
				else
				{
					AddListItem(item);
				}
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Returns the set of items stored in the list control.
		/// </summary>
		public TsCHdaItem[] GetItems(bool selected)
		{
			// fetch objects from list view.
			ArrayList items = new ArrayList(ItemsLV.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in ItemsLV.SelectedItems)
				{
					if (typeof(TsCHdaItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in ItemsLV.Items)
				{
					if (typeof(TsCHdaItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (TsCHdaItem[])items.ToArray(typeof(TsCHdaItem));
		}

		/// <summary>
		/// Returns the set of values stored in the list control.
		/// </summary>
		public TsCHdaItemValueCollection[] GetValues(bool selected)
		{
			// fetch objects from list view.
			ArrayList items = new ArrayList(ItemsLV.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in ItemsLV.SelectedItems)
				{
					if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in ItemsLV.Items)
				{
					if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (TsCHdaItemValueCollection[])items.ToArray(typeof(TsCHdaItemValueCollection));
		}
		#endregion
        
		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ITEMID     = 0;
		private const int AGGREGATE  = 1;
		private const int NUM_VALUES = 2;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Item ID",
			"Aggregate",
			"Num Values"
		};
		
		/// <summary>
		/// The trend containing the items being displayed.
		/// </summary>
		private TsCHdaTrend m_trend = null;

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			ItemsLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				ItemsLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < ItemsLV.Columns.Count; ii++)
			{
				// always show the item id and value column.
				if (ii == ITEMID)
				{
					ItemsLV.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in ItemsLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						ItemsLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) ItemsLV.Columns[ii].Width = 0;
			}
		}
		
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(object item, int fieldID)
		{
			// item identifier.
			if (typeof(OpcItem).IsInstanceOfType(item))
			{
				if (fieldID == ITEMID)
				{
					return ((OpcItem)item).ItemName; 
				}
			}

			// item.
			if (typeof(TsCHdaItem).IsInstanceOfType(item))
			{
				if (fieldID == AGGREGATE)
				{
					int aggregateID = ((TsCHdaItem)item).Aggregate;

					if (aggregateID != TsCHdaAggregateID.NoAggregate)
					{
						return m_trend.Server.Aggregates.Find(aggregateID);
					}
				}
			}

			// item value collection.
			if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
			{
				if (fieldID == NUM_VALUES)
				{
					return ((TsCHdaItemValueCollection)item).Count; 
				}
			}

			// invalid field or type.
			return null;
		}	

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(OpcItem item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateListItem(listItem, item);
		
			// add to list view.
			ItemsLV.Items.Add(listItem);
		}

		/// <summary>
		/// Updates the columns of an item in the list view.
		/// </summary>
		private void UpdateListItem(ListViewItem listItem, object item)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ii));
			}

			// save object as list view item tag.
			listItem.Tag = item;
		}
		#endregion

		/// <summary>
		/// Adds an item that was previously removed from the list.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				bool update = false;

				// create a list of trend items that are already in the view.
				ArrayList excludeList = new ArrayList();

				foreach (ListViewItem listItem in ItemsLV.Items)
				{
					if (typeof(OpcItem).IsInstanceOfType(listItem.Tag))
					{
						TsCHdaItem item = m_trend.Items[(OpcItem)listItem.Tag];

						if (item != null)
						{
							excludeList.Add(item);
						}

						update = typeof(TsCHdaItemValueCollection).IsInstanceOfType(listItem.Tag);
					}
				}

				// prompt user to select items.
				TsCHdaItem[] items = new TrendSelectItemsDlg().ShowDialog(m_trend, excludeList);

				if (items == null)
				{
					return;
				}

				// add new items to the list view.
				foreach (TsCHdaItem item in items)
				{
					if (update)
					{
						AddListItem(new TsCHdaItemValueCollection(item));
					}
					else
					{
						AddListItem(item);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits an item from the list.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ItemsLV.SelectedItems.Count != 1)
				{
					return;
				}

				object item = ItemsLV.SelectedItems[0].Tag;

				// edit an item.
				if (typeof(TsCHdaItem).IsInstanceOfType(item))
				{
					if (new ItemEditDlg().ShowDialog(m_trend.Server, (TsCHdaItem)item))
					{
						UpdateListItem(ItemsLV.SelectedItems[0], item);
					}
				}

				// edit an item value collection.
				else if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
				{
					if (new ItemValuesDlg().ShowDialog(m_trend.Server, (TsCHdaItemValueCollection)item, false))
					{
						UpdateListItem(ItemsLV.SelectedItems[0], item);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes an item from the list.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// build list of items to remove.
				ArrayList items = new ArrayList(ItemsLV.SelectedItems.Count);

				foreach (ListViewItem item in ItemsLV.SelectedItems)
				{
					items.Add(item);
				}

				// remove selected items.
				foreach (ListViewItem item in items)
				{
					item.Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Initializes an item value collection by reading data from another item.
		/// </summary>
		private void CopyDataMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ItemsLV.SelectedItems.Count != 1)
				{
					return;
				}

				// must be an item value collection.
				object item = ItemsLV.SelectedItems[0].Tag;

				if (!typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
				{
					return;
				}

				// prompt user to select a collection to copy.
				TsCHdaItemValueCollection values = new ReadValuesDlg().ShowDialog(m_trend.Server, RequestType.ReadRaw, true);

				if (values != null)
				{
					// replace item identifier information.
					TsCHdaItemValueCollection existing = (TsCHdaItemValueCollection)item;

					values.ItemName     = existing.ItemName;
					values.ItemPath     = existing.ItemPath;
					values.ServerHandle = existing.ServerHandle;
					values.ClientHandle = existing.ClientHandle;

					// update list item.
					UpdateListItem(ItemsLV.SelectedItems[0], values);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void ItemsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			AddMI.Enabled      = ItemsLV.Items.Count < m_trend.Items.Count;
			EditMI.Enabled     = false;
			RemoveMI.Enabled   = false;
			CopyDataMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ItemsLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (ItemsLV.SelectedItems.Count == 1)
			{
				EditMI.Enabled     = true;
				RemoveMI.Enabled   = true;
				CopyDataMI.Enabled = typeof(TsCHdaItemValueCollection).IsInstanceOfType(clickedItem.Tag);
			}
		}

		private void ItemsLV_DoubleClick(object sender, System.EventArgs e)
		{
			if (ItemPicked != null)
			{
				ItemPicked(null);
			}
		}

		private void ItemsLV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ItemSelected != null)
			{
				ItemSelected(null);
			}
		}
	}
}
