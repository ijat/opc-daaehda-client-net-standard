//============================================================================
// TITLE: AttributeSelectDlg.cs
//
// CONTENTS:
// 
// A dialog used to select an HDA item atribute.
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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// A control used browse and select a single OPC server. 
	/// </summary>
	public class AttributeFilterEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel TopPN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Label NameLB;
		private System.Windows.Forms.ComboBox AttributeCB;
		private System.Windows.Forms.Label DescriptionLB;
		private OpcClientSdk.Controls.EnumCtrl OperatorCTRL;
		private OpcClientSdk.Controls.ValueCtrl FilterValueCTRL;
		private System.Windows.Forms.Label OperatorLB;
		private System.Windows.Forms.Label FilterValueLB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AttributeFilterEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();
			
			FilterValueCTRL.AllowChangeType = false;
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
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.OkBTN = new System.Windows.Forms.Button();
			this.MainPN = new System.Windows.Forms.Panel();
			this.DescriptionLB = new System.Windows.Forms.Label();
			this.NameLB = new System.Windows.Forms.Label();
			this.AttributeCB = new System.Windows.Forms.ComboBox();
			this.TopPN = new System.Windows.Forms.Panel();
			this.OperatorCTRL = new OpcClientSdk.Controls.EnumCtrl();
			this.FilterValueCTRL = new OpcClientSdk.Controls.ValueCtrl();
			this.OperatorLB = new System.Windows.Forms.Label();
			this.FilterValueLB = new System.Windows.Forms.Label();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 138);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(304, 36);
			this.ButtonsPN.TabIndex = 1;
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(224, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(4, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.DescriptionLB);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Left = 4;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 76);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(304, 62);
			this.MainPN.TabIndex = 5;
			// 
			// DescriptionLB
			// 
			this.DescriptionLB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.DescriptionLB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescriptionLB.Location = new System.Drawing.Point(4, 4);
			this.DescriptionLB.Name = "DescriptionLB";
			this.DescriptionLB.Size = new System.Drawing.Size(296, 58);
			this.DescriptionLB.TabIndex = 2;
			this.DescriptionLB.Text = "Description";
			// 
			// NameLB
			// 
			this.NameLB.Location = new System.Drawing.Point(4, 4);
			this.NameLB.Name = "NameLB";
			this.NameLB.Size = new System.Drawing.Size(68, 23);
			this.NameLB.TabIndex = 0;
			this.NameLB.Text = "Attribute";
			this.NameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributeCB
			// 
			this.AttributeCB.Location = new System.Drawing.Point(72, 4);
			this.AttributeCB.Name = "AttributeCB";
			this.AttributeCB.Size = new System.Drawing.Size(228, 21);
			this.AttributeCB.TabIndex = 3;
			this.AttributeCB.SelectedIndexChanged += new System.EventHandler(this.AttributeCB_SelectedIndexChanged);
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.OperatorCTRL);
			this.TopPN.Controls.Add(this.FilterValueCTRL);
			this.TopPN.Controls.Add(this.OperatorLB);
			this.TopPN.Controls.Add(this.FilterValueLB);
			this.TopPN.Controls.Add(this.AttributeCB);
			this.TopPN.Controls.Add(this.NameLB);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(304, 76);
			this.TopPN.TabIndex = 6;
			// 
			// OperatorCTRL
			// 
			this.OperatorCTRL.Location = new System.Drawing.Point(72, 28);
			this.OperatorCTRL.Name = "OperatorCTRL";
			this.OperatorCTRL.Size = new System.Drawing.Size(144, 24);
			this.OperatorCTRL.TabIndex = 13;
			// 
			// FilterValueCTRL
			// 
			this.FilterValueCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterValueCTRL.ItemID = null;
			this.FilterValueCTRL.Location = new System.Drawing.Point(72, 52);
			this.FilterValueCTRL.Name = "FilterValueCTRL";
			this.FilterValueCTRL.Size = new System.Drawing.Size(228, 20);
			this.FilterValueCTRL.TabIndex = 12;
			// 
			// OperatorLB
			// 
			this.OperatorLB.Location = new System.Drawing.Point(4, 28);
			this.OperatorLB.Name = "OperatorLB";
			this.OperatorLB.Size = new System.Drawing.Size(68, 23);
			this.OperatorLB.TabIndex = 10;
			this.OperatorLB.Text = "Operator";
			this.OperatorLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FilterValueLB
			// 
			this.FilterValueLB.Location = new System.Drawing.Point(4, 52);
			this.FilterValueLB.Name = "FilterValueLB";
			this.FilterValueLB.Size = new System.Drawing.Size(68, 23);
			this.FilterValueLB.TabIndex = 11;
			this.FilterValueLB.Text = "Filter Value";
			this.FilterValueLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AttributeFilterEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(304, 174);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.TopPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "AttributeFilterEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Attribute Filter";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit an existing browse filter.
		/// </summary>
		public TsCHdaBrowseFilter ShowDialog(TsCHdaServer server, TsCHdaBrowseFilter filter)
		{
			// add valid attribute ids to the combo box.
			AttributeCB.Items.Clear();

			foreach (OpcClientSdk.Hda.TsCHdaAttribute attribute in server.Attributes)
			{
				if (filter.AttributeID == attribute.ID)
				{				
					AttributeCB.Items.Add(attribute);
					AttributeCB.SelectedItem = attribute;
					break;
				}
			}

			OperatorCTRL.Value    = filter.Operator;
			FilterValueCTRL.Value = filter.FilterValue;

			// prompt user to edit filter.
			return PromptUser();
		}

		/// <summary>
		/// Prompts the user to create a new browse filter.
		/// </summary>
		public TsCHdaBrowseFilter ShowDialog(TsCHdaServer server, ArrayList excludeIDs)
		{
			// add valid attribute ids to the combo box.
			AttributeCB.Items.Clear();

			foreach (OpcClientSdk.Hda.TsCHdaAttribute attribute in server.Attributes)
			{
				if (excludeIDs == null || !excludeIDs.Contains(attribute.ID))
				{				
					AttributeCB.Items.Add(attribute);
				}
			}

			// set default values.
			AttributeCB.SelectedItem = null;
			OperatorCTRL.Value       = TsCHdaOperator.Equal;
			FilterValueCTRL.Value    = "";

			// prompt user to create filter.
			return PromptUser();
		}

		/// <summary>
		/// Displays the dialog until the user enters valid data or clicks cancel.
		/// </summary>
		private TsCHdaBrowseFilter PromptUser()
		{
			while (ShowDialog() == DialogResult.OK)
			{
				try
				{
					OpcClientSdk.Hda.TsCHdaAttribute attribute = (OpcClientSdk.Hda.TsCHdaAttribute)AttributeCB.SelectedItem;

					if (attribute == null)
					{
						continue;
					}

					TsCHdaBrowseFilter filter = new TsCHdaBrowseFilter();

					filter.AttributeID = attribute.ID;
					filter.Operator    = (TsCHdaOperator)OperatorCTRL.Value;
					filter.FilterValue = FilterValueCTRL.Value;

					return filter;
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
				}
			}

			return null;
		}

		/// <summary>
		/// Handles a change to the selected attribute.
		/// </summary>
		private void AttributeCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				// get current selection.
				OpcClientSdk.Hda.TsCHdaAttribute attribute = (OpcClientSdk.Hda.TsCHdaAttribute)AttributeCB.SelectedItem;

				if (attribute == null)
				{
					DescriptionLB.Text = "";
					return;
				}

				// convert filter value to correct data type.
				object value = FilterValueCTRL.Value;

				if (value == null || value.GetType() != attribute.DataType)
				{
					try
					{
						FilterValueCTRL.Value = OpcClientSdk.OpcConvert.ChangeType(value, attribute.DataType);
					}
					catch
					{
						FilterValueCTRL.Value = OpcClientSdk.OpcConvert.ChangeType(null, attribute.DataType);
					}
				}
			
				// update description.
				DescriptionLB.Text = attribute.Description;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
