//============================================================================
// TITLE: PropertyFiltersCtrl.cs
//
// CONTENTS:
// 
// A control used to specify property filters used when browsing.
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using OpcClientSdk;
using OpcClientSdk.Da;

namespace Client
{
	/// <summary>
	/// A control used to specify property filters used when browsing.
	/// </summary>
	public class PropertyFiltersCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.CheckedListBox PropertyNamesLB;
		private System.Windows.Forms.CheckBox ReturnAllPropertiesCB;
		private System.Windows.Forms.CheckBox ReturnPropertyValuesCB;
		private System.Windows.Forms.Label ReturnAllPropertiesLB;
		private System.Windows.Forms.Label ReturnPropertyValuesLB;
		private System.Windows.Forms.Panel TopPN;
		private System.ComponentModel.IContainer components = null;
		
		public PropertyFiltersCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// popuplated the property names list
			TsDaPropertyDescription[] properties = TsDaPropertyDescription.Enumerate();

			foreach (TsDaPropertyDescription property in properties)
			{
				PropertyNamesLB.Items.Add(property);
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ReturnAllPropertiesCB = new System.Windows.Forms.CheckBox();
			this.ReturnPropertyValuesCB = new System.Windows.Forms.CheckBox();
			this.PropertyNamesLB = new System.Windows.Forms.CheckedListBox();
			this.ReturnAllPropertiesLB = new System.Windows.Forms.Label();
			this.ReturnPropertyValuesLB = new System.Windows.Forms.Label();
			this.TopPN = new System.Windows.Forms.Panel();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ReturnAllPropertiesCB
			// 
			this.ReturnAllPropertiesCB.Location = new System.Drawing.Point(112, 0);
			this.ReturnAllPropertiesCB.Name = "ReturnAllPropertiesCB";
			this.ReturnAllPropertiesCB.Size = new System.Drawing.Size(16, 24);
			this.ReturnAllPropertiesCB.TabIndex = 1;
			this.ReturnAllPropertiesCB.CheckedChanged += new System.EventHandler(this.ReturnAllPropertiesCB_CheckedChanged);
			// 
			// ReturnPropertyValuesCB
			// 
            this.ReturnPropertyValuesCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ReturnPropertyValuesCB.Location = new System.Drawing.Point(352, 0);
			this.ReturnPropertyValuesCB.Name = "ReturnPropertyValuesCB";
			this.ReturnPropertyValuesCB.Size = new System.Drawing.Size(16, 24);
			this.ReturnPropertyValuesCB.TabIndex = 3;
			// 
			// PropertyNamesLB
			// 
			this.PropertyNamesLB.CheckOnClick = true;
			this.PropertyNamesLB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertyNamesLB.Location = new System.Drawing.Point(0, 24);
			this.PropertyNamesLB.Name = "PropertyNamesLB";
            this.PropertyNamesLB.Size = new System.Drawing.Size(368, 160);
			this.PropertyNamesLB.TabIndex = 0;
			// 
			// ReturnAllPropertiesLB
			// 
            this.ReturnAllPropertiesLB.Location = new System.Drawing.Point(0, 0);
			this.ReturnAllPropertiesLB.Name = "ReturnAllPropertiesLB";
			this.ReturnAllPropertiesLB.Size = new System.Drawing.Size(112, 23);
			this.ReturnAllPropertiesLB.TabIndex = 0;
			this.ReturnAllPropertiesLB.Text = "Return All Properties";
			this.ReturnAllPropertiesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReturnPropertyValuesLB
			// 
            this.ReturnPropertyValuesLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ReturnPropertyValuesLB.Location = new System.Drawing.Point(224, 0);
			this.ReturnPropertyValuesLB.Name = "ReturnPropertyValuesLB";
			this.ReturnPropertyValuesLB.Size = new System.Drawing.Size(128, 23);
			this.ReturnPropertyValuesLB.TabIndex = 2;
			this.ReturnPropertyValuesLB.Text = "Return Property Values";
			this.ReturnPropertyValuesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TopPN
			// 
            this.TopPN.Controls.Add(this.ReturnAllPropertiesLB);
            this.TopPN.Controls.Add(this.ReturnAllPropertiesCB);
            this.TopPN.Controls.Add(this.ReturnPropertyValuesLB);
            this.TopPN.Controls.Add(this.ReturnPropertyValuesCB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(368, 24);
			this.TopPN.TabIndex = 29;
			// 
			// PropertyFiltersCtrl
			// 
            this.Controls.Add(this.PropertyNamesLB);
            this.Controls.Add(this.TopPN);
			this.Name = "PropertyFiltersCtrl";
			this.Size = new System.Drawing.Size(368, 184);
			this.TopPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Whether all properties for an item should be returned.
		/// </summary>
		public bool ReturnAllProperties
		{
			get { return ReturnAllPropertiesCB.Checked; }
			set { ReturnAllPropertiesCB.Checked = value; }
		}

		/// <summary>
		/// Whether property values should be returned with the descriptions.
		/// </summary>
		public bool ReturnPropertyValues
		{
			get { return ReturnPropertyValuesCB.Checked; }
			set { ReturnPropertyValuesCB.Checked = value; }
		}
		
		/// <summary>
		/// The set of selected property ids.
		/// </summary>
		public TsDaPropertyID[] PropertyIDs
		{
			get 
			{ 
				ArrayList propertyIDs = new ArrayList();

				foreach (TsDaPropertyDescription property in PropertyNamesLB.CheckedItems)
				{
					propertyIDs.Add(property.ID);
				}

				return (TsDaPropertyID[])propertyIDs.ToArray(typeof(TsDaPropertyID)); 
			}

			set 
			{ 
				for (int ii = 0; ii < PropertyNamesLB.Items.Count; ii++)
				{
					PropertyNamesLB.SetItemChecked(ii, false);

					if (value != null)
					{
						TsDaPropertyDescription property = (TsDaPropertyDescription)PropertyNamesLB.Items[ii];

						foreach (TsDaPropertyID propertyID in value)
						{
							if (property.ID == propertyID) 
							{
								PropertyNamesLB.SetItemChecked(ii, true);
								break;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Toggles the enabled state for the list of property names.
		/// </summary>
		private void ReturnAllPropertiesCB_CheckedChanged(object sender, System.EventArgs e)
		{
			PropertyNamesLB.Enabled = !ReturnAllPropertiesCB.Checked;
		}
	}
}
