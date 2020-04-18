//============================================================================
// TITLE: SubscriptionListEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to edit the state of a list of subscriptions.
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
using OpcClientSdk;
using OpcClientSdk.Da;
using OpcClientSdk.Controls;

namespace Client
{
	/// <summary>
	/// A dialog used to edit the state of a list of subscriptions.
	/// </summary>
	public class SubscriptionListEditDlg : EditObjectListDlg
	{
		private Client.SubscriptionEditCtrl ObjectCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SubscriptionListEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            Icon = ClientUtils.GetAppIcon();

			m_control = ObjectCTRL;
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
			this.ObjectCTRL = new Client.SubscriptionEditCtrl();
			this.SuspendLayout();
			// 
			// ObjectCTRL
			// 
			this.ObjectCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ObjectCTRL.Location = new System.Drawing.Point(4, 4);
			this.ObjectCTRL.Name = "ObjectCTRL";
			this.ObjectCTRL.Size = new System.Drawing.Size(228, 148);
			this.ObjectCTRL.TabIndex = 2;
			// 
			// SubscriptionListEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 166);
			this.Controls.Add(this.ObjectCTRL);
			this.Name = "SubscriptionListEditDlg";
			this.Text = "Edit Subscription";
			this.Controls.SetChildIndex(this.ObjectCTRL, 0);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Prompts the user to modify the subscription state parameters.
		/// </summary>
		public TsCDaSubscriptionState ShowDialog(TsCDaServer server, TsCDaSubscriptionState state)
		{
			ObjectCTRL.Server = server;

			if (state == null) state = (TsCDaSubscriptionState)ObjectCTRL.Create();

			ArrayList results = ShowDialog(new object[] { state });

			if (results != null && results.Count == 1)
			{
				return (TsCDaSubscriptionState)results[0];
			}

			return null;
		}
	}
}
