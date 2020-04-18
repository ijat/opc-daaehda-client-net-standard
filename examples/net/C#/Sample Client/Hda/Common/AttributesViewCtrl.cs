//============================================================================
// TITLE: AttributesViewCtrl.cs
//
// CONTENTS:
// 
// A control used to display a list of item attributes.
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
	public class AttributesViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView AttributesLV;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem ViewMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AttributesViewCtrl()
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
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.ViewMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// AttributesLV
			// 
			this.AttributesLV.ContextMenu = this.PopupMenu;
			this.AttributesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesLV.FullRowSelect = true;
			this.AttributesLV.Location = new System.Drawing.Point(0, 0);
			this.AttributesLV.MultiSelect = false;
			this.AttributesLV.Name = "AttributesLV";
			this.AttributesLV.Size = new System.Drawing.Size(432, 272);
			this.AttributesLV.TabIndex = 0;
			this.AttributesLV.View = System.Windows.Forms.View.Details;
			this.AttributesLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AttributesLV_MouseDown);
			this.AttributesLV.DoubleClick += new System.EventHandler(this.ViewMI_Click);
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
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewMI});
			// 
			// ViewMI
			// 
			this.ViewMI.Index = 0;
			this.ViewMI.Text = "View...";
			this.ViewMI.Click += new System.EventHandler(this.ViewMI_Click);
			// 
			// AttributesViewCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.AttributesLV);
			this.Name = "AttributesViewCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the attributes supported by the server.
		/// </summary>
		public void Initialize(TsCHdaServer server)
		{
			m_server = server;

			AttributesLV.Items.Clear();

			if (server != null)
			{
				foreach (OpcClientSdk.Hda.TsCHdaAttribute attribute in server.Attributes)
				{
					AddListItem(attribute);
				}
			
				AdjustColumns();
			}
		}	

		/// <summary>
		/// Displays the results of a read attributes request.
		/// </summary>
		public void Initialize(TsCHdaServer server, TsCHdaItemAttributeCollection results)
		{
			m_server = server;

			AttributesLV.Items.Clear();

			if (results != null)
			{
				foreach (OpcClientSdk.Hda.TsCHdaAttributeValueCollection result in results)
				{
					AddListItem(result);
				}
				
				AdjustColumns();
			}
		}	

		/// <summary>
		/// Displays the values of an attribute.
		/// </summary>
		public void Initialize(TsCHdaServer server, OpcClientSdk.Hda.TsCHdaAttributeValueCollection values)
		{
			m_server = server;

			AttributesLV.Items.Clear();

			if (values != null)
			{
				foreach (OpcClientSdk.Hda.TsCHdaAttributeValue value in values)
				{
					AddListItem(value);
				}

				AdjustColumns();
			}
		}	

		/// <summary>
		/// Displays the values of an attribute.
		/// </summary>
		public void Initialize(TsCHdaServer server, int attributeIDs, TsCHdaResultCollection results)
		{
			m_server = server;

			AttributesLV.Items.Clear();

			if (results != null)
			{
				foreach (TsCHdaResult result in results)
				{
					AddListItem(result);
				}

				AdjustColumns();
			}
		}	

		/// <summary>
		/// Returns the set of checked attributes.
		/// </summary>
		public OpcClientSdk.Hda.TsCHdaAttribute[] GetAttributes()
		{
			ArrayList attributes = new ArrayList();

			foreach (ListViewItem listItem in AttributesLV.CheckedItems)
			{
				if (typeof(OpcClientSdk.Hda.TsCHdaAttribute).IsInstanceOfType(listItem.Tag))
				{
					attributes.Add(listItem.Tag);
				}
			}

			return (OpcClientSdk.Hda.TsCHdaAttribute[])attributes.ToArray(typeof(OpcClientSdk.Hda.TsCHdaAttribute));
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int NAME         = 0;
		private const int DATA_TYPE    = 1;
		private const int DESCRIPTION  = 2;
		private const int NUM_VALUES   = 3;
		private const int TIMESTAMP    = 4;
		private const int VALUE        = 5;
		private const int RESULT       = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Name",
			"Data Type",
			"Description",
			"Count",
			"Timestamp",
			"Value",
			"Result"
		};
		
		/// <summary>
		/// The server containing the attributes to be displayed.
		/// </summary>
		private TsCHdaServer m_server = null;

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
		private object GetFieldValue(object attribute, int fieldID)
		{
			// display result code.
			if (typeof(IOpcResult).IsInstanceOfType(attribute))
			{
				switch (fieldID)
				{								
					case RESULT: { return ((OpcClientSdk.Hda.TsCHdaAttributeValueCollection)attribute).Result; }
				}
			}

			// displaying attribute descriptions. 
			if (typeof(OpcClientSdk.Hda.TsCHdaAttribute).IsInstanceOfType(attribute))
			{
				if (AttributesLV.CheckBoxes)
				{
					switch (fieldID)
					{
						case NAME: { return ((OpcClientSdk.Hda.TsCHdaAttribute)attribute).Name; }
					}
				}
				else
				{
					switch (fieldID)
					{
						case NAME:        { return ((OpcClientSdk.Hda.TsCHdaAttribute)attribute).Name;        }
						case DATA_TYPE:   { return ((OpcClientSdk.Hda.TsCHdaAttribute)attribute).DataType;    }
						case DESCRIPTION: { return ((OpcClientSdk.Hda.TsCHdaAttribute)attribute).Description; }
					}
				}
			}

			// displaying attribute results. 
			if (typeof(OpcClientSdk.Hda.TsCHdaAttributeValueCollection).IsInstanceOfType(attribute))
			{
				OpcClientSdk.Hda.TsCHdaAttributeValueCollection collection = (OpcClientSdk.Hda.TsCHdaAttributeValueCollection)attribute;

				switch (fieldID)
				{					
					case NAME:        
					{ 
						OpcClientSdk.Hda.TsCHdaAttribute description =	m_server.Attributes.Find(collection.AttributeID);

						if (description != null)
						{
							return description.Name; 
						}

						return null;
					}

					case NUM_VALUES:
					{
						if (collection.Count > 1)
						{
							return collection.Count;
						}

						return null;
					}
                        
					case VALUE:      
					{ 
						if (collection.Count == 1)
						{
							return collection[0].Value;
						}

						return null;
					}
				}
			}

			// displaying attribute values. 
			if (typeof(OpcClientSdk.Hda.TsCHdaAttributeValue).IsInstanceOfType(attribute))
			{
				switch (fieldID)
				{					
					case TIMESTAMP: { return ((OpcClientSdk.Hda.TsCHdaAttributeValue)attribute).Timestamp; }
					case VALUE:     { return ((OpcClientSdk.Hda.TsCHdaAttributeValue)attribute).Value;     }
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(object attribute)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_EXPLODING_BOX);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(attribute, ii));
			}

			// save object as list view item tag.
			listItem.Tag = attribute;
		
			// add to list view.
			AttributesLV.Items.Add(listItem);
		}
		#endregion

		/// <summary>
		/// Updates the state of the popup menu items based on the current selection.
		/// </summary>
		private void AttributesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			ViewMI.Enabled = false;

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
		}

		/// <summary>
		/// Displays a dialog with more detailed view of the current selection.
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

				ListViewItem selection = AttributesLV.SelectedItems[0];

				// show values if an attribute collection.
				if (typeof(OpcClientSdk.Hda.TsCHdaAttributeValueCollection).IsInstanceOfType(selection.Tag))
				{
					new AttributesViewDlg().ShowDialog(m_server, (OpcClientSdk.Hda.TsCHdaAttributeValueCollection)selection.Tag);
				}

				// show description of attribute.
				else if(typeof(OpcClientSdk.Hda.TsCHdaAttribute).IsInstanceOfType(selection.Tag))
				{
					OpcClientSdk.Hda.TsCHdaAttribute attribute = (OpcClientSdk.Hda.TsCHdaAttribute)selection.Tag;
					MessageBox.Show(attribute.Description, attribute.Name, MessageBoxButtons.OK);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
