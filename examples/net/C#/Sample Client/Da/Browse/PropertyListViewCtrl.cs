//============================================================================
// TITLE: PropertyListViewCtrl.cs
//
// CONTENTS:
// 
// A control used to display a list of item properties.
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
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Da;
using OpcClientSdk.Cpx;
using OpcClientSdk.Controls;

namespace Client
{
	/// <summary>
	/// A control used to display a list of item properties.
	/// </summary>
	public class PropertyListViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView PropertiesLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.MenuItem ViewMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PropertyListViewCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			PropertiesLV.SmallImageList = Resources.Instance.ImageList;
			
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
			this.PropertiesLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.ViewMI = new System.Windows.Forms.MenuItem();
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// PropertiesLV
			// 
			this.PropertiesLV.ContextMenu = this.PopupMenu;
			this.PropertiesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertiesLV.FullRowSelect = true;
			this.PropertiesLV.MultiSelect = false;
			this.PropertiesLV.Name = "PropertiesLV";
			this.PropertiesLV.Size = new System.Drawing.Size(432, 272);
			this.PropertiesLV.TabIndex = 0;
			this.PropertiesLV.View = System.Windows.Forms.View.Details;
			this.PropertiesLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PropertiesLV_MouseDown);
			this.PropertiesLV.DoubleClick += new System.EventHandler(this.ViewMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewMI});
			// 
			// ViewMI
			// 
			this.ViewMI.Index = 0;
			this.ViewMI.Text = "&View...";
			this.ViewMI.Click += new System.EventHandler(this.ViewMI_Click);
			// 
			// CopyMI
			// 
			this.CopyMI.Index = -1;
			this.CopyMI.Text = "";
			// 
			// EditMI
			// 
			this.EditMI.Index = -1;
			this.EditMI.Text = "";
			// 
			// RemoveMI
			// 
			this.RemoveMI.Index = -1;
			this.RemoveMI.Text = "";
			// 
			// PropertyListViewCtrl
			// 
			this.AllowDrop = true;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.PropertiesLV});
			this.Name = "PropertyListViewCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ID           = 0;
		private const int DESCRIPTION  = 1;
		private const int VALUE        = 2;
		private const int DATA_TYPE    = 3;
		private const int ITEM_PATH    = 4;
		private const int ITEM_NAME    = 5;
		private const int ERROR        = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"ID",
			"Description",
			"Value",
			"Data Type",
			"Item Path",
			"Item Name",
			"Result"
		};
		
		/// <summary>
		/// The browse element containin the properties being displayed.
		/// </summary>
		private TsCDaBrowseElement m_element = null;

		/// <summary>
		/// Initializes the control with a set of identified results.
		/// </summary>
		public void Initialize(TsCDaBrowseElement element)
		{
			PropertiesLV.Items.Clear();

			// check if there is nothing to do.
			if (element == null || element.Properties == null) return;

			m_element = element;

			foreach (TsCDaItemProperty property in element.Properties)
			{
				AddProperty(property);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			PropertiesLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				PropertiesLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < PropertiesLV.Columns.Count; ii++)
			{
				// always show the property id and value column.
				if (ii == ID || ii == VALUE)
				{
					PropertiesLV.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in PropertiesLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						PropertiesLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) PropertiesLV.Columns[ii].Width = 0;
			}

			/*
			// get total width
			int width = 0;

			foreach (ColumnHeader column in  PropertiesLV.Columns) width += column.Width;

			// expand parent form to display all columns.
			if (width > PropertiesLV.Width)
			{
				width = ParentForm.Width + (width - PropertiesLV.Width) + 4; 
				ParentForm.Width = (width > 1024)?1024:width;
			}
			*/
		}
	
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemProperty property, int fieldID)
		{
			switch (fieldID)
			{
				case ID:          { return property.ID.ToString(); }
				case DESCRIPTION: { return property.Description; }
				case VALUE:       { return property.Value; }
				case DATA_TYPE:   { return (property.Value != null)?property.Value.GetType():null; }
				case ITEM_PATH:   { return property.ItemPath; }
				case ITEM_NAME:   { return property.ItemName; }
				case ERROR:       { return property.Result; }
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddProperty(TsCDaItemProperty property)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem((string)GetFieldValue(property, ID), Resources.IMAGE_EXPLODING_BOX);

			// add appropriate sub-items.
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(property, DESCRIPTION)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(property, VALUE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(property, DATA_TYPE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(property, ITEM_PATH)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(property, ITEM_NAME)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(property, ERROR)));

			// save item object as list view item tag.
			listItem.Tag = property;
		
			// add to list view.
			PropertiesLV.Items.Add(listItem);
		}
		
		/// <summary>
		/// Shows a detailed view for array values.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			if (PropertiesLV.SelectedItems.Count > 0)
			{
				object tag = PropertiesLV.SelectedItems[0].Tag;

				if (tag != null && tag.GetType() == typeof(TsCDaItemProperty))
				{
					TsCDaItemProperty property = (TsCDaItemProperty)tag;

					if (property.Value != null)
					{
						if (property.ID == TsDaProperty.VALUE)
						{
							TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem(m_element);

							if (complexItem != null)
							{
								new EditComplexValueDlg().ShowDialog(complexItem, property.Value, true, true);
							}
						}
						else if (property.Value.GetType().IsArray)
						{
							new EditArrayDlg().ShowDialog(property.Value, true);
						}
					}
				}
			}
		}

		/// <summary>
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void PropertiesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			ViewMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = PropertiesLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			if (PropertiesLV.SelectedItems.Count == 1)
			{
				ViewMI.Enabled = true;
			}
		}
	}
}
