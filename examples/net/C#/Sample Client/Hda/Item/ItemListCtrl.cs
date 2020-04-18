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
	public class ItemListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ItemsLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem AddMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemListCtrl()
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
			this.ItemsLV.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddMI,
																					  this.EditMI,
																					  this.RemoveMI});
			// 
			// AddMI
			// 
			this.AddMI.Index = 0;
			this.AddMI.Text = "Add..";
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
			this.RemoveMI.Text = "Remove";
			this.RemoveMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// ItemListCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.ItemsLV);
			this.Name = "ItemListCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Initializes the control with a set of item identifiers.
		/// </summary>
		public void Initialize(TsCHdaServer server, OpcItem[] items)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			ItemsLV.Items.Clear();

			// check if there is nothing to do.
			if (items == null) return;

			foreach (OpcItem item in items)
			{
				AddListItem(item);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Adds the set of item identifiers to the control.
		/// </summary>
		public void AddItems(OpcItem[] items)
		{
			if (items != null)
			{
				foreach (OpcItem item in items)
				{
					AddListItem(new OpcItem(item));
				}

				// adjust the list view columns to fit the data.
				AdjustColumns();
			}
		}

		/// <summary>
		/// Returns the set of items stored in the list control.
		/// </summary>
		public OpcItem[] GetItemIDs(bool selected)
		{
			// fetch objects from list view.
			ArrayList items = new ArrayList(ItemsLV.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in ItemsLV.SelectedItems)
				{
					if (typeof(OpcItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in ItemsLV.Items)
				{
					if (typeof(OpcItem).IsInstanceOfType(listItem.Tag))
					{
						items.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (OpcItem[])items.ToArray(typeof(OpcItem));
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ITEMID = 0;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Item ID"
		};
		
		/// <summary>
		/// The server containing the items being viewed in the list. 
		/// </summary>
		private TsCHdaServer m_server = null;

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
			if (typeof(OpcItem).IsInstanceOfType(item))
			{
				if (fieldID == ITEMID)
				{
					return ((OpcItem)item).ItemName; 
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(object item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// update the columns.
			UpdateListItem(listItem, item);
		
			// add to list view.
			ItemsLV.Items.Add(listItem);
		}

		/// <summary>
		/// Updates an item in the list view.
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
		/// Adds an item to the list.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// prompt user to create a new item.
				OpcItem item = new OpcItem();

				if (!new ItemEditDlg().ShowDialog(item))
				{
					return;
				}

				// only add item if a vali item id was specified.
				if (item.ItemName != null && item.ItemName != "")
				{						
					// add to list view.
					AddListItem(item);
					
					// adjust columns.
					AdjustColumns();
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

				// check for correct type.
				object item = ItemsLV.SelectedItems[0].Tag;

				if (!typeof(OpcItem).IsInstanceOfType(item))
				{
					return;
				}

				// prompt user to edit the selected item.
				if (!new ItemEditDlg().ShowDialog((OpcItem)item))
				{
					return;
				}

				// update list view.
				UpdateListItem(ItemsLV.SelectedItems[0], item);
					
				// adjust columns.
				AdjustColumns();
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
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void ItemsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			AddMI.Enabled    = true;
			EditMI.Enabled   = false;
			RemoveMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ItemsLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (ItemsLV.SelectedItems.Count == 1)
			{
				EditMI.Enabled   = true;
				RemoveMI.Enabled = true;
			}
		}
	}
}
