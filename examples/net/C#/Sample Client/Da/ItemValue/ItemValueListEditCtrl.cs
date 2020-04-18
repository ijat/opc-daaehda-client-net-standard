//============================================================================
// TITLE: ItemValueListEditCtrl.cs
//
// CONTENTS:
// 
// A control used to display and edit a list of ItemValue objects.
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
	/// A control used to display and edit a list of ItemValue objects.
	/// </summary>
	public class ItemValueListEditCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ItemListLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem InitMI;
		private System.Windows.Forms.MenuItem DeleteMI;
		private System.Windows.Forms.MenuItem NewMI;
		private System.Windows.Forms.MenuItem ValuesOnlyMI;
		private System.Windows.Forms.MenuItem Separator01;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemValueListEditCtrl()
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
			this.InitMI = new System.Windows.Forms.MenuItem();
			this.DeleteMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.ValuesOnlyMI = new System.Windows.Forms.MenuItem();
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
																					  this.InitMI,
																					  this.DeleteMI,
																					  this.Separator01,
																					  this.ValuesOnlyMI});
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
			// InitMI
			// 
			this.InitMI.Index = 2;
			this.InitMI.Text = "&Initialize with Properties";
			this.InitMI.Click += new System.EventHandler(this.InitMI_Click);
			// 
			// DeleteMI
			// 
			this.DeleteMI.Index = 3;
			this.DeleteMI.Text = "&Delete";
			this.DeleteMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 4;
			this.Separator01.Text = "-";
			// 
			// ValuesOnlyMI
			// 
			this.ValuesOnlyMI.Checked = true;
			this.ValuesOnlyMI.Index = 5;
			this.ValuesOnlyMI.Text = "&Values Only";
			this.ValuesOnlyMI.Click += new System.EventHandler(this.ValuesOnlyMI_Click);
			// 
			// ItemValueListEditCtrl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ItemListLV});
			this.Name = "ItemValueListEditCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ITEM_ID          = 0;
		private const int ITEM_PATH        = 1;
		private const int VALUE            = 2;
		private const int VALUE_TYPE       = 3;
		private const int QUALITY_BITS     = 4;
		private const int LIMIT_BITS       = 5;
		private const int VENDOR_BITS      = 6;
		private const int TIMESTAMP        = 7;
		private const int QUALITY          = 100;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Item ID",
			"Item Path",
			"Value",
			"Data Type",
			"Quality Bits",
			"Limit Bits",
			"Vendor Bits",
			"Timestamp"
		};

		/// <summary>
		/// The server where the items are resident on.
		/// </summary>
		private TsCDaServer m_server = null;

		/// <summary>
		/// An item that specifies default values for all items.
		/// </summary>
		private TsCDaItemValue m_template = null;

		/// <summary>
		/// Initializes the control with the specified set of items.
		/// </summary>
		public void Initialize(TsCDaServer server, TsCDaItemValue template)
		{
			// clear existing items.
			ItemListLV.Items.Clear();

			// save reference to server object.
			m_server = server;

			// disable init from properties if no server provided.
			InitMI.Enabled = m_server != null;

			// create template item.
			m_template = (template != null)?(TsCDaItemValue)template.Clone():new TsCDaItemValue();
			m_template.ItemName = "<default>";

			// clear values only flag if quality or timestamp specified.
			if (m_template.QualitySpecified || m_template.TimestampSpecified)
			{
				ValuesOnlyMI.Checked = false;
			}

			// add template to list.
			AddItem(m_template);

			// adjust columns.
			AdjustColumns();
		}
	
		/// <summary>
		/// Initializes the control with the specified set of items.
		/// </summary>
		public void Initialize(TsCDaServer server, TsCDaItemValue template, TsCDaItem[] items)
		{
			Initialize(server, template);

			// add items.
			if (items != null)
			{
				foreach (TsCDaItem item in items) AddItemWithDefaults(new TsCDaItemValue(item));
			}

			// adjust columns.
			AdjustColumns();
		}	
	
		/// <summary>
		/// Initializes an item value object with the item properties.
		/// </summary>
		private void GetDefaultValues(TsCDaItemValue[] items, bool valuesOnly)
		{
			try
			{
				// get item value properties.
				TsCDaItemPropertyCollection[] propertyLists = m_server.GetProperties(
					items,
					new TsDaPropertyID[] { TsDaProperty.DATATYPE, TsDaProperty.QUALITY, TsDaProperty.TIMESTAMP, TsDaProperty.VALUE },
					true);

				// update item values.
				for (int ii = 0; ii < items.Length; ii++)
				{
					// ignore errors for failures for individual items.
					if (propertyLists[ii].Result.Failed())
					{
						continue;
					}

					// set a default value based on the data type.
					object defaultValue = propertyLists[ii][3].Value;

					if (defaultValue == null)
					{
						System.Type type = (System.Type)propertyLists[ii][0].Value;
						System.Type baseType = (type.IsArray)?type.GetElementType():type;

						if (baseType == typeof(string))   defaultValue = "";
						if (baseType == typeof(DateTime)) defaultValue = DateTime.Now;
						if (baseType == typeof(object))   defaultValue = "";

						defaultValue = OpcClientSdk.OpcConvert.ChangeType(defaultValue, baseType);

						// convert to a three element array.
						if (type.IsArray)
						{
							defaultValue = new object[] {defaultValue, defaultValue, defaultValue};
							defaultValue = OpcClientSdk.OpcConvert.ChangeType(defaultValue, type);
						}
					}

					// update the object.
					items[ii].Value     =  defaultValue;
					items[ii].Quality   =  (TsCDaQuality)propertyLists[ii][1].Value;
					items[ii].Timestamp =  (DateTime)propertyLists[ii][2].Value;

					// set the quality/timestamp exists flags.
					items[ii].QualitySpecified   = !valuesOnly;
					items[ii].TimestampSpecified = !valuesOnly;
				}
			}
			catch
			{
				// ignore errors.
			}
		}

		/// <summary>
		/// Updates the specified list item.
		/// </summary>
		private void UpdateItem(ListViewItem listItem, TsCDaItemValue item)
		{
			listItem.SubItems[VALUE].Text        = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VALUE));
			listItem.SubItems[VALUE_TYPE].Text   = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VALUE_TYPE));
			listItem.SubItems[QUALITY_BITS].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, QUALITY_BITS));
			listItem.SubItems[LIMIT_BITS].Text   = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, LIMIT_BITS));
			listItem.SubItems[VENDOR_BITS].Text  = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VENDOR_BITS));
			listItem.SubItems[TIMESTAMP].Text    = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, TIMESTAMP));
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
				if (ii == ITEM_ID || ii == VALUE)
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
        /// Performs a deep copy of an object if possible.
        /// </summary>
        public object Clone(object source)
        {
            if (source == null) return null;
            if (source.GetType().IsValueType) return source;

            if (source.GetType().IsArray || source.GetType() == typeof(Array))
            {
                Array array = (Array)((Array)source).Clone();

                for (int ii = 0; ii < array.Length; ii++)
                {
                    array.SetValue(Clone(array.GetValue(ii)), ii);
                }

                return array;
            }

            try { return ((ICloneable)source).Clone(); }
            catch { throw new NotSupportedException("Object cannot be cloned."); }
        }
        
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemValue item, int fieldID)
		{
			object fieldValue = null;

			switch (fieldID)
			{
				case ITEM_PATH:
				{
					fieldValue = item.ItemPath;
					break;
				}

				case VALUE:
				{
					fieldValue = item.Value;
					if (fieldValue == null)	fieldValue = OpcClientSdk.OpcConvert.Clone(m_template.Value);
					break;
				}

				case VALUE_TYPE:
				{
					fieldValue = (item.Value != null)?item.Value.GetType():null;
					if (fieldValue == null)	fieldValue = (m_template.Value != null)?m_template.Value.GetType():null;
					break;
				}		
				
				case QUALITY_BITS:
				{
					fieldValue = (item.QualitySpecified)?item.Quality.QualityBits:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.QualitySpecified)?m_template.Quality.QualityBits:fieldValue;
					break;
				}

				case LIMIT_BITS:
				{
					fieldValue = (item.QualitySpecified)?item.Quality.LimitBits:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.QualitySpecified)?m_template.Quality.LimitBits:fieldValue;
					break;
				}

				case VENDOR_BITS:
				{
					fieldValue = (item.QualitySpecified)?item.Quality.VendorBits:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.QualitySpecified)?m_template.Quality.VendorBits:fieldValue;
					break;
				}

				case TIMESTAMP:
				{
					fieldValue = (item.TimestampSpecified)?item.Timestamp:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.TimestampSpecified)?m_template.Timestamp:fieldValue;
					break;
				}

				case QUALITY:
				{
					fieldValue = (item.QualitySpecified)?item.Quality:fieldValue;
					if (fieldValue == null)	fieldValue = (m_template.QualitySpecified)?m_template.Quality:fieldValue;
					break;
				}
			}

			return fieldValue;
		}

		/// <summary>
		/// Adds a items to the list view.
		/// </summary>
		public void AddItemWithDefaults(TsCDaItemValue item)
		{
			GetDefaultValues(new TsCDaItemValue[] { item }, ValuesOnlyMI.Checked);
			AddItem(item);
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddItem(TsCDaItemValue item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem(item.ItemName, Resources.IMAGE_YELLOW_SCROLL);

			// add sub-items.
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ITEM_PATH)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VALUE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VALUE_TYPE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, QUALITY_BITS)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, LIMIT_BITS)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VENDOR_BITS)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, TIMESTAMP)));

			// save item object as list view item tag.
			listItem.Tag = item;

			// insert/add item to list view.
			if (item == m_template) ItemListLV.Items.Insert(0, listItem);
			else ItemListLV.Items.Add(listItem);		    

			// adjust column widths.
			AdjustColumns();
		}

		/// <summary>
		/// Returns the set of items in the control.
		/// </summary>
		public TsCDaItemValue[] GetItems()
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
				TsCDaItemValue item = (TsCDaItemValue)((TsCDaItemValue)listItem.Tag).Clone();

				// Value
				field	                = GetFieldValue(item, VALUE);
				item.Value              = field;

				// Quality
				field	                = GetFieldValue(item, QUALITY);
				item.Quality            = (field != null)?(TsCDaQuality)field:TsCDaQuality.Bad;
				item.QualitySpecified   = field != null;

				// Timestamp
				field	                = GetFieldValue(item, TIMESTAMP);
				item.Timestamp          = (field != null)?(DateTime)field:DateTime.MinValue;
				item.TimestampSpecified = field != null;

				// add item to list.
				items.Add(item);
			}	

			// convert to array of item objects.
			return (TsCDaItemValue[])items.ToArray(typeof(TsCDaItemValue));
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
		private void EditTemplate(TsCDaItemValue template)
		{			
			// prompt user to edit the template.
			TsCDaItemValue[] templates = new ItemValueListEditDlg().ShowDialog(new TsCDaItemValue[] { template }, false);

			if (templates == null || templates.Length != 1) 
			{
				return;
			}

			// get existing items without applying defaults.
			ArrayList items = new ArrayList();

			foreach (ListViewItem item in ItemListLV.Items)
			{
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItemValue))
				{
					if (item.Tag != m_template)	items.Add(item.Tag);
				}
			}

			// re-initialize the list with the new template.
			Initialize(m_server, templates[0]);

			// add items back.
			foreach (TsCDaItemValue item in items) AddItem(item);
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
				if (item.Tag != null && item.Tag.GetType() == typeof(TsCDaItemValue))
				{
					if (item.Tag != m_template)	itemList.Add(item.Tag);
				}
			}

			// prompt user to edit list of items.
			TsCDaItemValue[] items = new ItemValueListEditDlg().ShowDialog((TsCDaItemValue[])itemList.ToArray(typeof(TsCDaItemValue)), false);

			if (items == null) 
			{
				return;
			}
			
			// remove changed items.
			RemoveMI_Click(sender, e);

			// add changed items.
			foreach (TsCDaItemValue item in items) 
			{
				// clear values only flag if quality or timestamp specified.
				if (item.QualitySpecified || item.TimestampSpecified)
				{
					ValuesOnlyMI.Checked = false;
				}

				AddItem(item);
			}

			// adjust columns to fit data.
			AdjustColumns();
		}

		/// <summary>
		/// Creates a new item.
		/// </summary>
		private void NewMI_Click(object sender, System.EventArgs e)
		{
			TsCDaItemValue template = null;

			// copy the current selection.
			if (ItemListLV.SelectedItems.Count > 0)
			{
				template = (TsCDaItemValue)((TsCDaItemValue)ItemListLV.SelectedItems[0].Tag).Clone();
			}
			
			// prompt user to edit new item.
			TsCDaItemValue[] items = new ItemValueListEditDlg().ShowDialog(new TsCDaItemValue[] { template }, true);

			if (items == null) 
			{
				return;
			}

			// add new items.
			foreach (TsCDaItemValue item in items) AddItem(item);		

			// adjust columns to fit data.
			AdjustColumns();
		}

		/// <summary>
		/// Reads the item properties from the server and uses them to initialize the items.
		/// </summary>
		private void InitMI_Click(object sender, System.EventArgs e)
		{
			// build list of items to query properties for (exclude template).
			ArrayList items = new ArrayList(ItemListLV.SelectedItems.Count);

			foreach (ListViewItem listItem in ItemListLV.SelectedItems)
			{
				if (listItem.Tag != null && listItem.Tag.GetType() == typeof(TsCDaItemValue))
				{
					if (listItem.Tag != m_template)	
					{
						items.Add(listItem.Tag);
					}
				}
			}

			// fetch default values from item properties.
			GetDefaultValues((TsCDaItemValue[])items.ToArray(typeof(TsCDaItemValue)), ValuesOnlyMI.Checked);
			
			// update list view.
			foreach (ListViewItem listItem in ItemListLV.SelectedItems) 
			{
				UpdateItem(listItem, (TsCDaItemValue)listItem.Tag);
			}
			
			// adjust columns widths.
			AdjustColumns();
		}

		/// <summary>
		/// Toggles the flag indicating whether to write only values.
		/// </summary>
		private void ValuesOnlyMI_Click(object sender, System.EventArgs e)
		{
			ValuesOnlyMI.Checked = !ValuesOnlyMI.Checked;

			// clear quality and timestamp.
			if (ValuesOnlyMI.Checked)
			{
				foreach (ListViewItem listItem in ItemListLV.Items)
				{
					// get item.
					TsCDaItemValue item = (TsCDaItemValue)listItem.Tag;

					// disable quality/timestamp fields.
					item.QualitySpecified   = false;
					item.TimestampSpecified = false;
			
					// clear columns in the list view.
					listItem.SubItems[QUALITY_BITS].Text = "";
					listItem.SubItems[LIMIT_BITS].Text   = "";
					listItem.SubItems[VENDOR_BITS].Text  = "";
					listItem.SubItems[TIMESTAMP].Text    = "";
				}			

				AdjustColumns();
			}
		}
	}
}
