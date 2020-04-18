//============================================================================
// TITLE: BrowseFiltersDlg.cs
//
// CONTENTS:
// 
// A dialog used to specify element and property filters used when browsing.
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
using System.Xml;
using OpcClientSdk;
using OpcClientSdk.Controls;
using OpcClientSdk.Da;

namespace Client
{	
	/// <summary>
	/// Called when the browse filters have changed.
	/// </summary>
	public delegate void BrowseFiltersChangedCallback(TsCDaBrowseFilters filters);

	/// <summary>
	/// A dialog used to specify element and property filters used when browsing.
	/// </summary>
	public class BrowseFiltersDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private Client.PropertyFiltersCtrl PropertyFiltersCTRL;
		private System.Windows.Forms.NumericUpDown MaxElementsReturnedCTRL;
		private System.Windows.Forms.TextBox ElementNameFilterTB;
		private System.Windows.Forms.Label ReturnPropertiesLB;
		private System.Windows.Forms.Label ElementNameFilterLB;
		private System.Windows.Forms.CheckBox ReturnPropertiesCB;
		private System.Windows.Forms.Label VendorFilterLB;
		private System.Windows.Forms.TextBox VendorFilterTB;
		private System.Windows.Forms.Label BrowseFilterLB;
		private OpcClientSdk.Controls.EnumCtrl BrowseFilterCTRL;
		private System.Windows.Forms.Label MaxElementsReturnedLB;
		private System.Windows.Forms.Button ApplyBTN;
		private System.Windows.Forms.Panel TopPN;
		private System.ComponentModel.IContainer components = null;

