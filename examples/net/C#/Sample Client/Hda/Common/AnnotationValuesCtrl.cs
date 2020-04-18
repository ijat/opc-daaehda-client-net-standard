using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk.Controls;
using OpcClientSdk;
using scpl;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// Summary description for ReadParametersCtrl.
	/// </summary>
	public class AnnotationValuesCtrl : System.Windows.Forms.UserControl
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

		public AnnotationValuesCtrl()
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
			// 
			// DataMI
			// 
			this.DataMI.Checked = true;
			this.DataMI.Index = 1;
			this.DataMI.RadioCheck = true;
			this.DataMI.Text = "Data";
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
			// AnnotationValuesCtrl
			// 
			this.Controls.Add(this.MainPN);
			this.Name = "AnnotationValuesCtrl";
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
		/// Initializes the control with a set of items.
		/// </summary>
		public void Initialize(TsCHdaServer server, TsCHdaAnnotationValueCollection values)
		{
			m_server = server;
			m_item   = values;

			ValuesLV.Items.Clear();

			if (values != null)
			{
				// add item values to list.
				foreach (TsCHdaAnnotationValue value in values)
				{
					AddListItem(value, -1);
				}

				// adjust the list view columns to fit the data.
				AdjustColumns();
			}
		}	

		/// <summary>
		/// Returns the set of item values stored in the list control.
		/// </summary>
		public TsCHdaAnnotationValueCollection GetValues()
		{
			TsCHdaAnnotationValueCollection values = new TsCHdaAnnotationValueCollection();

			foreach (ListViewItem listItem in ValuesLV.Items)
			{
				if (typeof(TsCHdaAnnotationValue).IsInstanceOfType(listItem.Tag))
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
		private const int TIMESTAMP     = 0;
		private const int VALUE         = 1;
		private const int CREATION_TIME = 2;
		private const int USER          = 3;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Timestamp",
			"Annotation",
			"Created",
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

				// the value column has a default width of 200.
				if (ii == VALUE)
				{
					if (ValuesLV.Columns[ii].Width < 200)
					{
						ValuesLV.Columns[ii].Width = 200;
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
		private object GetFieldValue(TsCHdaAnnotationValue value, int fieldID)
		{
			if (value != null)
			{
				switch (fieldID)
				{
					case TIMESTAMP:     { return value.Timestamp;    }
					case VALUE:         { return value.Annotation;   }
					case CREATION_TIME: { return value.CreationTime; }
					case USER:          { return value.User;         }
				}
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(TsCHdaAnnotationValue value, int index)
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
		private void UpdateListItem(ListViewItem listItem, TsCHdaAnnotationValue value)
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
				TsCHdaAnnotationValue value = new TsCHdaAnnotationValue();

				value.Annotation   = null;
				value.Timestamp    = RunTestDlg.BASETIME;
				value.CreationTime = DateTime.MinValue;
				value.User         = null;

				// prompt user to edit item value.
				value = new AnnotationValueEditDlg().ShowDialog(value);

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

				TsCHdaAnnotationValue value = (TsCHdaAnnotationValue)ValuesLV.SelectedItems[0].Tag;

				// create new item value.
				TsCHdaAnnotationValue copy = new AnnotationValueEditDlg().ShowDialog((TsCHdaAnnotationValue)value.Clone());

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
				TsCHdaAnnotationValue value = new AnnotationValueEditDlg().ShowDialog((TsCHdaAnnotationValue)ValuesLV.SelectedItems[0].Tag);

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
				TsCHdaAnnotationValueCollection values = new ReadAnnotationsDlg().ShowDialog(m_server, true);

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
				foreach (TsCHdaAnnotationValue value in values)
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
