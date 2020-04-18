//============================================================================
// TITLE: UpdatesListViewCtrl.cs
//
// CONTENTS:
// 
// A control used to display a set of data updates from a server.
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
	/// Used to receive trace/debug output during data update processing.
	/// </summary>
	public delegate void UpdateEvent_EventHandler(object subscriptionHandle, object args);

	/// <summary>
	/// A control used to display a set of data updates from a server.
	/// </summary>
	public class UpdatesListViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView ItemListLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem RemoveMI;
		private System.Windows.Forms.MenuItem EditMI;
		private System.Windows.Forms.MenuItem CopyMI;
		private System.Windows.Forms.MenuItem ShowErrorTextMI;
		private System.Windows.Forms.MenuItem ViewMI;
		private System.Windows.Forms.MenuItem KeepValuesMI;
		private System.Windows.Forms.MenuItem ClearMI;
		private System.Windows.Forms.MenuItem Separator01;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constants used to identify the list view columns.
		/// </summary>
		private const int ITEMID    = 0;
		private const int ITEM_PATH = 1;
		private const int VALUE     = 2;
		private const int DATATYPE  = 3;
		private const int QUALITY   = 4;
		private const int TIMESTAMP = 5;
		private const int ERROR     = 6;

		/// <summary>
		/// The list view column names.
		/// </summary>
		private readonly string[] ColumnNames = new string[]
		{
			"Item ID",
			"Item Path",
			"Value",
			"Data Type",
			"Quality",
			"Timestamp",
			"Result"
		};

		public UpdatesListViewCtrl()
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
			this.KeepValuesMI = new System.Windows.Forms.MenuItem();
			this.ClearMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// ItemListLV
			// 
			this.ItemListLV.ContextMenu = this.PopupMenu;
			this.ItemListLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemListLV.FullRowSelect = true;
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
																					  this.ShowErrorTextMI,
																					  this.Separator01,
																					  this.KeepValuesMI,
																					  this.ClearMI});
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
			// KeepValuesMI
			// 
			this.KeepValuesMI.Index = 3;
			this.KeepValuesMI.Text = "&Keep Old Values";
			this.KeepValuesMI.Click += new System.EventHandler(this.KeepValuesMI_Click);
			// 
			// ClearMI
			// 
			this.ClearMI.Index = 4;
			this.ClearMI.Text = "&Clear";
			this.ClearMI.Click += new System.EventHandler(this.ClearMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 2;
			this.Separator01.Text = "-";
			// 
			// UpdatesListViewCtrl
			// 
			this.AllowDrop = true;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ItemListLV});
			this.Name = "UpdatesListViewCtrl";
			this.Size = new System.Drawing.Size(432, 272);
			this.ResumeLayout(false);

		}
		#endregion
	
		/// <summary>
		/// Used to receive trace/debug events generated by the control.
		/// </summary>
		public event UpdateEvent_EventHandler UpdateEvent = null;

		/// <summary>
		/// The currently active server object
		/// </summary>
		private TsCDaServer m_server = null;

		/// <summary>
		/// A table subscriptions indexed by handle.
		/// </summary>
		private Hashtable m_subscriptions = new Hashtable();

		/// <summary>
		/// A table of list items indexed by subscription.
		/// </summary>
		private Hashtable m_items = new Hashtable();

		/// <summary>
		/// A table of dialog displaying detailed views of an item.
		/// </summary>
		private Hashtable m_viewers = new Hashtable();

		/// <summary>
		/// Sets/clears the currently active server. 
		/// </summary>
		public void Initialize(TsCDaServer server)
		{
			m_server = server;
			m_items.Clear();
			m_subscriptions.Clear();

			ItemListLV.Items.Clear();
		}
 
		/// <summary>
		/// Called when a subscription is added or removed from the control.
		/// </summary>
		public void OnSubscriptionModified(TsCDaSubscription subscription, bool deleted)
		{
			if (subscription == null) return;

			if (!deleted)
			{
				// check if the subscription is already added to the control.
				if (m_items.Contains(subscription.ClientHandle)) return;

				// register for data updates.
				subscription.DataChangedEvent += new TsCDaDataChangedEventHandler(OnDataChangeEvent);

				// add to subscription list.
				m_subscriptions.Add(subscription.ClientHandle, subscription);
				m_items.Add(subscription.ClientHandle, new ArrayList());
			}
			else
			{
				// check if the subscription is already removed from the control.
				if (!m_items.Contains(subscription.ClientHandle)) return;
				
				// unregister for data updates.
				subscription.DataChangedEvent -= new TsCDaDataChangedEventHandler(OnDataChangeEvent);
				
				// remove all items for the subscription.
				ArrayList existingItemList = (ArrayList)m_items[subscription.ClientHandle];

				foreach (ListViewItem listItem in existingItemList)
				{
					EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[listItem];

					if (dialog != null)
					{
						dialog.Close();
						m_viewers.Remove(listItem);
					}

					listItem.Remove();
				}

				// remove from subscription list.
				m_subscriptions.Remove(subscription.ClientHandle);
				m_items.Remove(subscription.ClientHandle);
			}
		}

		/// <summary>
		/// Called when a data update event is raised by a subscription.
		/// </summary>
		private void OnDataChangeEvent(object subscriptionHandle, object requestHandle, TsCDaItemValueResult[] values)
		{
			// ensure processing is done on the control's main thread.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCDaDataChangedEventHandler(OnDataChangeEvent), new object[] { subscriptionHandle, requestHandle, values });
				return;
			}

			try
			{
				// find subscription.
				ArrayList existingItemList = (ArrayList)m_items[subscriptionHandle];

				// check if subscription is still valid.
				if (existingItemList == null) return;

				// change all existing item values for the subscription to 'grey'.
				// this indicates an update arrived but the value did not change.
				foreach (ListViewItem listItem in existingItemList)
				{
					if (listItem.ForeColor != Color.Gray) {	listItem.ForeColor = Color.Gray; }
				}

				// do nothing more if only a keep alive callback.
				if (values == null || values.Length == 0) 
				{
					OnKeepAlive(subscriptionHandle);
					return;
				}
				else
				{
					if (UpdateEvent != null)
					{
						UpdateEvent(subscriptionHandle, values);
					}
				}

				// update list view.
				ArrayList newListItems = new ArrayList();

				foreach (TsCDaItemValueResult value in values)
				{
					// item value should never have a null client handle.
					if (value.ClientHandle == null)
					{
						continue;
					}

					// this item can be updated with new values instead of inserting/removing items.
					ListViewItem replacableItem = null;

					// remove existing items.
					if (!KeepValuesMI.Checked)
					{
						// search list of existing items for previous values for this item.
						ArrayList updatedItemList = new ArrayList(existingItemList.Count);

						foreach (ListViewItem listItem in existingItemList)
						{
							TsCDaItemValueResult previous = (TsCDaItemValueResult)listItem.Tag;

							if (!value.ClientHandle.Equals(previous.ClientHandle))
							{
								updatedItemList.Add(listItem);
								continue;
							}

							if (replacableItem != null) 
							{
								EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[replacableItem];

								if (dialog != null)
								{
									dialog.Close();
									m_viewers.Remove(replacableItem);
								}

								replacableItem.Remove();
							}

							replacableItem = listItem;				
						}

						// the updated list has all values for the current item removed.
						existingItemList = updatedItemList;
					}

					// add value to list.
					AddValue(subscriptionHandle, value, ref replacableItem);

					// save new list item.
					if (replacableItem != null)	{ newListItems.Add(replacableItem); }
				}

				// add new items to existing item list.
				existingItemList.AddRange(newListItems);
				m_items[subscriptionHandle] = existingItemList;

				// adjust column widths.
				for (int ii = 0; ii < ItemListLV.Columns.Count; ii++)
				{
					if (ii != VALUE && ii != QUALITY) ItemListLV.Columns[ii].Width = -2;
				}
			}
			catch (Exception e)
			{
				OnException(subscriptionHandle, e);
			}
		}	

		/// <summary>
		/// Posts a message when an exception occurs.
		/// </summary>
		private void OnException(object subscription, Exception e)
		{
			if (UpdateEvent != null)
			{
				UpdateEvent(subscription, e.Message);
			}
		}

		/// <summary>
		/// Posts a message when a keep alive callback arrives.
		/// </summary>
		private void OnKeepAlive(object subscription)
		{
			if (UpdateEvent != null)
			{
				string message = "";
				
				message += OpcClientSdk.OpcConvert.ToString(DateTime.Now);
				message += "\t";
				message += "Keep alive callback received.";

				UpdateEvent(subscription, message);
			}
		}

		/// <summary>
		/// Sets the columns shown in the list view.
		/// </summary>
		private void SetColumns(string[] columns)
		{		
			ItemListLV.Clear();

			for (int ii = 0; ii < columns.Length; ii++)
			{
				ColumnHeader header = new ColumnHeader();
				header.Text  = columns[ii];
				header.Width = (ii != VALUE && ii != QUALITY)?-2:120;
				ItemListLV.Columns.Add(header);
			}
		}

		/// <summary>
		/// Adds an item to the list view.
		/// </summary>
		private void AddValue(object subscriptionHandle, TsCDaItemValueResult item, ref ListViewItem replaceableItem)
		{
			string quality = "";

			// format quality.
			if (item.QualitySpecified)
			{
				quality += item.Quality.QualityBits.ToString();

				if (item.Quality.LimitBits != TsDaLimitBits.None)
				{
					quality += ", ";
					quality += item.Quality.LimitBits.ToString();
				}

				if (item.Quality.VendorBits != 0)
				{
					quality += String.Format(", {0:X}", item.Quality.VendorBits);
				}
			}

			// format columns.
			string[] columns = new string[]
			{
				item.ItemName,
				item.ItemPath,
				OpcClientSdk.OpcConvert.ToString(item.Value),
				(item.Value != null)?OpcClientSdk.OpcConvert.ToString(item.Value.GetType()):"",
				quality,
				(item.TimestampSpecified)?OpcClientSdk.OpcConvert.ToString(item.Timestamp):"",
				GetErrorText(subscriptionHandle, item.Result)
			};

			// update an existing item.
			if (replaceableItem != null)
			{
				for (int ii = 0; ii < replaceableItem.SubItems.Count; ii++)
				{
					replaceableItem.SubItems[ii].Text = columns[ii];
				}

				replaceableItem.Tag = item;
				replaceableItem.ForeColor = Color.Empty;

				// update detail view dialog.
				EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[replaceableItem];

				if (dialog != null)
				{					
					dialog.UpdateValue(item.Value);
				}

				return;
			}

			// create a new list view item.
			replaceableItem = new ListViewItem(columns, Resources.IMAGE_YELLOW_SCROLL);
			replaceableItem.Tag = item;

			// insert after any existing item value with the same client handle.
			for (int ii = ItemListLV.Items.Count-1; ii >= 0; ii--)
			{
				TsCDaItemValueResult previous = (TsCDaItemValueResult)ItemListLV.Items[ii].Tag;

				if (previous.ClientHandle != null && previous.ClientHandle.Equals(item.ClientHandle))
				{
					ItemListLV.Items.Insert(ii+1, replaceableItem);
					return;
				}
			}

			ItemListLV.Items.Add(replaceableItem);
		}

		/// <summary>
		/// Lookups the error text for the specified error id.
		/// </summary>
		private string GetErrorText(object subscriptionHandle, OpcResult resultID)
		{
			if (ShowErrorTextMI.Checked)
			{
				// display nothing for ok results.
				if (resultID == OpcResult.S_OK) return "";
	
				// fetch the error text from the server.	
				string errorText = null;

				try 
				{
					TsCDaSubscription subscription = (TsCDaSubscription)m_subscriptions[subscriptionHandle];
					string locale = (subscription != null)?subscription.Locale:CultureInfo.CurrentCulture.Name;
					errorText = m_server.GetErrorText(locale, resultID);
				}
				catch
				{
					errorText = null;
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
				ListViewItem listItem = ItemListLV.SelectedItems[0];

				object tag = listItem.Tag;

				if (tag != null && tag.GetType() == typeof(TsCDaItemValueResult))
				{
					TsCDaItemValueResult item = (TsCDaItemValueResult)tag;

					if (item.Value != null)
					{
						TsCCpxComplexItem complexItem = TsCCpxComplexTypeCache.GetComplexItem(item);

						if (complexItem != null)
						{
							EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[listItem];

							if (dialog == null)
							{
								m_viewers[listItem] = dialog = new EditComplexValueDlg();
								dialog.Disposed += new EventHandler(OnViewerClosed);
							}

							dialog.ShowDialog(complexItem, item.Value, true, false);
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
		/// Removes a reference to the detail viewer dialog when it is closed.
		/// </summary>
		private void OnViewerClosed(object sender, System.EventArgs e)
		{
			IDictionaryEnumerator enumerator = m_viewers.GetEnumerator();

			while (enumerator.MoveNext())
			{
				if (enumerator.Value == sender)
				{
					m_viewers.Remove(enumerator.Key);
					break;
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
				if (clickedItem.Tag != null && clickedItem.Tag.GetType() == typeof(TsCDaItemValueResult))
				{
					TsCDaItemValueResult item = (TsCDaItemValueResult)clickedItem.Tag;

					if (item.Value != null)
					{
						ViewMI.Enabled = ((TsCCpxComplexTypeCache.GetComplexItem(item) != null) || (item.Value.GetType().IsArray));
					}
				}
			}
		}

		/// <summary>
		/// Toggles the state of the show error text flag.
		/// </summary>
		private void ShowErrorTextMI_Click(object sender, System.EventArgs e)
		{
			ShowErrorTextMI.Checked = !ShowErrorTextMI.Checked;
		}

		/// <summary>
		/// Indicates that old values should not be remove when new values are added.
		/// </summary>
		private void KeepValuesMI_Click(object sender, System.EventArgs e)
		{
			KeepValuesMI.Checked = !KeepValuesMI.Checked;
		}

		/// <summary>
		/// Clears the contents of the view.
		/// </summary>
		private void ClearMI_Click(object sender, System.EventArgs e)
		{
			// clear items.
			ItemListLV.Items.Clear();

			// clear subscription item list.
			foreach (ArrayList items in m_items.Values)
			{
				items.Clear();
			}
		}	
	}
}
