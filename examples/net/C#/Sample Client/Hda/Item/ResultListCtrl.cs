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
	public class ResultListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ItemsLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem ViewMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ResultListCtrl()
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
			this.ViewMI = new System.Windows.Forms.MenuItem();
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
			this.ItemsLV.DoubleClick += new System.EventHandler(this.ViewMI_Click);
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
			// ResultListCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.ItemsLV);
			this.Name = "ResultListCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Initializes the control with a set of results.
		/// </summary>
		public void Initialize(TsCHdaServer server, IOpcResult[] results)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			ItemsLV.Items.Clear();

			// check if there is nothing to do.
			if (results == null) return;

			foreach (IOpcResult result in results)
			{
				AddListItem(result);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}
		
		/// <summary>
		/// Initializes the control with a set of item value collections.
		/// </summary>
		public void Initialize(TsCHdaServer server, IList[] values, TsCHdaResultCollection[] results)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;
			
			ItemsLV.Items.Clear();

			// check if there is nothing to do.
			if (values == null || results == null) return;

			// collapse the array of collections into indiviual items in the list.
			for (int ii = 0; ii < results.Length; ii++)
			{
				for (int jj = 0; jj < results[ii].Count; jj++)
				{
					DateTime timestamp = DateTime.MinValue;

					if (ii < values.Length && jj < values[ii].Count)
					{
						if (typeof(TsCHdaItemValue).IsInstanceOfType(values[ii][jj]))
						{
							timestamp = ((TsCHdaItemValue)values[ii][jj]).Timestamp;
						}
						else if (typeof(TsCHdaAnnotationValue).IsInstanceOfType(values[ii][jj]))
						{
							timestamp = ((TsCHdaAnnotationValue)values[ii][jj]).Timestamp;
						}
					}

					AddListItem(new ItemTimeResult(results[ii], timestamp, results[ii][jj]));
				}
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Initializes the control with a set of attribute ids.
		/// </summary>
		public void Initialize(TsCHdaServer server, int[] attributeIDs, TsCHdaResultCollection results)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;
			
			ItemsLV.Items.Clear();

			// check if there is nothing to do.
			if (attributeIDs == null || results == null) return;

			// collapse the array of collections into indiviual items in the list.
			for (int ii = 0; ii < attributeIDs.Length; ii++)
			{
				if (ii < results.Count)
				{
					AddListItem(new AttributeResult(results, attributeIDs[ii], results[ii]));
				}
			}

			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with a set of item value collections.
		/// </summary>
		public void Initialize(
			TsCHdaServer             server,
            TsCHdaItemTimeCollection times,
			TsCHdaResultCollection[] results)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;
			
			ItemsLV.Items.Clear();

			// check if there is nothing to do.
			if (results == null)
			{
				return;
			}

			// collapse the array of collections into indiviual items in the list.
			if (results.Length > 0)
			{
				for (int ii = 0; ii < results.Length; ii++)
				{
					for (int jj = 0; jj < results[ii].Count; jj++)
					{
						if (times == null)
						{
							AddListItem(new ItemTimeResult(results[ii], DateTime.MinValue, results[ii][jj]));
						}
						else if (jj < times.Count)
						{
							AddListItem(new ItemTimeResult(results[ii], times[jj], results[ii][jj]));
						}
					}
				}
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ITEMID     = 0;
		private const int TIMESTAMP  = 1;
		private const int AGGREGATE  = 2;
		private const int ATTRIBUTE  = 3;
		private const int NUM_VALUES = 4;
		private const int RESULT     = 5;
 
		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Item ID",
			"Timestamp",
			"Aggregate",
			"Attribute",
			"Num Values",
			"Result"
		};

		/// <summary>
		/// An class used to associate item value results with the original item value/timestamp.
		/// </summary>
		private class ItemTimeResult : OpcItem, IOpcResult
		{
			public ItemTimeResult(OpcItem item, DateTime timestamp, IOpcResult result) : base(item)
			{
				Timestamp      = timestamp;
				Result       = result.Result;
				DiagnosticInfo = result.DiagnosticInfo;
			}

			/// <summary>
			/// The timestamp associated with the value.
			/// </summary>
			public DateTime Timestamp
			{
				get { return m_timestamp;  } 
				set { m_timestamp = value; }
			}

			#region IResult Members
			/// <summary>
			/// The error id for the result of an operation on an item.
			/// </summary>
			public OpcResult Result 
			{
				get { return m_resultID;  }
				set { m_resultID = value; }
			}	

			/// <summary>
			/// Vendor specific diagnostic information (not the localized error text).
			/// </summary>
			public string DiagnosticInfo
			{
				get { return m_diagnosticInfo;  }
				set { m_diagnosticInfo = value; }
			}
			#endregion

			#region Private Members
			private DateTime m_timestamp = DateTime.MinValue;
			private OpcResult m_resultID = OpcResult.S_OK;
			private string m_diagnosticInfo = null;
			#endregion
		}

		/// <summary>
		/// An class used to associate an attribute and a result code.
		/// </summary>
		private class AttributeResult : OpcItem, IOpcResult
		{
			public AttributeResult(OpcItem item, int attributeID, IOpcResult result) : base(item)
			{
				AttributeID    = attributeID;
				Result       = result.Result;
				DiagnosticInfo = result.DiagnosticInfo;
			}

			/// <summary>
			/// The timestamp associated with the value.
			/// </summary>
			public int AttributeID
			{
				get { return m_attributeID;  } 
				set { m_attributeID = value; }
			}

			#region IResult Members
			/// <summary>
			/// The error id for the result of an operation on an item.
			/// </summary>
			public OpcResult Result 
			{
				get { return m_resultID;  }
				set { m_resultID = value; }
			}	

			/// <summary>
			/// Vendor specific diagnostic information (not the localized error text).
			/// </summary>
			public string DiagnosticInfo
			{
				get { return m_diagnosticInfo;  }
				set { m_diagnosticInfo = value; }
			}
			#endregion

			#region Private Members
			private int m_attributeID = -1;
			private OpcResult m_resultID = OpcResult.S_OK;
			private string m_diagnosticInfo = null;
			#endregion
		}
		
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

			// attribute.
			if (typeof(AttributeResult).IsInstanceOfType(item))
			{
				if (fieldID == ATTRIBUTE)
				{
					return m_server.Attributes.Find(((AttributeResult)item).AttributeID);
				}
			}

			// item.
			if (typeof(TsCHdaItem).IsInstanceOfType(item))
			{
				if (fieldID == AGGREGATE)
				{
					return m_server.Aggregates.Find(((TsCHdaItem)item).Aggregate);
				}
			}
				
			// item value collection.
			if (typeof(TsCHdaItem).IsInstanceOfType(item))
			{
				if (fieldID == NUM_VALUES)
				{
					return ((ICollection)item).Count; 
				}
			}

			// item time result.
			if (typeof(ItemTimeResult).IsInstanceOfType(item))
			{
				if (fieldID == TIMESTAMP)
				{
					return ((ItemTimeResult)item).Timestamp; 
				}
			}

			// result.
			if (typeof(IOpcResult).IsInstanceOfType(item))
			{
				if (fieldID == RESULT)
				{
					return ((IOpcResult)item).Result; 
				}
			}

			// invalid field id or type.
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
			
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ii));
			}

			// save object as list view item tag.
			listItem.Tag = item;
		
			// add to list view.
			ItemsLV.Items.Add(listItem);
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
				if (ItemsLV.SelectedItems.Count != 1)
				{
					return;
				}	

				object item = ItemsLV.SelectedItems[0].Tag;

				if (typeof(TsCHdaItemValueCollection).IsInstanceOfType(item))
				{
					new ItemValuesDlg().ShowDialog(m_server, (TsCHdaItemValueCollection)item, true); 
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
			ViewMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ItemsLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (ItemsLV.SelectedItems.Count > 0)
			{
				ViewMI.Enabled = true;
			}
		}
	}
}
