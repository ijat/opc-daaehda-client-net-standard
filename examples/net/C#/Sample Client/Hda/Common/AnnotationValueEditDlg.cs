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
using System.Text;
using System.Reflection;
using System.Data;

using OpcClientSdk;
using OpcClientSdk.Hda.Test;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Hda.SampleClient
{	
	/// <summary>
	/// A dialog used to modify the parameters of an item.
	/// </summary>
	public class AnnotationValueEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel MainPN;
		private System.Windows.Forms.Label ValueLB;
		private System.Windows.Forms.Label TimestampLB;
		private System.Windows.Forms.DateTimePicker TimestampCTRL;
		private System.Windows.Forms.Label UserLB;
		private System.Windows.Forms.Label CreationTimeLB;
		private System.Windows.Forms.DateTimePicker CreationTimeCTRL;
		private System.Windows.Forms.TextBox UserTB;
		private System.Windows.Forms.TextBox AnnotationTB;
		private System.ComponentModel.IContainer components = null;

		public AnnotationValueEditDlg()
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
			this.CancelBTN = new System.Windows.Forms.Button();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OkBTN = new System.Windows.Forms.Button();
			this.MainPN = new System.Windows.Forms.Panel();
			this.TimestampCTRL = new System.Windows.Forms.DateTimePicker();
			this.TimestampLB = new System.Windows.Forms.Label();
			this.UserLB = new System.Windows.Forms.Label();
			this.CreationTimeLB = new System.Windows.Forms.Label();
			this.ValueLB = new System.Windows.Forms.Label();
			this.CreationTimeCTRL = new System.Windows.Forms.DateTimePicker();
			this.UserTB = new System.Windows.Forms.TextBox();
			this.AnnotationTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN.SuspendLayout();
			this.MainPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(288, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 98);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(368, 36);
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
			this.MainPN.Controls.Add(this.AnnotationTB);
			this.MainPN.Controls.Add(this.UserTB);
			this.MainPN.Controls.Add(this.CreationTimeCTRL);
			this.MainPN.Controls.Add(this.TimestampCTRL);
			this.MainPN.Controls.Add(this.TimestampLB);
			this.MainPN.Controls.Add(this.UserLB);
			this.MainPN.Controls.Add(this.CreationTimeLB);
			this.MainPN.Controls.Add(this.ValueLB);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Left = 4;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(368, 98);
			this.MainPN.TabIndex = 1;
			// 
			// TimestampCTRL
			// 
			this.TimestampCTRL.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.TimestampCTRL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.TimestampCTRL.Location = new System.Drawing.Point(80, 28);
			this.TimestampCTRL.Name = "TimestampCTRL";
			this.TimestampCTRL.Size = new System.Drawing.Size(132, 20);
			this.TimestampCTRL.TabIndex = 4;
			// 
			// TimestampLB
			// 
			this.TimestampLB.Location = new System.Drawing.Point(4, 28);
			this.TimestampLB.Name = "TimestampLB";
			this.TimestampLB.Size = new System.Drawing.Size(76, 23);
			this.TimestampLB.TabIndex = 3;
			this.TimestampLB.Text = "Timestamp";
			this.TimestampLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UserLB
			// 
			this.UserLB.Location = new System.Drawing.Point(4, 76);
			this.UserLB.Name = "UserLB";
			this.UserLB.Size = new System.Drawing.Size(76, 23);
			this.UserLB.TabIndex = 7;
			this.UserLB.Text = "User";
			this.UserLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CreationTimeLB
			// 
			this.CreationTimeLB.Location = new System.Drawing.Point(4, 52);
			this.CreationTimeLB.Name = "CreationTimeLB";
			this.CreationTimeLB.Size = new System.Drawing.Size(76, 23);
			this.CreationTimeLB.TabIndex = 5;
			this.CreationTimeLB.Text = "Creation Time";
			this.CreationTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ValueLB
			// 
			this.ValueLB.Location = new System.Drawing.Point(4, 4);
			this.ValueLB.Name = "ValueLB";
			this.ValueLB.Size = new System.Drawing.Size(76, 23);
			this.ValueLB.TabIndex = 0;
			this.ValueLB.Text = "Annotation";
			this.ValueLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CreationTimeCTRL
			// 
			this.CreationTimeCTRL.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.CreationTimeCTRL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.CreationTimeCTRL.Location = new System.Drawing.Point(80, 52);
			this.CreationTimeCTRL.Name = "CreationTimeCTRL";
			this.CreationTimeCTRL.Size = new System.Drawing.Size(132, 20);
			this.CreationTimeCTRL.TabIndex = 9;
			// 
			// UserTB
			// 
			this.UserTB.Location = new System.Drawing.Point(80, 76);
			this.UserTB.Name = "UserTB";
			this.UserTB.Size = new System.Drawing.Size(132, 20);
			this.UserTB.TabIndex = 10;
			this.UserTB.Text = "";
			// 
			// AnnotationTB
			// 
			this.AnnotationTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.AnnotationTB.Location = new System.Drawing.Point(80, 4);
			this.AnnotationTB.Name = "AnnotationTB";
			this.AnnotationTB.Size = new System.Drawing.Size(284, 20);
			this.AnnotationTB.TabIndex = 11;
			this.AnnotationTB.Text = "";
			// 
			// AnnotationValueEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 134);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "AnnotationValueEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Annotation";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to edit an item value.
		/// </summary>
		public TsCHdaAnnotationValue ShowDialog(TsCHdaAnnotationValue item)
		{
			// create a new item if none provided.
			if (item == null) 
			{				
				item = new TsCHdaAnnotationValue();
			}

			// initialize controls.
			AnnotationTB.Text      = item.Annotation;
			TimestampCTRL.Value    = DateTime.Now;
			CreationTimeCTRL.Value = DateTime.Now;
			UserTB.Text            = item.User;
			
			if (TimestampCTRL.MinDate < item.Timestamp)
			{
				TimestampCTRL.Value = item.Timestamp;
			}

			if (CreationTimeCTRL.MinDate < item.CreationTime)
			{
				CreationTimeCTRL.Value = item.CreationTime;
			}

			// display dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// update object.
			item.Annotation   = AnnotationTB.Text;
			item.Timestamp    = TimestampCTRL.Value;
			item.CreationTime = CreationTimeCTRL.Value;
			item.User         = UserTB.Text;

			// return new value.
			return item;
		}
		#endregion
	}
}
