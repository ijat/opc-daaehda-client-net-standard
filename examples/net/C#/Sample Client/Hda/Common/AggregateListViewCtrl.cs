//============================================================================
// TITLE: AggregateListViewCtrl.cs
//
// CONTENTS:
// 
// A control used to display a list of server aggregates.
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
	public class AggregateListViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.ListView AggregatesLV;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AggregateListViewCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			AggregatesLV.SmallImageList = Resources.Instance.ImageList;
			
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
			this.AggregatesLV = new System.Windows.Forms.ListView();
			this.CopyMI = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.RemoveMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// AggregatesLV
			// 
			this.AggregatesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AggregatesLV.FullRowSelect = true;
			this.AggregatesLV.Location = new System.Drawing.Point(0, 0);
			this.AggregatesLV.MultiSelect = false;
			this.AggregatesLV.Name = "AggregatesLV";
			this.AggregatesLV.Size = new System.Drawing.Size(432, 272);
			this.AggregatesLV.TabIndex = 0;
			this.AggregatesLV.View = System.Windows.Forms.View.Details;
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
			// AggregateListViewCtrl
			// 
			this.AllowDrop = true;
			this.Controls.Add(this.AggregatesLV);
			this.Name = "AggregateListViewCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ID          = 0;
		private const int NAME        = 1;
		private const int DESCRIPTION = 2;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"ID",
			"Name",
			"Description"
		};
		
		/// <summary>
		/// The server containing the aggregates to be displayed.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Initializes the control with a set of identified results.
		/// </summary>
		public void Initialize(TsCHdaServer server)
		{
			AggregatesLV.Items.Clear();

			// check if there is nothing to do.
			if (server == null) return;

			m_server = server;

			foreach (TsCHdaAggregate aggregate in server.Aggregates)
			{
				AddAggregate(aggregate);
			}
			
			// adjust the list view columns to fit the data.
			AdjustColumns();
		}	

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			AggregatesLV.Clear();

			foreach (string column in columns)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = column;
				AggregatesLV.Columns.Add(header);
			}

			AdjustColumns();
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns()
		{
			// adjust column widths.
			for (int ii = 0; ii < AggregatesLV.Columns.Count; ii++)
			{
				// always show the aggregate id and value column.
				if (ii == ID)
				{
					AggregatesLV.Columns[ii].Width = -2;
					continue;
				}

				// adjust to width of contents if column not empty.
				bool empty = true;

				foreach (ListViewItem current in AggregatesLV.Items)
				{
					if (current.SubItems[ii].Text != "") 
					{ 
						empty = false;
						AggregatesLV.Columns[ii].Width = -2;
						break;
					}
				}

				// set column width to zero if no data it in.
				if (empty) AggregatesLV.Columns[ii].Width = 0;
			}
		}
	
		/// <summary>
		/// Returns the value of the specified field.
		/// </summary>
		private object GetFieldValue(TsCHdaAggregate aggregate, int fieldID)
		{
			switch (fieldID)
			{
				case ID:          { return aggregate.Id; }
				case NAME:        { return aggregate.Name; }
				case DESCRIPTION: { return aggregate.Description; }
			}

			return null;
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddAggregate(TsCHdaAggregate aggregate)
		{
			// create list view item.
			ListViewItem listItem = new ListViewItem("", Resources.IMAGE_EXPLODING_BOX);

			// add empty columns.
			while (listItem.SubItems.Count < ColumnNames.Length) listItem.SubItems.Add("");
			
			// set column values.
			for (int ii = 0; ii < listItem.SubItems.Count; ii++)
			{
				listItem.SubItems[ii].Text = OpcClientSdk.OpcConvert.ToString(GetFieldValue(aggregate, ii));
			}

			// save object as list view item tag.
			listItem.Tag = aggregate;
		
			// add to list view.
			AggregatesLV.Items.Add(listItem);
		}
	}
}
