//============================================================================
// TITLE: ServerStatusCtrl.cs
//
// CONTENTS:
// 
// A control that periodically gets the server status and shows the results.
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using OpcClientSdk;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// A control that periodically gets the server status and shows the results.
	/// </summary>
	public class ServerStatusCtrl : System.Windows.Forms.StatusBar
	{
		private System.Windows.Forms.Timer UpdateTimer;
		private System.Windows.Forms.StatusBarPanel InfoPN;
		private System.Windows.Forms.StatusBarPanel StatePN;
		private System.Windows.Forms.StatusBarPanel TimePN;

		private System.ComponentModel.IContainer components = null;

		public ServerStatusCtrl()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.InfoPN = new System.Windows.Forms.StatusBarPanel();
			this.StatePN = new System.Windows.Forms.StatusBarPanel();
			this.TimePN = new System.Windows.Forms.StatusBarPanel();
			((System.ComponentModel.ISupportInitialize)(this.InfoPN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StatePN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TimePN)).BeginInit();
			// 
			// UpdateTimer
			// 
			this.UpdateTimer.Interval = 30000;
			this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
			// 
			// InfoPN
			// 
			this.InfoPN.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.InfoPN.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.InfoPN.Width = 10;
			// 
			// StatePN
			// 
			this.StatePN.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.StatePN.Width = 10;
			// 
			// TimePN
			// 
			this.TimePN.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.TimePN.Width = 10;
			// 
			// ServerStatusCtrl
			// 
			this.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																			   this.InfoPN,
																			   this.StatePN,
																			   this.TimePN});
			((System.ComponentModel.ISupportInitialize)(this.InfoPN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StatePN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TimePN)).EndInit();

		}
		#endregion

		/// <summary>
		/// The server being polled for its current status.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// Begins polling the status of the server.
		/// </summary>
		public void Start(TsCHdaServer server)
		{
			m_server = server;

			if (m_server == null)
			{
				UpdateTimer.Enabled = false;
				ShowPanels = false;
				Text = "Server not connected.";
			}
			else
			{
				UpdateTimer.Enabled = true;
				UpdateTimer_Tick(this, null);
			}
		}

		/// <summary>
		/// Stoppes polling the server for its status.
		/// </summary>
		public void Stop()
		{
			Start(null);
		}

		/// <summary>
		/// Called when the update timer expires - begins a get status request.
		/// </summary>
		private void UpdateTimer_Tick(object sender, System.EventArgs e)
		{
			try
			{
				OpcGetStatusDelegate callback = new OpcGetStatusDelegate(m_server.GetServerStatus);
				callback.BeginInvoke(new AsyncCallback(OnGetStatus), callback);
			}
			catch (Exception exception)
			{
				ShowPanels = false;
				Text = exception.Message;
			}
		}

		/// <summary>
		/// Completes an asynchronous get status request and updates the control.
		/// </summary>
		private void OnGetStatus(IAsyncResult result)
		{
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnGetStatus), result);
                return;
            }

			try
			{
				OpcGetStatusDelegate callback = (OpcGetStatusDelegate)result.AsyncState;

				OpcServerStatus status = callback.EndInvoke(result);

				ShowPanels   = true;
				InfoPN.Text  = status.VendorInfo;
				StatePN.Text = (status.StatusInfo == null)?status.ServerState.ToString():status.StatusInfo;
				TimePN.Text  = status.CurrentTime.ToString();
			}
			catch (Exception e)
			{
				ShowPanels = false;
				Text = e.Message;
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////
	#region Delegate Declarations

	/// <summary>
	/// The asynchronous delegate for GetStatus.
	/// </summary>
	public delegate OpcServerStatus OpcGetStatusDelegate();

	#endregion

}

