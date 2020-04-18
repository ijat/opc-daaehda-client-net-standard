//============================================================================
// TITLE: SubscriptionEditCtrl.cs
//
// CONTENTS:
// 
// A control used to edit the state of a subscription.
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
using OpcClientSdk.Controls;

namespace Client
{
	/// <summary>
	/// A control used to edit the state of a subscription.
	/// </summary>
	public class SubscriptionEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label NameLB;
		private System.Windows.Forms.Label ActiveLB;
		private System.Windows.Forms.Label UpdateRateLB;
		private System.Windows.Forms.Label KeepAliveRateLB;
		private System.Windows.Forms.Label DeadbandLB;
		private System.Windows.Forms.TextBox NameTB;
		private System.Windows.Forms.CheckBox ActiveCB;
		private System.Windows.Forms.NumericUpDown UpdateRateCTRL;
		private System.Windows.Forms.NumericUpDown KeepAliveRateCTRL;
		private System.Windows.Forms.NumericUpDown DeadbandCTRL;
		private System.Windows.Forms.CheckBox KeepAliveSpecifiedCB;
		private System.Windows.Forms.CheckBox DeadbandSpecifiedCB;
		private System.Windows.Forms.Label LocaleLB;
		private OpcClientSdk.Controls.LocaleCtrl LocaleCTRL;
		private System.Windows.Forms.CheckBox LocaleSpecifiedCB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SubscriptionEditCtrl()
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
			this.UpdateRateLB = new System.Windows.Forms.Label();
			this.KeepAliveRateLB = new System.Windows.Forms.Label();
			this.DeadbandLB = new System.Windows.Forms.Label();
			this.NameTB = new System.Windows.Forms.TextBox();
			this.ActiveCB = new System.Windows.Forms.CheckBox();
			this.UpdateRateCTRL = new System.Windows.Forms.NumericUpDown();
			this.KeepAliveRateCTRL = new System.Windows.Forms.NumericUpDown();
			this.DeadbandCTRL = new System.Windows.Forms.NumericUpDown();
			this.KeepAliveSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.DeadbandSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.LocaleLB = new System.Windows.Forms.Label();
			this.LocaleCTRL = new OpcClientSdk.Controls.LocaleCtrl();
			this.LocaleSpecifiedCB = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.UpdateRateCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.KeepAliveRateCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DeadbandCTRL)).BeginInit();
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
			// UpdateRateLB
			// 
			this.UpdateRateLB.Location = new System.Drawing.Point(0, 48);
			this.UpdateRateLB.Name = "UpdateRateLB";
			this.UpdateRateLB.TabIndex = 4;
			this.UpdateRateLB.Text = "Update Rate";
			this.UpdateRateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// KeepAliveRateLB
			// 
			this.KeepAliveRateLB.Location = new System.Drawing.Point(0, 72);
			this.KeepAliveRateLB.Name = "KeepAliveRateLB";
			this.KeepAliveRateLB.TabIndex = 5;
			this.KeepAliveRateLB.Text = "Keep Alive Rate";
			this.KeepAliveRateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DeadbandLB
			// 
			this.DeadbandLB.Location = new System.Drawing.Point(0, 96);
			this.DeadbandLB.Name = "DeadbandLB";
			this.DeadbandLB.TabIndex = 6;
			this.DeadbandLB.Text = "Deadband";
			this.DeadbandLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			this.NameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.NameTB.Location = new System.Drawing.Point(104, 0);
			this.NameTB.Name = "NameTB";
			this.NameTB.Size = new System.Drawing.Size(128, 20);
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
			// UpdateRateCTRL
			// 
			this.UpdateRateCTRL.Increment = new System.Decimal(new int[] {
																			 100,
																			 0,
																			 0,
																			 0});
			this.UpdateRateCTRL.Location = new System.Drawing.Point(104, 48);
			this.UpdateRateCTRL.Maximum = new System.Decimal(new int[] {
																		   1000000000,
																		   0,
																		   0,
																		   0});
			this.UpdateRateCTRL.Name = "UpdateRateCTRL";
			this.UpdateRateCTRL.Size = new System.Drawing.Size(72, 20);
			this.UpdateRateCTRL.TabIndex = 11;
			// 
			// KeepAliveRateCTRL
			// 
			this.KeepAliveRateCTRL.Increment = new System.Decimal(new int[] {
																				100,
																				0,
																				0,
																				0});
			this.KeepAliveRateCTRL.Location = new System.Drawing.Point(104, 72);
			this.KeepAliveRateCTRL.Maximum = new System.Decimal(new int[] {
																			  1000000000,
																			  0,
																			  0,
																			  0});
			this.KeepAliveRateCTRL.Name = "KeepAliveRateCTRL";
			this.KeepAliveRateCTRL.Size = new System.Drawing.Size(72, 20);
			this.KeepAliveRateCTRL.TabIndex = 12;
			// 
			// DeadbandCTRL
			// 
			this.DeadbandCTRL.DecimalPlaces = 1;
			this.DeadbandCTRL.Location = new System.Drawing.Point(104, 96);
			this.DeadbandCTRL.Name = "DeadbandCTRL";
			this.DeadbandCTRL.Size = new System.Drawing.Size(72, 20);
			this.DeadbandCTRL.TabIndex = 14;
			// 
			// KeepAliveSpecifiedCB
			// 
			this.KeepAliveSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.KeepAliveSpecifiedCB.Checked = true;
			this.KeepAliveSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.KeepAliveSpecifiedCB.Location = new System.Drawing.Point(216, 72);
			this.KeepAliveSpecifiedCB.Name = "KeepAliveSpecifiedCB";
			this.KeepAliveSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.KeepAliveSpecifiedCB.TabIndex = 20;
			this.KeepAliveSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// DeadbandSpecifiedCB
			// 
			this.DeadbandSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeadbandSpecifiedCB.Checked = true;
			this.DeadbandSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DeadbandSpecifiedCB.Location = new System.Drawing.Point(216, 96);
			this.DeadbandSpecifiedCB.Name = "DeadbandSpecifiedCB";
			this.DeadbandSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.DeadbandSpecifiedCB.TabIndex = 21;
			this.DeadbandSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// LocaleLB
			// 
			this.LocaleLB.Location = new System.Drawing.Point(0, 120);
			this.LocaleLB.Name = "LocaleLB";
			this.LocaleLB.TabIndex = 22;
			this.LocaleLB.Text = "Locale";
			this.LocaleLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LocaleCTRL
			// 
			this.LocaleCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.LocaleCTRL.Enabled = false;
			this.LocaleCTRL.Locale = "";
			this.LocaleCTRL.Location = new System.Drawing.Point(104, 120);
			this.LocaleCTRL.Name = "LocaleCTRL";
			this.LocaleCTRL.Size = new System.Drawing.Size(104, 24);
			this.LocaleCTRL.TabIndex = 23;
			// 
			// LocaleSpecifiedCB
			// 
			this.LocaleSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LocaleSpecifiedCB.Checked = true;
			this.LocaleSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.LocaleSpecifiedCB.Location = new System.Drawing.Point(216, 120);
			this.LocaleSpecifiedCB.Name = "LocaleSpecifiedCB";
			this.LocaleSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.LocaleSpecifiedCB.TabIndex = 24;
			this.LocaleSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// SubscriptionEditCtrl
			// 
			this.Controls.Add(this.LocaleSpecifiedCB);
			this.Controls.Add(this.LocaleCTRL);
			this.Controls.Add(this.LocaleLB);
			this.Controls.Add(this.DeadbandSpecifiedCB);
			this.Controls.Add(this.KeepAliveSpecifiedCB);
			this.Controls.Add(this.DeadbandCTRL);
			this.Controls.Add(this.KeepAliveRateCTRL);
			this.Controls.Add(this.UpdateRateCTRL);
			this.Controls.Add(this.ActiveCB);
			this.Controls.Add(this.NameTB);
			this.Controls.Add(this.KeepAliveRateLB);
			this.Controls.Add(this.ActiveLB);
			this.Controls.Add(this.NameLB);
			this.Controls.Add(this.UpdateRateLB);
			this.Controls.Add(this.DeadbandLB);
			this.Name = "SubscriptionEditCtrl";
			this.Size = new System.Drawing.Size(232, 144);
			((System.ComponentModel.ISupportInitialize)(this.UpdateRateCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.KeepAliveRateCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DeadbandCTRL)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// A handle assigned by the client to a subscription.
		/// </summary>
		private object m_clientHandle = null;

		/// <summary>
		/// A handle assigned by the server to a subscription.
		/// </summary>
		private object m_serverHandle = null;

		/// <summary>
		/// The server object which contains the subscriptions being edited.
		/// </summary>
		public TsCDaServer Server {set{ m_server = value; }}
		/// <remarks/>
		private TsCDaServer m_server = null;

		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			NameTB.Text                  = null;
			ActiveCB.Checked             = true;
			UpdateRateCTRL.Value         = 1000;
			KeepAliveRateCTRL.Value      = 0;
			KeepAliveSpecifiedCB.Checked = false;
			DeadbandCTRL.Value           = 0;
			DeadbandSpecifiedCB.Checked  = false;
			LocaleCTRL.Locale            = "";
			LocaleSpecifiedCB.Checked    = false;

			if (m_server != null)
			{
				LocaleCTRL.Locale = m_server.Locale;
				LocaleSpecifiedCB.Checked = m_server.Locale != null;
				LocaleCTRL.SetSupportedLocales(m_server.SupportedLocales);
			}
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			TsCDaSubscriptionState state = new TsCDaSubscriptionState();

			state.ClientHandle        = m_clientHandle;
			state.ServerHandle        = m_serverHandle;
			state.Name                = NameTB.Text;
			state.Active              = ActiveCB.Checked;
			state.UpdateRate          = (int)UpdateRateCTRL.Value;
			state.KeepAlive           = (int)KeepAliveRateCTRL.Value;
			state.Deadband            = (float)DeadbandCTRL.Value;
			state.Locale              = (LocaleSpecifiedCB.Checked)?LocaleCTRL.Locale:null;

			return state;
		}
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		public void Set(object value)
		{
			// check for null value.
			if (value == null) { SetDefaults(); return; }

			TsCDaSubscriptionState state = (TsCDaSubscriptionState)value;

			// save subscription handles.
			m_clientHandle = state.ClientHandle;
			m_serverHandle = state.ClientHandle;
			
			NameTB.Text                     = state.Name;
			ActiveCB.Checked                = state.Active;
			UpdateRateCTRL.Value            = (decimal)state.UpdateRate;
			KeepAliveRateCTRL.Value         = (decimal)state.KeepAlive;
			KeepAliveSpecifiedCB.Checked    = state.KeepAlive != 0;
			DeadbandCTRL.Value              = (decimal)state.Deadband;
			DeadbandSpecifiedCB.Checked     = state.Deadband != 0;
			LocaleCTRL.Locale               = state.Locale;
			LocaleSpecifiedCB.Checked       = state.Locale != null;

			if (m_server != null)
			{
				LocaleCTRL.SetSupportedLocales(m_server.SupportedLocales);
			}
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			TsCDaSubscriptionState state = new TsCDaSubscriptionState();
			state.UpdateRate = 1000;
			return state;
		}

		/// <summary>
		/// Toggles the enabled state of controls based on the specified check boxes.
		/// </summary>
		private void Specified_CheckedChanged(object sender, System.EventArgs e)
		{			
			KeepAliveRateCTRL.Enabled = KeepAliveSpecifiedCB.Checked;
			DeadbandCTRL.Enabled      = DeadbandSpecifiedCB.Checked;
			LocaleCTRL.Enabled        = LocaleSpecifiedCB.Checked;
		}
	}
}
