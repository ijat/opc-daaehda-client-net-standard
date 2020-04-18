//============================================================================
// TITLE: AsyncRequestDlg.cs
//
// CONTENTS:
// 
// A dialog used to send an asynchronous read or write request.
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
// 2003/03/26 RSA   Initial implementation.

using System;
using System.Drawing;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using OpcClientSdk;
using OpcClientSdk.Controls;
using OpcClientSdk.Da;

namespace Client
{	
	/// <summary>
	/// A dialog used to send an asynchronous read or write request.
	/// </summary>
	public class AsyncRequestDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Panel TopPN;
		private Client.ResultListViewCtrl ResultsCTRL;
		private System.Windows.Forms.Button GoBTN;
		private System.Windows.Forms.Button StopBTN;
		private System.ComponentModel.IContainer components = null;

		public AsyncRequestDlg()
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
			this.GoBTN = new System.Windows.Forms.Button();
			this.StopBTN = new System.Windows.Forms.Button();
			this.TopPN = new System.Windows.Forms.Panel();
			this.ResultsCTRL = new Client.ResultListViewCtrl();
			this.ButtonsPN.SuspendLayout();
			this.TopPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(5, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(392, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.GoBTN);
			this.ButtonsPN.Controls.Add(this.StopBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 202);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(472, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// GoBTN
			// 
			this.GoBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.GoBTN.Location = new System.Drawing.Point(200, 8);
			this.GoBTN.Name = "GoBTN";
			this.GoBTN.TabIndex = 2;
			this.GoBTN.Text = "Go";
			this.GoBTN.Click += new System.EventHandler(this.GoBTN_Click);
			// 
			// StopBTN
			// 
			this.StopBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.StopBTN.Location = new System.Drawing.Point(200, 8);
			this.StopBTN.Name = "StopBTN";
			this.StopBTN.TabIndex = 3;
			this.StopBTN.Text = "Stop";
			this.StopBTN.Click += new System.EventHandler(this.StopBTN_Click);
			// 
			// TopPN
			// 
			this.TopPN.Controls.Add(this.ResultsCTRL);
			this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopPN.DockPadding.Bottom = 4;
			this.TopPN.DockPadding.Left = 4;
			this.TopPN.DockPadding.Right = 4;
			this.TopPN.DockPadding.Top = 4;
			this.TopPN.Location = new System.Drawing.Point(0, 0);
			this.TopPN.Name = "TopPN";
			this.TopPN.Size = new System.Drawing.Size(472, 202);
			this.TopPN.TabIndex = 1;
			// 
			// ResultsCTRL
			// 
			this.ResultsCTRL.AllowDrop = true;
			this.ResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsCTRL.Location = new System.Drawing.Point(4, 4);
			this.ResultsCTRL.Name = "ResultsCTRL";
			this.ResultsCTRL.Size = new System.Drawing.Size(464, 194);
			this.ResultsCTRL.TabIndex = 0;
			// 
			// AsyncRequestDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 238);
			this.Controls.Add(this.TopPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "AsyncRequestDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Asynchronous Request";
			this.ButtonsPN.ResumeLayout(false);
			this.TopPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The subscription used to process the request.
		/// </summary>
		private TsCDaSubscription m_subscription = null;
	
		/// <summary>
		/// The items used for a read operation.
		/// </summary>
		private TsCDaItem[] m_items = null;

		/// <summary>
		/// The values used for a write operation.
		/// </summary>
		private TsCDaItemValue[] m_values = null;

		/// <summary>
		/// The results of the operation.
		/// </summary>
		private OpcItem[] m_results = null;

		/// <summary>
		/// The current request being executed.
		/// </summary>
		IOpcRequest m_request = null;

		/// <summary>
		/// The current request id being executed.
		/// </summary>
		int m_handle = 0;

		/// <summary>
		/// Executes an asynchronous read and displays the results.
		/// </summary>
		public TsCDaItemValueResult[] ShowDialog(TsCDaSubscription subscription, TsCDaItem[] items)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			m_subscription = subscription;
			m_items        = items;
			m_values       = null;
			m_results      = null;

			BeginRequest();

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return results.
			return (TsCDaItemValueResult[])m_results;
		}

		/// <summary>
		/// Executes an asynchronous read and displays the results.
		/// </summary>
		public OpcItemResult[] ShowDialog(TsCDaSubscription subscription, TsCDaItemValue[] values)
		{
			if (subscription == null) throw new ArgumentNullException("subscription");

			m_subscription = subscription;
			m_items        = null;
			m_values       = values;
			m_results      = null;

			BeginRequest();

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// return results.
			return (OpcItemResult[])m_results;
		}

		/// <summary>
		/// Begins the asynchronous request.
		/// </summary>
		private void BeginRequest()
		{
			try
			{				
				m_request = null;

				// begin the asynchronous read request.
				if (m_items != null)
				{
					m_subscription.Read(m_items, ++m_handle, new TsCDaReadCompleteEventHandler(OnReadComplete), out m_request);
				}				

				// begin the asynchronous write request.
				else if (m_values != null)
				{
                    m_subscription.Write(m_values, ++m_handle, new TsCDaWriteCompleteEventHandler(OnWriteComplete), out m_request);
				}

				// update controls if request successful.
				if (m_request != null)
				{
					OkBTN.Enabled     = false;
					CancelBTN.Enabled = false;
					GoBTN.Visible     = false;
					StopBTN.Visible   = true;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Cancels the asynchronous request.
		/// </summary>
		private void CancelRequest()
		{
			try
			{
				if (m_request != null)
				{
					m_subscription.Cancel(m_request, new TsCDaCancelCompleteEventHandler(OnCancelComplete));
				}				
			}
			catch (Exception e)
			{
				m_request = null;

				OkBTN.Enabled     = true;
				CancelBTN.Enabled = true;
				GoBTN.Visible     = true;
				StopBTN.Visible   = false;

				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Called when an asynchronous read request completes.
		/// </summary>
		private void OnReadComplete(object clientHandle, TsCDaItemValueResult[] results)
		{
			try
			{
				if (InvokeRequired)
				{
					BeginInvoke(new TsCDaReadCompleteEventHandler(OnReadComplete), new object[] { clientHandle, results });
					return;
				}

				if (!m_handle.Equals(clientHandle))
				{
					return;
				}
			
				ResultsCTRL.Initialize(m_subscription.Server, null, results);

				m_request = null;
				m_results = results;

				OkBTN.Enabled     = true;
				CancelBTN.Enabled = true;
				GoBTN.Visible     = true;
				StopBTN.Visible   = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		/// <summary>
		/// Called when an asynchronous write request completes.
		/// </summary>
		private void OnWriteComplete(object clientHandle, OpcItemResult[] results)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new TsCDaWriteCompleteEventHandler(OnWriteComplete), new object[] { clientHandle, results });
				return;
			}

			if (!m_handle.Equals(clientHandle))
			{
				return;
			}

			ResultsCTRL.Initialize(m_subscription.Server, null, results);

			m_request = null;
			m_results = results;

			OkBTN.Enabled     = true;
			CancelBTN.Enabled = true;
			GoBTN.Visible     = true;
			StopBTN.Visible   = false;
		}
		
		/// <summary>
		/// Displays a dialog indicating the request was cancelled successfully.
		/// </summary>
		private void OnCancelComplete(object clientHandle)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new TsCDaCancelCompleteEventHandler(OnCancelComplete), new object[] { clientHandle });
				return;
			}

			if (!m_handle.Equals(clientHandle))
			{
				return;
			}
			
			MessageBox.Show("Request cancelled successfully.");
			
			OkBTN.Enabled     = true;
			CancelBTN.Enabled = true;
			GoBTN.Visible     = true;
			StopBTN.Visible   = false;
		}

		/// <summary>
		/// Called to stop an active asynchronous request.
		/// </summary>
		private void StopBTN_Click(object sender, System.EventArgs e)
		{
			CancelRequest();
		}

		/// <summary>
		/// Called to start a new asynchronous request.
		/// </summary>
		private void GoBTN_Click(object sender, System.EventArgs e)
		{
			BeginRequest();
		}
	}
}
