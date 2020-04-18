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
	public class EventListCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView NotificationsLV;
		private System.Windows.Forms.ContextMenu PopupMenu;
		private System.Windows.Forms.MenuItem ClearAllMI;
		private System.Windows.Forms.MenuItem DeleteMI;
		private System.Windows.Forms.MenuItem AcknowledgeMI;
		private System.Windows.Forms.MenuItem ViewMI;
		private System.Windows.Forms.MenuItem Separator01;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EventListCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			NotificationsLV.SmallImageList = Resources.Instance.ImageList;

			AddHeader(NotificationsLV, "Event Time");
			AddHeader(NotificationsLV, "Severity");
			AddHeader(NotificationsLV, "Source");
			AddHeader(NotificationsLV, "Ack Req");
			AddHeader(NotificationsLV, "Condition");
			AddHeader(NotificationsLV, "Message");

			AdjustColumns(NotificationsLV);
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
			this.NotificationsLV = new System.Windows.Forms.ListView();
			this.PopupMenu = new System.Windows.Forms.ContextMenu();
			this.ViewMI = new System.Windows.Forms.MenuItem();
			this.AcknowledgeMI = new System.Windows.Forms.MenuItem();
			this.DeleteMI = new System.Windows.Forms.MenuItem();
			this.Separator01 = new System.Windows.Forms.MenuItem();
			this.ClearAllMI = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// NotificationsLV
			// 
			this.NotificationsLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NotificationsLV.FullRowSelect = true;
			this.NotificationsLV.Location = new System.Drawing.Point(0, 0);
			this.NotificationsLV.Name = "NotificationsLV";
			this.NotificationsLV.Size = new System.Drawing.Size(376, 200);
			this.NotificationsLV.TabIndex = 16;
			this.NotificationsLV.View = System.Windows.Forms.View.Details;
			this.NotificationsLV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotificationsLV_MouseDown);
			// 
			// PopupMenu
			// 
			this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ViewMI,
																					  this.AcknowledgeMI,
																					  this.DeleteMI,
																					  this.Separator01,
																					  this.ClearAllMI});
			// 
			// ViewMI
			// 
			this.ViewMI.Index = 0;
			this.ViewMI.Text = "View...";
			this.ViewMI.Click += new System.EventHandler(this.ViewMI_Click);
			// 
			// AcknowledgeMI
			// 
			this.AcknowledgeMI.Index = 1;
			this.AcknowledgeMI.Text = "Acknowledge...";
			this.AcknowledgeMI.Click += new System.EventHandler(this.AcknowledgeMI_Click);
			// 
			// DeleteMI
			// 
			this.DeleteMI.Index = 2;
			this.DeleteMI.Text = "Delete";
			this.DeleteMI.Click += new System.EventHandler(this.DeleteMI_Click);
			// 
			// Separator01
			// 
			this.Separator01.Index = 3;
			this.Separator01.Text = "-";
			// 
			// ClearAllMI
			// 
			this.ClearAllMI.Index = 4;
			this.ClearAllMI.Text = "Clear All";
			this.ClearAllMI.Click += new System.EventHandler(this.ClearAllMI_Click);
			// 
			// EventListCtrl
			// 
			this.ContextMenu = this.PopupMenu;
			this.Controls.Add(this.NotificationsLV);
			this.Name = "EventListCtrl";
			this.Size = new System.Drawing.Size(376, 200);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		TsCAeServer m_server = null;
		Hashtable m_subscriptions = new Hashtable();
		#endregion

		private class State
		{
			public Ae.TsCAeSubscription      Subscription;
			public TsCAeDataChangedEventHandler EventHandler;
		}

		#region Public Interface
		/// <summary>
		/// Adds a subscription to the control.
		/// </summary>
		public void AddSubscription(Ae.TsCAeSubscription subscription)
		{
			if (subscription == null) throw new ArgumentNullException();
			if (m_subscriptions.Contains(subscription.ClientHandle)) throw new ArgumentException("Subscription exists");

			// update current server.
			if (m_server != subscription.Server)
			{
				m_server = subscription.Server;
			}

			State state = new State();

			state.Subscription = subscription;
            state.EventHandler = new TsCAeDataChangedEventHandler(Subscription_EventChanged);

            subscription.DataChangedEvent += new TsCAeDataChangedEventHandler(Subscription_EventChanged);

			m_subscriptions.Add(subscription.ClientHandle, state);
		}

		/// <summary>
		/// Removes a subscription from the control.
		/// </summary>
		public void RemoveSubscription(Ae.TsCAeSubscription subscription)
		{
			State state = (State)m_subscriptions[subscription.ClientHandle];

			if (state != null)
			{
				// unregister call backs.
                subscription.DataChangedEvent -= state.EventHandler;

				// remove subscription.
				m_subscriptions.Remove(subscription.ClientHandle);

				// compile list of item to delete.
				ArrayList itemsToDelete = new ArrayList();

				foreach (ListViewItem item in NotificationsLV.Items)
				{
					TsCAeEventNotification notification = (TsCAeEventNotification)item.Tag;

					if (notification.ClientHandle.Equals(subscription.ClientHandle))
					{
						itemsToDelete.Add(item);
					}
				}

				// delete items.
				foreach (ListViewItem item in itemsToDelete)
				{
					item.Remove();
				}
			}
		}

		/// <summary>
		/// Removes all subscriptions from the control.
		/// </summary>
		public void RemoveSubscriptions()
		{
			// close callback connection.
			foreach (State state in m_subscriptions.Values)
			{
                try { state.Subscription.DataChangedEvent -= state.EventHandler; }
				catch {}
			}

			// clear subscriptions.
			m_subscriptions.Clear();

			// clear events.
			 NotificationsLV.Items.Clear();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Adds the area or source to the list.
		/// </summary>
		public void Add(TsCAeEventNotification notification, bool refresh)
		{
			ListViewItem item = new ListViewItem(notification.Time.ToString("HH:mm:ss.fff"));
			
			item.SubItems.Add(notification.Severity.ToString());
			item.SubItems.Add(notification.SourceID);
			item.SubItems.Add((notification.AckRequired)?"Y":"");
			item.SubItems.Add(notification.ConditionName + "." + notification.SubConditionName);
			item.SubItems.Add(notification.Message);

			item.ImageIndex = (notification.EventType != TsCAeEventType.Condition)?Resources.IMAGE_YELLOW_SCROLL:Resources.IMAGE_GREEN_SCROLL;
			item.Tag        = notification;
			item.ForeColor  = (refresh)?Color.IndianRed:Color.Empty;

			NotificationsLV.Items.Insert(0, item);
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
		private void NotificationsLV_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// ignore left button actions.
			if (e.Button != MouseButtons.Right)	return;

			// disable everything.
			ViewMI.Enabled        = false;
			AcknowledgeMI.Enabled = false;
			DeleteMI.Enabled      = false;
			ClearAllMI.Enabled    = true;

			// selects the item that was right clicked on.
			ListViewItem clickedItem = NotificationsLV.GetItemAt(e.X, e.Y);

			// no item clicked on - do nothing.
			if (clickedItem == null) return;

			// force selection to clicked node.
			clickedItem.Selected = true;

			// check for single selection.
			if (NotificationsLV.SelectedItems.Count == 1)
			{
				ViewMI.Enabled = true;
			}

			// check for multiple selection.
			if (NotificationsLV.SelectedItems.Count > 0)
			{
				AcknowledgeMI.Enabled = true;
				DeleteMI.Enabled      = true;

				// make sure all selected events require acknowledgement.
				foreach (ListViewItem item in NotificationsLV.SelectedItems)
				{
					TsCAeEventNotification notification = (TsCAeEventNotification)item.Tag;

					if (!notification.AckRequired)
					{
						AcknowledgeMI.Enabled = false;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Invokes the default action for the current selection.
		/// </summary>
		private void NotificationsLV_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (NotificationsLV.SelectedItems.Count != 1)
				{
					return;
				}

				if (typeof(OpcClientSdk.Ae.TsCAeBrowseElement).IsInstanceOfType(NotificationsLV.SelectedItems[0].Tag))
				{
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void Subscription_EventChanged(TsCAeEventNotification[] notifications, bool refresh, bool lastRefresh)
		{
			// synchronize the HMI thread.
			if (InvokeRequired)
			{
                BeginInvoke(new TsCAeDataChangedEventHandler(Subscription_EventChanged), new object[] { notifications, refresh, lastRefresh });
                return;
			}

			// gray out old entries.
			foreach (ListViewItem item in NotificationsLV.Items)
			{
				item.ForeColor = Color.Gray;
			}

			// add new entries.
			for (int ii = 0; ii < notifications.Length; ii++)
			{
				Add(notifications[ii], refresh);
			}

			AdjustColumns(NotificationsLV);
		}
		#endregion

		/// <summary>
		/// Displays a detailed view of an event notification.
		/// </summary>
		private void ViewMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (NotificationsLV.SelectedItems.Count != 1)
				{
					return;
				}

				TsCAeEventNotification notification = (TsCAeEventNotification)NotificationsLV.SelectedItems[0].Tag;
				State state = (State)m_subscriptions[notification.ClientHandle];

				new NotificationDlg().ShowDialog(state.Subscription, notification);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Sends acknowledgement for an event notification.
		/// </summary>
		private void AcknowledgeMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// get current selection.
				TsCAeEventNotification[] notifications = new TsCAeEventNotification[NotificationsLV.SelectedItems.Count];

				for (int ii = 0; ii < notifications.Length; ii++)
				{
					notifications[ii] = (TsCAeEventNotification)NotificationsLV.SelectedItems[ii].Tag;
				}

				// show dialog.
				bool result = new AcknowledgerEditDlg().ShowDialog(m_server, notifications);

				// delete events if successful.
				if (result)
				{
					DeleteMI_Click(sender, e);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}

		/// <summary>
		/// Deletes the selected events from the list view.
		/// </summary>
		private void DeleteMI_Click(object sender, System.EventArgs e)
		{
			try
			{
				// build list if items to remove.
				ArrayList items = new ArrayList();

				foreach (ListViewItem item in NotificationsLV.SelectedItems)
				{
					items.Add(item);
				}

				// actually remove items from list.
				foreach (ListViewItem item in items)
				{
					item.Remove();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}		
		}

		/// <summary>
		/// Deletes all events from the list view.
		/// </summary>
		private void ClearAllMI_Click(object sender, System.EventArgs e)
		{	
			try
			{
				NotificationsLV.Items.Clear();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}	
		}
	}
}
