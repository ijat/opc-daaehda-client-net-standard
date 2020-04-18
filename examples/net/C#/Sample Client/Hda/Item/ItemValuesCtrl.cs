using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Da;
using OpcClientSdk.Controls;
using scpl;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// Summary description for ReadParametersCtrl.
	/// </summary>
	public class ItemValuesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ValuesLV;
		private System.Windows.Forms.Panel MainPN;
		private scpl.Windows.PlotSurface2D PlotCTRL;
		private System.Windows.Forms.Panel PlotPN;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem AddMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem Separator01;
		private System.Windows.Forms.MenuItem GraphMI;
		private System.Windows.Forms.MenuItem DataMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.MenuItem Separator02;
		private System.Windows.Forms.MenuItem ImportValuesMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemValuesCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ValuesLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.GraphMI = new System.Windows.Forms.MenuItem();
			this.DataMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.AddMI = new System.Windows.Forms.MenuItem();
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.Separator02 = new System.Windows.Forms.MenuItem();
			this.ImportValuesMI = new System.Windows.Forms.MenuItem();
			this.MainPN = new System.Windows.Forms.Panel();
			this.PlotPN = new System.Windows.Forms.Panel();
			this.PlotCTRL = new scpl.Windows.PlotSurface2D();
			this.MainPN.SuspendLayout();
			this.PlotPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ValuesLV
			// 
			this.ValuesLV.ContextMenu = this.PopupMenu;
			this.ValuesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ValuesLV.FullRowSelect = true;
			this.ValuesLV.Location = new System.Drawing.Point(0, 0);
			this.ValuesLV.Name = "ValuesLV";
			this.ValuesLV.Size = new System.Drawing.Size(544, 360);
			this.ValuesLV.TabIndex = 1;
			this.ValuesLV.View = System.Windows.Forms.View.Details;
			this.ValuesLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ValuesLV_MouseDown);
			this.ValuesLV.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.GraphMI,
																					  this.DataMI,
																					  this.Separator01,
																					  this.AddMI,
																					  this.CopyMI,
																					  this.EditMI,
																					  this.RemoveMI,
																					  this.Separator02,
																					  this.ImportValuesMI});
			// 
			// GraphMI
			// 
			this.GraphMI.Index = 0;
			this.GraphMI.RadioCheck = true;
			this.GraphMI.Text = "Graph";
			this.GraphMI.Click += new System.EventHandler(this.GraphMI_Click);
			// 
			// DataMI
			// 
			this.DataMI.Checked = true;
			this.DataMI.Index = 1;
			this.DataMI.RadioCheck = true;
			this.DataMI.Text = "Data";
			this.DataMI.Click += new System.EventHandler(this.DataMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 2;
			this.Separator01.Text = "-";
			// 
			// AddMI
			// 
			this.AddMI.Index = 3;
			this.AddMI.Text = "Add...";
			this.AddMI.Click += new System.EventHandler(this.AddMI_Click);
			// 
			// CopyMI
			// 
			this.CopyMI.Index = 4;
			this.CopyMI.Text = "Copy...";
			this.CopyMI.Click += new System.EventHandler(this.CopyMI_Click);
			// 
			// EditMI
			// 
			this.EditMI.Index = 5;
			this.EditMI.Text = "Edit...";
			this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// RemoveMI
			// 
			this.RemoveMI.Index = 6;
			this.RemoveMI.Text = "Remove";
			this.RemoveMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// Separator02
			// 
			this.Separator02.Index = 7;
			this.Separator02.Text = "-";
			// 
			// ImportValuesMI
			// 
			this.ImportValuesMI.Index = 8;
			this.ImportValuesMI.Text = "Import Values...";
			this.ImportValuesMI.Click += new System.EventHandler(this.ImportValuesMI_Click);
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.ValuesLV);
			this.MainPN.Controls.Add(this.PlotPN);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(544, 360);
			this.MainPN.TabIndex = 2;
			// 
			// PlotPN
			// 
			this.PlotPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.PlotPN.Controls.Add(this.PlotCTRL);
			this.PlotPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlotPN.Location = new System.Drawing.Point(0, 0);
			this.PlotPN.Name = "PlotPN";
			this.PlotPN.Size = new System.Drawing.Size(544, 360);
			this.PlotPN.TabIndex = 3;
			// 
			// PlotCTRL
			// 
			this.PlotCTRL.AllowSelection = false;
			this.PlotCTRL.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.PlotCTRL.ContextMenu = this.PopupMenu;
			this.PlotCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlotCTRL.HorizontalEdgeLegendPlacement = scpl.Legend.Placement.Inside;
			this.PlotCTRL.LegendBorderStyle = scpl.Legend.BorderType.Shadow;
			this.PlotCTRL.LegendXOffset = 10F;
			this.PlotCTRL.LegendYOffset = 1F;
			this.PlotCTRL.Location = new System.Drawing.Point(0, 0);
			this.PlotCTRL.Name = "PlotCTRL";
			this.PlotCTRL.Padding = 10;
			this.PlotCTRL.PlotBackColor = System.Drawing.Color.White;
			this.PlotCTRL.ShowLegend = false;
			this.PlotCTRL.Size = new System.Drawing.Size(540, 356);
			this.PlotCTRL.TabIndex = 2;
			this.PlotCTRL.Title = "";
			this.PlotCTRL.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.PlotCTRL.VerticalEdgeLegendPlacement = scpl.Legend.Placement.Outside;
			this.PlotCTRL.XAxis1 = null;
			this.PlotCTRL.XAxis2 = null;
			this.PlotCTRL.YAxis1 = null;
			this.PlotCTRL.YAxis2 = null;
			// 
			// ItemValuesCtrl
			// 
			this.Controls.Add(this.MainPN);
			this.Name = "ItemValuesCtrl";
			this.Size = new System.Drawing.Size(544, 360);
			this.MainPN.ResumeLayout(false);
			this.PlotPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Whether the item values can be changed. 
		/// </summary>
		public bool ReadOnly
		{
			get { return m_readOnly;  }
			set { m_readOnly = value; }
		}

		/// <summary>
		/// Whether the controls displays the results in a graph.
		/// </summary>
		public bool DisplayGraph
		{
			get 
			{
				return GraphMI.Checked;  
			}
			
			set 
			{
				GraphMI.Checked = value;  
				SetState(value);
			}
		}

		/// <summary>
		/// Initializes the control with a set of items.
		/// </summary>
		public void Initialize(TsCHdaServer server, TsCHdaItemValueCollection values)
		{
			m_server = server;
			m_item   = values;

			ValuesLV.Items.Clear();
			PlotCTRL.Clear();

			if (values != null)
			{
				// add item values to list.
				foreach (TsCHdaItemValue value in values)
				{
					AddListItem(value, -1);
				}

				// adjust the list view columns to fit the data.
				AdjustColumns();
			}

			// update control state.
			SetState(GraphMI.Checked);
		}	

		/// <summary>
		/// Returns the set of item values stored in the list control.
		/// </summary>
		public TsCHdaItemValueCollection GetValues()
		{
			TsCHdaItemValueCollection values = new TsCHdaItemValueCollection();

			foreach (ListViewItem listItem in ValuesLV.Items)
			{
				if (typeof(TsCHdaItemValue).IsInstanceOfType(listItem.Tag))
				{
					values.Add(listItem.Tag);
				}
			}

			return values;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int TIMESTAMP         = 0;
		private const int VALUE             = 1;
		private const int QUALITY           = 2;
		private const int HISTORIAN_QUALITY = 3;
		private const int MODIFICATION_TIME = 4;
		private const int EDIT_TYPE         = 5;
		private const int USER              = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Timestamp",
			"Value",
			"Quality",
			"Historian Quality",
			"Modified",
			"Edit Type",
			"User"
		};
		
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// The current item id.
		/// </summary>
		private OpcItem m_item = null;

		/// <summary>
		/// Whether the item values can be changed. 
		/// </summary>
		private bool m_readOnly = false;

		/// <summary>
		/// Updates the enabled/visibility state of al contols.
		/// </summary>
		private void SetState(bool graph)
		{
			GraphMI.Checked  = graph;
			DataMI.Checked   = !graph;
			ValuesLV.Visible = !graph;
			PlotPN.Visible   = graph;
			AddMI.Enabled    = !graph;
			EditMI.Enabled   = !graph;
			RemoveMI.Enabled = !graph;

			if (GraphMI.Checked)
			{
				DrawGraph();
			}
		}

		/// <summary>
		/// Determines what time units should be used for the value collection.
		/// </summary>
		private double CalculateUnits(TsCHdaItemValueCollection values)
		{
			TimeSpan range = (values.EndTime - values.StartTime);

			if (values.Count > 0)
			{
				// calculate the total span.
				range = (values[values.Count-1].Timestamp-values[0].Timestamp);

				// up to 100 hours before switching to days.
				if (Math.Abs(range.TotalDays) > 4)
				{
					return TimeSpan.TicksPerDay;
				}

				// up to 1000 minutes before switching to hours.
				if (Math.Abs(range.TotalHours) > 16)
				{
					return TimeSpan.TicksPerHour;
				}

				// up to 1000 seconds before switching to minutes.
				if (Math.Abs(range.TotalMinutes) > 16)
				{
					return TimeSpan.TicksPerMinute;
				}
			}

			// default is seconds.
			return TimeSpan.TicksPerSecond;
		}

		/// <summary>
		/// Creates a set of points from an item value collection.
		/// </summary>
		private ArrayAdapter CreateAdapter(
			TsCHdaItemValueCollection values, 
			int                 qualityMask,
			DateTime            startTime,
			double              units)
		{
			// select only those values with the specified quality.
			ArrayList points = new ArrayList();

			foreach (TsCHdaItemValue value in values)
			{
				int qualityBits = (int)value.Quality.QualityBits & 0xC0;

				if (qualityBits == qualityMask)
				{
					points.Add(value);
				}
			}

			// no values meet quality criteria. 
			if (points.Count == 0)
			{
				return null;
			}

			// create array.
			double[] xs = new double[points.Count];
			double[] ys = new double[points.Count];

			for (int ii = 0; ii < points.Count; ii++)
			{
				TsCHdaItemValue value = (TsCHdaItemValue)points[ii];

				// calculate the difference between the start time and the current timestamp.
				long delta = ((TimeSpan)(value.Timestamp - startTime)).Ticks;

				xs[ii] = ((double)delta)/units;
				ys[ii] = System.Convert.ToDouble(value.Value);
			}

			// return points.
			return new ArrayAdapter(xs, ys);
		}

		/// <summary>
		/// Create the time axis label for a plot.
		/// </summary>
		private string CreateLabel(DateTime startTime, double units)
		{
			StringBuilder buffer = new StringBuilder();

			if (units == (double)TimeSpan.TicksPerDay)
			{
				buffer.Append("Days");
			}
			else if (units == (double)TimeSpan.TicksPerHour)
			{
				buffer.Append("Hours");
			}
			else if (units == (double)TimeSpan.TicksPerMinute)
			{
				buffer.Append("Minutes");
			}
			else if (units == (double)TimeSpan.TicksPerSecond)
			{
				buffer.Append("Seconds");
			}
			else
			{
				buffer.Append("Time");
			}

			buffer.Append(" (From ");
			buffer.Append(startTime.ToString("yyyy-MM-dd HH:mm:ss"));
			buffer.Append(")");

			return buffer.ToString();
		}

		/// <summary>
		/// Draws a graph for the current set of values.
		/// </summary>
		private void DrawGraph()
		{
			// clear existing plot.
			PlotCTRL.Clear();

			// update title.
			if (m_item != null && m_item.ItemName != null && m_item.ItemName != "")
			{
				PlotCTRL.Title = m_item.ItemName;
			}

			// get current set of values.
			TsCHdaItemValueCollection values = GetValues();

			if (values == null || (values.Count == 0 && (values.StartTime == DateTime.MinValue || values.EndTime == DateTime.MinValue)))
			{
				PlotCTRL.Add(new PointPlot(new ArrayAdapter(new double[] { 0, 100 }, new double[] { 0, 100 })));
				PlotCTRL.XAxis1.Label = "No Data Available";
				PlotCTRL.Refresh();

				return;
			}

			// determine the best set of units.
			double units = CalculateUnits(values);

			// the first timestamp is the reference point for the plot.
			DateTime startTime = (values.Count > 0)?values[0].Timestamp:values.StartTime;

			// display empty set by plotting the time axis.
			if (values.Count == 0)
			{
				// create array.
				double[] xs = new double[2];
				double[] ys = new double[2];
				
				xs[0] = 0;
				ys[0] = 0;

				xs[1] = ((double)(((TimeSpan)(values.EndTime - startTime)).Ticks))/units;
				ys[1] = 100;

				PlotCTRL.Add(new PointPlot(new ArrayAdapter(xs, ys)));
				PlotCTRL.XAxis1.Label = CreateLabel(startTime, units);
				PlotCTRL.Refresh();

				return;
			}
			
			// create seperate plots for each quality of data.
			int[] qualityMasks = new int[] { 0xC0, 0x40, 0x00 };
			
			// create different icons for each type of data.
			Marker[] markers = new Marker[] 
			{
				new Marker(MarkerType.Circle, 4, new Pen(Color.Black)),
				new Marker(MarkerType.Square, 4, new Pen(Color.Blue)),
				new Marker(MarkerType.Cross1, 4, new Pen(Color.Red))
			};

			// add plots to control.
			for (int ii = 0; ii < qualityMasks.Length; ii++)
			{
				ArrayAdapter adpater = CreateAdapter(values, qualityMasks[ii], startTime, units);

				if (adpater != null)
				{
					if (adpater.Count < 40)
					{
						PlotCTRL.Add(new PointPlot(adpater, markers[ii]));
					}
					else
					{
						PlotCTRL.Add(new LinePlot(adpater));
					}
				}
			}
			
			// update the label.
			PlotCTRL.XAxis1.Label = CreateLabel(startTime, units);

			// display the data. 
			PlotCTRL.Refresh();	
		}

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
				// always show the timestamp column.
				if (ii == TIMESTAMP)
				{
					ValuesLV.Columns[ii].Width = -2;
					continue;
				}

				// the value column has a default width of 100.
				if (ii == VALUE)
				{
					if (ValuesLV.Columns[ii].Width < 100)
					{
						ValuesLV.Columns[ii].Width = 100;
					}

					continue;
				}

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

				// set column width to zero if no data it in.
				if (empty) ValuesLV.Columns[ii].Width = 0;
			}
		}
		
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCHdaItemValue value, int fieldID)
		{
			if (value != null)
			{
				switch (fieldID)
				{
					case TIMESTAMP:         { return value.Timestamp;        }
					case VALUE:             { return value.Value;            }
					case QUALITY:           { return value.Quality;          }
					case HISTORIAN_QUALITY: { return value.HistorianQuality; }
				}

				if (typeof(TsCHdaModifiedValue).IsInstanceOfType(value))
				{
					switch (fieldID)
					{
						case MODIFICATION_TIME: { return ((TsCHdaModifiedValue)value).ModificationTime; }
						case EDIT_TYPE:         { return ((TsCHdaModifiedValue)value).EditType;         }
						case USER:              { return ((TsCHdaModifiedValue)value).User;             }
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(TsCHdaItemValue value, int index)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateListItem(listItem, value);
	
			// add to list view.
			if (index < 0)
			{
				ValuesLV.Items.Add(listItem);
			}
			else
			{
				ValuesLV.Items.Insert(index, listItem);
			}
		}

		/// <summary>
		/// Updates an item in the list view.
		/// </summary>
		private void UpdateListItem(ListViewItem listItem, TsCHdaItemValue value)
		{
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(value, ii));
			}

			// save object as list view item tag.
			listItem.Tag = value;
		}
		#endregion

		/// <summary>
		/// Activates or deactivates the graph view mode.
		/// </summary>
		private void GraphMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// toggle check box.
				GraphMI.Checked = !GraphMI.Checked;
				
				// update state.
				SetState(GraphMI.Checked);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Activates or deactivates the raw data view mode.
		/// </summary>
		private void DataMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// toggle check box.
				DataMI.Checked = !DataMI.Checked;
				
				// update state.
				SetState(!DataMI.Checked);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}


		/// <summary>
		/// Adds a new item value.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check control state.
				if (ReadOnly)
				{
					return;
				}

				// create new item value.
				TsCHdaItemValue value = new TsCHdaItemValue();

				value.Value            = new Double();
				value.Timestamp        = RunTestDlg.BASETIME;
				value.Quality          = Da.TsCDaQuality.Good;
				value.HistorianQuality = Hda.TsCHdaQuality.Raw;

				// prompt user to edit item value.
				value = new ItemValueEditDlg().ShowDialog(value);

				if (value == null)
				{
					return;
				}

				// get the current selection.
				int index = -1;

				if (ValuesLV.SelectedIndices.Count > 0)
				{
					index = ValuesLV.SelectedIndices[ValuesLV.SelectedIndices.Count-1];
				}

				// update display.
				AddListItem(value, index);

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Adds a new item value by copying an existing one.
		/// </summary>
		private void CopyMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly || ValuesLV.SelectedItems.Count != 1)
				{
					return;
				}

				TsCHdaItemValue value = (TsCHdaItemValue)ValuesLV.SelectedItems[0].Tag;

				// create new item value.
				TsCHdaItemValue copy = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)value.Clone());

				// prompt user to edit item value.
				if (copy == null)
				{
					return;
				}
				
				// update display.
				AddListItem(copy, ValuesLV.SelectedIndices[0]);

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits the parameters of s item value.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly || ValuesLV.SelectedItems.Count != 1)
				{
					return;
				}

				// create new item value.
				TsCHdaItemValue value = new ItemValueEditDlg().ShowDialog((TsCHdaItemValue)ValuesLV.SelectedItems[0].Tag);

				// prompt user to edit item value.
				if (value == null)
				{
					return;
				}
				
				// update display.
				UpdateListItem(ValuesLV.SelectedItems[0], value);
				
				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Deletes am existing item value.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly || ValuesLV.SelectedItems.Count == 0)
				{
					return;
				}
				
				// update display.
				ArrayList items = new ArrayList();

				foreach (ListViewItem listItem in ValuesLV.SelectedItems)
				{
					items.Add(listItem);
				}

				foreach (ListViewItem listItem in items)
				{
					listItem.Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Imports item values from another item.
		/// </summary>
		private void ImportValuesMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (ReadOnly)
				{
					return;
				}

				// prompt user to select values from another item.
				TsCHdaItemValueCollection values = new ReadValuesDlg().ShowDialog(m_server, RequestType.ReadRaw, true);

				if (values == null)
				{
					return;
				}

				// get the current selection.
				int index = 0;

				if (ValuesLV.SelectedIndices.Count > 0)
				{
					index = ValuesLV.SelectedIndices[ValuesLV.SelectedIndices.Count-1];
				}

				// add new values to list.
				foreach (TsCHdaItemValue value in values)
				{
					AddListItem(value, index++);
				}				  

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Updates the state of the menu buttons when the mouse is pressed.
		/// </summary>
		private void ValuesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default values.
			AddMI.Enabled          = !ReadOnly;
			CopyMI.Enabled         = false;
			EditMI.Enabled         = false;
			RemoveMI.Enabled       = false;
			ImportValuesMI.Enabled = !ReadOnly;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ValuesLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (ValuesLV.SelectedItems.Count == 1)
			{			
				CopyMI.Enabled   = !ReadOnly;
				EditMI.Enabled   = !ReadOnly;
			}

			if (ValuesLV.SelectedItems.Count > 0)
			{			
				RemoveMI.Enabled = !ReadOnly;
			}		
		}
	}
}
