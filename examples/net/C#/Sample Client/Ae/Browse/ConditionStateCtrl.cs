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
	public class ConditionStateCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TextBox StateTB;
		private System.Windows.Forms.GroupBox GeneralGB;
		private System.Windows.Forms.Label StateLB;
		private System.Windows.Forms.Label QualityLB;
		private System.Windows.Forms.Label CommentsLB;
		private System.Windows.Forms.TextBox QualityTB;
		private System.Windows.Forms.TextBox CommentsTB;
		private System.Windows.Forms.Label LastAcknowledgedLB;
		private System.Windows.Forms.Label ConditionLastActiveLB;
		private System.Windows.Forms.Label ConditionLastInactiveLB;
		private System.Windows.Forms.GroupBox SubConditionsGB;
		private System.Windows.Forms.Label SubConditionLastActiveLB;
		private System.Windows.Forms.TextBox LastAcknowledgedTB;
		private System.Windows.Forms.TextBox SubConditionLastActiveTB;
		private System.Windows.Forms.TextBox ConditionLastInactiveTB;
		private System.Windows.Forms.TextBox ConditionLastActiveTB;
		private System.Windows.Forms.ListView SubConditionsLV;
		private System.Windows.Forms.ListView AttributesLV;
		private System.Windows.Forms.GroupBox TimestampsGB;
		private System.Windows.Forms.GroupBox AttributesGB;
		private System.Windows.Forms.TextBox ActiveSubConditionTB;
		private System.Windows.Forms.Label ActiveSubConditionLB;
		private System.Windows.Forms.TextBox AcknowledgerTB;
		private System.Windows.Forms.Label AcknowledgerLB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConditionStateCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			AddHeader(SubConditionsLV, "Name");
			AddHeader(SubConditionsLV, "Severity");
			AddHeader(SubConditionsLV, "Definition");
			AddHeader(SubConditionsLV, "Description");
			AdjustColumns(SubConditionsLV);

			AddHeader(AttributesLV, "Name");
			AddHeader(AttributesLV, "Value");
			AddHeader(AttributesLV, "Result");
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
			this.StateTB = new System.Windows.Forms.TextBox();
			this.TimestampsGB = new System.Windows.Forms.GroupBox();
			this.LastAcknowledgedTB = new System.Windows.Forms.TextBox();
			this.SubConditionLastActiveTB = new System.Windows.Forms.TextBox();
			this.ConditionLastInactiveTB = new System.Windows.Forms.TextBox();
			this.ConditionLastActiveTB = new System.Windows.Forms.TextBox();
			this.SubConditionLastActiveLB = new System.Windows.Forms.Label();
			this.LastAcknowledgedLB = new System.Windows.Forms.Label();
			this.ConditionLastActiveLB = new System.Windows.Forms.Label();
			this.ConditionLastInactiveLB = new System.Windows.Forms.Label();
			this.AttributesGB = new System.Windows.Forms.GroupBox();
			this.AttributesLV = new System.Windows.Forms.ListView();
			this.SubConditionsGB = new System.Windows.Forms.GroupBox();
			this.SubConditionsLV = new System.Windows.Forms.ListView();
			this.GeneralGB = new System.Windows.Forms.GroupBox();
			this.ActiveSubConditionTB = new System.Windows.Forms.TextBox();
			this.ActiveSubConditionLB = new System.Windows.Forms.Label();
			this.AcknowledgerTB = new System.Windows.Forms.TextBox();
			this.CommentsTB = new System.Windows.Forms.TextBox();
			this.QualityTB = new System.Windows.Forms.TextBox();
			this.AcknowledgerLB = new System.Windows.Forms.Label();
			this.StateLB = new System.Windows.Forms.Label();
			this.QualityLB = new System.Windows.Forms.Label();
			this.CommentsLB = new System.Windows.Forms.Label();
			this.TimestampsGB.SuspendLayout();
			this.AttributesGB.SuspendLayout();
			this.SubConditionsGB.SuspendLayout();
			this.GeneralGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// StateTB
			// 
			this.StateTB.Location = new System.Drawing.Point(136, 16);
			this.StateTB.Name = "StateTB";
			this.StateTB.ReadOnly = true;
			this.StateTB.Size = new System.Drawing.Size(212, 20);
			this.StateTB.TabIndex = 8;
			this.StateTB.Text = "";
			// 
			// TimestampsGB
			// 
			this.TimestampsGB.Controls.Add(this.LastAcknowledgedTB);
			this.TimestampsGB.Controls.Add(this.SubConditionLastActiveTB);
			this.TimestampsGB.Controls.Add(this.ConditionLastInactiveTB);
			this.TimestampsGB.Controls.Add(this.ConditionLastActiveTB);
			this.TimestampsGB.Controls.Add(this.SubConditionLastActiveLB);
			this.TimestampsGB.Controls.Add(this.LastAcknowledgedLB);
			this.TimestampsGB.Controls.Add(this.ConditionLastActiveLB);
			this.TimestampsGB.Controls.Add(this.ConditionLastInactiveLB);
			this.TimestampsGB.Dock = System.Windows.Forms.DockStyle.Top;
			this.TimestampsGB.Location = new System.Drawing.Point(0, 136);
			this.TimestampsGB.Name = "TimestampsGB";
			this.TimestampsGB.Size = new System.Drawing.Size(544, 68);
			this.TimestampsGB.TabIndex = 10;
			this.TimestampsGB.TabStop = false;
			this.TimestampsGB.Text = "Timestamps";
			// 
			// LastAcknowledgedTB
			// 
			this.LastAcknowledgedTB.Location = new System.Drawing.Point(408, 40);
			this.LastAcknowledgedTB.Name = "LastAcknowledgedTB";
			this.LastAcknowledgedTB.ReadOnly = true;
			this.LastAcknowledgedTB.Size = new System.Drawing.Size(132, 20);
			this.LastAcknowledgedTB.TabIndex = 18;
			this.LastAcknowledgedTB.Text = "";
			// 
			// SubConditionLastActiveTB
			// 
			this.SubConditionLastActiveTB.Location = new System.Drawing.Point(408, 16);
			this.SubConditionLastActiveTB.Name = "SubConditionLastActiveTB";
			this.SubConditionLastActiveTB.ReadOnly = true;
			this.SubConditionLastActiveTB.Size = new System.Drawing.Size(132, 20);
			this.SubConditionLastActiveTB.TabIndex = 17;
			this.SubConditionLastActiveTB.Text = "";
			// 
			// ConditionLastInactiveTB
			// 
			this.ConditionLastInactiveTB.Location = new System.Drawing.Point(136, 40);
			this.ConditionLastInactiveTB.Name = "ConditionLastInactiveTB";
			this.ConditionLastInactiveTB.ReadOnly = true;
			this.ConditionLastInactiveTB.Size = new System.Drawing.Size(132, 20);
			this.ConditionLastInactiveTB.TabIndex = 16;
			this.ConditionLastInactiveTB.Text = "";
			// 
			// ConditionLastActiveTB
			// 
			this.ConditionLastActiveTB.Location = new System.Drawing.Point(136, 16);
			this.ConditionLastActiveTB.Name = "ConditionLastActiveTB";
			this.ConditionLastActiveTB.ReadOnly = true;
			this.ConditionLastActiveTB.Size = new System.Drawing.Size(132, 20);
			this.ConditionLastActiveTB.TabIndex = 15;
			this.ConditionLastActiveTB.Text = "";
			// 
			// SubConditionLastActiveLB
			// 
			this.SubConditionLastActiveLB.Location = new System.Drawing.Point(276, 16);
			this.SubConditionLastActiveLB.Name = "SubConditionLastActiveLB";
			this.SubConditionLastActiveLB.Size = new System.Drawing.Size(128, 23);
			this.SubConditionLastActiveLB.TabIndex = 11;
			this.SubConditionLastActiveLB.Text = "Subcondition Last Active";
			this.SubConditionLastActiveLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LastAcknowledgedLB
			// 
			this.LastAcknowledgedLB.Location = new System.Drawing.Point(276, 40);
			this.LastAcknowledgedLB.Name = "LastAcknowledgedLB";
			this.LastAcknowledgedLB.Size = new System.Drawing.Size(128, 23);
			this.LastAcknowledgedLB.TabIndex = 1;
			this.LastAcknowledgedLB.Text = "Last Acknowledged";
			this.LastAcknowledgedLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionLastActiveLB
			// 
			this.ConditionLastActiveLB.Location = new System.Drawing.Point(4, 16);
			this.ConditionLastActiveLB.Name = "ConditionLastActiveLB";
			this.ConditionLastActiveLB.Size = new System.Drawing.Size(128, 23);
			this.ConditionLastActiveLB.TabIndex = 4;
			this.ConditionLastActiveLB.Text = "Condition Last Active";
			this.ConditionLastActiveLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionLastInactiveLB
			// 
			this.ConditionLastInactiveLB.Location = new System.Drawing.Point(4, 40);
			this.ConditionLastInactiveLB.Name = "ConditionLastInactiveLB";
			this.ConditionLastInactiveLB.Size = new System.Drawing.Size(128, 23);
			this.ConditionLastInactiveLB.TabIndex = 10;
			this.ConditionLastInactiveLB.Text = "Condition Last Inactive";
			this.ConditionLastInactiveLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributesGB
			// 
			this.AttributesGB.Controls.Add(this.AttributesLV);
			this.AttributesGB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesGB.Location = new System.Drawing.Point(0, 328);
			this.AttributesGB.Name = "AttributesGB";
			this.AttributesGB.Size = new System.Drawing.Size(544, 140);
			this.AttributesGB.TabIndex = 11;
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
			this.AttributesLV.Size = new System.Drawing.Size(538, 121);
			this.AttributesLV.TabIndex = 1;
			this.AttributesLV.View = System.Windows.Forms.View.Details;
			// 
			// SubConditionsGB
			// 
			this.SubConditionsGB.Controls.Add(this.SubConditionsLV);
			this.SubConditionsGB.Dock = System.Windows.Forms.DockStyle.Top;
			this.SubConditionsGB.Location = new System.Drawing.Point(0, 204);
			this.SubConditionsGB.Name = "SubConditionsGB";
			this.SubConditionsGB.Size = new System.Drawing.Size(544, 124);
			this.SubConditionsGB.TabIndex = 12;
			this.SubConditionsGB.TabStop = false;
			this.SubConditionsGB.Text = "Subconditions";
			// 
			// SubConditionsLV
			// 
			this.SubConditionsLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SubConditionsLV.FullRowSelect = true;
			this.SubConditionsLV.Location = new System.Drawing.Point(3, 16);
			this.SubConditionsLV.MultiSelect = false;
			this.SubConditionsLV.Name = "SubConditionsLV";
			this.SubConditionsLV.Size = new System.Drawing.Size(538, 105);
			this.SubConditionsLV.TabIndex = 0;
			this.SubConditionsLV.View = System.Windows.Forms.View.Details;
			// 
			// GeneralGB
			// 
			this.GeneralGB.Controls.Add(this.ActiveSubConditionTB);
			this.GeneralGB.Controls.Add(this.ActiveSubConditionLB);
			this.GeneralGB.Controls.Add(this.AcknowledgerTB);
			this.GeneralGB.Controls.Add(this.CommentsTB);
			this.GeneralGB.Controls.Add(this.QualityTB);
			this.GeneralGB.Controls.Add(this.AcknowledgerLB);
			this.GeneralGB.Controls.Add(this.StateLB);
			this.GeneralGB.Controls.Add(this.QualityLB);
			this.GeneralGB.Controls.Add(this.CommentsLB);
			this.GeneralGB.Controls.Add(this.StateTB);
			this.GeneralGB.Dock = System.Windows.Forms.DockStyle.Top;
			this.GeneralGB.Location = new System.Drawing.Point(0, 0);
			this.GeneralGB.Name = "GeneralGB";
			this.GeneralGB.Size = new System.Drawing.Size(544, 136);
			this.GeneralGB.TabIndex = 13;
			this.GeneralGB.TabStop = false;
			this.GeneralGB.Text = "General";
			// 
			// ActiveSubConditionTB
			// 
			this.ActiveSubConditionTB.Location = new System.Drawing.Point(136, 40);
			this.ActiveSubConditionTB.Name = "ActiveSubConditionTB";
			this.ActiveSubConditionTB.ReadOnly = true;
			this.ActiveSubConditionTB.Size = new System.Drawing.Size(212, 20);
			this.ActiveSubConditionTB.TabIndex = 16;
			this.ActiveSubConditionTB.Text = "";
			// 
			// ActiveSubConditionLB
			// 
			this.ActiveSubConditionLB.Location = new System.Drawing.Point(4, 40);
			this.ActiveSubConditionLB.Name = "ActiveSubConditionLB";
			this.ActiveSubConditionLB.Size = new System.Drawing.Size(128, 23);
			this.ActiveSubConditionLB.TabIndex = 15;
			this.ActiveSubConditionLB.Text = "Active Subcondition";
			this.ActiveSubConditionLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AcknowledgerTB
			// 
			this.AcknowledgerTB.Location = new System.Drawing.Point(136, 112);
			this.AcknowledgerTB.Name = "AcknowledgerTB";
			this.AcknowledgerTB.ReadOnly = true;
			this.AcknowledgerTB.Size = new System.Drawing.Size(360, 20);
			this.AcknowledgerTB.TabIndex = 14;
			this.AcknowledgerTB.Text = "";
			// 
			// CommentsTB
			// 
			this.CommentsTB.Location = new System.Drawing.Point(136, 88);
			this.CommentsTB.Name = "CommentsTB";
			this.CommentsTB.ReadOnly = true;
			this.CommentsTB.Size = new System.Drawing.Size(360, 20);
			this.CommentsTB.TabIndex = 13;
			this.CommentsTB.Text = "";
			// 
			// QualityTB
			// 
			this.QualityTB.Location = new System.Drawing.Point(136, 64);
			this.QualityTB.Name = "QualityTB";
			this.QualityTB.ReadOnly = true;
			this.QualityTB.Size = new System.Drawing.Size(116, 20);
			this.QualityTB.TabIndex = 12;
			this.QualityTB.Text = "";
			// 
			// AcknowledgerLB
			// 
			this.AcknowledgerLB.Location = new System.Drawing.Point(4, 112);
			this.AcknowledgerLB.Name = "AcknowledgerLB";
			this.AcknowledgerLB.Size = new System.Drawing.Size(128, 23);
			this.AcknowledgerLB.TabIndex = 11;
			this.AcknowledgerLB.Text = "Acknowledger";
			this.AcknowledgerLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StateLB
			// 
			this.StateLB.Location = new System.Drawing.Point(4, 16);
			this.StateLB.Name = "StateLB";
			this.StateLB.Size = new System.Drawing.Size(128, 23);
			this.StateLB.TabIndex = 1;
			this.StateLB.Text = "State";
			this.StateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityLB
			// 
			this.QualityLB.Location = new System.Drawing.Point(4, 64);
			this.QualityLB.Name = "QualityLB";
			this.QualityLB.Size = new System.Drawing.Size(128, 23);
			this.QualityLB.TabIndex = 4;
			this.QualityLB.Text = "Quality";
			this.QualityLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CommentsLB
			// 
			this.CommentsLB.Location = new System.Drawing.Point(4, 88);
			this.CommentsLB.Name = "CommentsLB";
			this.CommentsLB.Size = new System.Drawing.Size(128, 23);
			this.CommentsLB.TabIndex = 10;
			this.CommentsLB.Text = "Comments";
			this.CommentsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConditionStateCtrl
			// 
			this.Controls.Add(this.AttributesGB);
			this.Controls.Add(this.SubConditionsGB);
			this.Controls.Add(this.TimestampsGB);
			this.Controls.Add(this.GeneralGB);
			this.Name = "ConditionStateCtrl";
			this.Size = new System.Drawing.Size(544, 468);
			this.TimestampsGB.ResumeLayout(false);
			this.AttributesGB.ResumeLayout(false);
			this.SubConditionsGB.ResumeLayout(false);
			this.GeneralGB.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Displays the condition in the control.
		/// </summary>
		public void ShowCondition(OpcClientSdk.Ae.TsCAeAttribute[] attributes, Ae.TsCAeCondition condition)
		{
			// check for null value.
			if (condition == null)
			{
				QualityTB.Text                = "";
				CommentsTB.Text               = "";
				AcknowledgerTB.Text           = "";
				ActiveSubConditionTB.Text     = "";
				ConditionLastActiveTB.Text    = "";
				ConditionLastInactiveTB.Text  = "";
				SubConditionLastActiveTB.Text = "";
				LastAcknowledgedTB.Text       = "";
				
				SubConditionsLV.Items.Clear();
				AttributesLV.Items.Clear();
				return;
			}
			
			// convert state to a string.
			StateTB.Text = "";

			if ((condition.State & (int)Ae.TsCAeConditionState.Active) != 0)
			{
				StateTB.Text += Ae.TsCAeConditionState.Active.ToString();
			}

			if ((condition.State & (int)Ae.TsCAeConditionState.Enabled) != 0)
			{
				if (StateTB.Text != "") StateTB.Text += " AND ";
				StateTB.Text += Ae.TsCAeConditionState.Enabled.ToString();
			}

			if ((condition.State & (int)Ae.TsCAeConditionState.Acknowledged) != 0)
			{
				if (StateTB.Text != "") StateTB.Text += " AND ";
				StateTB.Text += Ae.TsCAeConditionState.Acknowledged.ToString();
			}

			QualityTB.Text                = OpcClientSdk.OpcConvert.ToString(condition.Quality);
			CommentsTB.Text               = condition.Comment;
			AcknowledgerTB.Text           = condition.AcknowledgerID;
			ActiveSubConditionTB.Text     = condition.ActiveSubCondition.Name;
			ConditionLastActiveTB.Text    = OpcClientSdk.OpcConvert.ToString(condition.CondLastActive);
			ConditionLastInactiveTB.Text  = OpcClientSdk.OpcConvert.ToString(condition.CondLastInactive);
			SubConditionLastActiveTB.Text = OpcClientSdk.OpcConvert.ToString(condition.SubCondLastActive);
			LastAcknowledgedTB.Text       = OpcClientSdk.OpcConvert.ToString(condition.LastAckTime);

			// fill sub-conditions list.
			SubConditionsLV.Items.Clear();

			foreach (TsCAeSubCondition subcondition in condition.SubConditions)
			{
				ListViewItem item = new ListViewItem(subcondition.Name);

				if (subcondition.Name == condition.ActiveSubCondition.Name)
				{
					item.SubItems.Add(condition.ActiveSubCondition.Severity.ToString());
					item.SubItems.Add(condition.ActiveSubCondition.Definition);
					item.SubItems.Add(condition.ActiveSubCondition.Description);
					
					item.ForeColor = Color.Red;
				}
				else
				{
					item.SubItems.Add(subcondition.Severity.ToString());
					item.SubItems.Add(subcondition.Definition);
					item.SubItems.Add(subcondition.Description);
				}

				SubConditionsLV.Items.Add(item);
			}

			AdjustColumns(SubConditionsLV);

			// fill attributes list.
			AttributesLV.Items.Clear();

			for (int ii = 0; ii < condition.Attributes.Count; ii++)
			{
				ListViewItem item = new ListViewItem(attributes[ii].Name);

				item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(condition.Attributes[ii].Value));
				item.SubItems.Add(OpcClientSdk.OpcConvert.ToString(condition.Attributes[ii].Result));

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
