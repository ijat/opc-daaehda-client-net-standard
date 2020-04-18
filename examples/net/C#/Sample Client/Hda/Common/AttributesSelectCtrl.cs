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
	public class AttributesSelectCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView AttributesLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem AddMI;
		private System.Windows.Forms.MenuItem ViewMI;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem Separator01;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AttributesSelectCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			AttributesLV.SmallImageList = Resources.Instance.ImageList;
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
			this.AttributesLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.ViewMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.AddMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// AttributesLV
			// 
			this.AttributesLV.CheckBoxes = true;
			this.AttributesLV.ContextMenu = this.PopupMenu;
			this.AttributesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesLV.FullRowSelect = true;
			this.AttributesLV.Location = new System.Drawing.Point(0, 0);
			this.AttributesLV.Name = "AttributesLV";
			this.AttributesLV.Size = new System.Drawing.Size(432, 272);
			this.AttributesLV.TabIndex = 0;
			this.AttributesLV.View = System.Windows.Forms.View.Details;
			this.AttributesLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AttributesLV_MouseDown);
			this.AttributesLV.DoubleClick += new System.EventHandler(this.AttributesLV_DoubleClick);
			this.AttributesLV.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AttributesLV_ColumnClick);
			this.AttributesLV.SelectedIndexChanged += new System.EventHandler(this.AttributesLV_SelectedIndexChanged);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewMI,
																					  this.Separator01,
																					  this.AddMI,
																					  this.RemoveMI});
			// 
			// ViewMI
			// 
			this.ViewMI.Index = 0;
			this.ViewMI.Text = "View...";
			this.ViewMI.Click += new System.EventHandler(this.ViewMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 1;
			this.Separator01.Text = "-";
			// 
			// AddMI
			// 
			this.AddMI.Index = 2;
			this.AddMI.Text = "Add...";
			this.AddMI.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// RemoveMI
			// 
			this.RemoveMI.Index = 3;
			this.RemoveMI.Text = "Remove...";
			this.RemoveMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// AttributesSelectCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.AttributesLV);
			this.Name = "AttributesSelectCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Whether the attribute list can be changed. 
		/// </summary>
		public bool ReadOnly
		{
			get { return m_readOnly;  }
			set { m_readOnly = value; }
		}

		/// <summary>
		/// A delegate to receive picked picked events.
		/// </summary>
		public delegate void AttributePickedEventHandler(OpcClientSdk.Hda.TsCHdaAttribute[] attributes);

		/// <summary>
		/// Fired when one or more items are explicitly picked within the tree control.
		/// </summary>
		public event AttributePickedEventHandler AttributePicked;

		/// <summary>
		/// A delegate to receive item selected events.
		/// </summary>
		public delegate void AttributeSelectedEventHandler(OpcClientSdk.Hda.TsCHdaAttribute attribute);

		/// <summary>
		/// Fired when an item node is selected in the tree.
		/// </summary>
		public event AttributeSelectedEventHandler AttributeSelected;

		/// <summary>
		/// Initializes the control with the set of items in a trend.
		/// </summary>
		public void Initialize(TsCHdaServer server, ArrayList excludeList)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			AttributesLV.Items.Clear();
			
			// add server attributes.
			foreach (OpcClientSdk.Hda.TsCHdaAttribute attribute in server.Attributes)
			{
				// ignore attributes in the exclude list.
				if (excludeList != null)
				{
					if (excludeList.Contains(attribute.ID))
					{
						continue;
					}
				}

				AddListItem(attribute);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Returns the set of attributes stored in the list control.
		/// </summary>
		public OpcClientSdk.Hda.TsCHdaAttribute[] GetAttributes(bool selected)
		{
			// fetch objects from list view.
			ArrayList attributes = new ArrayList(AttributesLV.Items.Count);

			if (selected)
			{				
				foreach (ListViewItem listItem in AttributesLV.CheckedItems)
				{
					if (typeof(OpcClientSdk.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
					{
						attributes.Add(listItem.Tag);
					}
				}
			}
			else
			{
				foreach (ListViewItem listItem in AttributesLV.Items)
				{
					if (typeof(OpcClientSdk.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
					{
						attributes.Add(listItem.Tag);
					}
				}
			}		

			// convert to an array.
			return (OpcClientSdk.Hda.TsCHdaAttribute[])attributes.ToArray(typeof(OpcClientSdk.Hda.TsCHdaAttribute));
		}

		/// <summary>
		/// Returns the ids of attributes stored in the list control.
		/// </summary>
		public int[] GetAttributeIDs(bool selected)
		{
			// convert attribute list to a list of ids.
			OpcClientSdk.Hda.TsCHdaAttribute[] attributes = GetAttributes(selected);

			if (attributes != null)
			{
				int[] ids = new int[attributes.Length];

				for (int ii = 0; ii < attributes.Length; ii++)
				{
					ids[ii] = attributes[ii].ID;
				}

				return ids;
			}

			// convert to an array.
			return null;
		}
		#endregion
        
		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ATTRIBUTE = 0;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Attribute"
		};
		
		/// <summary>
		/// The server containing the attributes being displayed.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Whether the attribute list can be changed. 
		/// </summary>
		private bool m_readOnly = false;

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			AttributesLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				AttributesLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < AttributesLV.Columns.Count; ii++)
			{
				// always show the item id and value column.
				if (ii == ATTRIBUTE)
				{
					AttributesLV.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in AttributesLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						AttributesLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) AttributesLV.Columns[ii].Width = 0;
			}
		}
		
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(object item, int fieldID)
		{
			// attribute.
			if (typeof(OpcClientSdk.Hda.TsCHdaAttribute).IsInstanceOfType(item))
			{
				if (fieldID == ATTRIBUTE)
				{
					return ((OpcClientSdk.Hda.TsCHdaAttribute)item).Name; 
				}
			}

			// invalid field or type.
			return null;
		}	

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(object item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_EXPLODING_BOX);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateListItem(listItem, item);
		
			// add to list view.
			AttributesLV.Items.Add(listItem);

			// new items checked by default.
			listItem.Checked = true;
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
		/// Edits an item from the list.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (AttributesLV.SelectedItems.Count != 1)
				{
					return;
				}

				OpcClientSdk.Hda.TsCHdaAttribute attribute = (OpcClientSdk.Hda.TsCHdaAttribute)AttributesLV.SelectedItems[0].Tag;

				// view an attribute.
				MessageBox.Show(attribute.Description, attribute.Name);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Adds an item that was previously removed from the list.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ReadOnly)
				{
					return;
				}

				// create a list of trend items that are already in the view.
				ArrayList excludeList = new ArrayList();

				foreach (ListViewItem listItem in AttributesLV.Items)
				{
					if (typeof(OpcClientSdk.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
					{
                        excludeList.Add(((OpcClientSdk.Hda.TsCHdaAttribute)listItem.Tag).ID);
					}
				}

				// prompt user to select attributes.
				OpcClientSdk.Hda.TsCHdaAttribute[] attributes = new AttributesSelectDlg().ShowDialog(m_server, excludeList);

				if (attributes == null)
				{
					return;
				}

				// add new attributes to the list view.
				foreach (OpcClientSdk.Hda.TsCHdaAttribute attribute in attributes)
				{
					AddListItem(attribute);
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
				if (ReadOnly)
				{
					return;
				}

				// build list of items to remove.
				ArrayList attributes = new ArrayList(AttributesLV.SelectedItems.Count);

				foreach (ListViewItem item in AttributesLV.SelectedItems)
				{
					attributes.Add(item);
				}

				// remove selected items.
				foreach (ListViewItem item in attributes)
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
		private void AttributesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			AddMI.Enabled      = !ReadOnly && AttributesLV.Items.Count < m_server.Attributes.Count;
			ViewMI.Enabled     = false;
			RemoveMI.Enabled   = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = AttributesLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (AttributesLV.SelectedItems.Count == 1)
			{
				ViewMI.Enabled = true;
			}

			if (AttributesLV.SelectedItems.Count > 0)
			{
				RemoveMI.Enabled = !ReadOnly;
			}
		}

		/// <summary>
		/// Fires an attribute picked event.
		/// </summary>
		private void AttributesLV_DoubleClick(object sender, System.EventArgs e)
		{
			if (AttributePicked != null)
			{
				AttributePicked(GetAttributes(true));
			}
			else
			{
				ViewMI_Click(sender, e);
			}
		}

		/// <summary>
		/// Fires an attribute selected event.
		/// </summary>
		private void AttributesLV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (AttributeSelected != null)
			{
				if (AttributesLV.SelectedItems.Count > 0)
				{
					AttributeSelected((OpcClientSdk.Hda.TsCHdaAttribute)AttributesLV.SelectedItems[0].Tag);
				}
				else
				{
					AttributeSelected(null);
				}
			}
		}

		/// <summary>
		/// Toggles the state of the check boxes.
		/// </summary>
		private void AttributesLV_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			foreach (ListViewItem listItem in  AttributesLV.Items)
			{
				listItem.Checked = !listItem.Checked;
			}
		}
	}
}
