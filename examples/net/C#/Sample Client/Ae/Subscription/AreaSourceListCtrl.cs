#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using System;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Ae.SampleClient
{
	/// <summary>
	/// A control used to edit the state of a subscription.
	/// </summary>
	public class AreaSourceListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView AreaSourceLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem AddAreaMI;
		private System.Windows.Forms.MenuItem AddSourceMI;
		private System.Windows.Forms.MenuItem DeleteMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem Separator01;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AreaSourceListCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			AreaSourceLV.SmallImageList = Resources.Instance.ImageList;

			AddHeader(AreaSourceLV, "Qualified Name");
			AddHeader(AreaSourceLV, "Node Type");

			AdjustColumns(AreaSourceLV);
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
			this.AreaSourceLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.AddAreaMI = new System.Windows.Forms.MenuItem();
			this.AddSourceMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.EditMI = new System.Windows.Forms.MenuItem();
			this.DeleteMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// AreaSourceLV
			// 
			this.AreaSourceLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AreaSourceLV.FullRowSelect = true;
			this.AreaSourceLV.Location = new System.Drawing.Point(0, 0);
			this.AreaSourceLV.MultiSelect = false;
			this.AreaSourceLV.Name = "AreaSourceLV";
			this.AreaSourceLV.Size = new System.Drawing.Size(376, 200);
			this.AreaSourceLV.TabIndex = 16;
			this.AreaSourceLV.View = System.Windows.Forms.View.Details;
			this.AreaSourceLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AreaSourceLV_MouseDown);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AddAreaMI,
																					  this.AddSourceMI,
																					  this.Separator01,
																					  this.EditMI,
																					  this.DeleteMI});
			// 
			// AddAreaMI
			// 
			this.AddAreaMI.Index = 0;
			this.AddAreaMI.Text = "Add Area,,,";
			this.AddAreaMI.Click += new System.EventHandler(this.AddAreaMI_Click);
			// 
			// AddSourceMI
			// 
			this.AddSourceMI.Index = 1;
			this.AddSourceMI.Text = "Add Source...";
			this.AddSourceMI.Click += new System.EventHandler(this.AddSourceMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 2;
			this.Separator01.Text = "-";
			// 
			// EditMI
			// 
			this.EditMI.Index = 3;
			this.EditMI.Text = "Edit..";
			this.EditMI.Click += new System.EventHandler(this.EditMI_Click);
			// 
			// DeleteMI
			// 
			this.DeleteMI.Index = 4;
			this.DeleteMI.Text = "Delete";
			this.DeleteMI.Click += new System.EventHandler(this.DeleteMI_Click);
			// 
			// AreaSourceListCtrl
			// 
			this.ContextMenu = this.PopupMenu;
			this.Controls.Add(this.AreaSourceLV);
			this.Name = "AreaSourceListCtrl";
			this.Size = new System.Drawing.Size(376, 200);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Returns the qualified names for the areas in the control.
		/// </summary>
		public string[] GetAreas()
		{
			ArrayList areas = new ArrayList();

			foreach (ListViewItem item in AreaSourceLV.Items)
			{
				OpcClientSdk.Ae.TsCAeBrowseElement element = (OpcClientSdk.Ae.TsCAeBrowseElement)item.Tag;

				if (element.NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)
				{
					areas.Add(element.QualifiedName);
				}
			}

			return (string[])areas.ToArray(typeof(string));
		}

		/// <summary>
		/// Returns the qualified names for the sources in the control.
		/// </summary>
		public string[] GetSources()
		{
			ArrayList sources = new ArrayList();

			foreach (ListViewItem item in AreaSourceLV.Items)
			{
				OpcClientSdk.Ae.TsCAeBrowseElement element = (OpcClientSdk.Ae.TsCAeBrowseElement)item.Tag;

				if (element.NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Source)
				{
					sources.Add(element.QualifiedName);
				}
			}

			return (string[])sources.ToArray(typeof(string));
		}
		
		/// <summary>
		/// Adds multiple areas to the list.
		/// </summary>
		public void AddAreas(string[] areas)
		{
			if (areas != null)
			{
				for (int ii = 0; ii < areas.Length; ii++)
				{
					OpcClientSdk.Ae.TsCAeBrowseElement element = new OpcClientSdk.Ae.TsCAeBrowseElement();

					element.QualifiedName = areas[ii];
					element.NodeType      = OpcClientSdk.Ae.TsCAeBrowseType.Area;

					Add(element);
				}
				
				AdjustColumns(AreaSourceLV);
			}
		}		

		/// <summary>
		/// Adds multiple sources to the list.
		/// </summary>
		public void AddSources(string[] sources)
		{
			if (sources != null)
			{
				for (int ii = 0; ii < sources.Length; ii++)
				{
					OpcClientSdk.Ae.TsCAeBrowseElement element = new OpcClientSdk.Ae.TsCAeBrowseElement();

					element.QualifiedName = sources[ii];
					element.NodeType      = OpcClientSdk.Ae.TsCAeBrowseType.Source;

					Add(element);
				}

				AdjustColumns(AreaSourceLV);
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Adds the area or source to the list.
		/// </summary>
		public void Add(OpcClientSdk.Ae.TsCAeBrowseElement element)
		{
			ListViewItem item = new ListViewItem(element.QualifiedName);
			
			item.SubItems.Add(element.NodeType.ToString());

			item.ImageIndex = (element.NodeType == OpcClientSdk.Ae.TsCAeBrowseType.Area)?Resources.IMAGE_CLOSED_BLUE_FOLDER:Resources.IMAGE_GREEN_SCROLL;
			item.Tag        = element;

			AreaSourceLV.Items.Add(item);
		}

		/// <summary>
		/// Populates the list box with the categories.
		/// </summary>
		private void AddHeader(ListView listview, string name)
		{
			ColumnHeader header = new ColumnHeader();
			header.Text = name;
			listview.Columns.Add(header);
		}

		/// <summary>
		/// Adjusts the columns shown in the list view.
		/// </summary>
		private void AdjustColumns(ListView listview)
		{
			// adjust column widths.
			for (int ii = 0; ii < listview.Columns.Count; ii++)
			{
				listview.Columns[ii].Width = -2;
			}
		}
		#endregion
		
		#region Event Handlers
		/// <summary>
		/// Enables items in popup menu based on current selection.
		/// </summary>
		private void AreaSourceLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			AddSourceMI.Enabled = false;
			AddAreaMI.Enabled   = false;
			EditMI.Enabled      = false;
			DeleteMI.Enabled    = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = AreaSourceLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			// enable everything.
			AddSourceMI.Enabled = true;
			AddAreaMI.Enabled   = true;

			if (AreaSourceLV.SelectedItems.Count == 1)
			{
				EditMI.Enabled = true;
			}

			if (AreaSourceLV.SelectedItems.Count > 0)
			{
				DeleteMI.Enabled = true;
			}
		}

		/// <summary>
		/// Invokes the default action for the current selection.
		/// </summary>
		private void AreaSourceLV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (AreaSourceLV.SelectedItems.Count != 1)
				{
					return;
				}

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(AreaSourceLV.SelectedItems[0].Tag))
				{
					EditMI_Click(sender, e);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Prompts the user to enter the qualified name for an area.
		/// </summary>
		private void AddAreaMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				string qualifiedName = new QualifiedNameEditDlg().ShowDialog(null);

				if (qualifiedName == null)
				{
					return;
				}

				OpcClientSdk.Ae.TsCAeBrowseElement element = new OpcClientSdk.Ae.TsCAeBrowseElement();

				element.QualifiedName = qualifiedName;
				element.NodeType      = OpcClientSdk.Ae.TsCAeBrowseType.Area;
			
				Add(element);
				AdjustColumns(AreaSourceLV);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Prompts the user to enter the qualified name for a source.
		/// </summary>
		private void AddSourceMI_Click(object sender, System.EventArgs e)
		{	
			try
			{
				string qualifiedName = new QualifiedNameEditDlg().ShowDialog(null);

				if (qualifiedName == null)
				{
					return;
				}

				OpcClientSdk.Ae.TsCAeBrowseElement element = new OpcClientSdk.Ae.TsCAeBrowseElement();

				element.QualifiedName = qualifiedName;
				element.NodeType      = OpcClientSdk.Ae.TsCAeBrowseType.Source;
			
				Add(element);
				AdjustColumns(AreaSourceLV);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Edits the currently selected element in the list.
		/// </summary>
		private void EditMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (AreaSourceLV.SelectedItems.Count != 1)
				{
					return;
				}

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(AreaSourceLV.SelectedItems[0].Tag))
				{
					OpcClientSdk.Ae.TsCAeBrowseElement element = (OpcClientSdk.Ae.TsCAeBrowseElement)AreaSourceLV.SelectedItems[0].Tag;

					string qualifiedName = new QualifiedNameEditDlg().ShowDialog(element.QualifiedName);

					if (qualifiedName == null)
					{
						return;
					}

					element.QualifiedName = qualifiedName;
					AdjustColumns(AreaSourceLV);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}

		/// <summary>
		/// Deletes the currently selected items from the list.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{		
			try
			{
				if (AreaSourceLV.SelectedItems.Count == 0)
				{
					return;
				}
				
				// collect the items.
				ListViewItem[] items = new ListViewItem[AreaSourceLV.SelectedItems.Count];

				for (int ii = 0; ii < AreaSourceLV.SelectedItems.Count; ii++)
				{
					items[ii] = AreaSourceLV.SelectedItems[ii];
				}

				// remove the items.
				for (int ii = 0; ii < items.Length; ii++)
				{
					items[ii].Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		#endregion
	}
}
