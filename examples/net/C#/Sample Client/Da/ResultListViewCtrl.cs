//============================================================================
// TITLE: ResultListViewCtrl.cs
//
// CONTENTS:
// 
// A control used to display a set of results.
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
	/// A control used to display a set of results.
	/// </summary>
	public class ResultListViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ItemListLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.MenuItem ShowErrorTextMI;
		private System.Windows.Forms.MenuItem ViewMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ResultListViewCtrl()
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
			this.ViewMI = new System.Windows.Forms.MenuItem();
			this.ShowErrorTextMI = new System.Windows.Forms.MenuItem();
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// ItemListLV
			// 
			this.ItemListLV.ContextMenu = this.PopupMenu;
			this.ItemListLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemListLV.FullRowSelect = true;
			this.ItemListLV.Location = new System.Drawing.Point(0, 0);
			this.ItemListLV.MultiSelect = false;
			this.ItemListLV.Name = "ItemListLV";
			this.ItemListLV.Size = new System.Drawing.Size(432, 272);
			this.ItemListLV.TabIndex = 0;
			this.ItemListLV.View = System.Windows.Forms.View.Details;
			this.ItemListLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemListLV_MouseDown);
			this.ItemListLV.DoubleClick += new System.EventHandler(this.ViewMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewMI,
																					  this.ShowErrorTextMI});
			// 
			// ViewMI
			// 
			this.ViewMI.Index = 0;
			this.ViewMI.Text = "&View...";
			this.ViewMI.Click += new System.EventHandler(this.ViewMI_Click);
			// 
			// ShowErrorTextMI
			// 
			this.ShowErrorTextMI.Index = 1;
			this.ShowErrorTextMI.Text = "&Show Error Text";
			this.ShowErrorTextMI.Click += new System.EventHandler(this.ShowErrorTextMI_Click);
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
			// ResultListViewCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.ItemListLV);
			this.Name = "ResultListViewCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ITEM_NAME        = 0;
		private const int ITEM_PATH        = 1;
		private const int VALUE            = 2;
		private const int DATA_TYPE        = 3;
		private const int QUALITY_BITS     = 4;
		private const int LIMIT_BITS       = 5;
		private const int VENDOR_BITS      = 6;
		private const int TIMESTAMP        = 7;
		private const int DEADBAND         = 8;
		private const int SAMPLING_RATE    = 9;
		private const int ENABLE_BUFFERING = 10;
		private const int ERROR            = 11;
		private const int CLIENT_HANDLE    = 12;
		private const int SERVER_HANDLE    = 13;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Item Name",
			"Item Path",
			"Value",
			"Data Type",
			"Quality Bits",
			"Limit Bits",
			"Vendor Bits",
			"Timestamp",
			"Deadband",
			"Sampling Rate",
			"Buffering",
			"Result",
			"Client Handle",
			"Server Handle"
		};

		/// <summary>
		/// The server used to fetch localized texts for error messages.
		/// </summary>
		public TsCDaServer m_server = null;

		/// <summary>
		/// The locale to use when fetching localized texts for the error mesasges.
		/// </summary>
		public string m_locale = null;

		/// <summary>
		/// The set of values displayed in the the control.
		/// </summary>
		public Hashtable m_values = new Hashtable();

		/// <summary>
		/// A table of localize error texts indexed by result id.
		/// </summary>
		public Hashtable m_errors = new Hashtable();

		/// <summary>
		/// Initializes the control with a set of identified results.
		/// </summary>
		public void Initialize(TsCDaServer server, string locale, OpcItemResult[] results)
		{
			m_server = server;
			m_locale = locale;

			m_errors.Clear();

			ItemListLV.Items.Clear();

			// check if there is nothing to do.
			if (results == null || results.Length == 0) return;

			foreach (OpcItemResult result in results)
			{
				AddResult(result);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with a set of item results.
		/// </summary>
		public void Initialize(TsCDaServer server, string locale, TsCDaItemResult[] results)
		{
			m_server = server;
			m_locale = locale;

			m_errors.Clear();

			ItemListLV.Items.Clear();

			// check if there is nothing to do.
			if (results == null || results.Length == 0) return;

			foreach (TsCDaItemResult result in results)
			{
				AddResult(result);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}

		/// <summary>
		/// Initializes the control with a set of item value results.
		/// </summary>
		public void Initialize(TsCDaServer server, string locale, TsCDaItemValueResult[] results)
		{
			m_server = server;
			m_locale = locale;

			m_errors.Clear();

			ItemListLV.Items.Clear();

			// check if there is nothing to do.
			if (results == null || results.Length == 0) return;

			foreach (TsCDaItemValueResult result in results)
			{
				AddResult(result);
			}
			
			// adjust the list view columns to fit the data.
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
				// always show the item id  and value column.
				if (ii == ITEM_NAME)
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

			/*
			// get total width
			int width = 0;

			foreach (ColumnHeader column in  ItemListLV.Columns) width += column.Width;

			// expand parent form to display all columns.
			if (width > ItemListLV.Width)
			{
				width = ParentForm.Width + (width - ItemListLV.Width) + 4; 
				ParentForm.Width = (width > 1024)?1024:width;
			}
			*/
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(object item, int fieldID)
		{
			if (item.GetType() == typeof(OpcItemResult)) return GetFieldValue((OpcItemResult)item, fieldID);
			if (item.GetType() == typeof(TsCDaItemResult))       return GetFieldValue((TsCDaItemResult)item, fieldID);
			if (item.GetType() == typeof(TsCDaItemValueResult))  return GetFieldValue((TsCDaItemValueResult)item, fieldID);

			return null;
		}
	
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(OpcItemResult item, int fieldID)
		{
			switch (fieldID)
			{
				case ITEM_NAME:     { return item.ItemName; }
				case ITEM_PATH:     { return item.ItemPath; }
				// case CLIENT_HANDLE: { return OpcClientSdk.Utilities.Convert.ToString(item.ClientHandle); }
				// case SERVER_HANDLE: { return OpcClientSdk.Utilities.Convert.ToString(item.ServerHandle); }
				case ERROR:         { return GetErrorText(item.Result); }
			}

			return null;
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemResult item, int fieldID)
		{
			object fieldValue = null;

			switch (fieldID)
			{
				case ITEM_NAME:        { return item.ItemName; }
				case ITEM_PATH:        { return item.ItemPath; }
				// case CLIENT_HANDLE:    { return OpcClientSdk.Utilities.Convert.ToString(item.ClientHandle); }
				// case SERVER_HANDLE:    { return OpcClientSdk.Utilities.Convert.ToString(item.ServerHandle); }
				case DEADBAND:         { return (item.DeadbandSpecified)?item.Deadband:fieldValue; }
				case SAMPLING_RATE:	   { return (item.SamplingRateSpecified)?item.SamplingRate:fieldValue; }
				case ENABLE_BUFFERING: { return (item.EnableBufferingSpecified)?item.EnableBuffering:fieldValue; }
				case ERROR:            { return GetErrorText(item.Result); }
			}

			return null;
		}


		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCDaItemValueResult item, int fieldID)
		{
			object fieldValue = null;

			switch (fieldID)
			{

				case ITEM_NAME:     { return item.ItemName; }
				case ITEM_PATH:     { return item.ItemPath; }
				// case CLIENT_HANDLE: { return OpcClientSdk.Utilities.Convert.ToString(item.ClientHandle); }
				// case SERVER_HANDLE: { return OpcClientSdk.Utilities.Convert.ToString(item.ServerHandle); }
				case VALUE:         { return OpcClientSdk.OpcConvert.ToString(item.Value); }
				case DATA_TYPE:	    { return (item.Value != null)?item.Value.GetType():fieldValue; }
				case QUALITY_BITS:  { return (item.QualitySpecified && item.Quality.QualityBits != TsDaQualityBits.Good)?item.Quality.QualityBits:fieldValue; }
				case LIMIT_BITS:    { return (item.QualitySpecified && item.Quality.LimitBits != TsDaLimitBits.None)?item.Quality.LimitBits:fieldValue; }
				case VENDOR_BITS:   { return (item.QualitySpecified && item.Quality.VendorBits != 0)?item.Quality.VendorBits:fieldValue; }
				case TIMESTAMP:     { return (item.TimestampSpecified)?item.Timestamp:fieldValue; }
				case ERROR:         { return GetErrorText(item.Result); }
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddResult(object item)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem((string)GetFieldValue(item, ITEM_NAME), Resources.IMAGE_YELLOW_SCROLL);

			// add appropriate sub-items.
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ITEM_PATH)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VALUE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, DATA_TYPE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, QUALITY_BITS)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, LIMIT_BITS)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, VENDOR_BITS)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, TIMESTAMP)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, DEADBAND)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, SAMPLING_RATE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ENABLE_BUFFERING)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ERROR)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, CLIENT_HANDLE)));
			listItem.SubItems.Add(OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, SERVER_HANDLE)));

			// save item object as list view item tag.
			listItem.Tag = item;
		
			// add to list view.
			ItemListLV.Items.Add(listItem);
		}

		/// <summary>
		/// Lookups the error text for the specified error id.
		/// </summary>
		private string GetErrorText(OpcResult resultID)
		{
			if (ShowErrorTextMI.Checked)
			{
				// display nothing for ok results.
				if (resultID == OpcResult.S_OK) return "";
	
				// check if text has already been fetched.
				string errorText = (string)m_errors[resultID];

				// fetch the error text from the server.
				if (errorText == null)
				{
					try 
					{
						errorText = m_server.GetErrorText(m_locale, resultID);
						m_errors[resultID] = errorText;
					}
					catch
					{
						errorText = null;
					}
				}

				// return the result;
				return (errorText != null)?errorText:"";
			}

			// return the result id as a string.
			return resultID.ToString();
		}

		/// <summary>
		/// Shows a detailed view for array values.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			if (ItemListLV.SelectedItems.Count > 0)
			{
				object tag = ItemListLV.SelectedItems[0].Tag;

				if (tag != null && tag.GetType() == typeof(TsCDaItemValueResult))
				{
					TsCDaItemValueResult item = (TsCDaItemValueResult)tag;

					if (item.Value != null)
					{
						TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem(item);

						if (complexItem != null)
						{
							new EditComplexValueDlg().ShowDialog(complexItem, item.Value, true, true);
						}

						else if (item.Value.GetType().IsArray)
						{
							new EditArrayDlg().ShowDialog(item.Value, true);
						}
					}
				}
			}
		}

		/// <summary>
		/// Enables/disables items in the popup menu before it is displayed.
		/// </summary>
		private void ItemListLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			ViewMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ItemListLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			if (ItemListLV.SelectedItems.Count == 1)
			{
				ViewMI.Enabled = (clickedItem.Tag != null && clickedItem.Tag.GetType() == typeof(TsCDaItemValueResult));
			}
		}

		/// <summary>
		/// Toggles the state of the show error text flag.
		/// </summary>
		private void ShowErrorTextMI_Click(object sender, System.EventArgs e)
		{
			// toggle state.
			ShowErrorTextMI.Checked = !ShowErrorTextMI.Checked;

			// update list items.
			foreach (ListViewItem listItem in ItemListLV.Items)
			{
				if (listItem.Tag == null) { continue; }

				string errorText = null;

				if (listItem.Tag.GetType() == typeof(OpcItemResult))
				{
					errorText = GetErrorText(((OpcItemResult)listItem.Tag).Result);
				}

				else if (listItem.Tag.GetType() == typeof(TsCDaItemResult))
				{
					errorText = GetErrorText(((TsCDaItemResult)listItem.Tag).Result);
				}

				else if (listItem.Tag.GetType() == typeof(TsCDaItemValueResult))
				{
					errorText = GetErrorText(((TsCDaItemValueResult)listItem.Tag).Result);
				}

			    listItem.SubItems[listItem.SubItems.Count-3].Text = errorText;
			}

			// adjust column widths.
			AdjustColumns();
		}
	}
}
