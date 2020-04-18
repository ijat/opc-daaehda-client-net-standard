//============================================================================
// TITLE: ItemEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to modify the parameters of an item.
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
using System.Text;
using System.Reflection;
using System.Data;

using OpcClientSdk;
using OpcClientSdk.Da;
using OpcClientSdk.Hda.Test;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class TestEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.ListView ValuesLV;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Label ResultIDLB;
		private System.Windows.Forms.TextBox ResultIDTB;
		private System.Windows.Forms.Button OkBTN;
		private OpcClientSdk.Hda.SampleClient.TrendEditCtrl TrendCTRL;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem AddMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.MenuItem DeleteMI;
		private System.Windows.Forms.MenuItem ClearMI;
		private System.Windows.Forms.MenuItem AcceptActualMI;
		private System.Windows.Forms.MenuItem Separator01;
		private System.ComponentModel.IContainer components = null;

		public TestEditDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
		
			ValuesLV.SmallImageList = Resources.Instance.ImageList;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OkBTN = new System.Windows.Forms.Button();
			this.MainPN = new System.Windows.Forms.Panel();
			this.ValuesLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.AddMI = new System.Windows.Forms.MenuItem();
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.DeleteMI = new System.Windows.Forms.MenuItem();
			this.ClearMI = new System.Windows.Forms.MenuItem();
			this.TopPN = new System.Windows.Forms.Panel();
			this.TrendCTRL = new OpcClientSdk.Hda.SampleClient.TrendEditCtrl();
			this.ResultIDLB = new System.Windows.Forms.Label();
			this.ResultIDTB = new System.Windows.Forms.TextBox();
			this.AcceptActualMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(304, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 378);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(384, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(4, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 0;
			this.OkBTN.Text = "OK";
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.ValuesLV);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Left = 4;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 192);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(384, 186);
			this.MainPN.TabIndex = 32;
			// 
			// ValuesLV
			// 
			this.ValuesLV.ContextMenu = this.PopupMenu;
			this.ValuesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ValuesLV.FullRowSelect = true;
			this.ValuesLV.Location = new System.Drawing.Point(4, 4);
			this.ValuesLV.MultiSelect = false;
			this.ValuesLV.Name = "ValuesLV";
			this.ValuesLV.Size = new System.Drawing.Size(376, 182);
			this.ValuesLV.TabIndex = 0;
			this.ValuesLV.View = System.Windows.Forms.View.Details;
			this.ValuesLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ValuesLV_MouseDown);
			this.ValuesLV.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddMI,
																					  this.CopyMI,
																					  this.EditMI,
																					  this.DeleteMI,
																					  this.Separator01,
																					  this.ClearMI,
																					  this.AcceptActualMI});
			// 
			// AddMI
			// 
			this.AddMI.Index = 0;
			this.AddMI.Text = "Add...";
			this.AddMI.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// CopyMI
			// 
			this.CopyMI.Index = 1;
			this.CopyMI.Text = "Copy....";
			this.CopyMI.Click += new System.EventHandler(this.CopyMI_Click);
			// 
			// EditMI
			// 
			this.EditMI.Index = 2;
			this.EditMI.Text = "Edit..";
			this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// DeleteMI
			// 
			this.DeleteMI.Index = 3;
			this.DeleteMI.Text = "Delete";
			this.DeleteMI.Click += new System.EventHandler(this.DeleteMI_Click);
			// 
			// ClearMI
			// 
			this.ClearMI.Index = 5;
			this.ClearMI.Text = "Clear";
			this.ClearMI.Click += new System.EventHandler(this.ClearMI_Click);
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.TrendCTRL);
			this.TopPN.Controls.Add(this.ResultIDLB);
			this.TopPN.Controls.Add(this.ResultIDTB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPN.DockPadding.Left = 4;
			this.TopPN.DockPadding.Right = 4;
			this.TopPN.DockPadding.Top = 4;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(384, 192);
			this.TopPN.TabIndex = 33;
			// 
			// TrendCTRL
			// 
			this.TrendCTRL.Dock = System.Windows.Forms.DockStyle.Top;
			this.TrendCTRL.Location = new System.Drawing.Point(4, 4);
			this.TrendCTRL.Name = "TrendCTRL";
			this.TrendCTRL.Size = new System.Drawing.Size(376, 168);
			this.TrendCTRL.TabIndex = 1;
			// 
			// ResultIDLB
			// 
			this.ResultIDLB.Location = new System.Drawing.Point(4, 172);
			this.ResultIDLB.Name = "ResultIDLB";
			this.ResultIDLB.Size = new System.Drawing.Size(96, 23);
			this.ResultIDLB.TabIndex = 0;
			this.ResultIDLB.Text = "Result ID";
			this.ResultIDLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResultIDTB
			// 
			this.ResultIDTB.Location = new System.Drawing.Point(100, 172);
			this.ResultIDTB.Name = "ResultIDTB";
			this.ResultIDTB.Size = new System.Drawing.Size(204, 20);
			this.ResultIDTB.TabIndex = 0;
			this.ResultIDTB.Text = "";
			// 
			// AcceptActualMI
			// 
			this.AcceptActualMI.Index = 6;
			this.AcceptActualMI.Text = "Accept Actual Values...";
			this.AcceptActualMI.Click += new System.EventHandler(this.AcceptActualMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 4;
			this.Separator01.Text = "-";
			// 
			// TestEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 414);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.TopPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "TestEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Test Case";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Runs all tests with the specified name and displays the results.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, TestData test)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;

			TrendCTRL.Initialize(test.Trend, RequestType.None);

			ValuesLV.Tag = test;

			if (test.Expected != null)
			{
				// add expected result.
				ResultIDTB.Text = test.Expected.Result.Name.Name;

				// add expected values to list view.
				UpdateValues();
			}

			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}
			
			// update trend and expected values.
			TrendCTRL.Update(test.Trend);
			
			if (test.Expected != null)
			{
				// only update result if it does not have invalid characters.
				if (ResultIDTB.Text.IndexOfAny("() ".ToCharArray()) == -1) 
				{
					test.Expected.Result = new OpcResult(ResultIDTB.Text, "");
				}

				test.Expected.Clear();

				foreach (ListViewItem listItem in ValuesLV.Items)
				{
					if (typeof(TsCHdaItemValue).IsInstanceOfType(listItem.Tag))
					{
						test.Expected.Add(listItem.Tag);
					}
				}
			}

			return true;
		}
		#endregion
		
		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int TIMESTAMP           = 0;
		private const int VALUE               = 1;
		private const int QUALITY             = 2;
		private const int HISTORIAN_QUALITY   = 3;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Timestamp",
			"Value",
			"Quality",
			"Historian Quality"
		};
		
		/// <summary>
		/// The server executing the test cases.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			ValuesLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				ValuesLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < ValuesLV.Columns.Count; ii++)
			{
				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in ValuesLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						ValuesLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no test it in.
				if (empty) ValuesLV.Columns[ii].Width = 0;
			}
		}
	
		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddItem(TsCHdaItemValue item, bool highlight)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateItem(listItem, item);

			if (highlight)
			{
				listItem.ForeColor = Color.Red;
			}
		
			// add to list view.
			ValuesLV.Items.Add(listItem);
		}

		/// <summary>
		/// Updates the columns of an item in the list view.
		/// </summary>
		private void UpdateItem(ListViewItem listItem, TsCHdaItemValue item)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(item, ii));
			}

			// save object as list view item tag.
			listItem.Tag = item;
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCHdaItemValue item, int fieldID)
		{
			if (item == null)
			{
				return null;
			}

			switch (fieldID)
			{
				case TIMESTAMP:   
				{ 
					if (item.Timestamp != DateTime.MinValue)
					{
						return item.Timestamp.ToString("HH:mm:ss"); 
					}

					return null;
				}

				case VALUE:              { return item.Value;            }
				case QUALITY:            { return item.Quality;          }
				case HISTORIAN_QUALITY:  { return item.HistorianQuality; }
			}

			return null;
		}

		/// <summary>
		/// Adds the expected and actual values to the list view.
		/// </summary>
		private void UpdateValues()
		{			
			// get test object.
			TestData test = (TestData)ValuesLV.Tag;

			// clear existing values.
			ValuesLV.Items.Clear();

			// add expected values.
			foreach (TsCHdaItemValue value in test.Expected)
			{
				AddItem(value, false);
			}

			if (test.Actual != null)
			{
				// append actual result to result.
				ResultIDTB.Text += " (" + test.Actual.Result.Name.Name + ")";

				for (int ii = 0; ii < test.Actual.Count; ii++)
				{
					// append actual values to columns of expected item.
					if (ii < ValuesLV.Items.Count)
					{		
						ListViewItem listItem = ValuesLV.Items[ii];

						for (int jj = 0; jj < listItem.SubItems.Count; jj++)
						{
							string expected = listItem.SubItems[jj].Text;
							string actual   = OpcClientSdk.OpcConvert.ToString(GetFieldValue(test.Actual[ii], jj));

							if (expected != actual)
							{
								listItem.SubItems[jj].Text = expected + " (" + actual + ")";
								listItem.ForeColor = Color.Green;
							}
						}
					}

						// add a new item with a different colour.
					else
					{
						AddItem(test.Actual[ii], true);
					}
				}

				// change color of expected items that are not in the set of actual items.
				for (int ii = test.Actual.Count; ii < test.Expected.Count; ii++)
				{
					ValuesLV.Items[ii].ForeColor = Color.Blue;
				}
			}

			// adjust columns.
			AdjustColumns();
		}
		#endregion

		/// <summary>
		/// Adds a new test case.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create new item value.
				TsCHdaItemValue value = new TsCHdaItemValue();

				value.Value            = new Double();
				value.Timestamp        = RunTestDlg.BASETIME;
				value.Quality          = Da.TsCDaQuality.Good;
				value.HistorianQuality = OpcClientSdk.Hda.TsCHdaQuality.Raw;

				// prompt user to edit test case.
				value = new ItemValueEditDlg().ShowDialog(value);

				if (value == null)
				{
					return;
				}
				
				// update display.
				AddItem(value, false);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Adds a new test case by copying an existing one.
		/// </summary>
		private void CopyMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ValuesLV.SelectedItems.Count != 1)
				{
					return;
				}

				TsCHdaItemValue value = (TsCHdaItemValue)ValuesLV.SelectedItems[0].Tag;

				// create new item value.
				TsCHdaItemValue copy = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)value.Clone());

				// prompt user to edit test case.
				if (copy == null)
				{
					return;
				}
				
				// update display.
				AddItem(copy, false);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits the parameters of s test case.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ValuesLV.SelectedItems.Count != 1)
				{
					return;
				}

				// create new item value.
				TsCHdaItemValue value = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)ValuesLV.SelectedItems[0].Tag);

				// prompt user to edit test case.
				if (value == null)
				{
					return;
				}
				
				// update display.
				UpdateItem(ValuesLV.SelectedItems[0], value);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Deletes am existing test case.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ValuesLV.SelectedItems.Count != 1)
				{
					return;
				}
				
				// update display.
				ValuesLV.SelectedItems[0].Remove();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void ValuesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			AddMI.Enabled    = true;
			CopyMI.Enabled   = false;
			EditMI.Enabled   = false;
			DeleteMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ValuesLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (ValuesLV.SelectedItems.Count == 1)
			{			
				CopyMI.Enabled   = true;
				EditMI.Enabled   = true;
				DeleteMI.Enabled = true;
			}
		}

		/// <summary>
		/// Remove all values from the list.
		/// </summary>
		private void ClearMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				ValuesLV.Items.Clear();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Accepts the actual values as the expected values.
		/// </summary>
		private void AcceptActualMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// get test object.
				TestData test = (TestData)ValuesLV.Tag;

				// set actual values as expected and update list view.
				if (test.Actual != null)
				{
					test.Expected = test.Actual;
					UpdateValues();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}
	}

	/// <summary>
	/// Contains data related to a test run.
	/// </summary>
	public class TestData
	{
		public _DataSet.TestCase TestCase;
		public TsCHdaTrend Trend;
		public TsCHdaItemValueCollection Actual;
		public TsCHdaItemValueCollection Expected;
		public bool Passed;
	}
}
