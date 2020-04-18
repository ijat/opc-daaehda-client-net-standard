//============================================================================
// TITLE: ItemEditCtrl.cs
//
// CONTENTS:
// 
// A control used to display and edit the contents of an Item object.
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
	/// A control used to display and edit the contents of an Item object.
	/// </summary>
	public class ItemEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label ActiveLB;
		private System.Windows.Forms.Label ReqTypeLB;
		private System.Windows.Forms.Label DeadbandLB;
		private System.Windows.Forms.Label EnableBufferingLB;
		private System.Windows.Forms.CheckBox ActiveCB;
		private System.Windows.Forms.NumericUpDown DeadbandCTRL;
		private System.Windows.Forms.CheckBox EnableBufferingCB;
		private System.Windows.Forms.CheckBox EnableBufferSpecifiedCB;
		private OpcClientSdk.Controls.DataTypeCtrl ReqTypeCTRL;
		private System.Windows.Forms.Label ItemNameLB;
		private System.Windows.Forms.TextBox ItemNameTB;
		private System.Windows.Forms.TextBox ItemPathTB;
		private System.Windows.Forms.Label ItemPathLB;
		private System.Windows.Forms.Label SamplingRateLB;
		private System.Windows.Forms.NumericUpDown SamplingRateCTRL;
		private System.Windows.Forms.NumericUpDown MaxAgeCTRL;
		private System.Windows.Forms.Label MaxAgeLB;
		private System.Windows.Forms.CheckBox DeadbandSpecifiedCB;
		private System.Windows.Forms.CheckBox ActiveSpecifiedCB;
		private System.Windows.Forms.CheckBox SamplingRateSpecifiedCB;
		private System.Windows.Forms.CheckBox MaxAgeSpecifiedCB;
		private System.Windows.Forms.CheckBox ReqTypeSpecifiedCB;
		private System.Windows.Forms.Panel ReadPN;
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Panel SubscribePN;
		private System.Windows.Forms.Label TypeConversionLB;
		private System.Windows.Forms.ComboBox TypeConversionCB;
		private System.Windows.Forms.Label DataFilterLN;
		private System.Windows.Forms.TextBox DataFilterTB;
		private System.Windows.Forms.Panel ComplexItemPN;
		private System.Windows.Forms.CheckBox DataFilterSpecifiedCB;
		private System.Windows.Forms.CheckBox TypeConversionSpecifiedCB;
		private System.Windows.Forms.Panel ReqTypePN;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemEditCtrl()
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
			this.ItemNameLB = new System.Windows.Forms.Label();
			this.ActiveLB = new System.Windows.Forms.Label();
			this.ReqTypeLB = new System.Windows.Forms.Label();
			this.SamplingRateLB = new System.Windows.Forms.Label();
			this.DeadbandLB = new System.Windows.Forms.Label();
			this.EnableBufferingLB = new System.Windows.Forms.Label();
			this.ItemNameTB = new System.Windows.Forms.TextBox();
			this.ActiveCB = new System.Windows.Forms.CheckBox();
			this.SamplingRateCTRL = new System.Windows.Forms.NumericUpDown();
			this.DeadbandCTRL = new System.Windows.Forms.NumericUpDown();
			this.EnableBufferingCB = new System.Windows.Forms.CheckBox();
			this.DeadbandSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.ActiveSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.SamplingRateSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.EnableBufferSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.ReqTypeCTRL = new OpcClientSdk.Controls.DataTypeCtrl();
			this.ItemPathTB = new System.Windows.Forms.TextBox();
			this.ItemPathLB = new System.Windows.Forms.Label();
			this.MaxAgeSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.MaxAgeCTRL = new System.Windows.Forms.NumericUpDown();
			this.MaxAgeLB = new System.Windows.Forms.Label();
			this.ReqTypeSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.SubscribePN = new System.Windows.Forms.Panel();
			this.ReadPN = new System.Windows.Forms.Panel();
			this.TopPN = new System.Windows.Forms.Panel();
			this.TypeConversionLB = new System.Windows.Forms.Label();
			this.TypeConversionCB = new System.Windows.Forms.ComboBox();
			this.DataFilterLN = new System.Windows.Forms.Label();
			this.DataFilterTB = new System.Windows.Forms.TextBox();
			this.ComplexItemPN = new System.Windows.Forms.Panel();
			this.DataFilterSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.TypeConversionSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.ReqTypePN = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.SamplingRateCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DeadbandCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxAgeCTRL)).BeginInit();
			this.SubscribePN.SuspendLayout();
			this.ReadPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.ComplexItemPN.SuspendLayout();
			this.ReqTypePN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ItemNameLB
			// 
			this.ItemNameLB.Location = new System.Drawing.Point(0, 0);
			this.ItemNameLB.Name = "ItemNameLB";
			this.ItemNameLB.TabIndex = 0;
			this.ItemNameLB.Text = "Item Name";
			this.ItemNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ActiveLB
			// 
			this.ActiveLB.Location = new System.Drawing.Point(0, 0);
			this.ActiveLB.Name = "ActiveLB";
			this.ActiveLB.TabIndex = 1;
			this.ActiveLB.Text = "Active";
			this.ActiveLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReqTypeLB
			// 
			this.ReqTypeLB.Location = new System.Drawing.Point(0, 0);
			this.ReqTypeLB.Name = "ReqTypeLB";
			this.ReqTypeLB.TabIndex = 3;
			this.ReqTypeLB.Text = "Requested Type";
			this.ReqTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SamplingRateLB
			// 
			this.SamplingRateLB.Location = new System.Drawing.Point(0, 48);
			this.SamplingRateLB.Name = "SamplingRateLB";
			this.SamplingRateLB.TabIndex = 5;
			this.SamplingRateLB.Text = "Sampling Rate";
			this.SamplingRateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DeadbandLB
			// 
			this.DeadbandLB.Location = new System.Drawing.Point(0, 24);
			this.DeadbandLB.Name = "DeadbandLB";
			this.DeadbandLB.TabIndex = 6;
			this.DeadbandLB.Text = "Deadband";
			this.DeadbandLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EnableBufferingLB
			// 
			this.EnableBufferingLB.Location = new System.Drawing.Point(0, 72);
			this.EnableBufferingLB.Name = "EnableBufferingLB";
			this.EnableBufferingLB.TabIndex = 7;
			this.EnableBufferingLB.Text = "Enable Buffering";
			this.EnableBufferingLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.ItemNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ItemNameTB.Location = new System.Drawing.Point(104, 0);
			this.ItemNameTB.Name = "ItemNameTB";
			this.ItemNameTB.ReadOnly = true;
			this.ItemNameTB.Size = new System.Drawing.Size(280, 20);
			this.ItemNameTB.TabIndex = 8;
			this.ItemNameTB.Text = "";
			// 
			// ActiveCB
			// 
			this.ActiveCB.Location = new System.Drawing.Point(104, 0);
			this.ActiveCB.Name = "ActiveCB";
			this.ActiveCB.Size = new System.Drawing.Size(16, 24);
			this.ActiveCB.TabIndex = 9;
			// 
			// SamplingRateCTRL
			// 
			this.SamplingRateCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.SamplingRateCTRL.Increment = new System.Decimal(new int[] {
																			   100,
																			   0,
																			   0,
																			   0});
			this.SamplingRateCTRL.Location = new System.Drawing.Point(104, 50);
			this.SamplingRateCTRL.Maximum = new System.Decimal(new int[] {
																			 1000000000,
																			 0,
																			 0,
																			 0});
			this.SamplingRateCTRL.Name = "SamplingRateCTRL";
			this.SamplingRateCTRL.Size = new System.Drawing.Size(168, 20);
			this.SamplingRateCTRL.TabIndex = 12;
			// 
			// DeadbandCTRL
			// 
			this.DeadbandCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.DeadbandCTRL.DecimalPlaces = 1;
			this.DeadbandCTRL.Location = new System.Drawing.Point(104, 26);
			this.DeadbandCTRL.Name = "DeadbandCTRL";
			this.DeadbandCTRL.Size = new System.Drawing.Size(168, 20);
			this.DeadbandCTRL.TabIndex = 14;
			// 
			// EnableBufferingCB
			// 
			this.EnableBufferingCB.Location = new System.Drawing.Point(104, 72);
			this.EnableBufferingCB.Name = "EnableBufferingCB";
			this.EnableBufferingCB.Size = new System.Drawing.Size(16, 24);
			this.EnableBufferingCB.TabIndex = 15;
			// 
			// DeadbandSpecifiedCB
			// 
			this.DeadbandSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeadbandSpecifiedCB.Checked = true;
			this.DeadbandSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DeadbandSpecifiedCB.Location = new System.Drawing.Point(368, 24);
			this.DeadbandSpecifiedCB.Name = "DeadbandSpecifiedCB";
			this.DeadbandSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.DeadbandSpecifiedCB.TabIndex = 18;
			this.DeadbandSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// ActiveSpecifiedCB
			// 
			this.ActiveSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ActiveSpecifiedCB.Checked = true;
			this.ActiveSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ActiveSpecifiedCB.Location = new System.Drawing.Point(368, 0);
			this.ActiveSpecifiedCB.Name = "ActiveSpecifiedCB";
			this.ActiveSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.ActiveSpecifiedCB.TabIndex = 20;
			this.ActiveSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// SamplingRateSpecifiedCB
			// 
			this.SamplingRateSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SamplingRateSpecifiedCB.Checked = true;
			this.SamplingRateSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SamplingRateSpecifiedCB.Location = new System.Drawing.Point(368, 48);
			this.SamplingRateSpecifiedCB.Name = "SamplingRateSpecifiedCB";
			this.SamplingRateSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.SamplingRateSpecifiedCB.TabIndex = 21;
			this.SamplingRateSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// EnableBufferSpecifiedCB
			// 
			this.EnableBufferSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.EnableBufferSpecifiedCB.Checked = true;
			this.EnableBufferSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.EnableBufferSpecifiedCB.Location = new System.Drawing.Point(368, 72);
			this.EnableBufferSpecifiedCB.Name = "EnableBufferSpecifiedCB";
			this.EnableBufferSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.EnableBufferSpecifiedCB.TabIndex = 22;
			this.EnableBufferSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// ReqTypeCTRL
			// 
			this.ReqTypeCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ReqTypeCTRL.Location = new System.Drawing.Point(104, 0);
			this.ReqTypeCTRL.Name = "ReqTypeCTRL";
			this.ReqTypeCTRL.SelectedType = null;
			this.ReqTypeCTRL.Size = new System.Drawing.Size(208, 24);
			this.ReqTypeCTRL.TabIndex = 23;
			// 
			// ItemPathTB
			// 
			this.ItemPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ItemPathTB.Location = new System.Drawing.Point(104, 24);
			this.ItemPathTB.Name = "ItemPathTB";
			this.ItemPathTB.ReadOnly = true;
			this.ItemPathTB.Size = new System.Drawing.Size(280, 20);
			this.ItemPathTB.TabIndex = 27;
			this.ItemPathTB.Text = "";
			// 
			// ItemPathLB
			// 
			this.ItemPathLB.Location = new System.Drawing.Point(0, 24);
			this.ItemPathLB.Name = "ItemPathLB";
			this.ItemPathLB.TabIndex = 26;
			this.ItemPathLB.Text = "Item Path";
			this.ItemPathLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxAgeSpecifiedCB
			// 
			this.MaxAgeSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MaxAgeSpecifiedCB.Checked = true;
			this.MaxAgeSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MaxAgeSpecifiedCB.Location = new System.Drawing.Point(368, 0);
			this.MaxAgeSpecifiedCB.Name = "MaxAgeSpecifiedCB";
			this.MaxAgeSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.MaxAgeSpecifiedCB.TabIndex = 30;
			this.MaxAgeSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// MaxAgeCTRL
			// 
			this.MaxAgeCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.MaxAgeCTRL.DecimalPlaces = 3;
			this.MaxAgeCTRL.Location = new System.Drawing.Point(104, 2);
			this.MaxAgeCTRL.Maximum = new System.Decimal(new int[] {
																	   1000000000,
																	   0,
																	   0,
																	   0});
			this.MaxAgeCTRL.Name = "MaxAgeCTRL";
			this.MaxAgeCTRL.Size = new System.Drawing.Size(168, 20);
			this.MaxAgeCTRL.TabIndex = 29;
			// 
			// MaxAgeLB
			// 
			this.MaxAgeLB.Location = new System.Drawing.Point(0, 0);
			this.MaxAgeLB.Name = "MaxAgeLB";
			this.MaxAgeLB.TabIndex = 28;
			this.MaxAgeLB.Text = "Maximum Age";
			this.MaxAgeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReqTypeSpecifiedCB
			// 
			this.ReqTypeSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ReqTypeSpecifiedCB.Checked = true;
			this.ReqTypeSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ReqTypeSpecifiedCB.Location = new System.Drawing.Point(368, 0);
			this.ReqTypeSpecifiedCB.Name = "ReqTypeSpecifiedCB";
			this.ReqTypeSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.ReqTypeSpecifiedCB.TabIndex = 31;
			this.ReqTypeSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// SubscribePN
			// 
			this.SubscribePN.Controls.Add(this.ActiveLB);
			this.SubscribePN.Controls.Add(this.DeadbandCTRL);
			this.SubscribePN.Controls.Add(this.ActiveCB);
			this.SubscribePN.Controls.Add(this.SamplingRateLB);
			this.SubscribePN.Controls.Add(this.EnableBufferSpecifiedCB);
			this.SubscribePN.Controls.Add(this.DeadbandSpecifiedCB);
			this.SubscribePN.Controls.Add(this.SamplingRateCTRL);
			this.SubscribePN.Controls.Add(this.ActiveSpecifiedCB);
			this.SubscribePN.Controls.Add(this.EnableBufferingLB);
			this.SubscribePN.Controls.Add(this.SamplingRateSpecifiedCB);
			this.SubscribePN.Controls.Add(this.DeadbandLB);
			this.SubscribePN.Controls.Add(this.EnableBufferingCB);
			this.SubscribePN.Dock = System.Windows.Forms.DockStyle.Top;
			this.SubscribePN.Location = new System.Drawing.Point(0, 144);
			this.SubscribePN.Name = "SubscribePN";
			this.SubscribePN.Size = new System.Drawing.Size(384, 96);
			this.SubscribePN.TabIndex = 32;
			this.SubscribePN.Visible = false;
			// 
			// ReadPN
			// 
			this.ReadPN.Controls.Add(this.MaxAgeSpecifiedCB);
			this.ReadPN.Controls.Add(this.MaxAgeLB);
			this.ReadPN.Controls.Add(this.MaxAgeCTRL);
			this.ReadPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.ReadPN.Location = new System.Drawing.Point(0, 120);
			this.ReadPN.Name = "ReadPN";
			this.ReadPN.Size = new System.Drawing.Size(384, 24);
			this.ReadPN.TabIndex = 33;
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.ItemNameLB);
			this.TopPN.Controls.Add(this.ItemPathLB);
			this.TopPN.Controls.Add(this.ItemPathTB);
			this.TopPN.Controls.Add(this.ItemNameTB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(384, 48);
			this.TopPN.TabIndex = 34;
			// 
			// TypeConversionLB
			// 
			this.TypeConversionLB.Location = new System.Drawing.Point(0, 0);
			this.TypeConversionLB.Name = "TypeConversionLB";
			this.TypeConversionLB.TabIndex = 4;
			this.TypeConversionLB.Text = "Type Conversion";
			this.TypeConversionLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TypeConversionCB
			// 
			this.TypeConversionCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TypeConversionCB.Location = new System.Drawing.Point(104, 0);
			this.TypeConversionCB.Name = "TypeConversionCB";
			this.TypeConversionCB.Size = new System.Drawing.Size(208, 21);
			this.TypeConversionCB.TabIndex = 5;
			this.TypeConversionCB.SelectedIndexChanged += new System.EventHandler(this.TypeConversionCB_SelectedIndexChanged);
			// 
			// DataFilterLN
			// 
			this.DataFilterLN.Location = new System.Drawing.Point(0, 24);
			this.DataFilterLN.Name = "DataFilterLN";
			this.DataFilterLN.TabIndex = 6;
			this.DataFilterLN.Text = "Data Filter";
			this.DataFilterLN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataFilterTB
			// 
			this.DataFilterTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.DataFilterTB.Location = new System.Drawing.Point(104, 24);
			this.DataFilterTB.Name = "DataFilterTB";
			this.DataFilterTB.Size = new System.Drawing.Size(256, 20);
			this.DataFilterTB.TabIndex = 36;
			this.DataFilterTB.Text = "";
			// 
			// ComplexItemPN
			// 
			this.ComplexItemPN.Controls.Add(this.DataFilterLN);
			this.ComplexItemPN.Controls.Add(this.TypeConversionLB);
			this.ComplexItemPN.Controls.Add(this.DataFilterTB);
			this.ComplexItemPN.Controls.Add(this.TypeConversionCB);
			this.ComplexItemPN.Controls.Add(this.DataFilterSpecifiedCB);
			this.ComplexItemPN.Controls.Add(this.TypeConversionSpecifiedCB);
			this.ComplexItemPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.ComplexItemPN.Location = new System.Drawing.Point(0, 72);
			this.ComplexItemPN.Name = "ComplexItemPN";
			this.ComplexItemPN.Size = new System.Drawing.Size(384, 48);
			this.ComplexItemPN.TabIndex = 37;
			// 
			// DataFilterSpecifiedCB
			// 
			this.DataFilterSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DataFilterSpecifiedCB.Checked = true;
			this.DataFilterSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DataFilterSpecifiedCB.Location = new System.Drawing.Point(368, 24);
			this.DataFilterSpecifiedCB.Name = "DataFilterSpecifiedCB";
			this.DataFilterSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.DataFilterSpecifiedCB.TabIndex = 37;
			this.DataFilterSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// TypeConversionSpecifiedCB
			// 
			this.TypeConversionSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TypeConversionSpecifiedCB.Checked = true;
			this.TypeConversionSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.TypeConversionSpecifiedCB.Location = new System.Drawing.Point(368, 0);
			this.TypeConversionSpecifiedCB.Name = "TypeConversionSpecifiedCB";
			this.TypeConversionSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.TypeConversionSpecifiedCB.TabIndex = 38;
			this.TypeConversionSpecifiedCB.CheckedChanged += new System.EventHandler(this.TypeConversionCB_SelectedIndexChanged);
			// 
			// ReqTypePN
			// 
			this.ReqTypePN.Controls.Add(this.ReqTypeLB);
			this.ReqTypePN.Controls.Add(this.ReqTypeSpecifiedCB);
			this.ReqTypePN.Controls.Add(this.ReqTypeCTRL);
			this.ReqTypePN.Dock = System.Windows.Forms.DockStyle.Top;
			this.ReqTypePN.Location = new System.Drawing.Point(0, 48);
			this.ReqTypePN.Name = "ReqTypePN";
			this.ReqTypePN.Size = new System.Drawing.Size(384, 24);
			this.ReqTypePN.TabIndex = 38;
			// 
			// ItemEditCtrl
			// 
			this.Controls.Add(this.SubscribePN);
			this.Controls.Add(this.ReadPN);
			this.Controls.Add(this.ComplexItemPN);
			this.Controls.Add(this.ReqTypePN);
			this.Controls.Add(this.TopPN);
			this.Name = "ItemEditCtrl";
			this.Size = new System.Drawing.Size(384, 240);
			((System.ComponentModel.ISupportInitialize)(this.SamplingRateCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DeadbandCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxAgeCTRL)).EndInit();
			this.SubscribePN.ResumeLayout(false);
			this.ReadPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			this.ComplexItemPN.ResumeLayout(false);
			this.ReqTypePN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The item identifier passed to the control.
		/// </summary>
		private OpcItem m_identifier = null;

		/// <summary>
		/// Whether changes to the item name and item path are allowed.
		/// </summary>
		public bool AllowEditItemID 
		{
			get	{return !ItemNameTB.ReadOnly;}
 
			set
			{
				ItemNameTB.ReadOnly = !value;
				ItemPathTB.ReadOnly = !value;
			}
		}

		/// <summary>
		/// Whether the control is editing a 'read' item or a 'subscribe' item.
		/// </summary>
		public bool IsReadItem
		{
			get	{return ReadPN.Visible;}
 
			set
			{
				ReadPN.Visible      = value;
				SubscribePN.Visible = !value;
			}
		}

		//======================================================================
		// IEditObjectCtrl

		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			ItemNameTB.Text                   = null;
			ItemPathTB.Text                   = null;
			ReqTypeCTRL.SelectedType          = null;
			ReqTypeSpecifiedCB.Checked        = false;
			MaxAgeCTRL.Value                  = 0;
			MaxAgeSpecifiedCB.Checked         = false;
			ActiveCB.Checked                  = false;
			ActiveSpecifiedCB.Checked         = false;
			DeadbandCTRL.Value                = 0;
			DeadbandSpecifiedCB.Checked       = false;
			SamplingRateCTRL.Value            = 0;
			SamplingRateSpecifiedCB.Checked   = false;
			EnableBufferingCB.Checked         = false;
			EnableBufferSpecifiedCB.Checked   = false;
			TypeConversionCB.Text             = null;
			TypeConversionSpecifiedCB.Checked = false;
			DataFilterTB.Text                 = null;
			DataFilterSpecifiedCB.Checked     = false;
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			TsCDaItem item = new TsCDaItem(m_identifier);

			item.ItemName                 = ItemNameTB.Text;
			item.ItemPath                 = ItemPathTB.Text;
			item.ReqType                  = (ReqTypeSpecifiedCB.Checked)?ReqTypeCTRL.SelectedType:null;
			item.MaxAge                   = (MaxAgeSpecifiedCB.Checked)?(int)MaxAgeCTRL.Value*1000:0;
			item.MaxAgeSpecified          = MaxAgeSpecifiedCB.Checked;
			item.Active                   = (ActiveSpecifiedCB.Checked)?ActiveCB.Checked:false;
			item.ActiveSpecified          = ActiveSpecifiedCB.Checked;
			item.Deadband                 = (DeadbandSpecifiedCB.Checked)?(float)DeadbandCTRL.Value:0;
			item.DeadbandSpecified        = DeadbandSpecifiedCB.Checked;
			item.SamplingRate             = (SamplingRateSpecifiedCB.Checked)?(int)SamplingRateCTRL.Value:0;
			item.SamplingRateSpecified    = SamplingRateSpecifiedCB.Checked;
			item.EnableBuffering          = (EnableBufferSpecifiedCB.Checked)?EnableBufferingCB.Checked:false;
			item.EnableBufferingSpecified = EnableBufferSpecifiedCB.Checked;

			// update the item id to reflect selections for complex data.
			try
			{
				GetComplexItem(item);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				item.ItemName = ItemNameTB.Text;
				item.ItemPath = ItemPathTB.Text;
			}

			return item;
		}
		
		/// <summary>
		/// Copy object values into controls.
		/// </summary>
		public void Set(object value)
		{
			// check for null value.
			if (value == null) { SetDefaults(); return; }

			// cast value to item object.
			TsCDaItem item = (TsCDaItem)value;

			// save item identifier (including client and server handles).
			m_identifier = new OpcItem(item);

			// update controls.
			ItemNameTB.Text                 = item.ItemName;
			ItemPathTB.Text                 = item.ItemPath;
			ReqTypeCTRL.SelectedType        = item.ReqType;
			ReqTypeSpecifiedCB.Checked      = item.ReqType != null;
			MaxAgeCTRL.Value                = (item.MaxAgeSpecified)?((decimal)item.MaxAge)/1000:0;
			MaxAgeSpecifiedCB.Checked       = item.MaxAgeSpecified;
			ActiveCB.Checked                = (item.ActiveSpecified)?item.Active:false;
			ActiveSpecifiedCB.Checked       = item.ActiveSpecified;
			DeadbandCTRL.Value              = (item.DeadbandSpecified)?(decimal)item.Deadband:0;
			DeadbandSpecifiedCB.Checked     = item.DeadbandSpecified;
			SamplingRateCTRL.Value          = (item.SamplingRateSpecified)?(decimal)item.SamplingRate:0;
			SamplingRateSpecifiedCB.Checked = item.SamplingRateSpecified;
			EnableBufferingCB.Checked       = (item.EnableBufferingSpecified)?item.EnableBuffering:false;
			EnableBufferSpecifiedCB.Checked = item.EnableBufferingSpecified;

			ReqTypePN.Visible     = true;
			ComplexItemPN.Visible = false;

			// initialize complex data controls.
			try
			{
				SetComplexItem(m_identifier);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				ReqTypePN.Visible     = true;
				ComplexItemPN.Visible = false;
			}
		}

		/// <summary>
		/// The active complex data item.
		/// </summary>
		private OpcClientSdk.Cpx.TsCCpxComplexItem m_item = null;

		/// <summary>
		/// Initializes the control with information specified to a complex item. 
		/// </summary>
		private void SetComplexItem(OpcItem itemID)
		{
			m_item = TsCCpxComplexTypeCache.GetComplexItem(itemID);

			// do nothing for items that are not complex.
			if (m_item == null)
			{
				ReqTypePN.Visible     = true;
				ComplexItemPN.Visible = false;
				return;
			}

			// display complex item controls.
			ReqTypePN.Visible     = false;
			ComplexItemPN.Visible = true;

			// initialize controls.
			TypeConversionCB.Items.Clear();
			TypeConversionCB.Text = null;
			TypeConversionSpecifiedCB.Checked = false;

			DataFilterTB.Text = null;
			DataFilterSpecifiedCB.Checked = false;

			// fetch the available type conversions.
			OpcClientSdk.Cpx.TsCCpxComplexItem[] conversions = m_item.GetRootItem().GetTypeConversions(TsCCpxComplexTypeCache.Server);

			// no conversions available.
			if (conversions == null || conversions.Length == 0)
			{
				TypeConversionSpecifiedCB.Enabled = false;
			}

			// populate conversions drop down menu.
			else
			{
				OpcClientSdk.Cpx.TsCCpxComplexItem item = m_item;

				if (item.UnfilteredItemID != null)
				{
					item = TsCCpxComplexTypeCache.GetComplexItem(item.UnfilteredItemID);
				}

				foreach (TsCCpxComplexItem conversion in conversions)
				{
					TypeConversionCB.Items.Add(conversion);

					if (conversion.Key == item.Key)
					{
						TypeConversionCB.SelectedItem = conversion;
						TypeConversionSpecifiedCB.Checked = true;
					}
				}

				if (TypeConversionCB.SelectedItem == null)
				{
					TypeConversionCB.SelectedIndex = 0;
				}
			}

			// display the active data filter.
			if (m_item.UnfilteredItemID != null)
			{
				DataFilterTB.Text = m_item.DataFilterValue;
				DataFilterSpecifiedCB.Checked = true;
			}
		}
		
		/// <summary>
		/// Updates the complex data properties affected by the item.
		/// </summary>
		private void GetComplexItem(OpcItem itemID)
		{
			if (m_item == null) { return; }

			TsCCpxComplexItem item = m_item;

			// clear any existing data filter.
			if (!DataFilterSpecifiedCB.Checked || !DataFilterSpecifiedCB.Enabled || DataFilterTB.Text == "")
			{
				if (m_item.UnfilteredItemID != null)
				{
					m_item.UpdateDataFilter(TsCCpxComplexTypeCache.Server, "");
					
					if (m_item.UnconvertedItemID != null)
					{
						item = TsCCpxComplexTypeCache.GetComplexItem(m_item.UnconvertedItemID);
					}
					else
					{
						item = TsCCpxComplexTypeCache.GetComplexItem(m_item.UnfilteredItemID);
					}
				}
			}

			// clear any existing type conversion.
			if (!TypeConversionSpecifiedCB.Checked || TypeConversionCB.SelectedItem == null)
			{
				// check if type conversion removed.
				if (m_item.UnconvertedItemID != null)
				{
					item = TsCCpxComplexTypeCache.GetComplexItem(m_item.UnconvertedItemID);
				}
			}
			else
			{
				// check if the type conversion changed.
				TsCCpxComplexItem conversion = (TsCCpxComplexItem)TypeConversionCB.SelectedItem;

				if (conversion.Key != item.Key)
				{				
					if (item.UnfilteredItemID == null || conversion.Key != item.UnfilteredItemID.Key)
					{
						item = conversion;
					}
				}
			}

			// apply the new filter value.
			if (DataFilterSpecifiedCB.Checked && DataFilterSpecifiedCB.Enabled && DataFilterTB.Text != "")
			{
				// update an existing data filter.
				if (item.UnfilteredItemID != null)
				{
					item.UpdateDataFilter(TsCCpxComplexTypeCache.Server, DataFilterTB.Text);
				}
				else
				{
					// get the existing data filters.
					TsCCpxComplexItem[] filters = item.GetDataFilters(TsCCpxComplexTypeCache.Server);

					// assign a unique filter name.
					int ii = 0;
					string filterName = null;
					
					do
					{
						filterName = String.Format("Filter{0:00}", ii++);

						foreach (TsCCpxComplexItem filter in filters)
						{
							if (filter.Name == filterName)
							{
								filterName = null;
								break;
							}
						}
					}
					while (filterName == null);

					// create the filter.
					item = item.CreateDataFilter(TsCCpxComplexTypeCache.Server, filterName, DataFilterTB.Text);
				}
			}

			// update the item id.
			if (item != null)
			{
				itemID.ItemPath = item.ItemPath;
				itemID.ItemName = item.ItemName;
			}
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			return new TsCDaItem();
		}

		/// <summary>
		/// Toggles the enabled state of controls based on the specified check boxes.
		/// </summary>
		private void Specified_CheckedChanged(object sender, System.EventArgs e)
		{			
			ReqTypeCTRL.Enabled       = ReqTypeSpecifiedCB.Checked;
			MaxAgeCTRL.Enabled        = MaxAgeSpecifiedCB.Checked;
			ActiveCB.Enabled          = ActiveSpecifiedCB.Checked;
			DeadbandCTRL.Enabled      = DeadbandSpecifiedCB.Checked;
			SamplingRateCTRL.Enabled  = SamplingRateSpecifiedCB.Checked;
			EnableBufferingCB.Enabled = EnableBufferSpecifiedCB.Checked;
			DataFilterTB.Enabled      = DataFilterSpecifiedCB.Checked;
		}

		/// <summary>
		/// Updates the data filter whenever the selected index changed.
		/// </summary>
		private void TypeConversionCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TypeConversionCB.Enabled = TypeConversionSpecifiedCB.Checked;

			TsCCpxComplexItem item = null;

			if (TypeConversionSpecifiedCB.Checked)
			{
				item = (TsCCpxComplexItem)TypeConversionCB.SelectedItem;
			}
			else
			{
				if (m_item != null)
				{
					item = m_item.GetRootItem();
				}
			}

			if (item != null)
			{
				DataFilterSpecifiedCB.Enabled = (item.DataFilterItem != null);
				DataFilterTB.Enabled          = DataFilterSpecifiedCB.Enabled && DataFilterSpecifiedCB.Checked;
			}
        }
	}
}