		public BrowseFiltersDlg()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
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
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.ApplyBTN = new System.Windows.Forms.Button();
			this.PropertyFiltersCTRL = new Client.PropertyFiltersCtrl();
			this.MaxElementsReturnedCTRL = new System.Windows.Forms.NumericUpDown();
			this.ElementNameFilterTB = new System.Windows.Forms.TextBox();
			this.ReturnPropertiesLB = new System.Windows.Forms.Label();
			this.ElementNameFilterLB = new System.Windows.Forms.Label();
			this.ReturnPropertiesCB = new System.Windows.Forms.CheckBox();
			this.VendorFilterLB = new System.Windows.Forms.Label();
			this.VendorFilterTB = new System.Windows.Forms.TextBox();
			this.BrowseFilterLB = new System.Windows.Forms.Label();
			this.BrowseFilterCTRL = new OpcClientSdk.Controls.EnumCtrl();
			this.MaxElementsReturnedLB = new System.Windows.Forms.Label();
			this.TopPN = new System.Windows.Forms.Panel();
			this.ButtonsPN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxElementsReturnedCTRL)).BeginInit();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
            this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBTN.Location = new System.Drawing.Point(118, 6);
			this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
			// 
			// CancelBTN
			// 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(280, 6);
			this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
			// 
			// ButtonsPN
			// 
            this.ButtonsPN.Controls.Add(this.ApplyBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(4, 274);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(360, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// ApplyBTN
			// 
            this.ApplyBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ApplyBTN.Location = new System.Drawing.Point(199, 6);
			this.ApplyBTN.Name = "ApplyBTN";
            this.ApplyBTN.Size = new System.Drawing.Size(75, 23);
			this.ApplyBTN.TabIndex = 2;
			this.ApplyBTN.Text = "Apply";
			this.ApplyBTN.Click += new System.EventHandler(this.ApplyBTN_Click);
			// 
			// PropertyFiltersCTRL
			// 
			this.PropertyFiltersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertyFiltersCTRL.Location = new System.Drawing.Point(4, 124);
			this.PropertyFiltersCTRL.Name = "PropertyFiltersCTRL";
			this.PropertyFiltersCTRL.PropertyIDs = new TsDaPropertyID[0];
			this.PropertyFiltersCTRL.ReturnAllProperties = true;
			this.PropertyFiltersCTRL.ReturnPropertyValues = true;
			this.PropertyFiltersCTRL.Size = new System.Drawing.Size(360, 150);
			this.PropertyFiltersCTRL.TabIndex = 0;
			// 
			// MaxElementsReturnedCTRL
			// 
			this.MaxElementsReturnedCTRL.Location = new System.Drawing.Point(112, 24);
			this.MaxElementsReturnedCTRL.Maximum = new System.Decimal(new int[] {
																					10000,
																					0,
																					0,
																					0});
			this.MaxElementsReturnedCTRL.Name = "MaxElementsReturnedCTRL";
			this.MaxElementsReturnedCTRL.Size = new System.Drawing.Size(72, 20);
			this.MaxElementsReturnedCTRL.TabIndex = 3;
			// 
			// ElementNameFilterTB
			// 
            this.ElementNameFilterTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ElementNameFilterTB.Location = new System.Drawing.Point(112, 48);
			this.ElementNameFilterTB.Name = "ElementNameFilterTB";
			this.ElementNameFilterTB.Size = new System.Drawing.Size(240, 20);
			this.ElementNameFilterTB.TabIndex = 5;
			// 
			// ReturnPropertiesLB
			// 
			this.ReturnPropertiesLB.Location = new System.Drawing.Point(0, 96);
			this.ReturnPropertiesLB.Name = "ReturnPropertiesLB";
			this.ReturnPropertiesLB.Size = new System.Drawing.Size(112, 23);
			this.ReturnPropertiesLB.TabIndex = 8;
			this.ReturnPropertiesLB.Text = "Return Properties";
			this.ReturnPropertiesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ElementNameFilterLB
			// 
			this.ElementNameFilterLB.Location = new System.Drawing.Point(0, 48);
			this.ElementNameFilterLB.Name = "ElementNameFilterLB";
			this.ElementNameFilterLB.Size = new System.Drawing.Size(112, 23);
			this.ElementNameFilterLB.TabIndex = 4;
			this.ElementNameFilterLB.Text = "Element Name Filter";
			this.ElementNameFilterLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReturnPropertiesCB
			// 
			this.ReturnPropertiesCB.Checked = true;
			this.ReturnPropertiesCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ReturnPropertiesCB.Location = new System.Drawing.Point(112, 96);
			this.ReturnPropertiesCB.Name = "ReturnPropertiesCB";
			this.ReturnPropertiesCB.Size = new System.Drawing.Size(16, 24);
			this.ReturnPropertiesCB.TabIndex = 9;
			this.ReturnPropertiesCB.CheckedChanged += new System.EventHandler(this.ReturnPropertiesCB_CheckedChanged);
			// 
			// VendorFilterLB
			// 
			this.VendorFilterLB.Location = new System.Drawing.Point(0, 72);
			this.VendorFilterLB.Name = "VendorFilterLB";
			this.VendorFilterLB.Size = new System.Drawing.Size(112, 23);
			this.VendorFilterLB.TabIndex = 6;
			this.VendorFilterLB.Text = "Vendor Filter";
			this.VendorFilterLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VendorFilterTB
			// 
            this.VendorFilterTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.VendorFilterTB.Location = new System.Drawing.Point(112, 72);
			this.VendorFilterTB.Name = "VendorFilterTB";
			this.VendorFilterTB.Size = new System.Drawing.Size(240, 20);
			this.VendorFilterTB.TabIndex = 7;
			// 
			// BrowseFilterLB
			// 
            this.BrowseFilterLB.Location = new System.Drawing.Point(0, 0);
			this.BrowseFilterLB.Name = "BrowseFilterLB";
			this.BrowseFilterLB.Size = new System.Drawing.Size(112, 23);
			this.BrowseFilterLB.TabIndex = 0;
			this.BrowseFilterLB.Text = "Browse Filter";
			this.BrowseFilterLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BrowseFilterCTRL
			// 
			this.BrowseFilterCTRL.Location = new System.Drawing.Point(112, 0);
			this.BrowseFilterCTRL.Name = "BrowseFilterCTRL";
			this.BrowseFilterCTRL.Size = new System.Drawing.Size(152, 24);
			this.BrowseFilterCTRL.TabIndex = 1;
            this.BrowseFilterCTRL.Value = null;
			// 
			// MaxElementsReturnedLB
			// 
			this.MaxElementsReturnedLB.Location = new System.Drawing.Point(0, 24);
			this.MaxElementsReturnedLB.Name = "MaxElementsReturnedLB";
			this.MaxElementsReturnedLB.Size = new System.Drawing.Size(112, 23);
			this.MaxElementsReturnedLB.TabIndex = 2;
			this.MaxElementsReturnedLB.Text = "Maximum Returned";
			this.MaxElementsReturnedLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
            this.TopPN.Controls.Add(this.ElementNameFilterTB);
            this.TopPN.Controls.Add(this.MaxElementsReturnedCTRL);
            this.TopPN.Controls.Add(this.BrowseFilterCTRL);
            this.TopPN.Controls.Add(this.BrowseFilterLB);
            this.TopPN.Controls.Add(this.ReturnPropertiesLB);
            this.TopPN.Controls.Add(this.VendorFilterLB);
            this.TopPN.Controls.Add(this.MaxElementsReturnedLB);
            this.TopPN.Controls.Add(this.ReturnPropertiesCB);
            this.TopPN.Controls.Add(this.ElementNameFilterLB);
            this.TopPN.Controls.Add(this.VendorFilterTB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPN.Location = new System.Drawing.Point(4, 4);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(360, 120);
			this.TopPN.TabIndex = 32;
			// 
			// BrowseFiltersDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 310);
            this.Controls.Add(this.PropertyFiltersCTRL);
            this.Controls.Add(this.ButtonsPN);
            this.Controls.Add(this.TopPN);
			this.Name = "BrowseFiltersDlg";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse Filters";
			this.ButtonsPN.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MaxElementsReturnedCTRL)).EndInit();
			this.TopPN.ResumeLayout(false);
            this.TopPN.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called when the OK or Apply button is clicked.
		/// </summary>
		private BrowseFiltersChangedCallback m_callback = null;

		/// <summary>
		/// Displays the browse filters in a non-model dialog.
		/// </summary>
		public void Show(
			Form                         owner,
			TsCDaBrowseFilters                filters,
			BrowseFiltersChangedCallback callback)
		{
			if (callback == null) throw new ArgumentNullException("callback");

			Owner      = owner;
			m_callback = callback;

			BrowseFilterCTRL.Value        = filters.BrowseFilter;
			MaxElementsReturnedCTRL.Value = (decimal)filters.MaxElementsReturned;
			ElementNameFilterTB.Text      = filters.ElementNameFilter;
			VendorFilterTB.Text           = filters.VendorFilter;
			ReturnPropertiesCB.Checked    = (filters.PropertyIDs != null || filters.ReturnAllProperties);

			PropertyFiltersCTRL.ReturnAllProperties  = filters.ReturnAllProperties;
			PropertyFiltersCTRL.ReturnPropertyValues = filters.ReturnPropertyValues;
			PropertyFiltersCTRL.PropertyIDs          = filters.PropertyIDs;

			Show();
		}

		/// <summary>
		/// Invokes the callback an passes the new browse filters.
		/// </summary>
		private void ApplyChanges()
		{
			TsCDaBrowseFilters filters = new TsCDaBrowseFilters();

			filters.BrowseFilter         = (TsCDaBrowseFilter)BrowseFilterCTRL.Value;
			filters.MaxElementsReturned  = (int)MaxElementsReturnedCTRL.Value;
			filters.ElementNameFilter    = ElementNameFilterTB.Text;
			filters.VendorFilter         = VendorFilterTB.Text;

			if (!ReturnPropertiesCB.Checked)
			{
				filters.ReturnAllProperties  = false;
				filters.ReturnPropertyValues = false;
				filters.PropertyIDs          = null;
			}
			else
			{
				filters.ReturnAllProperties  = PropertyFiltersCTRL.ReturnAllProperties;
				filters.ReturnPropertyValues = PropertyFiltersCTRL.ReturnPropertyValues;

				if (!filters.ReturnAllProperties)
				{
					filters.PropertyIDs = PropertyFiltersCTRL.PropertyIDs;
				}
				else
				{
					filters.PropertyIDs = null;
				}
			}

			if (m_callback != null)
			{
				m_callback(filters);
			}
		}

		/// <summary>
		/// Sends the updated filters notification and closes the form. 
		/// </summary>
		private void OkBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
			Close();
		}

		/// <summary>
		/// Sends the updated filters notification. 
		/// </summary>
		private void ApplyBTN_Click(object sender, System.EventArgs e)
		{
			ApplyChanges();
		}
		/// <summary>
		/// Closes the form. 
		/// </summary>
		private void CancelBTN_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Toggles the state of the property filters control.
		/// </summary>
		private void ReturnPropertiesCB_CheckedChanged(object sender, System.EventArgs e)
		{
			PropertyFiltersCTRL.Enabled = ReturnPropertiesCB.Checked;

			if (PropertyFiltersCTRL.Enabled)
			{
				if (PropertyFiltersCTRL.PropertyIDs.Length == 0)
				{
					PropertyFiltersCTRL.ReturnAllProperties = true;
				}
			}
		}
	}
}
