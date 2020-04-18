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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class ItemEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.Label AggregateLB;
		private System.Windows.Forms.ComboBox AggregateCB;
		private System.Windows.Forms.Label ItemNameLB;
		private System.Windows.Forms.TextBox ItemNameTB;
		private System.Windows.Forms.TextBox ItemPathTB;
		private System.Windows.Forms.Label ItemPathLB;
		private System.Windows.Forms.CheckBox AggregateSpecifiedCB;
		private System.ComponentModel.IContainer components = null;

		public ItemEditDlg()
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
			this.ItemNameLB = new System.Windows.Forms.Label();
			this.MainPN = new System.Windows.Forms.Panel();
			this.ItemPathTB = new System.Windows.Forms.TextBox();
			this.ItemPathLB = new System.Windows.Forms.Label();
			this.AggregateCB = new System.Windows.Forms.ComboBox();
			this.AggregateLB = new System.Windows.Forms.Label();
			this.ItemNameTB = new System.Windows.Forms.TextBox();
			this.AggregateSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			this.SuspendLayout();
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
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(192, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 74);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(272, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// ItemNameLB
			// 
			this.ItemNameLB.Location = new System.Drawing.Point(4, 4);
			this.ItemNameLB.Name = "ItemNameLB";
			this.ItemNameLB.Size = new System.Drawing.Size(60, 23);
			this.ItemNameLB.TabIndex = 0;
			this.ItemNameLB.Text = "Item Name";
			this.ItemNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.AggregateSpecifiedCB);
			this.MainPN.Controls.Add(this.ItemPathTB);
			this.MainPN.Controls.Add(this.ItemPathLB);
			this.MainPN.Controls.Add(this.AggregateCB);
			this.MainPN.Controls.Add(this.AggregateLB);
			this.MainPN.Controls.Add(this.ItemNameTB);
			this.MainPN.Controls.Add(this.ItemNameLB);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(272, 74);
			this.MainPN.TabIndex = 1;
			// 
			// ItemPathTB
			// 
			this.ItemPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ItemPathTB.Location = new System.Drawing.Point(64, 28);
			this.ItemPathTB.Name = "ItemPathTB";
			this.ItemPathTB.Size = new System.Drawing.Size(204, 20);
			this.ItemPathTB.TabIndex = 3;
			this.ItemPathTB.Text = "";
			// 
			// ItemPathLB
			// 
			this.ItemPathLB.Location = new System.Drawing.Point(4, 28);
			this.ItemPathLB.Name = "ItemPathLB";
			this.ItemPathLB.Size = new System.Drawing.Size(60, 23);
			this.ItemPathLB.TabIndex = 2;
			this.ItemPathLB.Text = "Item Path";
			this.ItemPathLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateCB
			// 
			this.AggregateCB.Enabled = false;
			this.AggregateCB.Location = new System.Drawing.Point(64, 52);
			this.AggregateCB.Name = "AggregateCB";
			this.AggregateCB.Size = new System.Drawing.Size(121, 21);
			this.AggregateCB.TabIndex = 5;
			// 
			// AggregateLB
			// 
			this.AggregateLB.Location = new System.Drawing.Point(4, 52);
			this.AggregateLB.Name = "AggregateLB";
			this.AggregateLB.Size = new System.Drawing.Size(60, 23);
			this.AggregateLB.TabIndex = 4;
			this.AggregateLB.Text = "Aggregate";
			this.AggregateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameTB
			// 
			this.ItemNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ItemNameTB.Location = new System.Drawing.Point(64, 4);
			this.ItemNameTB.Name = "ItemNameTB";
			this.ItemNameTB.Size = new System.Drawing.Size(204, 20);
			this.ItemNameTB.TabIndex = 1;
			this.ItemNameTB.Text = "";
			// 
			// AggregateSpecifiedCB
			// 
			this.AggregateSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AggregateSpecifiedCB.Location = new System.Drawing.Point(192, 50);
			this.AggregateSpecifiedCB.Name = "AggregateSpecifiedCB";
			this.AggregateSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.AggregateSpecifiedCB.TabIndex = 6;
			this.AggregateSpecifiedCB.CheckedChanged += new System.EventHandler(this.AggregateSpecifiedCB_CheckedChanged);
			// 
			// ItemEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 110);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "ItemEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Item";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the use to edit the properties of an item object.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, TsCHdaItem item)
		{
			if (server == null) throw new ArgumentNullException("server");
			if (item == null)   throw new ArgumentNullException("item");

			// cannot edit item id in this context.
			ItemNameTB.ReadOnly          = true;
			ItemPathTB.ReadOnly          = true;
			AggregateCB.Enabled          = true;
			AggregateSpecifiedCB.Enabled = true;
			AggregateLB.Enabled          = true;

			// fill in the item id.
			ItemNameTB.Text = item.ItemName;
			ItemPathTB.Text = item.ItemPath;

			// populate aggregate drop down list.
			AggregateCB.Items.Clear();

			foreach (TsCHdaAggregate aggregate in server.Aggregates)
			{
				AggregateCB.Items.Add(aggregate);

				if (aggregate.Id == item.Aggregate)
				{
					AggregateCB.SelectedItem = aggregate;
				}
			}

			AggregateSpecifiedCB.Checked = (item.Aggregate != TsCHdaAggregateID.NoAggregate);
			
			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update the item.
			item.Aggregate = TsCHdaAggregateID.NoAggregate;

			if (AggregateSpecifiedCB.Checked && AggregateCB.SelectedItem != null)
			{
				item.Aggregate = ((TsCHdaAggregate)AggregateCB.SelectedItem).Id;
			}

			return true;
		}

		/// <summary>
		/// Prompts the use to edit the properties of an item identifier object.
		/// </summary>
		public bool ShowDialog(OpcItem item)
		{
			if (item == null)   throw new ArgumentNullException("item");

			// cannot edit item id in this context.
			ItemNameTB.ReadOnly          = false;
			ItemPathTB.ReadOnly          = false;
			AggregateCB.Enabled          = false;
			AggregateSpecifiedCB.Enabled = false;
			AggregateLB.Enabled          = false;

			// fill in the item id.
			ItemNameTB.Text = item.ItemName;
			ItemPathTB.Text = item.ItemPath;
		
			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			// update the item.
			item.ItemName = ItemNameTB.Text;
			item.ItemPath = ItemPathTB.Text;

			return true;
		}
		#endregion

		/// <summary>
		/// Toggles the enabled state of the aggregate selector.
		/// </summary>
		private void AggregateSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			AggregateCB.Enabled = AggregateSpecifiedCB.Checked;
		}
	}
}
