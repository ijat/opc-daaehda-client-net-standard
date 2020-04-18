//============================================================================
// TITLE: AttributeEditDlg.cs
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
	public class AttributesSelectDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel MainPN;
		private OpcClientSdk.Hda.SampleClient.AttributesSelectCtrl AttributesCTRL;
		private System.ComponentModel.IContainer components = null;

		public AttributesSelectDlg()
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
			this.MainPN = new System.Windows.Forms.Panel();
			this.AttributesCTRL = new OpcClientSdk.Hda.SampleClient.AttributesSelectCtrl();
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
			this.CancelBTN.Location = new System.Drawing.Point(184, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 378);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(264, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// MainPN
			// 
			this.MainPN.Controls.Add(this.AttributesCTRL);
			this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPN.DockPadding.Left = 4;
			this.MainPN.DockPadding.Right = 4;
			this.MainPN.DockPadding.Top = 4;
			this.MainPN.Location = new System.Drawing.Point(0, 0);
			this.MainPN.Name = "MainPN";
			this.MainPN.Size = new System.Drawing.Size(264, 378);
			this.MainPN.TabIndex = 32;
			// 
			// AttributesCTRL
			// 
			this.AttributesCTRL.AllowDrop = true;
			this.AttributesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesCTRL.Location = new System.Drawing.Point(4, 4);
			this.AttributesCTRL.Name = "AttributesCTRL";
			this.AttributesCTRL.ReadOnly = false;
			this.AttributesCTRL.Size = new System.Drawing.Size(256, 374);
			this.AttributesCTRL.TabIndex = 0;
			this.AttributesCTRL.AttributePicked += new OpcClientSdk.Hda.SampleClient.AttributesSelectCtrl.AttributePickedEventHandler(this.AttributesCTRL_AttributePicked);
			// 
			// AttributesSelectDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 414);
			this.Controls.Add(this.MainPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "AttributesSelectDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Attributes";
			this.ButtonsPN.ResumeLayout(false);
			this.MainPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to edit the properties of a server.
		/// </summary>
		public OpcClientSdk.Hda.TsCHdaAttribute[] ShowDialog(TsCHdaServer server, ArrayList excludeList)
		{
			if (server == null) throw new ArgumentNullException("server");
			
			// initialize the controls.
			AttributesCTRL.Initialize(server, excludeList);

			// show the dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return selected items.
			return AttributesCTRL.GetAttributes(true);
		}

		/// <summary>
		/// Called when an item is double clicked in the list.
		/// </summary>
		private void AttributesCTRL_AttributePicked(OpcClientSdk.Hda.TsCHdaAttribute[] attributes)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
