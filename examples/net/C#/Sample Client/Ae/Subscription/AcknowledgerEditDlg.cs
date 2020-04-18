#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: http://www.technosoftware.com 
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OpcClientSdk;
using OpcClientSdk.Controls;

namespace OpcClientSdk.Ae.SampleClient
{
	/// <summary>
	/// A dialog that displays the current status of an OPC server.
	/// </summary>
	public class AcknowledgerEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Label AcknowledgerLB;
		private System.Windows.Forms.TextBox AcknowledgerTB;
		private System.Windows.Forms.Label CommentLB;
		private System.Windows.Forms.TextBox CommentTB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AcknowledgerEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
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
			this.AcknowledgerLB = new System.Windows.Forms.Label();
			this.AcknowledgerTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.CommentLB = new System.Windows.Forms.Label();
			this.CommentTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// AcknowledgerLB
			// 
			this.AcknowledgerLB.Location = new System.Drawing.Point(4, 4);
			this.AcknowledgerLB.Name = "AcknowledgerLB";
			this.AcknowledgerLB.Size = new System.Drawing.Size(100, 20);
			this.AcknowledgerLB.TabIndex = 1;
			this.AcknowledgerLB.Text = "Acknowledger ID";
			this.AcknowledgerLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AcknowledgerTB
			// 
			this.AcknowledgerTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.AcknowledgerTB.Location = new System.Drawing.Point(96, 4);
			this.AcknowledgerTB.Name = "AcknowledgerTB";
			this.AcknowledgerTB.Size = new System.Drawing.Size(296, 20);
			this.AcknowledgerTB.TabIndex = 2;
			this.AcknowledgerTB.Text = "";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 50);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(400, 36);
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
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(320, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// CommentLB
			// 
			this.CommentLB.Location = new System.Drawing.Point(4, 28);
			this.CommentLB.Name = "CommentLB";
			this.CommentLB.Size = new System.Drawing.Size(84, 20);
			this.CommentLB.TabIndex = 3;
			this.CommentLB.Text = "Comment";
			this.CommentLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CommentTB
			// 
			this.CommentTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.CommentTB.Location = new System.Drawing.Point(96, 28);
			this.CommentTB.Name = "CommentTB";
			this.CommentTB.Size = new System.Drawing.Size(296, 20);
			this.CommentTB.TabIndex = 4;
			this.CommentTB.Text = "";
			// 
			// AcknowledgerEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(400, 86);
			this.Controls.Add(this.CommentTB);
			this.Controls.Add(this.CommentLB);
			this.Controls.Add(this.AcknowledgerTB);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.AcknowledgerLB);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(312, 0);
			this.Name = "AcknowledgerEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Acknowledge Event";
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		#endregion

		#region Public Interface
		/// <summary>
		/// Prompts the user to provide a comment before acknowledging a group of events.
		/// </summary>
		public bool ShowDialog(TsCAeServer server, TsCAeEventNotification[] notifications)
		{
			// prompt user to provide a comment.
			AcknowledgerTB.Text = Environment.UserName;
			CommentTB.Text      = "Acknowledged.";

			if (ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			try
			{
				// create acknowledgements.
				TsCAeEventAcknowledgement[] acknowledgements = new TsCAeEventAcknowledgement[notifications.Length];

				for (int ii = 0; ii < notifications.Length; ii++)
				{					
					acknowledgements[ii] = new TsCAeEventAcknowledgement(notifications[ii]);
				}

				// acknowledge events.
				OpcResult[] results = server.AcknowledgeCondition(
					AcknowledgerTB.Text,
					CommentTB.Text,
					acknowledgements);

				// check for errors.
				StringBuilder errors = new StringBuilder();

				for (int ii = 0; ii < results.Length; ii++)
				{				
					if (results[ii].Failed())
					{			
						if (errors.Length > 0)
						{
							errors.Append(Environment.NewLine);
						}

						errors.Append(acknowledgements[ii].SourceName);
						errors.Append("/");
						errors.Append(acknowledgements[ii].ConditionName);
						errors.Append(" Failed: ");
						errors.Append(results[ii].ToString());
						errors.Append(".");
					}
				}

				// show errors.
				if (errors.Length > 0)
				{
					MessageBox.Show(errors.ToString(), "Acknowledgement Failed");
				}
				
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return false;
		}
		#endregion

	}
}
