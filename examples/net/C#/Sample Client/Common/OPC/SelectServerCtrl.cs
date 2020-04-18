//============================================================================
// TITLE: SelectServerCtrl.cs
//
// CONTENTS:
// 
// A control used browse and select a single OPC server. 
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
using OpcClientSdk;
using OpcClientSdk.Com;

namespace OpcClientSdk.Controls
{
	/// <summary>
	/// Use to receive notifications when a the connect server button is clicked.
	/// </summary>
	public delegate void ConnectServer_EventHandler(OpcServer server);

	/// <summary>
	/// A control used browse and select a single OPC server. 
	/// </summary>
	public class SelectServerCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Button ConnectBTN;
		private System.Windows.Forms.Label ServerUrlLB;
		private System.Windows.Forms.ComboBox ServerUrlCB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectServerCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.ServerUrlLB = new System.Windows.Forms.Label();
            this.ServerUrlCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectBTN.Location = new System.Drawing.Point(712, 0);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(75, 21);
            this.ConnectBTN.TabIndex = 0;
            this.ConnectBTN.Text = "Connect";
            this.ConnectBTN.Click += new System.EventHandler(this.ConnectBTN_Click);
            // 
            // ServerUrlLB
            // 
            this.ServerUrlLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left)));
            this.ServerUrlLB.Location = new System.Drawing.Point(0, 0);
            this.ServerUrlLB.Name = "ServerUrlLB";
            this.ServerUrlLB.Size = new System.Drawing.Size(40, 21);
            this.ServerUrlLB.TabIndex = 1;
            this.ServerUrlLB.Text = "Server";
            this.ServerUrlLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerUrlCB
            // 
            this.ServerUrlCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerUrlCB.Location = new System.Drawing.Point(48, 0);
            this.ServerUrlCB.Name = "ServerUrlCB";
            this.ServerUrlCB.Size = new System.Drawing.Size(656, 21);
            this.ServerUrlCB.TabIndex = 2;
            this.ServerUrlCB.SelectedIndexChanged += new System.EventHandler(this.ServerUrlCB_SelectedIndexChanged);
            // 
            // SelectServerCtrl
            // 
            this.Controls.Add(this.ServerUrlCB);
            this.Controls.Add(this.ServerUrlLB);
            this.Controls.Add(this.ConnectBTN);
            this.Name = "SelectServerCtrl";
            this.Size = new System.Drawing.Size(788, 22);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// Called when a server is connected.
		/// </summary>
		public event ConnectServer_EventHandler ConnectServer;

		/// <summary>
		/// The label displayed in the control.
		/// </summary>
		public string Label
		{
			get { return ServerUrlLB.Text;  }
			set { ServerUrlLB.Text = value; }
		}

		/// <summary>
		/// The specification to use when browsing for servers.
		/// </summary>
		private OpcSpecification m_specification = OpcSpecification.OPC_DA_20;

		/// <summary>
		/// Initializes the control with a set of known urls.
		/// </summary>
		public void Initialize(OpcUrl[] knownUrls, int selectedIndex, OpcSpecification specification)
		{
			// store the default specification.
			m_specification = specification;

			// clear the existing items.
			ServerUrlCB.Items.Clear();

			// add a 'special' item that shows the browse servers dialog.
			ServerUrlCB.Items.Add("<Browse...>");
			
			// add known urls.
			if (knownUrls != null && knownUrls.Length > 0) 
			{
				ServerUrlCB.Items.AddRange(knownUrls);
			}

			// update the selection.
			if (selectedIndex < ServerUrlCB.Items.Count-1)
			{
				ServerUrlCB.SelectedIndex = (selectedIndex != -1)?selectedIndex+1:1;
			}
		}

		/// <summary>
		/// Returns the set of known urls.
		/// </summary>
		public OpcUrl[] GetKnownURLs(out int selectedUrl)
		{
			selectedUrl = -1;

			ArrayList knownUrls = new ArrayList();

			foreach (object url in ServerUrlCB.Items)
			{
				if (url.GetType() == typeof(OpcUrl))
				{
					if (url.Equals(ServerUrlCB.SelectedItem))
					{
						selectedUrl = knownUrls.Count;
					}

					knownUrls.Add(url);
				}
			}

			return (OpcUrl[])knownUrls.ToArray(typeof(OpcUrl));
		}

		/// <summary>
		/// Adds/selects the server in the combo box and connects to the server.
		/// </summary>
		public void Connect()
		{
			OpcUrl url = null;

			// get the url from the select or from the text.
			object selection = ServerUrlCB.SelectedItem;
			
			if (selection != null && selection.GetType() == typeof(OpcUrl))
			{
				url = (OpcUrl)selection;
			}
			else
			{
				url = new OpcUrl(ServerUrlCB.Text);
			}

			// create an unconnected server object.
			OpcServer server = Factory.GetServerForURL(url);

			// invoke the connect server callback.
			if (server != null)
			{
				if (ConnectServer != null) { ConnectServer(server); }
			}
		}

		/// <summary>
		/// Adds/selects the specified server in the combo box.
		/// </summary>
		public void OnConnect(OpcServer server)
		{
			// check if the server url already exists.
			int index = ServerUrlCB.FindStringExact(server.Url.ToString());

			// add url if it does not exist.
			if (index == -1)
			{
				index = 1;
				ServerUrlCB.Items.Insert(index, server.Url);
			}

			// select the new url.
			ServerUrlCB.SelectedIndex = index;
		}

		/// <summary>
		/// Displays the select server dialog if the "Browse..." item was selected.
		/// </summary>
		private void ServerUrlCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			object selection = ServerUrlCB.SelectedItem;

			if (selection != null && selection.GetType() == typeof(string))
			{
				OpcServer server = new SelectServerDlg().ShowDialog(m_specification);
					
				// invoke the connect server callback.
				if (server != null)
				{
					if (ConnectServer != null) 
					{ 
						try   { ConnectServer(server); }
						catch { ServerUrlCB.SelectedItem = null; }
					}
				}
			}
		}

		/// <summary>
		/// Connects to the server and raises an event if successful.
		/// </summary>
		private void ConnectBTN_Click(object sender, System.EventArgs e)
		{
			try  
			{ 
				Connect(); 
			}
			catch (Exception)
			{ 
				ServerUrlCB.SelectedItem = null; 
			}
		}
	}
}
