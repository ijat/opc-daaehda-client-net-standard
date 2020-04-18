//============================================================================
// TITLE: EditArrayDlg.cs
//
// CONTENTS:
// 
// A dialog used to display and edit the contents of an array.
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpcClientSdk.Controls
{
	/// <summary>
	/// A dialog used to display and edit the contents of an array.
	/// </summary>
	public class EditArrayDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private OpcClientSdk.Controls.ValueCtrl ValueCTRL;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.ListView ArrayLV;
		private System.Windows.Forms.ColumnHeader IndexCH;
		private System.Windows.Forms.ColumnHeader ValueCH;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem ViewMI;
		private System.Windows.Forms.MenuItem DeleteMI;
		private System.Windows.Forms.MenuItem InsertMI;
		private System.Windows.Forms.MenuItem Separator01;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditArrayDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			ValueCTRL.ValueChanged += new ValueChangedCallback(OnValueChanged);
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
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.OkBTN = new System.Windows.Forms.Button();
            this.ValueCTRL = new ValueCtrl();
			this.MainPN = new System.Windows.Forms.Panel();
			this.ArrayLV = new System.Windows.Forms.ListView();
            this.IndexCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.ViewMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.InsertMI = new System.Windows.Forms.MenuItem();
			this.DeleteMI = new System.Windows.Forms.MenuItem();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 146);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(296, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(216, 8);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBTN.Location = new System.Drawing.Point(135, 6);
			this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
			// 
			// ValueCTRL
			// 
			this.ValueCTRL.Dock = System.Windows.Forms.DockStyle.Top;
			this.ValueCTRL.ItemID = null;
			this.ValueCTRL.Location = new System.Drawing.Point(0, 0);
			this.ValueCTRL.Name = "ValueCTRL";
            this.ValueCTRL.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.ValueCTRL.Size = new System.Drawing.Size(296, 28);
			this.ValueCTRL.TabIndex = 1;
            this.ValueCTRL.Value = null;
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.ArrayLV);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.Location = new System.Drawing.Point(0, 28);
			this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.MainPN.Size = new System.Drawing.Size(296, 118);
			this.MainPN.TabIndex = 2;
			// 
			// ArrayLV
			// 
			this.ArrayLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.IndexCH,
																					  this.ValueCH});
			this.ArrayLV.ContextMenu = this.PopupMenu;
			this.ArrayLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ArrayLV.FullRowSelect = true;
			this.ArrayLV.GridLines = true;
			this.ArrayLV.Location = new System.Drawing.Point(4, 4);
			this.ArrayLV.Name = "ArrayLV";
			this.ArrayLV.Size = new System.Drawing.Size(288, 114);
			this.ArrayLV.TabIndex = 0;
            this.ArrayLV.UseCompatibleStateImageBehavior = false;
			this.ArrayLV.View = System.Windows.Forms.View.Details;
            this.ArrayLV.SelectedIndexChanged += new System.EventHandler(this.ArrayLV_SelectedIndexChanged);
            this.ArrayLV.DoubleClick += new System.EventHandler(this.ViewMI_Click);
			this.ArrayLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrayLV_MouseDown);
			// 
			// IndexCH
			// 
			this.IndexCH.Text = "Index";
			this.IndexCH.Width = 38;
			// 
			// ValueCH
			// 
			this.ValueCH.Text = "Value";
			this.ValueCH.Width = 246;
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewMI,
																					  this.Separator01,
																					  this.InsertMI,
																					  this.DeleteMI});
			// 
			// ViewMI
			// 
			this.ViewMI.Index = 0;
			this.ViewMI.Text = "&View...";
			this.ViewMI.Click += new System.EventHandler(this.ViewMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 1;
			this.Separator01.Text = "-";
			// 
			// InsertMI
			// 
			this.InsertMI.Index = 2;
			this.InsertMI.Text = "&Insert";
			this.InsertMI.Click += new System.EventHandler(this.InsertMI_Click);
			// 
			// DeleteMI
			// 
			this.DeleteMI.Index = 3;
			this.DeleteMI.Text = "&Delete";
			this.DeleteMI.Click += new System.EventHandler(this.DeleteMI_Click);
			// 
			// EditArrayDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 182);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ValueCTRL);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "EditArrayDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Array";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The current array object.
		/// </summary>
		private object m_value = null;

		/// <summary>
		/// The data type of the elements of the current array object.
		/// </summary>
		private System.Type m_type = null;

		/// <summary>
		/// Whether the value may be modified.
		/// </summary>
		private bool m_readOnly = false;

		/// <summary>
		/// The index of the item shown in the value control.
		/// </summary>
		private int m_index = -1;


        /// <summary>
        /// Performs a deep copy of an object if possible.
        /// </summary>
        public object Clone(object source)
        {
            if (source == null) return null;
            if (source.GetType().IsValueType) return source;

            if (source.GetType().IsArray || source.GetType() == typeof(Array))
            {
                Array array = (Array)((Array)source).Clone();

                for (int ii = 0; ii < array.Length; ii++)
                {
                    array.SetValue(Clone(array.GetValue(ii)), ii);
                }

                return array;
            }

            try { return ((ICloneable)source).Clone(); }
            catch { throw new NotSupportedException("Object cannot be cloned."); }
        }


		/// <summary>
		/// Displays the dialog with the specified array.
		/// </summary>
		public object ShowDialog(object value, bool readOnly)
		{
			if (value == null) throw new ArgumentNullException("value");
			if (!value.GetType().IsArray) throw new ArgumentException("Not an array", "value");

			m_value    = OpcClientSdk.OpcConvert.Clone(value);
			m_type     = m_value.GetType().GetElementType();
			m_readOnly = readOnly;

			ValueCTRL.AllowChangeType = (m_type == typeof(object));

			Update();

			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			return m_value;
		}

		/// <summary>
		/// Updates the array list view with the current array elements.
		/// </summary>
		private new void Update()
		{
			m_index = -1;
			ValueCTRL.Set(null, m_readOnly);
			ArrayLV.Items.Clear();

			int index = 0;

			foreach (object element in (Array)m_value)
			{
				string[] columns = new string[] 
				{ 
					String.Format("[{0}]", index++), 
					OpcClientSdk.OpcConvert.ToString(element)
				};

				ListViewItem item = new ListViewItem(columns, Resources.IMAGE_YELLOW_SCROLL);
				item.Tag = element;

				ArrayLV.Items.Add(item);
			}

			// select the first item.
			if (ArrayLV.Items.Count > 0) ArrayLV.Items[0].Selected = true;
		}

		/// <summary>
		/// Saves the value currentlt being edited.
		/// </summary>
		private bool Save()
		{
			if (m_readOnly || m_index == -1) return true;

			try
			{
				// get and convert the new value.
				object value = OpcClientSdk.OpcConvert.ChangeType(ValueCTRL.Get(), m_type);

				// update the array.
				((Array)m_value).SetValue(value, m_index);

				// update the list view.
				ArrayLV.Items[m_index].Tag = value;
				ArrayLV.Items[m_index].SubItems[1].Text = OpcClientSdk.OpcConvert.ToString(value);

				// clear index.
				m_index = -1;
				return true;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				return false;
			}
		}

		/// <summary>
		/// Called when the value is changed.
		/// </summary>
		public void OnValueChanged(Control control, object value)
		{
			Save();
		}

		/// <summary>
		/// Displays the first selected value in the value control.
		/// </summary>
		private void ArrayLV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!m_readOnly && m_index != -1)
			{
				Save();
			}

			if (ArrayLV.SelectedIndices.Count > 0)
			{
				m_index = ArrayLV.SelectedIndices[0];
				ValueCTRL.Set(ArrayLV.Items[m_index].Tag, m_readOnly);
				return;
			}

			m_index = -1;
			ValueCTRL.Set(null, m_readOnly);
		}

		/// <summary>
		/// Enables items in popup menu based on current selection.
		/// </summary>
		private void ArrayLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			ViewMI.Enabled   = false;
			InsertMI.Enabled = false;
			DeleteMI.Enabled = false;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = ArrayLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			// check for single selection on an array element.
			if (ArrayLV.SelectedItems.Count == 1)
			{
				if (clickedItem.Tag != null && clickedItem.Tag.GetType().IsArray)
				{
					ViewMI.Enabled = true;
				}
			}

			// check for any selection.
			if (ArrayLV.SelectedItems.Count > 0)
			{
				InsertMI.Enabled = !m_readOnly;
				DeleteMI.Enabled = !m_readOnly;
			}
		}

		/// <summary>
		/// Shows the edit array dialog for an element.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			if (ArrayLV.SelectedItems.Count == 1)
			{
				ListViewItem item = ArrayLV.SelectedItems[0];

				if (item.Tag == null || !item.Tag.GetType().IsArray)
				{
					return;
				}

				try
				{
					int index = ArrayLV.SelectedIndices[0];

					// get and convert the new value.
					object value = new EditArrayDlg().ShowDialog(item.Tag, m_readOnly);

					if (m_readOnly || value == null)
					{
						return;
					}

					// update the array.
					((Array)m_value).SetValue(value, index);

					// update the list view.
					ArrayLV.Items[index].Tag = value;
					ArrayLV.Items[index].SubItems[1].Text = OpcClientSdk.OpcConvert.ToString(value);

					// clear index.
					m_index = -1;
					ArrayLV.SelectedItems.Clear();
					item.Selected = true;
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		/// <summary>
		/// Inserts new elements into the array.
		/// </summary>
		private void InsertMI_Click(object sender, System.EventArgs e)
		{
			if (!m_readOnly && ArrayLV.SelectedIndices.Count > 0)
			{
				int count = ArrayLV.SelectedIndices.Count;
				int index = ArrayLV.SelectedIndices[count-1];
				
				// build the expanded array.
				ArrayList array = new ArrayList(ArrayLV.Items.Count+count);

				// add preceding elements.
				for (int ii = 0; ii < index+1; ii++)
				{
					array.Add(ArrayLV.Items[ii].Tag);
				}

				// add new elements by copying the last selected element.
				object template = ArrayLV.Items[index].Tag;

				for (int ii = 0; ii < count; ii++)
				{
					array.Add(OpcClientSdk.OpcConvert.Clone(template));
				}

				// add trailing elements.
				for (int ii = index+1; ii < ArrayLV.Items.Count; ii++)
				{
					array.Add(ArrayLV.Items[ii].Tag);
				}

				// convert to array with correct element type.
				m_value = array.ToArray(m_type);

				// update view.
				Update();
			}	
		}

		/// <summary>
		/// Removes elements from the array.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{
			if (!m_readOnly && ArrayLV.SelectedItems.Count > 0)
			{
				// build list of items to delete.
				ArrayList items = new ArrayList(ArrayLV.SelectedItems.Count);
				foreach (ListViewItem item in ArrayLV.SelectedItems) items.Add(item);

				// remove items.
				foreach (ListViewItem item in items) item.Remove();

				// build the contracted array.
				ArrayList array = new ArrayList(ArrayLV.Items.Count);
				foreach (ListViewItem item in ArrayLV.Items) array.Add(item.Tag);

				// convert to array with correct element type.
				m_value = array.ToArray(m_type);

				// update view.
				Update();
			}	
		}

		/// <summary>
		/// Called when the OK button is clicked.
		/// </summary>
		private void OkBTN_Click(object sender, System.EventArgs e)
		{
			if (Save())
			{
				DialogResult = DialogResult.OK;
			}
		}

		/// <summary>
		/// Called when the Cancel button is clicked.
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
