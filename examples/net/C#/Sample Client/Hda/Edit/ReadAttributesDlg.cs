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
	/// Summary description for ItemAddDlg.
	/// </summary>
	public class ReadAttributesDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Splitter SplitterV;
		private System.Windows.Forms.Panel RightPN;
		private System.Windows.Forms.Panel LeftPN;
		private OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl BrowseCTRL;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button BackBTN;
		private System.Windows.Forms.Button NextBTN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button DoneBTN;
		private OpcClientSdk.Hda.SampleClient.TrendEditCtrl TrendCTRL;
		private OpcClientSdk.Hda.SampleClient.AttributesViewCtrl ResultsCTRL;
		private OpcClientSdk.Hda.SampleClient.AttributesSelectCtrl AttributesCTRL;
		private OpcClientSdk.Hda.SampleClient.ResultListCtrl AsyncResultsCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReadAttributesDlg()
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
			this.SplitterV = new System.Windows.Forms.Splitter();
			this.RightPN = new System.Windows.Forms.Panel();
			this.BrowseCTRL = new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl();
			this.AttributesCTRL = new OpcClientSdk.Hda.SampleClient.AttributesSelectCtrl();
			this.ResultsCTRL = new OpcClientSdk.Hda.SampleClient.AttributesViewCtrl();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.TrendCTRL = new OpcClientSdk.Hda.SampleClient.TrendEditCtrl();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.BackBTN = new System.Windows.Forms.Button();
			this.NextBTN = new System.Windows.Forms.Button();
			this.DoneBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.AsyncResultsCTRL = new OpcClientSdk.Hda.SampleClient.ResultListCtrl();
			this.RightPN.SuspendLayout();
			this.LeftPN.SuspendLayout();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplitterV
			// 
			this.SplitterV.Location = new System.Drawing.Point(328, 0);
			this.SplitterV.Name = "SplitterV";
			this.SplitterV.Size = new System.Drawing.Size(3, 386);
			this.SplitterV.TabIndex = 12;
			this.SplitterV.TabStop = false;
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.AsyncResultsCTRL);
			this.RightPN.Controls.Add(this.BrowseCTRL);
			this.RightPN.Controls.Add(this.AttributesCTRL);
			this.RightPN.Controls.Add(this.ResultsCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(331, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(605, 386);
			this.RightPN.TabIndex = 13;
			// 
			// BrowseCTRL
			// 
			this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseCTRL.Location = new System.Drawing.Point(0, 4);
			this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(601, 382);
			this.BrowseCTRL.TabIndex = 1;
			this.BrowseCTRL.ItemSelected += new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl.ItemSelectedEventHandler(this.BrowseCTRL_ItemSelected);
			this.BrowseCTRL.ItemPicked += new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl.ItemPickedEventHandler(this.BrowseCTRL_ItemPicked);
			// 
			// AttributesCTRL
			// 
			this.AttributesCTRL.AllowDrop = true;
			this.AttributesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AttributesCTRL.Location = new System.Drawing.Point(0, 4);
			this.AttributesCTRL.Name = "AttributesCTRL";
			this.AttributesCTRL.ReadOnly = false;
			this.AttributesCTRL.Size = new System.Drawing.Size(601, 382);
			this.AttributesCTRL.TabIndex = 5;
			// 
			// ResultsCTRL
			// 
			this.ResultsCTRL.AllowDrop = true;
			this.ResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsCTRL.Location = new System.Drawing.Point(0, 4);
			this.ResultsCTRL.Name = "ResultsCTRL";
			this.ResultsCTRL.Size = new System.Drawing.Size(601, 382);
			this.ResultsCTRL.TabIndex = 4;
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.TrendCTRL);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(328, 386);
			this.LeftPN.TabIndex = 14;
			// 
			// TrendCTRL
			// 
			this.TrendCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TrendCTRL.Location = new System.Drawing.Point(4, 4);
			this.TrendCTRL.Name = "TrendCTRL";
			this.TrendCTRL.RequestType = RequestType.ReadRaw;
			this.TrendCTRL.Size = new System.Drawing.Size(324, 382);
			this.TrendCTRL.TabIndex = 3;
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.BackBTN);
			this.ButtonsPN.Controls.Add(this.NextBTN);
			this.ButtonsPN.Controls.Add(this.DoneBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 386);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(936, 36);
			this.ButtonsPN.TabIndex = 15;
			// 
			// BackBTN
			// 
			this.BackBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BackBTN.Location = new System.Drawing.Point(696, 8);
			this.BackBTN.Name = "BackBTN";
			this.BackBTN.TabIndex = 3;
			this.BackBTN.Text = "< Back";
			this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
			// 
			// NextBTN
			// 
			this.NextBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NextBTN.Location = new System.Drawing.Point(776, 8);
			this.NextBTN.Name = "NextBTN";
			this.NextBTN.TabIndex = 2;
			this.NextBTN.Text = "Next >";
			this.NextBTN.Click += new System.EventHandler(this.NextBTN_Click);
			// 
			// DoneBTN
			// 
			this.DoneBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.DoneBTN.Location = new System.Drawing.Point(856, 8);
			this.DoneBTN.Name = "DoneBTN";
			this.DoneBTN.TabIndex = 0;
			this.DoneBTN.Text = "Done";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(856, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 5;
			this.CancelBTN.Text = "Cancel";
			// 
			// AsyncResultsCTRL
			// 
			this.AsyncResultsCTRL.AllowDrop = true;
			this.AsyncResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AsyncResultsCTRL.Location = new System.Drawing.Point(0, 4);
			this.AsyncResultsCTRL.Name = "AsyncResultsCTRL";
			this.AsyncResultsCTRL.Size = new System.Drawing.Size(601, 382);
			this.AsyncResultsCTRL.TabIndex = 6;
			// 
			// ReadAttributesDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 422);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.SplitterV);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "ReadAttributesDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Read Attributes";
			this.RightPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Prompts the user to select an item and specify trend properties.
		/// </summary>
		public TsCHdaItemAttributeCollection ShowDialog(TsCHdaServer server, bool synchronous)
		{
			return ShowDialog(server, null, new TsCHdaTime("NOW"), null, synchronous);
		}

		/// <summary>
		/// Prompts the user to select attributes to read for an item.
		/// </summary>
		public TsCHdaItemAttributeCollection ShowDialog(
			TsCHdaServer server, 
			OpcItem      item,
			TsCHdaTime           startTime,
			TsCHdaTime           endTime,
			bool           synchronous)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server      = server;
			m_item        = item;
			m_fixedItem   = item != null;
			m_synchronous = synchronous;
			m_results     = null;

			// create new trend.
			m_trend = new TsCHdaTrend(m_server);

			// set reasonable defaults.
			m_trend.StartTime = startTime;
			m_trend.EndTime   = endTime;

			BrowseCTRL.Browse(m_server, null);
			TrendCTRL.Initialize(m_trend, RequestType.ReadAttributes);
			AttributesCTRL.Initialize(m_server, null);
			ResultsCTRL.Initialize(m_server, m_results);
			AsyncResultsCTRL.Initialize(m_server, null);

			// update dialog state.
			SetState();

			// show dialog.
			bool result = (ShowDialog() == DialogResult.OK);

			// release item handles.
			m_trend.ClearItems();

			// return item values.
			return (result)?m_results:null;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer m_server = null;
		
		/// <summary>
		/// The trend used to read the data.
		/// </summary>
		private TsCHdaTrend m_trend = null;

		/// <summary>
		/// Whether to use synchronous or asynchronous reads.
		/// </summary>
		private bool m_synchronous = true;

		/// <summary>
		/// The item to read.
		/// </summary>
		private OpcItem m_item = null;

		/// <summary>
		/// The set of attribute ids which should be read.
		/// </summary>
		private int[] m_attributeIDs = null;

		/// <summary>
		/// The requst object for an asynchronous read.
		/// </summary>
		private IOpcRequest m_request = null;

		/// <summary>
		/// Whether an asynchronous request was sent (and possibly failed).
		/// </summary>
		private bool m_asyncSent = false;

		/// <summary>
		/// The set of new items which will be added to the trend.
		/// </summary>
		private TsCHdaItemAttributeCollection m_results = null;

		/// <summary>
		/// Whether only a single item is being read.
		/// </summary>
		private bool m_fixedItem = false;

		/// <summary>
		/// Creates a server handle for the selected item and reads the data.
		/// </summary>
		private void DoItemRead()
		{
			// get the attribute ids.
			if (m_attributeIDs == null)
			{
				m_attributeIDs = AttributesCTRL.GetAttributeIDs(true);
				return;
			}

			// create item (if necessary).
			TsCHdaItem item = m_trend.Items[m_item];

			if (item == null)
			{
				item = m_trend.AddItem(m_item);
			}

			// get the paramaters.
			TrendCTRL.Update(m_trend);
			
			// get the attributes.
			m_attributeIDs = AttributesCTRL.GetAttributeIDs(true);

			if (m_synchronous)
			{
				// read data.
				TsCHdaItemAttributeCollection results = m_trend.ReadAttributes(item, m_attributeIDs);

				if (results == null || results.Count != m_attributeIDs.Length)
				{
					////throw new InvalidResponseException();
				}

				// display results.
				ResultsCTRL.Initialize(m_server, results);

				// save results.
				m_results = results;
			}
			else
			{
				// check if already waiting for results.
				if (m_asyncSent)
				{
					return;
				}

				// begin read data.
				TsCHdaResultCollection results = m_trend.ReadAttributes(
					item,
					m_attributeIDs,
					null,
					new TsCHdaReadAttributesCompleteEventHandler(OnReadComplete),
					out m_request);

				if (results == null || results.Count != m_attributeIDs.Length)
				{
					////throw new InvalidResponseException();
				}

				// display initial results.
				AsyncResultsCTRL.Initialize(m_server, m_attributeIDs, results);
				m_asyncSent = true;
			}	
		}

		/// <summary>
		/// Remove server handles for new items.
		/// </summary>
		private void UndoRead()
		{
			m_results   = null;
			m_asyncSent = false;

			if (m_request != null)
			{
				m_server.CancelRequest(m_request, new TsCHdaCancelCompleteEventHandler(OnCancelComplete));
				m_request = null;
			}

			if (!m_fixedItem)
			{
				m_attributeIDs = null;
				m_item = null;
			}
		}

		/// <summary>
		/// Called when a read request completes.
		/// </summary>
		public void OnReadComplete(IOpcRequest request, TsCHdaItemAttributeCollection results)
		{
			// check if dialog has closed.
			if (IsDisposed)
			{
				return;
			}

			// check if invoke is required.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCHdaReadAttributesCompleteEventHandler(OnReadComplete), new object[] { request, results });
				return;
			}
			
			try
			{				
				// enable next button since first batch of results have arrived.
				ResultsCTRL.Initialize(m_server, results);
				m_results = results;
				NextBTN.Enabled = true;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		
		/// <summary>
		/// Called when a cancel request completes.
		/// </summary>
		public void OnCancelComplete(IOpcRequest request)
		{
			// check if invoke is required.
			if (InvokeRequired)
			{
				BeginInvoke(new TsCHdaCancelCompleteEventHandler(OnCancelComplete), new object[] { request });
				return;
			}
			
			// check if dialog has closed.
			if (IsDisposed)
			{
				return;
			}

			MessageBox.Show("Asynchronous read successfully cancelled.");
		}

		/// <summary>
		/// Toggle control visibility based on the dialog state.
		/// </summary>
		private void SetState()
		{
			if (m_results != null)
			{ 
				NextBTN.Enabled          = false;
				BackBTN.Enabled          = true;
				DoneBTN.Visible          = true;
				CancelBTN.Visible        = false;
				TrendCTRL.Visible        = true;
				BrowseCTRL.Visible       = false;
				AttributesCTRL.Visible   = false;
				ResultsCTRL.Visible      = true;
				AsyncResultsCTRL.Visible = false;
			}
			else if (m_asyncSent)
			{
				NextBTN.Enabled          = m_results != null;
				BackBTN.Enabled          = true;
				DoneBTN.Visible          = false;
				CancelBTN.Visible        = true;
				TrendCTRL.Visible        = true;
				BrowseCTRL.Visible       = false;
				AttributesCTRL.Visible   = false;
				ResultsCTRL.Visible      = false;
				AsyncResultsCTRL.Visible = true;
			}
			else
			{
				NextBTN.Enabled          = m_item != null;
				BackBTN.Enabled          = m_item != null && !m_fixedItem;
				DoneBTN.Visible          = false;
				CancelBTN.Visible        = true;
				TrendCTRL.Visible        = true;
				BrowseCTRL.Visible       = m_item == null;
				AttributesCTRL.Visible   = m_item != null;
				ResultsCTRL.Visible      = m_item != null;
				AsyncResultsCTRL.Visible = false;

				BrowseCTRL.ClearSelection();
			}
		}
		#endregion

		/// <summary>
		/// Adds the current set of items to server.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_item == null)
				{
					return;
				}

				// read values.
				DoItemRead();

				// display results.
				ResultsCTRL.Initialize(m_server, m_results);

				// update dialog state.
				SetState();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Removes the items and goes back to the select items view.
		/// </summary>
		private void BackBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				// releases handles for items.
				UndoRead();

				// display results.
				ResultsCTRL.Initialize(m_server, m_results);

				// update dialog state.
				SetState();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Toggles the state of the next button based on the current selection.
		/// </summary>
		private void BrowseCTRL_ItemSelected(OpcItem item)
		{
			m_item = item;
			NextBTN.Enabled = item != null;
		}

		/// <summary>
		/// Activates the next button when an item is picked.
		/// </summary>
		private void BrowseCTRL_ItemPicked(OpcItem[] items)
		{
			if (items != null && items.Length == 1)
			{
				m_item = items[0];
				NextBTN.Enabled = true;
				NextBTN_Click(BrowseCTRL, null);
			}	
		}
	}
}
