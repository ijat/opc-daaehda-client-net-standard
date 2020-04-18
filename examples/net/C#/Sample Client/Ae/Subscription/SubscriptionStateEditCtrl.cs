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
	public class SubscriptionStateEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label ActiveLB;
		private System.Windows.Forms.CheckBox ActiveCB;
		private System.Windows.Forms.Label BufferTimeLB;
		private System.Windows.Forms.NumericUpDown BufferTimeCTRL;
		private System.Windows.Forms.Label NameLB;
		private System.Windows.Forms.Label KeepAliveLB;
		private System.Windows.Forms.Label MaxSizeLB;
		private System.Windows.Forms.TextBox NameTB;
		private System.Windows.Forms.NumericUpDown KeepAliveCTRL;
		private System.Windows.Forms.NumericUpDown MaxSizeCTRL;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SubscriptionStateEditCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
			this.NameLB = new System.Windows.Forms.Label();
			this.ActiveLB = new System.Windows.Forms.Label();
			this.BufferTimeLB = new System.Windows.Forms.Label();
			this.KeepAliveLB = new System.Windows.Forms.Label();
			this.MaxSizeLB = new System.Windows.Forms.Label();
			this.NameTB = new System.Windows.Forms.TextBox();
			this.ActiveCB = new System.Windows.Forms.CheckBox();
			this.BufferTimeCTRL = new System.Windows.Forms.NumericUpDown();
			this.KeepAliveCTRL = new System.Windows.Forms.NumericUpDown();
			this.MaxSizeCTRL = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.BufferTimeCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.KeepAliveCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxSizeCTRL)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLB
			// 
			this.NameLB.Location = new System.Drawing.Point(0, 0);
			this.NameLB.Name = "NameLB";
			this.NameLB.TabIndex = 0;
			this.NameLB.Text = "Name";
			this.NameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActiveLB
			// 
			this.ActiveLB.Location = new System.Drawing.Point(0, 24);
			this.ActiveLB.Name = "ActiveLB";
			this.ActiveLB.TabIndex = 1;
			this.ActiveLB.Text = "Active";
			this.ActiveLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BufferTimeLB
			// 
			this.BufferTimeLB.Location = new System.Drawing.Point(0, 48);
			this.BufferTimeLB.Name = "BufferTimeLB";
			this.BufferTimeLB.TabIndex = 4;
			this.BufferTimeLB.Text = "Buffer Time";
			this.BufferTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// KeepAliveLB
			// 
			this.KeepAliveLB.Location = new System.Drawing.Point(0, 72);
			this.KeepAliveLB.Name = "KeepAliveLB";
			this.KeepAliveLB.TabIndex = 5;
			this.KeepAliveLB.Text = "Keep Alive Time";
			this.KeepAliveLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxSizeLB
			// 
			this.MaxSizeLB.Location = new System.Drawing.Point(0, 96);
			this.MaxSizeLB.Name = "MaxSizeLB";
			this.MaxSizeLB.TabIndex = 6;
			this.MaxSizeLB.Text = "Max Size";
			this.MaxSizeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			this.NameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.NameTB.Location = new System.Drawing.Point(104, 0);
			this.NameTB.Name = "NameTB";
			this.NameTB.Size = new System.Drawing.Size(124, 20);
			this.NameTB.TabIndex = 8;
			this.NameTB.Text = "";
			// 
			// ActiveCB
			// 
			this.ActiveCB.Location = new System.Drawing.Point(104, 24);
			this.ActiveCB.Name = "ActiveCB";
			this.ActiveCB.Size = new System.Drawing.Size(16, 24);
			this.ActiveCB.TabIndex = 9;
			// 
			// BufferTimeCTRL
			// 
			this.BufferTimeCTRL.Increment = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			this.BufferTimeCTRL.Location = new System.Drawing.Point(104, 48);
			this.BufferTimeCTRL.Maximum = new System.Decimal(new int[] {
																		   1000000000,
																		   0,
																		   0,
																		   0});
			this.BufferTimeCTRL.Name = "BufferTimeCTRL";
			this.BufferTimeCTRL.Size = new System.Drawing.Size(72, 20);
			this.BufferTimeCTRL.TabIndex = 11;
			// 
			// KeepAliveCTRL
			// 
			this.KeepAliveCTRL.Increment = new System.Decimal(new int[] {
																			100,
																			0,
																			0,
																			0});
			this.KeepAliveCTRL.Location = new System.Drawing.Point(104, 72);
			this.KeepAliveCTRL.Maximum = new System.Decimal(new int[] {
																		  1000000000,
																		  0,
																		  0,
																		  0});
			this.KeepAliveCTRL.Name = "KeepAliveCTRL";
			this.KeepAliveCTRL.Size = new System.Drawing.Size(72, 20);
			this.KeepAliveCTRL.TabIndex = 12;
			// 
			// MaxSizeCTRL
			// 
			this.MaxSizeCTRL.Increment = new System.Decimal(new int[] {
																		  100,
																		  0,
																		  0,
																		  0});
			this.MaxSizeCTRL.Location = new System.Drawing.Point(104, 96);
			this.MaxSizeCTRL.Maximum = new System.Decimal(new int[] {
																		100000,
																		0,
																		0,
																		0});
			this.MaxSizeCTRL.Name = "MaxSizeCTRL";
			this.MaxSizeCTRL.Size = new System.Drawing.Size(72, 20);
			this.MaxSizeCTRL.TabIndex = 14;
			// 
			// SubscriptionStateEditCtrl
			// 
			this.Controls.Add(this.MaxSizeCTRL);
			this.Controls.Add(this.KeepAliveCTRL);
			this.Controls.Add(this.BufferTimeCTRL);
			this.Controls.Add(this.ActiveCB);
			this.Controls.Add(this.NameTB);
			this.Controls.Add(this.KeepAliveLB);
			this.Controls.Add(this.ActiveLB);
			this.Controls.Add(this.NameLB);
			this.Controls.Add(this.BufferTimeLB);
			this.Controls.Add(this.MaxSizeLB);
			this.Name = "SubscriptionStateEditCtrl";
			this.Size = new System.Drawing.Size(232, 120);
			((System.ComponentModel.ISupportInitialize)(this.BufferTimeCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.KeepAliveCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxSizeCTRL)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region IEditObjectCtrl Members
		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			NameTB.Text          = null;
			ActiveCB.Checked     = true;
			BufferTimeCTRL.Value = 1000;
			KeepAliveCTRL.Value  = 0;
			MaxSizeCTRL.Value    = 0;
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			Ae.TsCAeSubscriptionState state = new Ae.TsCAeSubscriptionState();

			state.Name         = NameTB.Text;
			state.Active       = ActiveCB.Checked;
			state.BufferTime   = (int)BufferTimeCTRL.Value;
			state.KeepAlive    = (int)KeepAliveCTRL.Value;
			state.MaxSize      = (int)MaxSizeCTRL.Value;

			return state;
		}
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		public void Set(object value)
		{
			// check for null value.
			if (value == null) { SetDefaults(); return; }

			Ae.TsCAeSubscriptionState state = (Ae.TsCAeSubscriptionState)value;
			
			NameTB.Text          = state.Name;
			ActiveCB.Checked     = state.Active;
			BufferTimeCTRL.Value = (decimal)state.BufferTime;
			KeepAliveCTRL.Value  = (decimal)state.KeepAlive;
			MaxSizeCTRL.Value    = (decimal)state.MaxSize;
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			Ae.TsCAeSubscriptionState state = new Ae.TsCAeSubscriptionState();
			state.BufferTime = 1000;
			return state;
		}
		#endregion
	}
}
