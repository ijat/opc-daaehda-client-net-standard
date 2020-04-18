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
using OpcClientSdk.SampleClient;

namespace OpcClientSdk.Ae.SampleClient
{
	/// <summary>
	/// A control used to edit the state of a subscription.
	/// </summary>
	public class NotificationCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView AttributesLV;
		private System.Windows.Forms.GroupBox AttributesGB;
		private System.Windows.Forms.Panel GeneralGB;
		private System.Windows.Forms.TextBox NewStateTB;
		private System.Windows.Forms.Label NewStateLB;
		private System.Windows.Forms.Label SubConditionNameLB;
		private System.Windows.Forms.TextBox SubConditionNameTB;
		private System.Windows.Forms.Label ConditionNameLB;
		private System.Windows.Forms.TextBox ConditionNameTB;
		private System.Windows.Forms.Label EventCategoryLB;
		private System.Windows.Forms.TextBox EventCategoryTB;
		private System.Windows.Forms.Label EventTypeLB;
		private System.Windows.Forms.TextBox EventTypeTB;
		private System.Windows.Forms.TextBox TimeTB;
		private System.Windows.Forms.Label TimeLB;
		private System.Windows.Forms.TextBox ActorTB;
		private System.Windows.Forms.TextBox MessageTB;
		private System.Windows.Forms.TextBox AckRequiredTB;
		private System.Windows.Forms.Label ActorLB;
		private System.Windows.Forms.Label SourceLB;
		private System.Windows.Forms.Label AckRequiredLB;
		private System.Windows.Forms.Label MessageLB;
		private System.Windows.Forms.TextBox SourceTB;
		private System.Windows.Forms.TextBox ActiveTimeTB;
		private System.Windows.Forms.Label ActiveTimeLB;
		private System.Windows.Forms.TextBox QualityTB;
		private System.Windows.Forms.Label QualityLB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NotificationCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			AddHeader(AttributesLV, "Name");
			AddHeader(AttributesLV, "Value");
			AdjustColumns(AttributesLV);
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
			this.AttributesGB = new System.Windows.Forms.GroupBox();
			this.AttributesLV = new System.Windows.Forms.ListView();
			this.GeneralGB = new System.Windows.Forms.Panel();
			this.ActiveTimeTB = new System.Windows.Forms.TextBox();
			this.ActiveTimeLB = new System.Windows.Forms.Label();
			this.QualityTB = new System.Windows.Forms.TextBox();
			this.QualityLB = new System.Windows.Forms.Label();
			this.NewStateTB = new System.Windows.Forms.TextBox();
			this.NewStateLB = new System.Windows.Forms.Label();
			this.SubConditionNameLB = new System.Windows.Forms.Label();
			this.SubConditionNameTB = new System.Windows.Forms.TextBox();
			this.ConditionNameLB = new System.Windows.Forms.Label();
			this.ConditionNameTB = new System.Windows.Forms.TextBox();
			this.EventCategoryLB = new System.Windows.Forms.Label();
			this.EventCategoryTB = new System.Windows.Forms.TextBox();
			this.EventTypeLB = new System.Windows.Forms.Label();
			this.EventTypeTB = new System.Windows.Forms.TextBox();
			this.TimeTB = new System.Windows.Forms.TextBox();
			this.TimeLB = new System.Windows.Forms.Label();
			this.ActorTB = new System.Windows.Forms.TextBox();
			this.MessageTB = new System.Windows.Forms.TextBox();
			this.AckRequiredTB = new System.Windows.Forms.TextBox();
			this.ActorLB = new System.Windows.Forms.Label();
			this.SourceLB = new System.Windows.Forms.Label();
			this.AckRequiredLB = new System.Windows.Forms.Label();
			this.MessageLB = new System.Windows.Forms.Label();
			this.SourceTB = new System.Windows.Forms.TextBox();
			this.AttributesGB.SuspendLayout();
			this.GeneralGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// AttributesGB
			// 
			this.AttributesGB.Controls.Add(this.AttributesLV);
			this.AttributesGB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesGB.Location = new System.Drawing.Point(0, 284);
			this.AttributesGB.Name = "AttributesGB";
			this.AttributesGB.Size = new System.Drawing.Size(544, 184);
			this.AttributesGB.TabIndex = 0;
			this.AttributesGB.TabStop = false;
			this.AttributesGB.Text = "Attributes";
			// 
			// AttributesLV
			// 
			this.AttributesLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesLV.FullRowSelect = true;
			this.AttributesLV.Location = new System.Drawing.Point(3, 16);
			this.AttributesLV.MultiSelect = false;
			this.AttributesLV.Name = "AttributesLV";
			this.AttributesLV.Size = new System.Drawing.Size(538, 165);
			this.AttributesLV.TabIndex = 0;
			this.AttributesLV.View = System.Windows.Forms.View.Details;
			// 
			// GeneralGB
			// 
			this.GeneralGB.Controls.Add(this.ActiveTimeTB);
			this.GeneralGB.Controls.Add(this.ActiveTimeLB);
			this.GeneralGB.Controls.Add(this.QualityTB);
			this.GeneralGB.Controls.Add(this.QualityLB);
			this.GeneralGB.Controls.Add(this.NewStateTB);
			this.GeneralGB.Controls.Add(this.NewStateLB);
			this.GeneralGB.Controls.Add(this.SubConditionNameLB);
			this.GeneralGB.Controls.Add(this.SubConditionNameTB);
			this.GeneralGB.Controls.Add(this.ConditionNameLB);
			this.GeneralGB.Controls.Add(this.ConditionNameTB);
			this.GeneralGB.Controls.Add(this.EventCategoryLB);
			this.GeneralGB.Controls.Add(this.EventCategoryTB);
			this.GeneralGB.Controls.Add(this.EventTypeLB);
			this.GeneralGB.Controls.Add(this.EventTypeTB);
			this.GeneralGB.Controls.Add(this.TimeTB);
			this.GeneralGB.Controls.Add(this.TimeLB);
			this.GeneralGB.Controls.Add(this.ActorTB);
			this.GeneralGB.Controls.Add(this.MessageTB);
			this.GeneralGB.Controls.Add(this.AckRequiredTB);
			this.GeneralGB.Controls.Add(this.ActorLB);
			this.GeneralGB.Controls.Add(this.SourceLB);
			this.GeneralGB.Controls.Add(this.AckRequiredLB);
			this.GeneralGB.Controls.Add(this.MessageLB);
			this.GeneralGB.Controls.Add(this.SourceTB);
			this.GeneralGB.Dock = System.Windows.Forms.DockStyle.Top;
			this.GeneralGB.Location = new System.Drawing.Point(0, 0);
			this.GeneralGB.Name = "GeneralGB";
			this.GeneralGB.Size = new System.Drawing.Size(544, 284);
			this.GeneralGB.TabIndex = 13;
			this.GeneralGB.Text = "General";
			// 
			// ActiveTimeTB
			// 
			this.ActiveTimeTB.Location = new System.Drawing.Point(132, 240);
			this.ActiveTimeTB.Name = "ActiveTimeTB";
			this.ActiveTimeTB.ReadOnly = true;
			this.ActiveTimeTB.Size = new System.Drawing.Size(132, 20);
			this.ActiveTimeTB.TabIndex = 21;
			this.ActiveTimeTB.Text = "";
			// 
			// ActiveTimeLB
			// 
			this.ActiveTimeLB.Location = new System.Drawing.Point(0, 240);
			this.ActiveTimeLB.Name = "ActiveTimeLB";
			this.ActiveTimeLB.Size = new System.Drawing.Size(128, 23);
			this.ActiveTimeLB.TabIndex = 20;
			this.ActiveTimeLB.Text = "Active Time";
			this.ActiveTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityTB
			// 
			this.QualityTB.Location = new System.Drawing.Point(132, 216);
			this.QualityTB.Name = "QualityTB";
			this.QualityTB.ReadOnly = true;
			this.QualityTB.Size = new System.Drawing.Size(132, 20);
			this.QualityTB.TabIndex = 19;
			this.QualityTB.Text = "";
			// 
			// QualityLB
			// 
			this.QualityLB.Location = new System.Drawing.Point(0, 216);
			this.QualityLB.Name = "QualityLB";
			this.QualityLB.Size = new System.Drawing.Size(128, 23);
			this.QualityLB.TabIndex = 18;
			this.QualityLB.Text = "Quality";
			this.QualityLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NewStateTB
			// 
			this.NewStateTB.Location = new System.Drawing.Point(132, 168);
			this.NewStateTB.Name = "NewStateTB";
			this.NewStateTB.ReadOnly = true;
			this.NewStateTB.Size = new System.Drawing.Size(212, 20);
			this.NewStateTB.TabIndex = 15;
			this.NewStateTB.Text = "";
			// 
			// NewStateLB
			// 
			this.NewStateLB.Location = new System.Drawing.Point(0, 168);
			this.NewStateLB.Name = "NewStateLB";
			this.NewStateLB.Size = new System.Drawing.Size(128, 23);
			this.NewStateLB.TabIndex = 14;
			this.NewStateLB.Text = "New State";
			this.NewStateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubConditionNameLB
			// 
			this.SubConditionNameLB.Location = new System.Drawing.Point(0, 144);
			this.SubConditionNameLB.Name = "SubConditionNameLB";
			this.SubConditionNameLB.Size = new System.Drawing.Size(128, 23);
			this.SubConditionNameLB.TabIndex = 12;
			this.SubConditionNameLB.Text = "Subcondition Name";
			this.SubConditionNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubConditionNameTB
			// 
			this.SubConditionNameTB.Location = new System.Drawing.Point(132, 144);
			this.SubConditionNameTB.Name = "SubConditionNameTB";
			this.SubConditionNameTB.ReadOnly = true;
			this.SubConditionNameTB.Size = new System.Drawing.Size(212, 20);
			this.SubConditionNameTB.TabIndex = 13;
			this.SubConditionNameTB.Text = "";
			// 
			// ConditionNameLB
			// 
			this.ConditionNameLB.Location = new System.Drawing.Point(0, 120);
			this.ConditionNameLB.Name = "ConditionNameLB";
			this.ConditionNameLB.Size = new System.Drawing.Size(128, 23);
			this.ConditionNameLB.TabIndex = 10;
			this.ConditionNameLB.Text = "Condition Name";
			this.ConditionNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionNameTB
			// 
			this.ConditionNameTB.Location = new System.Drawing.Point(132, 120);
			this.ConditionNameTB.Name = "ConditionNameTB";
			this.ConditionNameTB.ReadOnly = true;
			this.ConditionNameTB.Size = new System.Drawing.Size(212, 20);
			this.ConditionNameTB.TabIndex = 11;
			this.ConditionNameTB.Text = "";
			// 
			// EventCategoryLB
			// 
			this.EventCategoryLB.Location = new System.Drawing.Point(0, 96);
			this.EventCategoryLB.Name = "EventCategoryLB";
			this.EventCategoryLB.Size = new System.Drawing.Size(128, 23);
			this.EventCategoryLB.TabIndex = 8;
			this.EventCategoryLB.Text = "Event Category";
			this.EventCategoryLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EventCategoryTB
			// 
			this.EventCategoryTB.Location = new System.Drawing.Point(132, 96);
			this.EventCategoryTB.Name = "EventCategoryTB";
			this.EventCategoryTB.ReadOnly = true;
			this.EventCategoryTB.Size = new System.Drawing.Size(212, 20);
			this.EventCategoryTB.TabIndex = 9;
			this.EventCategoryTB.Text = "";
			// 
			// EventTypeLB
			// 
			this.EventTypeLB.Location = new System.Drawing.Point(0, 72);
			this.EventTypeLB.Name = "EventTypeLB";
			this.EventTypeLB.Size = new System.Drawing.Size(128, 23);
			this.EventTypeLB.TabIndex = 6;
			this.EventTypeLB.Text = "Event Type";
			this.EventTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EventTypeTB
			// 
			this.EventTypeTB.Location = new System.Drawing.Point(132, 72);
			this.EventTypeTB.Name = "EventTypeTB";
			this.EventTypeTB.ReadOnly = true;
			this.EventTypeTB.Size = new System.Drawing.Size(212, 20);
			this.EventTypeTB.TabIndex = 7;
			this.EventTypeTB.Text = "";
			// 
			// TimeTB
			// 
			this.TimeTB.Location = new System.Drawing.Point(132, 24);
			this.TimeTB.Name = "TimeTB";
			this.TimeTB.ReadOnly = true;
			this.TimeTB.Size = new System.Drawing.Size(132, 20);
			this.TimeTB.TabIndex = 3;
			this.TimeTB.Text = "";
			// 
			// TimeLB
			// 
			this.TimeLB.Location = new System.Drawing.Point(0, 24);
			this.TimeLB.Name = "TimeLB";
			this.TimeLB.Size = new System.Drawing.Size(128, 23);
			this.TimeLB.TabIndex = 2;
			this.TimeLB.Text = "Time";
			this.TimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActorTB
			// 
			this.ActorTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ActorTB.Location = new System.Drawing.Point(132, 264);
			this.ActorTB.Name = "ActorTB";
			this.ActorTB.ReadOnly = true;
			this.ActorTB.Size = new System.Drawing.Size(404, 20);
			this.ActorTB.TabIndex = 23;
			this.ActorTB.Text = "";
			// 
			// MessageTB
			// 
			this.MessageTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MessageTB.Location = new System.Drawing.Point(132, 48);
			this.MessageTB.Name = "MessageTB";
			this.MessageTB.ReadOnly = true;
			this.MessageTB.Size = new System.Drawing.Size(404, 20);
			this.MessageTB.TabIndex = 5;
			this.MessageTB.Text = "";
			// 
			// AckRequiredTB
			// 
			this.AckRequiredTB.Location = new System.Drawing.Point(132, 192);
			this.AckRequiredTB.Name = "AckRequiredTB";
			this.AckRequiredTB.ReadOnly = true;
			this.AckRequiredTB.Size = new System.Drawing.Size(132, 20);
			this.AckRequiredTB.TabIndex = 17;
			this.AckRequiredTB.Text = "";
			// 
			// ActorLB
			// 
			this.ActorLB.Location = new System.Drawing.Point(0, 264);
			this.ActorLB.Name = "ActorLB";
			this.ActorLB.Size = new System.Drawing.Size(128, 23);
			this.ActorLB.TabIndex = 22;
			this.ActorLB.Text = "Actor ID";
			this.ActorLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SourceLB
			// 
			this.SourceLB.Location = new System.Drawing.Point(0, 0);
			this.SourceLB.Name = "SourceLB";
			this.SourceLB.Size = new System.Drawing.Size(128, 23);
			this.SourceLB.TabIndex = 0;
			this.SourceLB.Text = "Source";
			this.SourceLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AckRequiredLB
			// 
			this.AckRequiredLB.Location = new System.Drawing.Point(0, 192);
			this.AckRequiredLB.Name = "AckRequiredLB";
			this.AckRequiredLB.Size = new System.Drawing.Size(128, 23);
			this.AckRequiredLB.TabIndex = 16;
			this.AckRequiredLB.Text = "Ack Requried";
			this.AckRequiredLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MessageLB
			// 
			this.MessageLB.Location = new System.Drawing.Point(0, 48);
			this.MessageLB.Name = "MessageLB";
			this.MessageLB.Size = new System.Drawing.Size(128, 23);
			this.MessageLB.TabIndex = 4;
			this.MessageLB.Text = "Message";
			this.MessageLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SourceTB
			// 
			this.SourceTB.Location = new System.Drawing.Point(132, 0);
			this.SourceTB.Name = "SourceTB";
			this.SourceTB.ReadOnly = true;
			this.SourceTB.Size = new System.Drawing.Size(212, 20);
			this.SourceTB.TabIndex = 1;
			this.SourceTB.Text = "";
			// 
			// NotificationCtrl
			// 
			this.Controls.Add(this.AttributesGB);
			this.Controls.Add(this.GeneralGB);
			this.Name = "NotificationCtrl";
			this.Size = new System.Drawing.Size(544, 468);
			this.AttributesGB.ResumeLayout(false);
			this.GeneralGB.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the notification in the control.
		/// </summary>
		public void ShowNotification(Ae.TsCAeSubscription subscription, TsCAeEventNotification notification)
		{
			// check for null value.
			if (notification == null)
			{
				SourceTB.Text           = "";
				TimeTB.Text             = "";
				MessageTB.Text          = "";
				EventTypeTB.Text        = "";
				EventCategoryTB.Text    = "";
				ConditionNameTB.Text    = "";
				SubConditionNameTB.Text = "";
				NewStateTB.Text         = "";
				AckRequiredTB.Text      = "";
				QualityTB.Text          = "";
				ActiveTimeTB.Text       = "";
				ActorTB.Text            = "";
				
				AttributesLV.Items.Clear();
				return;
			}

			// find category.
			OpcClientSdk.Ae.TsCAeCategory category = null;

			try
			{
				OpcClientSdk.Ae.TsCAeCategory[] categories = subscription.Server.QueryEventCategories((int)notification.EventType);

				for (int ii = 0; ii < categories.Length; ii++)
				{
					if (categories[ii].ID == notification.EventCategory)
					{
						category = categories[ii];
						break;
					}
				}
			}
			catch
			{
				category = null;
			}
			
			// find attributes.
			ArrayList attributes = new ArrayList();

			try
			{
				// get attribute descriptions.
				OpcClientSdk.Ae.TsCAeAttribute[] descriptions = subscription.Server.QueryEventAttributes(notification.EventCategory);

				// get selected attributes.
				int[] attributeIDs = null;
				
				if (subscription.Attributes.Contains(notification.EventCategory))
				{
					attributeIDs = subscription.Attributes[notification.EventCategory].ToArray();
				}

				// find decriptions for selected attributes.
				if (attributeIDs != null)
				{
					for (int ii = 0; ii < attributeIDs.Length; ii++)
					{
						for (int jj = 0; jj < descriptions.Length; jj++)
						{
							if (descriptions[jj].ID == attributeIDs[ii])
							{
								attributes.Add(descriptions[jj]);
								break;
							}
						}
					}
				}
			}
			catch
			{
				// ignore errors.
			}			

			SourceTB.Text           = notification.SourceID;
			TimeTB.Text             = OpcClientSdk.OpcConvert.ToString(notification.Time);
			MessageTB.Text          = notification.Message;
			EventTypeTB.Text        = OpcClientSdk.OpcConvert.ToString(notification.EventType);
			EventCategoryTB.Text    = (category != null)?category.Name:"";
			ConditionNameTB.Text    = notification.ConditionName;
			SubConditionNameTB.Text = notification.SubConditionName;
			NewStateTB.Text         = "";
			AckRequiredTB.Text      = OpcClientSdk.OpcConvert.ToString(notification.AckRequired);
			QualityTB.Text          = OpcClientSdk.OpcConvert.ToString(notification.Quality);
			ActiveTimeTB.Text       = OpcClientSdk.OpcConvert.ToString(notification.ActiveTime);
			ActorTB.Text            = notification.ActorID;

			// convert state to a string.
			if ((notification.NewState & (int)Ae.TsCAeConditionState.Active) != 0)
			{
				NewStateTB.Text += Ae.TsCAeConditionState.Active.ToString();
			}

			if ((notification.NewState & (int)Ae.TsCAeConditionState.Enabled) != 0)
			{
				if (NewStateTB.Text != "") NewStateTB.Text += " AND ";
				NewStateTB.Text += Ae.TsCAeConditionState.Enabled.ToString();
			}

			if ((notification.NewState & (int)Ae.TsCAeConditionState.Acknowledged) != 0)
			{
				if (NewStateTB.Text != "") NewStateTB.Text += " AND ";
				NewStateTB.Text += Ae.TsCAeConditionState.Acknowledged.ToString();
			}

			// fill attributes list.
			AttributesLV.Items.Clear();

			for (int ii = 0; ii < notification.Attributes.Count; ii++)
			{
				OpcClientSdk.Ae.TsCAeAttribute attribute = (ii < attributes.Count)?(OpcClientSdk.Ae.TsCAeAttribute)attributes[ii]:null;

				ListViewItem item = new ListViewItem((attribute != null)?attribute.Name:"Unknown");

				item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(notification.Attributes[ii]));

				AttributesLV.Items.Add(item);
			}

			AdjustColumns(AttributesLV);
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
	}
}
