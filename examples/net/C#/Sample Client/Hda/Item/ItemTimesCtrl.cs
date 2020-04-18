using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;
using scpl;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// Summary description for ReadParametersCtrl.
	/// </summary>
	public class ItemTimesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView TimesLV;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem AddMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.MenuItem Separator02;
		private System.Windows.Forms.MenuItem ImportTimesMI;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemTimesCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			TimesLV.SmallImageList = Resources.Instance.ImageList;
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
			this.TimesLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.AddMI = new System.Windows.Forms.MenuItem();
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.Separator02 = new System.Windows.Forms.MenuItem();
			this.ImportTimesMI = new System.Windows.Forms.MenuItem();
			this.MainPN = new System.Windows.Forms.Panel();
			this.MainPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// TimesLV
			// 
			this.TimesLV.ContextMenu = this.PopupMenu;
			this.TimesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TimesLV.FullRowSelect = true;
			this.TimesLV.Location = new System.Drawing.Point(0, 0);
			this.TimesLV.Name = "TimesLV";
			this.TimesLV.Size = new System.Drawing.Size(544, 360);
			this.TimesLV.TabIndex = 1;
			this.TimesLV.View = System.Windows.Forms.View.Details;
			this.TimesLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimesLV_MouseDown);
			this.TimesLV.DoubleClick += new System.EventHandler(this.EditMI_Click);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddMI,
																					  this.CopyMI,
																					  this.EditMI,
																					  this.RemoveMI,
																					  this.Separator02,
																					  this.ImportTimesMI});
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
			this.EditMI.Text = "Edit...";
			this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// RemoveMI
			// 
			this.RemoveMI.Index = 3;
			this.RemoveMI.Text = "Remove";
			this.RemoveMI.Click += new System.EventHandler(this.RemoveMI_Click);
			// 
			// Separator02
			// 
			this.Separator02.Index = 4;
			this.Separator02.Text = "-";
			// 
			// ImportTimesMI
			// 
			this.ImportTimesMI.Index = 5;
			this.ImportTimesMI.Text = "Import Times...";
			this.ImportTimesMI.Click += new System.EventHandler(this.ImportTimesMI_Click);
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.TimesLV);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(544, 360);
			this.MainPN.TabIndex = 2;
			// 
			// ItemTimesCtrl
			// 
			this.Controls.Add(this.MainPN);
			this.Name = "ItemTimesCtrl";
			this.Size = new System.Drawing.Size(544, 360);
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Initializes the control with a set of items.
		/// </summary>
		public void Initialize(TsCHdaServer server, TsCHdaItemTimeCollection times)
		{
			m_server = server;

			TimesLV.Items.Clear();

			if (times != null)
			{
				// add item times to list.
				foreach (DateTime time in times)
				{
					AddListItem(time, -1);
				}

				// adjust the list view columns to fit the data.
				AdjustColumns();
			}
		}	

		/// <summary>
		/// Returns the set of item times stored in the list control.
		/// </summary>
		public TsCHdaItemTimeCollection GetTimes()
		{
			TsCHdaItemTimeCollection times = new TsCHdaItemTimeCollection();

			foreach (ListViewItem listItem in TimesLV.Items)
			{
				if (typeof(DateTime).IsInstanceOfType(listItem.Tag))
				{
					times.Add(listItem.Tag);
				}
			}

			return times;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int TIMESTAMP         = 0;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Timestamp"
		};
		
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer m_server = null;	

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			TimesLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				TimesLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < TimesLV.Columns.Count; ii++)
			{
				// always show the timestamp column.
				if (ii == TIMESTAMP)
				{
					TimesLV.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in TimesLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						TimesLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) TimesLV.Columns[ii].Width = 0;
			}
		}
		
		/// <summary>
		/// Returns the time of the specified field.
		/// </summary>
		private object GetFieldValue(DateTime time, int fieldID)
		{
			switch (fieldID)
			{
				case TIMESTAMP: { return time.ToString("yyyy-MM-dd hh:mm:ss"); }
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddListItem(DateTime time, int index)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_YELLOW_SCROLL);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// update columns.
			UpdateListItem(listItem, time);
	
			// add to list view.
			if (index < 0)
			{
				TimesLV.Items.Add(listItem);
			}
			else
			{
				TimesLV.Items.Insert(index, listItem);
			}
		}

		/// <summary>
		/// Updates an item in the list view.
		/// </summary>
		private void UpdateListItem(ListViewItem listItem, DateTime time)
		{
			// set column times.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(time, ii));
			}

			// save object as list view item tag.
			listItem.Tag = time;
		}
		#endregion

		/// <summary>
		/// Adds a new item time.
		/// </summary>
		private void AddMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// prompt user to edit item time.
				DateTime time = new ItemTimeEditDlg().ShowDialog(RunTestDlg.BASETIME);

				if (time == DateTime.MinValue)
				{
					return;
				}

				// get the current selection.
				int index = -1;

				if (TimesLV.SelectedIndices.Count > 0)
				{
					index = TimesLV.SelectedIndices[TimesLV.SelectedIndices.Count-1];
				}

				// update display.
				AddListItem(time, index);

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Adds a new item time by copying an existing one.
		/// </summary>
		private void CopyMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (TimesLV.SelectedItems.Count != 1)
				{
					return;
				}

				DateTime time = (DateTime)TimesLV.SelectedItems[0].Tag;

				// create new item time.
				DateTime copy = new ItemTimeEditDlg().ShowDialog((DateTime)time);

				// prompt user to edit item time.
				if (copy == DateTime.MinValue)
				{
					return;
				}
				
				// update display.
				AddListItem(copy, TimesLV.SelectedIndices[0]);

				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits the parameters of s item time.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (TimesLV.SelectedItems.Count != 1)
				{
					return;
				}

				// create new item time.
				DateTime time = new ItemTimeEditDlg().ShowDialog((DateTime)TimesLV.SelectedItems[0].Tag);

				// prompt user to edit item time.
				if (time == DateTime.MinValue)
				{
					return;
				}
				
				// update display.
				UpdateListItem(TimesLV.SelectedItems[0], time);
				
				// adjust columns
				AdjustColumns();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Deletes am existing item time.
		/// </summary>
		private void RemoveMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// check for valid selection.
				if (TimesLV.SelectedItems.Count == 0)
				{
					return;
				}
				
				// update display.
				ArrayList items = new ArrayList();

				foreach (ListViewItem listItem in TimesLV.SelectedItems)
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
		/// Imports item times from another item.
		/// </summary>
		private void ImportTimesMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// prompt user to select values from another item.
				TsCHdaItemValueCollection values = new ReadValuesDlg().ShowDialog(m_server, RequestType.ReadRaw, true);

				if (values == null)
				{
					return;
				}

				// get the current selection.
				int index = 0;

				if (TimesLV.SelectedIndices.Count > 0)
				{
					index = TimesLV.SelectedIndices[TimesLV.SelectedIndices.Count-1];
				}

				// add new times to list.
				foreach (TsCHdaItemValue value in values)
				{
					AddListItem(value.Timestamp, index++);
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
		private void TimesLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// set default times.
			AddMI.Enabled         = true;
			CopyMI.Enabled        = false;
			EditMI.Enabled        = false;
			RemoveMI.Enabled      = false;
			ImportTimesMI.Enabled = true;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = TimesLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked item.
			clickedItem.Selected = true;

			if (TimesLV.SelectedItems.Count == 1)
			{			
				CopyMI.Enabled = true;
				EditMI.Enabled = true;
			}

			if (TimesLV.SelectedItems.Count > 0)
			{			
				RemoveMI.Enabled = true;
			}		
		}
	}
}
