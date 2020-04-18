//============================================================================
// TITLE: BrowseFiltersDlg.cs
//
// CONTENTS:
// 
// A dialog used to specify item attribute filters used when browsing.
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
// 2003/12/31 RSA   Initial implementation.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{	
	/// <summary>
	/// Called when the browse filters have changed.
	/// </summary>
	public delegate void BrowseFiltersChangedCallback(int maxElements, TsCHdaBrowseFilter[] filters);

	/// <summary>
	/// A dialog used to specify element and property filters used when browsing.
	/// </summary>
	public class BrowseFiltersDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.ListView BrowseFiltersLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.Button ApplyBTN;
		private System.Windows.Forms.MenuItem AddMI;
		private System.Windows.Forms.Label ItemNameLB;
		private System.Windows.Forms.TextBox ItemNameTB;
		private System.Windows.Forms.Label DataTypeLB;
		private OpcClientSdk.Controls.DataTypeCtrl DataTypeCTRL;
		private System.Windows.Forms.Label MaxElementsLB;
		private System.Windows.Forms.NumericUpDown MaxElementsCTRL;
		private System.ComponentModel.IContainer components = null;

		public BrowseFiltersDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			BrowseFiltersLV.SmallImageList = Resources.Instance.ImageList;

			BrowseFiltersLV.Columns.Add("Attribute", -2, HorizontalAlignment.Left);
			BrowseFiltersLV.Columns.Add("Operator", -2, HorizontalAlignment.Left);
			BrowseFiltersLV.Columns.Add("Value", -2, HorizontalAlignment.Left);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.ApplyBTN = new System.Windows.Forms.Button();
			this.ItemNameLB = new System.Windows.Forms.Label();
			this.TopPN = new System.Windows.Forms.Panel();
			this.MaxElementsCTRL = new System.Windows.Forms.NumericUpDown();
			this.MaxElementsLB = new System.Windows.Forms.Label();
			this.DataTypeCTRL = new OpcClientSdk.Controls.DataTypeCtrl();
			this.DataTypeLB = new System.Windows.Forms.Label();
			this.ItemNameTB = new System.Windows.Forms.TextBox();
			this.MainPN = new System.Windows.Forms.Panel();
			this.BrowseFiltersLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.AddMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.ButtonsPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxElementsCTRL)).BeginInit();
			this.MainPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.Location = new System.Drawing.Point(4, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(248, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.ApplyBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(4, 218);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(328, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// ApplyBTN
			// 
			this.ApplyBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.ApplyBTN.Location = new System.Drawing.Point(127, 7);
			this.ApplyBTN.Name = "ApplyBTN";
			this.ApplyBTN.TabIndex = 2;
			this.ApplyBTN.Text = "Apply";
			this.ApplyBTN.Click += new System.EventHandler(this.ApplyBTN_Click);
			// 
			// ItemNameLB
			// 
			this.ItemNameLB.Location = new System.Drawing.Point(8, 0);
			this.ItemNameLB.Name = "ItemNameLB";
			this.ItemNameLB.Size = new System.Drawing.Size(80, 23);
			this.ItemNameLB.TabIndex = 0;
			this.ItemNameLB.Text = "Item Name";
			this.ItemNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.MaxElementsCTRL);
			this.TopPN.Controls.Add(this.MaxElementsLB);
			this.TopPN.Controls.Add(this.DataTypeCTRL);
			this.TopPN.Controls.Add(this.DataTypeLB);
			this.TopPN.Controls.Add(this.ItemNameTB);
			this.TopPN.Controls.Add(this.ItemNameLB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPN.Location = new System.Drawing.Point(4, 4);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(328, 72);
			this.TopPN.TabIndex = 32;
			// 
			// MaxElementsCTRL
			// 
			this.MaxElementsCTRL.Location = new System.Drawing.Point(88, 49);
			this.MaxElementsCTRL.Maximum = new System.Decimal(new int[] {
																			2147483647,
																			0,
																			0,
																			0});
			this.MaxElementsCTRL.Name = "MaxElementsCTRL";
			this.MaxElementsCTRL.TabIndex = 14;
			// 
			// MaxElementsLB
			// 
			this.MaxElementsLB.Location = new System.Drawing.Point(8, 48);
			this.MaxElementsLB.Name = "MaxElementsLB";
			this.MaxElementsLB.Size = new System.Drawing.Size(80, 23);
			this.MaxElementsLB.TabIndex = 13;
			this.MaxElementsLB.Text = "Max Items";
			this.MaxElementsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataTypeCTRL
			// 
			this.DataTypeCTRL.Location = new System.Drawing.Point(88, 24);
			this.DataTypeCTRL.Name = "DataTypeCTRL";
			this.DataTypeCTRL.SelectedType = null;
			this.DataTypeCTRL.Size = new System.Drawing.Size(120, 24);
			this.DataTypeCTRL.TabIndex = 12;
			// 
			// DataTypeLB
			// 
			this.DataTypeLB.Location = new System.Drawing.Point(8, 24);
			this.DataTypeLB.Name = "DataTypeLB";
			this.DataTypeLB.Size = new System.Drawing.Size(80, 23);
			this.DataTypeLB.TabIndex = 11;
			this.DataTypeLB.Text = "Data Type";
			this.DataTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.ItemNameTB.Location = new System.Drawing.Point(88, 0);
			this.ItemNameTB.Name = "ItemNameTB";
			this.ItemNameTB.Size = new System.Drawing.Size(236, 20);
			this.ItemNameTB.TabIndex = 10;
			this.ItemNameTB.Text = "";
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.BrowseFiltersLV);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Bottom = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(4, 76);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(328, 142);
			this.MainPN.TabIndex = 33;
			// 
			// BrowseFiltersLV
			// 
			this.BrowseFiltersLV.ContextMenu = this.PopupMenu;
			this.BrowseFiltersLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseFiltersLV.FullRowSelect = true;
			this.BrowseFiltersLV.Location = new System.Drawing.Point(0, 4);
			this.BrowseFiltersLV.MultiSelect = false;
			this.BrowseFiltersLV.Name = "BrowseFiltersLV";
			this.BrowseFiltersLV.Size = new System.Drawing.Size(328, 134);
			this.BrowseFiltersLV.TabIndex = 0;
			this.BrowseFiltersLV.View = System.Windows.Forms.View.Details;
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddMI,
																					  this.RemoveMI});
			// 
			// AddMI
			// 
			this.AddMI.Index = 0;
			this.AddMI.Text = "&Add";
			this.AddMI.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// RemoveMI
			// 
			this.RemoveMI.Index = 1;
			this.RemoveMI.Text = "&Remove";
			this.RemoveMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// BrowseFiltersDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 254);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.TopPN);
			this.DockPadding.Left = 4;
			this.DockPadding.Right = 4;
			this.DockPadding.Top = 4;
			this.Name = "BrowseFiltersDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Browse Filters";
			this.ButtonsPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MaxElementsCTRL)).EndInit();
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called when the OK or Apply button is clicked.
		/// </summary>
		private BrowseFiltersChangedCallback m_callback = null;

		/// <summary>
		/// The server who address space is being browsed.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Displays the browse filters in a non-model dialog.
		/// </summary>
		public void Show(
			Form                         owner,
			TsCHdaServer               server,
			ITsCHdaBrowser             browser,
			int                          maxItems,
			BrowseFiltersChangedCallback callback)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server   = server;
			m_callback = callback;

			// set default filter values.
			ItemNameTB.Text = "";
			DataTypeCTRL.SelectedType = null;
			MaxElementsCTRL.Value = maxItems;
			BrowseFiltersLV.Items.Clear();

			// fetch existing filters from browse object.
			if (browser != null)
			{
				foreach (TsCHdaBrowseFilter filter in browser.Filters)
				{
					switch (filter.AttributeID)
					{
						case OpcClientSdk.Hda.TsCHdaAttributeID.ITEMID:
						{
							ItemNameTB.Text = (string)filter.FilterValue;
							break;
						}

						case OpcClientSdk.Hda.TsCHdaAttributeID.DATA_TYPE:
						{
							DataTypeCTRL.SelectedType = (System.Type)filter.FilterValue;
							break;
						}

						default:
						{
							AddFilter(filter);
							break;
						}
					}
				}

				AdjustColumns();
			}

			StartPosition = FormStartPosition.Manual;
				
			int X = owner.Left + (owner.Width - Width)/2;
			int Y = owner.Top  + (owner.Height - Height)/2;
 
			SetDesktopLocation(X, Y);

			// show the dialog.
			Show();

			BringToFront();
		}

		/// <summary>
		/// Adds a browse filter to the list view.
		/// </summary>
		private void AddFilter(TsCHdaBrowseFilter filter)
		{
			ListViewItem item = new ListViewItem("", Resources.IMAGE_EXPLODING_BOX);

			item.SubItems.Add("");
			item.SubItems.Add("");

			item.SubItems[0].Text = m_server.Attributes.Find(filter.AttributeID).Name;
			item.SubItems[1].Text = filter.Operator.ToString();
			item.SubItems[2].Text = OpcClientSdk.OpcConvert.ToString(filter.FilterValue);

			BrowseFiltersLV.Items.Add(item);
				
			item.Tag = filter;
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			foreach (ColumnHeader column in BrowseFiltersLV.Columns)
			{
				column.Width = -2;
			}
		}

		/// <summary>
		/// Invokes the callback an passes the new browse filters.
		/// </summary>
		private void ApplyChanges()
		{
			ArrayList filters = new ArrayList();

			// add item id filter.
			if (ItemNameTB.Text != "")
			{
				TsCHdaBrowseFilter filter = new TsCHdaBrowseFilter();

				filter.AttributeID = OpcClientSdk.Hda.TsCHdaAttributeID.ITEMID;
				filter.Operator    = TsCHdaOperator.Equal;
				filter.FilterValue = ItemNameTB.Text;

				filters.Add(filter);
			}

			// add data type filter.
			if (DataTypeCTRL.SelectedType != null && DataTypeCTRL.SelectedType != typeof(object))
			{
				TsCHdaBrowseFilter filter = new TsCHdaBrowseFilter();

				filter.AttributeID = OpcClientSdk.Hda.TsCHdaAttributeID.DATA_TYPE;
				filter.Operator    = TsCHdaOperator.Equal;
				filter.FilterValue = DataTypeCTRL.SelectedType;

				filters.Add(filter);
			}

			// add other attribute filters.
			foreach (ListViewItem item in BrowseFiltersLV.Items)
			{
				filters.Add(item.Tag);
			}

			// send notification.
			if (m_callback != null)
			{
				m_callback((int)MaxElementsCTRL.Value, (TsCHdaBrowseFilter[])filters.ToArray(typeof(TsCHdaBrowseFilter)));
			}
		}

		/// <summary>
		/// Sends the updated filters notification and closes the form. 
		/// </summary>
		private void OkBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
			Close();
		}

		/// <summary>
		/// Sends the updated filters notification. 
		/// </summary>
		private void ApplyBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
		}
		/// <summary>
		/// Closes the form. 
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Adds a new browse filter to the list view.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			// exclude attributes that are already in use.
			ArrayList excludeIDs = new ArrayList();

			excludeIDs.Add(OpcClientSdk.Hda.TsCHdaAttributeID.ITEMID);
			excludeIDs.Add(OpcClientSdk.Hda.TsCHdaAttributeID.DATA_TYPE);

			foreach (ListViewItem item in BrowseFiltersLV.Items)
			{				
				excludeIDs.Add(((TsCHdaBrowseFilter)item.Tag).AttributeID);
			}

			// edit filter values.
			TsCHdaBrowseFilter filter = new AttributeFilterEditDlg().ShowDialog(m_server, excludeIDs);

			if (filter == null)
			{
				return;
			}

			// add new filter to list.
			AddFilter(filter);

			// adjust columns.
			AdjustColumns();
		}

		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			// do nothing if nothing currently selected.
			if (BrowseFiltersLV.SelectedItems.Count == 0)
			{
				return;
			}

			// removing selected filter should cause the controls to be updated.
			BrowseFiltersLV.SelectedItems[0].Remove();
		}
	}
}
