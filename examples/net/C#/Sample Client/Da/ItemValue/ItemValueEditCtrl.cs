//============================================================================
// TITLE: ItemValueEditCtrl.cs
//
// CONTENTS:
// 
// A control used to display and edit the contents of an ItemValue object.
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
	/// A control used to display and edit the contents of an ItemValue object.
	/// </summary>
	public class ItemValueEditCtrl : System.Windows.Forms.UserControl, IEditObjectCtrl
	{
		private System.Windows.Forms.Label ItemNameLB;
		private System.Windows.Forms.TextBox ItemNameTB;
		private System.Windows.Forms.TextBox ItemPathTB;
		private System.Windows.Forms.Label ItemPathLB;
		private System.Windows.Forms.Label TimestampLB;
		private System.Windows.Forms.Label ValueLB;
		private System.Windows.Forms.CheckBox TimestampSpecifiedCB;
		private System.Windows.Forms.CheckBox QualitySpecifiedCB;
		private System.Windows.Forms.NumericUpDown VendorBitsCTRL;
		private System.Windows.Forms.Label QualityBitsLB;
		private System.Windows.Forms.CheckBox ValueSpecifiedCB;
		private OpcClientSdk.Controls.EnumCtrl QualityBitsCTRL;
		private OpcClientSdk.Controls.EnumCtrl LimitBitsCTRL;
		private System.Windows.Forms.Label LimitBitsLB;
		private System.Windows.Forms.Label VendorBitsLB;
		private OpcClientSdk.Controls.ValueCtrl ValueCTRL;
		private System.Windows.Forms.DateTimePicker TimestampCTRL;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ItemValueEditCtrl()
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
			this.TimestampLB = new System.Windows.Forms.Label();
			this.ValueLB = new System.Windows.Forms.Label();
			this.ItemNameTB = new System.Windows.Forms.TextBox();
			this.TimestampSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.ItemPathTB = new System.Windows.Forms.TextBox();
			this.ItemPathLB = new System.Windows.Forms.Label();
			this.QualitySpecifiedCB = new System.Windows.Forms.CheckBox();
			this.VendorBitsCTRL = new System.Windows.Forms.NumericUpDown();
			this.QualityBitsLB = new System.Windows.Forms.Label();
			this.ValueSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.QualityBitsCTRL = new OpcClientSdk.Controls.EnumCtrl();
			this.LimitBitsCTRL = new OpcClientSdk.Controls.EnumCtrl();
			this.LimitBitsLB = new System.Windows.Forms.Label();
			this.VendorBitsLB = new System.Windows.Forms.Label();
			this.ValueCTRL = new OpcClientSdk.Controls.ValueCtrl();
			this.TimestampCTRL = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.VendorBitsCTRL)).BeginInit();
			this.SuspendLayout();
			// 
			// ItemNameLB
			// 
			this.ItemNameLB.Name = "ItemNameLB";
			this.ItemNameLB.TabIndex = 0;
			this.ItemNameLB.Text = "Item Name";
			this.ItemNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TimestampLB
			// 
			this.TimestampLB.Location = new System.Drawing.Point(0, 144);
			this.TimestampLB.Name = "TimestampLB";
			this.TimestampLB.TabIndex = 1;
			this.TimestampLB.Text = "Timestamp";
			this.TimestampLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			this.ValueLB.Location = new System.Drawing.Point(0, 48);
			this.ValueLB.Name = "ValueLB";
			this.ValueLB.TabIndex = 3;
			this.ValueLB.Text = "Value";
			this.ValueLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.ItemNameTB.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.ItemNameTB.Location = new System.Drawing.Point(104, 0);
			this.ItemNameTB.Name = "ItemNameTB";
			this.ItemNameTB.ReadOnly = true;
			this.ItemNameTB.Size = new System.Drawing.Size(248, 20);
			this.ItemNameTB.TabIndex = 8;
			this.ItemNameTB.Text = "";
			// 
			// TimestampSpecifiedCB
			// 
			this.TimestampSpecifiedCB.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.TimestampSpecifiedCB.Checked = true;
			this.TimestampSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.TimestampSpecifiedCB.Location = new System.Drawing.Point(336, 143);
			this.TimestampSpecifiedCB.Name = "TimestampSpecifiedCB";
			this.TimestampSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.TimestampSpecifiedCB.TabIndex = 20;
			this.TimestampSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// ItemPathTB
			// 
			this.ItemPathTB.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.ItemPathTB.Location = new System.Drawing.Point(104, 24);
			this.ItemPathTB.Name = "ItemPathTB";
			this.ItemPathTB.ReadOnly = true;
			this.ItemPathTB.Size = new System.Drawing.Size(248, 20);
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
			// QualitySpecifiedCB
			// 
			this.QualitySpecifiedCB.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.QualitySpecifiedCB.Checked = true;
			this.QualitySpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.QualitySpecifiedCB.Location = new System.Drawing.Point(336, 71);
			this.QualitySpecifiedCB.Name = "QualitySpecifiedCB";
			this.QualitySpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.QualitySpecifiedCB.TabIndex = 30;
			this.QualitySpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// VendorBitsCTRL
			// 
			this.VendorBitsCTRL.Location = new System.Drawing.Point(104, 121);
			this.VendorBitsCTRL.Maximum = new System.Decimal(new int[] {
																		   255,
																		   0,
																		   0,
																		   0});
			this.VendorBitsCTRL.Name = "VendorBitsCTRL";
			this.VendorBitsCTRL.Size = new System.Drawing.Size(80, 20);
			this.VendorBitsCTRL.TabIndex = 29;
			// 
			// QualityBitsLB
			// 
			this.QualityBitsLB.Location = new System.Drawing.Point(0, 72);
			this.QualityBitsLB.Name = "QualityBitsLB";
			this.QualityBitsLB.TabIndex = 28;
			this.QualityBitsLB.Text = "Quality Bits";
			this.QualityBitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueSpecifiedCB
			// 
			this.ValueSpecifiedCB.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.ValueSpecifiedCB.Checked = true;
			this.ValueSpecifiedCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ValueSpecifiedCB.Location = new System.Drawing.Point(336, 48);
			this.ValueSpecifiedCB.Name = "ValueSpecifiedCB";
			this.ValueSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.ValueSpecifiedCB.TabIndex = 31;
			this.ValueSpecifiedCB.CheckedChanged += new System.EventHandler(this.Specified_CheckedChanged);
			// 
			// QualityBitsCTRL
			// 
			this.QualityBitsCTRL.Location = new System.Drawing.Point(104, 71);
			this.QualityBitsCTRL.Name = "QualityBitsCTRL";
			this.QualityBitsCTRL.Size = new System.Drawing.Size(152, 24);
			this.QualityBitsCTRL.TabIndex = 32;
			// 
			// LimitBitsCTRL
			// 
			this.LimitBitsCTRL.Location = new System.Drawing.Point(104, 95);
			this.LimitBitsCTRL.Name = "LimitBitsCTRL";
			this.LimitBitsCTRL.Size = new System.Drawing.Size(80, 24);
			this.LimitBitsCTRL.TabIndex = 34;
			// 
			// LimitBitsLB
			// 
			this.LimitBitsLB.Location = new System.Drawing.Point(0, 96);
			this.LimitBitsLB.Name = "LimitBitsLB";
			this.LimitBitsLB.TabIndex = 33;
			this.LimitBitsLB.Text = "Limit Bits";
			this.LimitBitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorBitsLB
			// 
			this.VendorBitsLB.Location = new System.Drawing.Point(0, 120);
			this.VendorBitsLB.Name = "VendorBitsLB";
			this.VendorBitsLB.TabIndex = 35;
			this.VendorBitsLB.Text = "Vendor Bits";
			this.VendorBitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueCTRL
			// 
			this.ValueCTRL.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.ValueCTRL.Location = new System.Drawing.Point(104, 49);
			this.ValueCTRL.Name = "ValueCTRL";
			this.ValueCTRL.Size = new System.Drawing.Size(224, 20);
			this.ValueCTRL.TabIndex = 36;
			// 
			// TimestampCTRL
			// 
			this.TimestampCTRL.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			this.TimestampCTRL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TimestampCTRL.Location = new System.Drawing.Point(104, 145);
			this.TimestampCTRL.Name = "TimestampCTRL";
			this.TimestampCTRL.ShowUpDown = true;
			this.TimestampCTRL.Size = new System.Drawing.Size(136, 20);
			this.TimestampCTRL.TabIndex = 37;
			// 
			// ItemValueEditCtrl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.TimestampCTRL,
																		  this.ValueCTRL,
																		  this.VendorBitsLB,
																		  this.LimitBitsCTRL,
																		  this.LimitBitsLB,
																		  this.QualityBitsCTRL,
																		  this.ValueSpecifiedCB,
																		  this.QualitySpecifiedCB,
																		  this.VendorBitsCTRL,
																		  this.QualityBitsLB,
																		  this.ItemPathTB,
																		  this.ItemPathLB,
																		  this.TimestampSpecifiedCB,
																		  this.ItemNameTB,
																		  this.ValueLB,
																		  this.TimestampLB,
																		  this.ItemNameLB});
			this.Name = "ItemValueEditCtrl";
			this.Size = new System.Drawing.Size(360, 168);
			((System.ComponentModel.ISupportInitialize)(this.VendorBitsCTRL)).EndInit();
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
		
		//======================================================================
		// IEditObjectCtrl

		/// <summary>
		/// Set all fields to default values.
		/// </summary>
		public void SetDefaults()
		{
			ItemNameTB.Text              = null;
			ItemPathTB.Text              = null;
			ValueCTRL.ItemID             = null;
			ValueCTRL.Value              = null;
			ValueSpecifiedCB.Checked     = false;
			QualitySpecifiedCB.Checked   = false;
			QualityBitsCTRL.Value        = TsDaQualityBits.Bad;
			LimitBitsCTRL.Value          = TsDaLimitBits.None;
			VendorBitsCTRL.Value         = 0;
			TimestampCTRL.Value          = TimestampCTRL.MinDate;
			TimestampSpecifiedCB.Checked = false;
		}

		/// <summary>
		/// Copy values from control into object - throw exceptions on error.
		/// </summary>
		public object Get()
		{
			TsCDaItemValue item = new TsCDaItemValue(m_identifier);

			item.ItemName = ItemNameTB.Text;
			item.ItemPath = ItemPathTB.Text;

			item.Value = (ValueSpecifiedCB.Checked)?ValueCTRL.Value:null;

			// set quality fields.
			item.Quality = TsCDaQuality.Bad;

			if (QualitySpecifiedCB.Checked)
			{
				TsCDaQuality quality = new TsCDaQuality();

				quality.QualityBits = (TsDaQualityBits)QualityBitsCTRL.Value;
				quality.LimitBits   = (TsDaLimitBits)LimitBitsCTRL.Value;
				quality.VendorBits  = (byte)VendorBitsCTRL.Value;

				item.Quality = quality;
			}

			item.QualitySpecified = QualitySpecifiedCB.Checked;

			// set timestamp - jump through some hoops to handle invalid values.
			item.Timestamp = DateTime.MinValue;

			if (TimestampSpecifiedCB.Checked)
			{
				item.Timestamp = (TimestampCTRL.Value > TimestampCTRL.MinDate)?TimestampCTRL.Value:DateTime.MinValue;
			}

			item.TimestampSpecified = TimestampSpecifiedCB.Checked;
		
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
			TsCDaItemValue item = (TsCDaItemValue)value;

			// save item identifier (including client and server handles).
			m_identifier = new OpcItem(item);

			ItemNameTB.Text              = item.ItemName;
			ItemPathTB.Text              = item.ItemPath;
			ValueCTRL.ItemID             = new OpcItem(item);
			ValueCTRL.Value              = item.Value;
			ValueSpecifiedCB.Checked     = item.Value != null;
			QualitySpecifiedCB.Checked   = item.QualitySpecified;
			QualityBitsCTRL.Value        = item.Quality.QualityBits;
			LimitBitsCTRL.Value          = item.Quality.LimitBits;
			VendorBitsCTRL.Value         = item.Quality.VendorBits;
			TimestampCTRL.Value          = TimestampCTRL.MinDate;
			TimestampSpecifiedCB.Checked = item.TimestampSpecified;

			// set timestamp - jump through some hoops to handle invalid values.
			if (item.TimestampSpecified)
			{
				TimestampCTRL.Value = (item.Timestamp > TimestampCTRL.MinDate)?item.Timestamp:TimestampCTRL.MinDate;
			}
		}

		/// <summary>
		/// Creates a new object.
		/// </summary>
		public object Create()
		{
			TsCDaItemValue item = new TsCDaItemValue(m_identifier);

			item.Value              = null;
			item.Quality            = TsCDaQuality.Bad;
			item.QualitySpecified   = false;
			item.Timestamp          = DateTime.MinValue;
			item.TimestampSpecified = false;

			return item;
		}

		/// <summary>
		/// Toggles the enabled state of controls based on the specified check boxes.
		/// </summary>
		private void Specified_CheckedChanged(object sender, System.EventArgs e)
		{			
			ValueCTRL.Enabled       = ValueSpecifiedCB.Checked;
			QualityBitsCTRL.Enabled = QualitySpecifiedCB.Checked;
			LimitBitsCTRL.Enabled   = QualitySpecifiedCB.Checked;
			VendorBitsCTRL.Enabled  = QualitySpecifiedCB.Checked;

			// set timestamp to now when enabling timestamp.
			if (!TimestampCTRL.Enabled && TimestampSpecifiedCB.Checked)
			{
				TimestampCTRL.Enabled = true;
				TimestampCTRL.Value   = DateTime.Now;
			}

			// set timestamp to inavalid date when disabling timestamp.
			if (TimestampCTRL.Enabled && !TimestampSpecifiedCB.Checked)
			{
				TimestampCTRL.Enabled = false;
				TimestampCTRL.Value   = TimestampCTRL.MinDate;
			}
		}
	}
}
