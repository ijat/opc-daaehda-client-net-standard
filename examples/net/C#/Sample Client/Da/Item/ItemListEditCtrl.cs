//============================================================================
// TITLE: ItemListEditCtrl.cs
//
// CONTENTS:
// 
// A control used to display and edit a list of Item objects.
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using OpcClientSdk;
using OpcClientSdk.Da;
using OpcClientSdk.Controls;

namespace Client
{
	/// <summary>
	/// A control used to display and edit a list of Item objects.
	/// </summary>
	public class ItemListEditCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ItemListLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem NewMI;
		private System.Windows.Forms.MenuItem DeleteMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemListEditCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			ItemListLV.SmallImageList = Resources.Instance.ImageList;

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
			this.ItemListLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.NewMI = new System.Windows.Forms.MenuItem();
			this.DeleteMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// ItemListLV
			// 
			this.ItemListLV.ContextMenu = this.PopupMenu;
			this.ItemListLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemListLV.FullRowSelect = true;
			this.ItemListLV.Name = "ItemListLV";
			this.ItemListLV.Size = new System.Drawing.Size(432, 272);
			this.ItemListLV.TabIndex = 0;
			this.ItemListLV.View = System.Windows.Forms.View.Details;
			this.ItemListLV.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.EditMI,
																					  this.NewMI,
																					  this.DeleteMI});
			// 
			// EditMI
			// 
			this.EditMI.Index = 0;
			this.EditMI.Text = "&Edit...";
			this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// NewMI
			// 
			this.NewMI.Index = 1;
			this.NewMI.Text = "&New...";
			this.NewMI.Click += new System.EventHandler(this.NewMI_Click);
			// 
			// DeleteMI
			// 
			this.DeleteMI.Index = 2;
			this.DeleteMI.Text = "&Delete";
			this.DeleteMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// ItemListEditCtrl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ItemListLV});
			this.Name = "ItemListEditCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ITEM_ID          = 0;
		private const int ITEM_PATH        = 1;
		private const int REQUESTED_TYPE   = 2;
		private const int MAXIMUM_AGE      = 3;
		private const int ACTIVE           = 4;
		private const int DEADBAND         = 5;
		private const int SAMPLING_RATE    = 6;
		private const int ENABLE_BUFFERING = 7;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Item ID",
			"Item Path",
			"Req Type",
			"Max Age",
			"Active",
			"Deadband",
			"Sampling",
			"Buffering"
		};

		/// <summary>
		/// Whether the control is displaying a 'read' item or a 'subscribe' items.
		/// </summary>
		public bool IsReadItem = false;

		/// <summary>
		/// An item that specifies default values for all items.
		/// </summary>
		private TsCDaItem m_template = null;

		/// <summary>
		/// Initializes the control with the specified template item.
		/// </summary>
		public void Initialize(TsCDaItem template)
		{
			// clear existing items.
			ItemListLV.Items.Clear();

			// create template item.
			m_template = (template != null)?(TsCDaItem)template.Clone():new TsCDaItem();
			m_template.ItemName = "<default>";

			// add template to list.
			AddItem(m_template);

			// adjust columns.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with the specified set of items.
		/// </summary>
		public void Initialize(TsCDaItem template, TsCDaItem[] items)
		{
			Initialize(template);

			// add items.
			if (items != null)
			{
				foreach (TsCDaItem item in items)
				{
					// clear subscription related fields.
					if (IsReadItem)
					{
						item.ActiveSpecified          = false;
						item.DeadbandSpecified        = false;
						item.SamplingRateSpecified    = false;
						item.EnableBufferingSpecified = false;
					}

					AddItem(item);
				}
			}

			// adjust columns.
			AdjustColumns();
		}	
	
		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			ItemListLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				ItemListLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < ItemListLV.Columns.Count; ii++)
			{
				// always show the item id column.
				if (ii == ITEM_ID)
				{
					ItemListLV.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in ItemListLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						ItemListLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) ItemListLV.Columns[ii].Width = 0;
			}
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItem item, int fieldID)
		{
			object fieldValue = null;

			switch (fieldID)
			{
				// Item Path
				case ITEM_PATH:
				{
					fieldValue = item.ItemPath;
					break;
				}

				// Req Type
				case REQUESTED_TYPE:
				{
					fieldValue = item.ReqType;
					if (fieldValue == null)	fieldValue = m_template.ReqType;
					break;
				}

				// Max Age
				case MAXIMUM_AGE:
				{
					fieldValue = (item.MaxAgeSpecified)?item.MaxAge:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.MaxAgeSpecified)?m_template.MaxAge:fieldValue;
					break;
				}

				// Active
				case ACTIVE:
				{
					fieldValue = (item.ActiveSpecified)?item.Active:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.ActiveSpecified)?m_template.Active:fieldValue;
					break;
				}

				// Deadband
				case DEADBAND:
				{
					fieldValue = (item.DeadbandSpecified)?item.Deadband:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.DeadbandSpecified)?m_template.Deadband:fieldValue;
					break;
				}

				// Sampling Rate
				case SAMPLING_RATE:
				{
					fieldValue = (item.SamplingRateSpecified)?item.SamplingRate:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.SamplingRateSpecified)?m_template.SamplingRate:fieldValue;
					break;
				}

				// Enable Buffering
				case ENABLE_BUFFERING:
				{
					fieldValue = (item.EnableBufferingSpecified)?item.EnableBuffering:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.EnableBufferingSpecified)?m_template.EnableBuffering:fieldValue;
					break;
				}
			}

			return fieldValue;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		public void AddItem(TsCDaItem item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem(item.ItemName, Resources.IMAGE_YELLOW_SCROLL);

			// add appropriate sub-items.
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ITEM_PATH)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, REQUESTED_TYPE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, MAXIMUM_AGE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ACTIVE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, DEADBAND)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, SAMPLING_RATE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ENABLE_BUFFERING)));

			// save item object as list view item tag.
			listItem.Tag = item;

			// insert/add item to list view.
			if (item == m_template) ItemListLV.Items.Insert(0, listItem);
			else ItemListLV.Items.Add(listItem);		    

			// adjust columns.
			AdjustColumns();
		}

		/// <summary>
		/// Returns the set of items in the control.
		/// </summary>
		public TsCDaItem[] GetItems()
		{
			ArrayList items = new ArrayList();

			foreach (ListViewItem listItem in ItemListLV.Items)
			{
				// skip template.
				if (listItem.Tag == m_template)
				{
					continue;
				}

				object field = null;

				// create copy of item.
				TsCDaItem item = (TsCDaItem)((TsCDaItem)listItem.Tag).Clone();

				// Req Type
				field	                      = GetFieldValue(item, REQUESTED_TYPE);
				item.ReqType                  = (System.Type)field;

				// Max Age
				field                         = GetFieldValue(item, MAXIMUM_AGE);
				item.MaxAge                   = (field != null)?(int)field:0;
				item.MaxAgeSpecified          = field != null;

				// Active
				field                         = GetFieldValue(item, ACTIVE);
				item.Active                   = (field != null)?(bool)field:false;
				item.ActiveSpecified          = field != null;

				// Deadband
				field                         = GetFieldValue(item, DEADBAND);
				item.Deadband                 = (field != null)?(float)field:0;
				item.DeadbandSpecified        = field != null;

				// Sampling Rate
				field                         = GetFieldValue(item, SAMPLING_RATE);
				item.SamplingRate             = (field != null)?(int)field:0;
				item.SamplingRateSpecified    = field != null;

				// Enable Buffering
				field                         = GetFieldValue(item, ENABLE_BUFFERING);
				item.EnableBuffering          = (field != null)?(bool)field:false;
				item.EnableBufferingSpecified = field != null;

				// add item to list.
				items.Add(item);
			}	

			// convert to array of item objects.
			return (TsCDaItem[])items.ToArray(typeof(TsCDaItem));
		}	

		/// <summary>
		/// Removes the selected items from the list.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			// copy the selected items collection.
			ArrayList items = new ArrayList(ItemListLV.SelectedItems.Count);

			items.AddRange(ItemListLV.SelectedItems);

			// remove the selected items.
			foreach (ListViewItem item in items)
			{
				if (item.Tag != m_template)	item.Remove();
			}	
		}

		/// <summary>
		/// Edits the item template.
		/// </summary>
		private void EditTemplate(TsCDaItem template)
		{			
			// prompt user to edit the template.
			TsCDaItem[] templates = new ItemListEditDlg().ShowDialog(new TsCDaItem[] { template }, IsReadItem, false);

			if (templates == null || templates.Length != 1) 
			{
				return;
			}

			// get existing items without applying defaults.
			ArrayList items = new ArrayList();

			foreach (ListViewItem item in ItemListLV.Items)
			{
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItem))
				{
					if (item.Tag != m_template)	items.Add(item.Tag);
				}
			}

			// re-initialize the list with the new template.
			Initialize(templates[0]);

			// add items back.
			foreach (TsCDaItem item in items) AddItem(item);
		}

		/// <summary>
		/// Edits a group of items.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{			
			// check if the template if being editied.
			if (ItemListLV.SelectedItems.Count == 1)
			{
				if (ItemListLV.SelectedItems[0].Tag == m_template)
				{
					EditTemplate(m_template);
					return;
				}
			}
			
			// build list of items to edit (exclude template).
			ArrayList itemList = new ArrayList(ItemListLV.SelectedItems.Count);

			foreach (ListViewItem item in ItemListLV.SelectedItems)
			{
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItem))
				{
					if (item.Tag != m_template)	itemList.Add(item.Tag);
				}
			}

			// prompt user to edit list of items.
			TsCDaItem[] items = new ItemListEditDlg().ShowDialog((TsCDaItem[])itemList.ToArray(typeof(TsCDaItem)), IsReadItem, false);

			if (items == null) 
			{
				return;
			}
			
			// remove changed items.
			RemoveMI_Click(sender, e);

			// add changed items.
			foreach (TsCDaItem item in items) AddItem(item);
		}

		/// <summary>
		/// Creates a new item.
		/// </summary>
		private void NewMI_Click(object sender, System.EventArgs e)
		{
			TsCDaItem template = null;

			// copy the current selection.
			if (ItemListLV.SelectedItems.Count > 0)
			{
				template = (TsCDaItem)((TsCDaItem)ItemListLV.SelectedItems[0].Tag).Clone();
			}
			
			// prompt user to edit new item.
			TsCDaItem[] items = new ItemListEditDlg().ShowDialog(new TsCDaItem[] { template }, IsReadItem, true);

			if (items == null) 
			{
				return;
			}

			// add new items.
			foreach (TsCDaItem item in items) AddItem(item);		
		}
	}
}
