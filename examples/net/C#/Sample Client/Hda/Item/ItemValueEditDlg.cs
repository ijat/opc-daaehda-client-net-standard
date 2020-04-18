//============================================================================
// TITLE: ItemEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to modify the parameters of an item.
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
// 2003/12/31 RSA   Initial implementation.
// 2004/11/23 RSA   Removed historial quality from dialog.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Data;

using OpcClientSdk;
using OpcClientSdk.Da;
using OpcClientSdk.Hda.Test;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class ItemValueEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.Label ValueLB;
		private System.Windows.Forms.Label QualityLB;
		private System.Windows.Forms.Label LimitBitsLB;
		private System.Windows.Forms.Label VendorBitsLB;
		private System.Windows.Forms.NumericUpDown ValueCTRL;
		private System.Windows.Forms.NumericUpDown VendorBitsCTRL;
		private System.Windows.Forms.ComboBox LimitBitsCB;
		private System.Windows.Forms.ComboBox QualityCB;
		private System.Windows.Forms.Label TimestampLB;
		private System.Windows.Forms.DateTimePicker TimestampCTRL;
		private System.Windows.Forms.CheckBox ValueSpecifiedCB;
		private System.ComponentModel.IContainer components = null;

		public ItemValueEditDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			// populate quality drop down.
			QualityCB.Items.Clear();

			foreach (TsDaQualityBits quality in Enum.GetValues(typeof(TsDaQualityBits)))
			{
				QualityCB.Items.Add(quality);
			}

			// populate limit bits drop down.
			LimitBitsCB.Items.Clear();

			foreach (TsDaLimitBits limitBits in Enum.GetValues(typeof(TsDaLimitBits)))
			{
				LimitBitsCB.Items.Add(limitBits);
			}
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
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OkBTN = new System.Windows.Forms.Button();
			this.MainPN = new System.Windows.Forms.Panel();
			this.ValueSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.TimestampCTRL = new System.Windows.Forms.DateTimePicker();
			this.TimestampLB = new System.Windows.Forms.Label();
			this.QualityCB = new System.Windows.Forms.ComboBox();
			this.LimitBitsCB = new System.Windows.Forms.ComboBox();
			this.VendorBitsCTRL = new System.Windows.Forms.NumericUpDown();
			this.VendorBitsLB = new System.Windows.Forms.Label();
			this.LimitBitsLB = new System.Windows.Forms.Label();
			this.QualityLB = new System.Windows.Forms.Label();
			this.ValueLB = new System.Windows.Forms.Label();
			this.ValueCTRL = new System.Windows.Forms.NumericUpDown();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.VendorBitsCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueCTRL)).BeginInit();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(192, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 122);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(272, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// OkBTN
			// 
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(4, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.ValueSpecifiedCB);
			this.MainPN.Controls.Add(this.TimestampCTRL);
			this.MainPN.Controls.Add(this.TimestampLB);
			this.MainPN.Controls.Add(this.QualityCB);
			this.MainPN.Controls.Add(this.LimitBitsCB);
			this.MainPN.Controls.Add(this.VendorBitsCTRL);
			this.MainPN.Controls.Add(this.VendorBitsLB);
			this.MainPN.Controls.Add(this.LimitBitsLB);
			this.MainPN.Controls.Add(this.QualityLB);
			this.MainPN.Controls.Add(this.ValueLB);
			this.MainPN.Controls.Add(this.ValueCTRL);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Left = 4;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(272, 122);
			this.MainPN.TabIndex = 1;
			// 
			// ValueSpecifiedCB
			// 
			this.ValueSpecifiedCB.Location = new System.Drawing.Point(252, 3);
			this.ValueSpecifiedCB.Name = "ValueSpecifiedCB";
			this.ValueSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.ValueSpecifiedCB.TabIndex = 2;
			this.ValueSpecifiedCB.CheckedChanged += new System.EventHandler(this.ValueSpecifiedCB_CheckedChanged);
			// 
			// TimestampCTRL
			// 
			this.TimestampCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TimestampCTRL.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.TimestampCTRL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TimestampCTRL.Location = new System.Drawing.Point(96, 28);
			this.TimestampCTRL.Name = "TimestampCTRL";
			this.TimestampCTRL.Size = new System.Drawing.Size(148, 20);
			this.TimestampCTRL.TabIndex = 4;
			// 
			// TimestampLB
			// 
			this.TimestampLB.Location = new System.Drawing.Point(4, 28);
			this.TimestampLB.Name = "TimestampLB";
			this.TimestampLB.Size = new System.Drawing.Size(92, 23);
			this.TimestampLB.TabIndex = 3;
			this.TimestampLB.Text = "Timestamp";
			this.TimestampLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityCB
			// 
			this.QualityCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.QualityCB.Location = new System.Drawing.Point(96, 52);
			this.QualityCB.Name = "QualityCB";
			this.QualityCB.Size = new System.Drawing.Size(172, 21);
			this.QualityCB.TabIndex = 6;
			// 
			// LimitBitsCB
			// 
			this.LimitBitsCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.LimitBitsCB.Location = new System.Drawing.Point(96, 76);
			this.LimitBitsCB.Name = "LimitBitsCB";
			this.LimitBitsCB.Size = new System.Drawing.Size(172, 21);
			this.LimitBitsCB.TabIndex = 8;
			// 
			// VendorBitsCTRL
			// 
			this.VendorBitsCTRL.Location = new System.Drawing.Point(96, 100);
			this.VendorBitsCTRL.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.VendorBitsCTRL.Name = "VendorBitsCTRL";
			this.VendorBitsCTRL.Size = new System.Drawing.Size(60, 20);
			this.VendorBitsCTRL.TabIndex = 10;
			// 
			// VendorBitsLB
			// 
			this.VendorBitsLB.Location = new System.Drawing.Point(4, 100);
			this.VendorBitsLB.Name = "VendorBitsLB";
			this.VendorBitsLB.Size = new System.Drawing.Size(92, 23);
			this.VendorBitsLB.TabIndex = 9;
			this.VendorBitsLB.Text = "Vendor Bits";
			this.VendorBitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LimitBitsLB
			// 
			this.LimitBitsLB.Location = new System.Drawing.Point(4, 76);
			this.LimitBitsLB.Name = "LimitBitsLB";
			this.LimitBitsLB.Size = new System.Drawing.Size(92, 23);
			this.LimitBitsLB.TabIndex = 7;
			this.LimitBitsLB.Text = "Limit Bits";
			this.LimitBitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QualityLB
			// 
			this.QualityLB.Location = new System.Drawing.Point(4, 52);
			this.QualityLB.Name = "QualityLB";
			this.QualityLB.Size = new System.Drawing.Size(92, 23);
			this.QualityLB.TabIndex = 5;
			this.QualityLB.Text = "Quality";
			this.QualityLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			this.ValueLB.Location = new System.Drawing.Point(4, 4);
			this.ValueLB.Name = "ValueLB";
			this.ValueLB.Size = new System.Drawing.Size(92, 23);
			this.ValueLB.TabIndex = 0;
			this.ValueLB.Text = "Value";
			this.ValueLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueCTRL
			// 
			this.ValueCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ValueCTRL.DecimalPlaces = 15;
			this.ValueCTRL.Enabled = false;
			this.ValueCTRL.Location = new System.Drawing.Point(96, 4);
			this.ValueCTRL.Name = "ValueCTRL";
			this.ValueCTRL.Size = new System.Drawing.Size(152, 20);
			this.ValueCTRL.TabIndex = 1;
			// 
			// ItemValueEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 158);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "ItemValueEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Item Value";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.VendorBitsCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueCTRL)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to edit an item value.
		/// </summary>
		public TsCHdaItemValue ShowDialog(TsCHdaItemValue item)
		{
			// create a new item if none provided.
			if (item == null) 
			{				
				item = new TsCHdaItemValue();
			}

			// initialize controls.
			ValueCTRL.Value          = System.Convert.ToDecimal(item.Value);
			ValueSpecifiedCB.Checked = item.Value != null;
			QualityCB.SelectedItem   = item.Quality.QualityBits;
			LimitBitsCB.SelectedItem = item.Quality.LimitBits;
			VendorBitsCTRL.Value     = item.Quality.VendorBits;

			if (TimestampCTRL.MinDate > item.Timestamp)
			{
				TimestampCTRL.Value = TimestampCTRL.MinDate;
			}
			else
			{
				TimestampCTRL.Value = item.Timestamp;
			}

			// display dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// update object.
			item = new TsCHdaItemValue();

			if (ValueSpecifiedCB.Checked)
			{
				item.Value = (double)ValueCTRL.Value;
			}

			Da.TsCDaQuality quality = new Da.TsCDaQuality();

			quality.QualityBits = (TsDaQualityBits)QualityCB.SelectedItem;
			quality.LimitBits   = (TsDaLimitBits)LimitBitsCB.SelectedItem;
			quality.VendorBits  = (byte)VendorBitsCTRL.Value;

			item.Quality = quality;
			
			if (TimestampCTRL.Value == TimestampCTRL.MinDate)
			{
				item.Timestamp = DateTime.MinValue;
			}
			else
			{
				item.Timestamp = TimestampCTRL.Value;
			}

			// return new value.
			return item;
		}
		#endregion

		/// <summary>
		/// Toggles the enabled state of the value control.
		/// </summary>
		private void ValueSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			 ValueCTRL.Enabled = ValueSpecifiedCB.Checked;
		}
	}
}
