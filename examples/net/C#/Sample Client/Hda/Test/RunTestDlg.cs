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
	public class RunTestDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.ListView ResultsLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem AddMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.Button RunBTN;
		private System.ComponentModel.IContainer components = null;

		public RunTestDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
			
			ResultsLV.SmallImageList = Resources.Instance.ImageList;
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
			this.RunBTN = new System.Windows.Forms.Button();
			this.MainPN = new System.Windows.Forms.Panel();
			this.ResultsLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.AddMI = new System.Windows.Forms.MenuItem();
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(480, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Close";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.RunBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 346);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(560, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// RunBTN
			// 
			this.RunBTN.Location = new System.Drawing.Point(4, 8);
			this.RunBTN.Name = "RunBTN";
			this.RunBTN.TabIndex = 1;
			this.RunBTN.Text = "Run";
			this.RunBTN.Click += new System.EventHandler(this.RunBTN_Click);
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.ResultsLV);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Left = 4;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(560, 346);
			this.MainPN.TabIndex = 32;
			// 
			// ResultsLV
			// 
			this.ResultsLV.ContextMenu = this.PopupMenu;
			this.ResultsLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsLV.FullRowSelect = true;
			this.ResultsLV.Location = new System.Drawing.Point(4, 4);
			this.ResultsLV.MultiSelect = false;
			this.ResultsLV.Name = "ResultsLV";
			this.ResultsLV.Size = new System.Drawing.Size(552, 342);
			this.ResultsLV.TabIndex = 0;
			this.ResultsLV.View = System.Windows.Forms.View.Details;
			this.ResultsLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResultsLV_MouseDown);
			this.ResultsLV.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddMI,
																					  this.CopyMI,
																					  this.EditMI,
																					  this.RemoveMI});
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
			this.CopyMI.Text = "Copy...";
			this.CopyMI.Click += new System.EventHandler(this.CopyMI_Click);
			// 
			// EditMI
			// 
			this.EditMI.Index = 2;
			this.EditMI.Text = "Edit..";
			this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// RemoveMI
			// 
			this.RemoveMI.Index = 3;
			this.RemoveMI.Text = "Delete";
			this.RemoveMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// RunTestDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 382);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "RunTestDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Run Test Cases";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The base time for all test parameters/results.
		/// </summary>
		internal static readonly DateTime BASETIME = new DateTime(2005, 1, 1);

		/// <summary>
		/// The server executing the test cases.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// The dataset describing the test cases.
		/// </summary>
		private OpcClientSdk.Hda.Test._DataSet m_dataset = null;

		/// <summary>
		/// The file containing the test case descriptions.
		/// </summary>
		private string m_filePath = null;
	
		/// <summary>
		/// The item id to use for the tests.
		/// </summary>
		private string m_itemID = null;

		/// <summary>
		/// Runs all tests with the specified name and displays the results.
		/// </summary>
		public void ShowDialog(TsCHdaServer server, string fileName, string itemID)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server = server;	
			m_itemID = itemID;
			
			// construct full file path.
			m_filePath = Application.StartupPath + "\\" + fileName;

			// run the test
			try
			{
				Run();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}

			// display dilaog.
			ShowDialog();

			// dispose of dataset.
			if (m_dataset != null) 
			{
				m_dataset.Dispose();
				m_dataset = null;
			}
		}

		/// <summary>
		/// Runs all test cases and displays the results.
		/// </summary>
		private void Run()
		{
			TsCHdaItem[] items = null;

			try
			{
				// clear existing results.
				ResultsLV.Items.Clear();

				// free the existing dataset.
				if (m_dataset != null) 
				{
					m_dataset.Dispose();
					m_dataset = null;
				}

				// load the dataset.
				TestData[] tests = LoadDataSet();

				if (tests == null)
				{
					return;
				}

				// create the item.
				OpcItemResult[] results = m_server.CreateItems(new OpcItem[] { new OpcItem(m_itemID) });

				if (results == null || results.Length != 1)
				{
					//throw new InvalidResponseException();
				}

				// return items.
				items = new TsCHdaItem[] { new TsCHdaItem(results[0]) };

				// execute test cases.
				foreach (TestData test in tests)
				{
					ExecuteTest(test, items);
				}

				// adjust columns.
				AdjustColumns();

				// scroll to the first failed result.
				for (int ii = 0; ii < ResultsLV.Items.Count; ii++)
				{
					if (ResultsLV.Items[ii].ForeColor == Color.Red)
					{						
						ResultsLV.EnsureVisible(ii);
						break;
					}
				}
			}
			finally
			{				
				if (items != null)
				{
					try   { m_server.ReleaseItems(items); }
					catch {}
				}
			}
		}

		/// <summary>
		/// Loads the dataset containing the test descriptions.
		/// </summary>
		private TestData[] LoadDataSet()
		{
			try
			{
				// create the dataset.
				m_dataset = new _DataSet();

				// load the test case descriptions.
				m_dataset.ReadXml(m_filePath);

				// select only the desired test cases. 
				m_dataset.TestCases.DefaultView.Sort = "Name";

				// execute the test cases.
				ArrayList tests = new ArrayList(m_dataset.TestCases.DefaultView.Count);

				foreach (DataRowView row in m_dataset.TestCases.DefaultView)
				{
					_DataSet.TestCase testcase = (_DataSet.TestCase)row.Row;

					// create trend.
					TsCHdaTrend trend = new TsCHdaTrend(m_server);

					trend.Name             = testcase.Name;
					trend.Aggregate      = testcase.AggregateID;
					trend.MaxValues        = testcase.MaxValues;
					trend.IncludeBounds    = testcase.IncludeBounds;
					trend.ResampleInterval = testcase.ResampleInterval;

					if (testcase.StartTime != Decimal.MinValue)
					{
						trend.StartTime = new TsCHdaTime(BASETIME.AddSeconds((double)testcase.StartTime));
					}

					if (testcase.EndTime != Decimal.MinValue)
					{
						trend.EndTime = new TsCHdaTime(BASETIME.AddSeconds((double)testcase.EndTime));
					}

					TestData test = new TestData();

					test.TestCase = testcase;
					test.Trend    = trend;
					test.Expected = GetExpectedResults(testcase);

					// add to list.
					tests.Add(test);
				}

				// return set of trends.
				return (TestData[])tests.ToArray(typeof(TestData));
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return null;
		}

		/// <summary>
		/// Creates the item to use for the tests.
		/// </summary>
		private void ExecuteTest(TestData test, TsCHdaItem[] items)
		{
			try
			{
				// read values from server.
				TsCHdaItemValueCollection[] actualResults = test.Trend.Read(items);

				if (actualResults == null || actualResults.Length != 1)
				{
					//throw new InvalidResponseException();
				}

				// check results.
				test.Actual = actualResults[0];
				test.Passed = CheckResults(test.Expected, test.Actual);
			}
			catch (Exception e)
			{
				test.Actual = new TsCHdaItemValueCollection();
				test.Actual.Result = OpcResult.E_FAIL;
				test.Actual.DiagnosticInfo = e.Message;
			}

			// add test data to list view.
			AddItem(test);
		}

		/// <summary>
		/// Reads the expected results for a test case from the dataset.
		/// </summary>
		private TsCHdaItemValueCollection GetExpectedResults(_DataSet.TestCase testcase)
		{
			// create item value collection.
			TsCHdaItemValueCollection values = new TsCHdaItemValueCollection();

			try
			{
				// set expected result.
				values.Result = new OpcResult(testcase.ResultID, "");

				// get the item values.
				DataRow[] rows = testcase.GetChildRows(m_dataset.TestCases.ChildRelations[0]);

				// read the expected values.
				if (rows != null)
				{
					foreach (_DataSet.TsCHdaItemValue row in rows)
					{
						// create item value.
						TsCHdaItemValue value = new TsCHdaItemValue();

						if (!typeof(DBNull).IsInstanceOfType(row["Value"]))
						{
							value.Value = row.Value;
						}

						value.Timestamp        = BASETIME.AddSeconds((double)row.Timestamp);
						value.Quality          = new Da.TsCDaQuality((short)(row.Quality & 0x000FFFF));
						value.HistorianQuality = (OpcClientSdk.Hda.TsCHdaQuality)Enum.ToObject(typeof(OpcClientSdk.Hda.TsCHdaQuality), (int)(row.Quality & 0xFFFF0000));

						// add to list.
						values.Add(value);
					}
				}
			}
			catch (Exception)
			{
				// ignore exceptions - return at whatever was read correctly.
			}

			// return set of values.
			return values;
		}

		/// <summary>
		/// Compares the expected results to the actual results.
		/// </summary>
		private bool CheckResults(TsCHdaItemValueCollection expected, TsCHdaItemValueCollection actual)
		{
			// check result codes.
			if (expected.Result.Name.Name != actual.Result.Name.Name)
			{
				return false;
			}

			// check that number of results are equal.
			if (expected.Count != actual.Count)
			{
				return false;
			}

			for (int ii = 0; ii < expected.Count; ii++)
			{
				// compare timestamps.
				if (expected[ii].Timestamp != actual[ii].Timestamp)
				{
					return false;
				}

				// compare quality.
				if (expected[ii].Quality != actual[ii].Quality)
				{
					return false;
				}

				// compare histrorian quality.
				if (expected[ii].HistorianQuality != actual[ii].HistorianQuality)
				{
					return false;
				}

				// check for null (empty or bad values).
				if (expected[ii].Value == null || actual[ii].Value == null)
				{
					if (expected[ii].Value != actual[ii].Value)
					{
						return false;
					}
				}

				// comapare value - allowing for some round off errors.
				else
				{
					decimal expectedValue = System.Convert.ToDecimal(expected[ii].Value);
					decimal actualValue   = System.Convert.ToDecimal(actual[ii].Value);

					if (Math.Abs(expectedValue - actualValue) > 0.001M)
					{
						return false;
					}
				}
			}

			// test passed - actual results match expected.
			return true;
		}

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int TESTCASE            = 0;
		private const int AGGREGATE           = 1;
		private const int START_TIME          = 2;
		private const int END_TIME            = 3;
		private const int MAX_VALUES          = 4;
		private const int INCLUDE_BOUNDS      = 5;
		private const int RESAMPLING_INTERVAL = 6;
		private const int RESULT              = 7;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Test Case",
			"Aggregate",
			"Start",
			"End",
			"Max",
			"Bounds",
			"Sampling",
			"Result"
		};
		
		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			ResultsLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				ResultsLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < ResultsLV.Columns.Count; ii++)
			{
				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in ResultsLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						ResultsLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) ResultsLV.Columns[ii].Width = 0;
			}
		}
	
		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddItem(TestData test)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateItem(listItem, test);

			// add to list view.
			ResultsLV.Items.Add(listItem);
		}

		/// <summary>
		/// Updates the columns of an item in the list view.
		/// </summary>
		private void UpdateItem(ListViewItem listItem, TestData test)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(test, ii));
			}

			// flag tests that failed.
			listItem.ForeColor = (test.Passed)?Color.Empty:Color.Red;
			
			// save object as list view item tag.
			listItem.Tag = test;
		}

		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TestData test, int fieldID)
		{
			if (test == null)
			{
				return null;
			}

			switch (fieldID)
			{
				case TESTCASE: { return test.Trend.Name; }
				
				case AGGREGATE:           
				{ 
					if (test.Trend.Aggregate != TsCHdaAggregateID.NoAggregate)
					{
						foreach (TsCHdaAggregate aggregate in m_server.Aggregates)
						{
							if (aggregate.Id == test.Trend.Aggregate)
							{
								return aggregate;
							}
						}
					}

					return null;
				}

				case START_TIME:   
				{ 
					if (test.Trend.StartTime != null)
					{
						return test.Trend.StartTime.AbsoluteTime.ToString("HH:mm:ss"); 
					}

					return null;
				}

				case END_TIME: 
				{ 
					if (test.Trend.EndTime != null)
					{
						return test.Trend.EndTime.AbsoluteTime.ToString("HH:mm:ss"); 
					}

					return null;
				}

				case MAX_VALUES:   
				{
					if (test.Trend.Aggregate == TsCHdaAggregateID.NoAggregate)
					{
						return test.Trend.MaxValues;
					}

					return null;
				}

				case INCLUDE_BOUNDS:  
				{
					if (test.Trend.Aggregate == TsCHdaAggregateID.NoAggregate)
					{
						return test.Trend.IncludeBounds;
					}

					return null;
				}

				case RESAMPLING_INTERVAL:
				{
					if (test.Trend.Aggregate != TsCHdaAggregateID.NoAggregate)
					{
						return test.Trend.ResampleInterval;
					}

					return null;
				}

				case RESULT: 
				{
					// check if passed.
					if (test.Passed)
					{
						return String.Format("Passed ({0}, {1} Values)", test.Expected.Result.Name.Name, test.Expected.Count);
					}

					if (test.Actual != null)
					{
						// exception thrown.
						if (test.Actual.DiagnosticInfo != null)
						{
							return test.Actual.DiagnosticInfo;
						}

						// result code wrong.
						if (test.Actual.Result.Name.Name != test.Expected.Result.Name.Name)
						{
							return "Unexpected result: " + test.Actual.Result;
						}
						
						// incorrect values.
						return "Incorrect set of item values.";
					}

					// test not executed.
					return null;
				}
			}

			return null;
		}

		/// <summary>
		/// Updates the a testcase in the dataset.
		/// </summary>
		private void UpdateTestCase(TestData test)
		{
			// update the test case.
			test.TestCase.Name             = test.Trend.Name;
			test.TestCase.AggregateID      = test.Trend.Aggregate;
			test.TestCase.StartTime        = Decimal.MinValue;
			test.TestCase.EndTime          = Decimal.MinValue;
			test.TestCase.MaxValues        = test.Trend.MaxValues;
			test.TestCase.IncludeBounds    = test.Trend.IncludeBounds;
			test.TestCase.ResampleInterval = test.Trend.ResampleInterval;
			test.TestCase.ResultID         = test.Expected.Result.Name.Name;

			if (test.Trend.StartTime != null)
			{
				test.TestCase.StartTime = (decimal)((TimeSpan)(test.Trend.StartTime.AbsoluteTime - BASETIME)).TotalSeconds;
			}		

			if (test.Trend.EndTime != null)
			{
				test.TestCase.EndTime = (decimal)((TimeSpan)(test.Trend.EndTime.AbsoluteTime - BASETIME)).TotalSeconds;
			}

			// get child rows.
			DataRow[] rows = test.TestCase.GetChildRows(m_dataset.TestCases.ChildRelations[0]);

			// update existing records or add new records as required.
			for (int ii = 0; ii < test.Expected.Count; ii++)
			{
				_DataSet.TsCHdaItemValue value = null;

				if (rows != null && ii < rows.Length)
				{
					value = (_DataSet.TsCHdaItemValue)rows[ii];
				}
				else
				{
					value = m_dataset.ItemValues.NewItemValue();
					value.TestCase = test.TestCase;					
					m_dataset.ItemValues.AddItemValue(value);
				}

				if (test.Expected[ii].Value != null)
				{
					value.Value = System.Convert.ToDouble(test.Expected[ii].Value);
				}
				else
				{
					value["Value"] = DBNull.Value;
				}

				value.Timestamp  = (decimal)((TimeSpan)(test.Expected[ii].Timestamp - BASETIME)).TotalSeconds;
				value.Quality    = (int)test.Expected[ii].Quality.GetCode();
				value.Quality   |= (int)test.Expected[ii].HistorianQuality;
			}

			// delete unnecessary records.
			if (rows != null)
			{
				for (int ii = test.Expected.Count; ii < rows.Length; ii++)
				{
					rows[ii].Delete();
				}
			}
		}

		/// <summary>
		/// Adds a new test case.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create new test case.
				TestData test = new TestData();

				test.Trend                  = new TsCHdaTrend(m_server);
				test.Trend.Name             = "Test01";
				test.Trend.Aggregate = TsCHdaAggregateID.NoAggregate;
				test.Trend.StartTime        = new TsCHdaTime(BASETIME);
				test.Trend.EndTime          = new TsCHdaTime(BASETIME);
				test.Trend.MaxValues        = 0;
				test.Trend.IncludeBounds    = false;
				test.Trend.ResampleInterval = 0;

				test.Expected = new TsCHdaItemValueCollection();

				// prompt user to edit test case.
				if (!new TestEditDlg().ShowDialog(m_server, test))
				{
					return;
				}
				
				// create test case.
				test.TestCase = m_dataset.TestCases.NewTestCase();
				m_dataset.TestCases.AddTestCase(test.TestCase);

				// update test case.
				UpdateTestCase(test);

				// accept changes and save the dataset.
				m_dataset.AcceptChanges();
				m_dataset.WriteXml(m_filePath);

				// update display.
				AddItem(test);
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
				if (ResultsLV.SelectedItems.Count != 1)
				{
					return;
				}

				TestData test = (TestData)ResultsLV.SelectedItems[0].Tag;

				// create new test case.
				TestData copy = new TestData();

				copy.Trend    = (TsCHdaTrend)test.Trend.Clone();
				copy.Expected = (TsCHdaItemValueCollection)test.Expected.Clone();

				// prompt user to edit test case.
				if (!new TestEditDlg().ShowDialog(m_server, copy))
				{
					return;
				}

				// create test case.
				copy.TestCase = m_dataset.TestCases.NewTestCase();
				m_dataset.TestCases.AddTestCase(copy.TestCase);

				// update test case.
				UpdateTestCase(copy);

				// accept changes and save the dataset.
				m_dataset.AcceptChanges();
				m_dataset.WriteXml(m_filePath);

				// update display.
				AddItem(copy);
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
				if (ResultsLV.SelectedItems.Count != 1)
				{
					return;
				}

				TestData test = (TestData)ResultsLV.SelectedItems[0].Tag;

				if (!new TestEditDlg().ShowDialog(m_server, test))
				{
					return;
				}

				// update test case.
				UpdateTestCase(test);

				// accept changes and save the dataset.
				m_dataset.AcceptChanges();
				m_dataset.WriteXml(m_filePath);

				// update display.
				UpdateItem(ResultsLV.SelectedItems[0], test);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Deletes am existing test case.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ResultsLV.SelectedItems.Count != 1)
				{
					return;
				}

				TestData test = (TestData)ResultsLV.SelectedItems[0].Tag;

				// confirm delete.
				DialogResult result = MessageBox.Show("Permenently delete the test case?", test.Trend.Name, MessageBoxButtons.YesNo);

				if (result != DialogResult.Yes)
				{
					return;
				}

				// fetch the current index in the dataset.
				int index = m_dataset.TestCases.DefaultView.Find(test.Trend.Name);

				if (index == -1)
				{
					return;
				}

				_DataSet.TestCase testcase = (_DataSet.TestCase)m_dataset.TestCases.DefaultView[index].Row;

				// delete the test case.
				testcase.Delete();

				// accept changes and save the dataset.
				m_dataset.AcceptChanges();
				m_dataset.WriteXml(m_filePath);

				// update display.
				ResultsLV.SelectedItems[0].Remove();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Updates state of the popup menu before display.
		/// </summary>
		private void ResultsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			AddMI.Enabled    = true;
			CopyMI.Enabled   = false;
			EditMI.Enabled   = false;
			RemoveMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ResultsLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (ResultsLV.SelectedItems.Count == 1)
			{			
				CopyMI.Enabled   = true;
				EditMI.Enabled   = true;
				RemoveMI.Enabled = true;
			}
		}

		/// <summary>
		/// Re-runs the tests.
		/// </summary>
		private void RunBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				Run();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
