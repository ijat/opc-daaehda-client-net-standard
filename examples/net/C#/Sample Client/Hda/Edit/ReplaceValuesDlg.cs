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
	public class ReplaceValuesDlg : System.Windows.Forms.Form
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
		private OpcClientSdk.Hda.SampleClient.ItemValuesCtrl ValuesCTRL;
		private OpcClientSdk.Hda.SampleClient.ResultListCtrl ResultsCTRL;
		private OpcClientSdk.Hda.SampleClient.ResultListCtrl AsyncResultsCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReplaceValuesDlg()
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
			this.ValuesCTRL = new OpcClientSdk.Hda.SampleClient.ItemValuesCtrl();
			this.BrowseCTRL = new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl();
			this.ResultsCTRL = new OpcClientSdk.Hda.SampleClient.ResultListCtrl();
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
			this.SplitterV.Location = new System.Drawing.Point(360, 0);
			this.SplitterV.Name = "SplitterV";
			this.SplitterV.Size = new System.Drawing.Size(3, 386);
			this.SplitterV.TabIndex = 12;
			this.SplitterV.TabStop = false;
			// 
			// RightPN
			// 
			this.RightPN.Controls.Add(this.AsyncResultsCTRL);
			this.RightPN.Controls.Add(this.ValuesCTRL);
			this.RightPN.Controls.Add(this.BrowseCTRL);
			this.RightPN.Controls.Add(this.ResultsCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(363, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(509, 386);
			this.RightPN.TabIndex = 13;
			// 
			// ValuesCTRL
			// 
			this.ValuesCTRL.DisplayGraph = false;
			this.ValuesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ValuesCTRL.Location = new System.Drawing.Point(0, 4);
			this.ValuesCTRL.Name = "ValuesCTRL";
			this.ValuesCTRL.ReadOnly = false;
			this.ValuesCTRL.Size = new System.Drawing.Size(505, 382);
			this.ValuesCTRL.TabIndex = 3;
			// 
			// BrowseCTRL
			// 
			this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseCTRL.Location = new System.Drawing.Point(0, 4);
			this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(505, 382);
			this.BrowseCTRL.TabIndex = 1;
			this.BrowseCTRL.ItemSelected += new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl.ItemSelectedEventHandler(this.BrowseCTRL_ItemSelected);
			this.BrowseCTRL.ItemPicked += new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl.ItemPickedEventHandler(this.BrowseCTRL_ItemPicked);
			// 
			// ResultsCTRL
			// 
			this.ResultsCTRL.AllowDrop = true;
			this.ResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsCTRL.Location = new System.Drawing.Point(0, 4);
			this.ResultsCTRL.Name = "ResultsCTRL";
			this.ResultsCTRL.Size = new System.Drawing.Size(505, 382);
			this.ResultsCTRL.TabIndex = 0;
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.TrendCTRL);
			this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPN.DockPadding.Left = 4;
			this.LeftPN.DockPadding.Top = 4;
			this.LeftPN.Location = new System.Drawing.Point(0, 0);
			this.LeftPN.Name = "LeftPN";
			this.LeftPN.Size = new System.Drawing.Size(360, 386);
			this.LeftPN.TabIndex = 14;
			// 
			// TrendCTRL
			// 
			this.TrendCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TrendCTRL.Location = new System.Drawing.Point(4, 4);
			this.TrendCTRL.Name = "TrendCTRL";
			this.TrendCTRL.RequestType = OpcClientSdk.Hda.SampleClient.RequestType.ReadRaw;
			this.TrendCTRL.Size = new System.Drawing.Size(356, 382);
			this.TrendCTRL.TabIndex = 2;
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
			this.ButtonsPN.Size = new System.Drawing.Size(872, 36);
			this.ButtonsPN.TabIndex = 15;
			// 
			// BackBTN
			// 
			this.BackBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BackBTN.Location = new System.Drawing.Point(632, 8);
			this.BackBTN.Name = "BackBTN";
			this.BackBTN.TabIndex = 3;
			this.BackBTN.Text = "< Back";
			this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
			// 
			// NextBTN
			// 
			this.NextBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NextBTN.Location = new System.Drawing.Point(712, 8);
			this.NextBTN.Name = "NextBTN";
			this.NextBTN.TabIndex = 2;
			this.NextBTN.Text = "Next >";
			this.NextBTN.Click += new System.EventHandler(this.NextBTN_Click);
			// 
			// DoneBTN
			// 
			this.DoneBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.DoneBTN.Location = new System.Drawing.Point(792, 8);
			this.DoneBTN.Name = "DoneBTN";
			this.DoneBTN.TabIndex = 0;
			this.DoneBTN.Text = "Done";
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(792, 8);
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
			this.AsyncResultsCTRL.Size = new System.Drawing.Size(505, 382);
			this.AsyncResultsCTRL.TabIndex = 4;
			// 
			// ReplaceValuesDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(872, 422);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.SplitterV);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "ReplaceValuesDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Replace Item Values";
			this.RightPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region Public Interface
		/// <summary>
		/// Prompts the user to specified values to replace.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, bool synchronous)
		{
			return ShowDialog(server, null, synchronous);
		}

		/// <summary>
		/// Prompts the user to specified values to replace.
		/// </summary>
		public bool ShowDialog(TsCHdaServer server, OpcItem item, bool synchronous)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server      = server;
			m_synchronous = synchronous;
			m_item        = item;
			m_values      = null;
			m_results     = null;

			// create new trend.
			m_trend = new TsCHdaTrend(m_server);

			// set reasonable defaults.
			m_trend.StartTime = new TsCHdaTime("YEAR");
			m_trend.EndTime   = new TsCHdaTime("YEAR+1H");

			BrowseCTRL.Browse(m_server, null);
			TrendCTRL.Initialize(m_trend, RequestType.ReadRaw);
			ValuesCTRL.Initialize(m_server, null);
			AsyncResultsCTRL.Initialize(m_server, null);
			ResultsCTRL.Initialize(m_server, null);

			// update dialog state.
			SetState();

			// show dialog.
			bool result = (ShowDialog() == DialogResult.OK);

			// release item handles.
			m_trend.ClearItems();

			// return item values.
			return result;
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
		/// The requst object for an asynchronous update.
		/// </summary>
		private IOpcRequest m_request = null;

		/// <summary>
		/// Whether an asynchronous request was sent (and possibly failed).
		/// </summary>
		private bool m_asyncSent = false;
		
		/// <summary>
		/// Whether to use synchronous or asynchronous updates.
		/// </summary>
		private bool m_synchronous = true;

		/// <summary>
		/// The item to read.
		/// </summary>
		private OpcItem m_item = null;

		/// <summary>
		/// The set of new items which will be added to the trend.
		/// </summary>
		private TsCHdaItemValueCollection[] m_values = null;

		/// <summary>
		/// The set of results from the insert operation.
		/// </summary>
		private TsCHdaResultCollection[] m_results = null;

		/// <summary>
		/// Create server handles for new items.
		/// </summary>
		private void DoRead()
		{
			// fetch the new trend parameters.
			TrendCTRL.Update(m_trend);

			// create item (if necessary).
			TsCHdaItem item = m_trend.Items[m_item];

			if (item == null)
			{
				item = m_trend.AddItem(m_item);
			}

			// read data.
			TsCHdaItemValueCollection[] results = m_trend.Read(new TsCHdaItem[] { item });

			if (results == null || results.Length != 1)
			{
				////throw new InvalidResponseException();
			}

			// save results.
			m_values = results;
					
			// display results.
			ValuesCTRL.Initialize(m_server, m_values[0]);
		}

		/// <summary>
		/// Updates the values of the item.
		/// </summary>
		private void DoReplace()
		{
			// get the values to insert/replace.
			m_values = new TsCHdaItemValueCollection[] { ValuesCTRL.GetValues() };

			// check if there is nothing to do.
			if (m_values[0] == null || m_values[0].Count == 0)
			{
				return;
			}
			
			// create item (if necessary).
			TsCHdaItem item = m_trend.Items[m_item];

			if (item == null)
			{
				item = m_trend.AddItem(m_item);
			}

			// add the item identifier information to the collection.
			m_values[0].ItemName     = item.ItemName;
			m_values[0].ItemPath     = item.ItemPath;
			m_values[0].ServerHandle = item.ServerHandle;
			m_values[0].ClientHandle = item.ClientHandle;

			if (m_synchronous)
			{
				// replace data.
				TsCHdaResultCollection[] results =  m_server.Replace(m_values);

				if (results == null || results.Length != 1)
				{
					////throw new InvalidResponseException();
				}

				// display results.
				ResultsCTRL.Initialize(m_server, m_values, results);

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

				// begin replace data.
				OpcItemResult[] results =  m_server.Replace(
					m_values,
					null,
                    new TsCHdaUpdateCompleteEventHandler(OnUpdateComplete),
					out m_request);
	
				if (results == null || results.Length != 1)
				{
					//throw new InvalidResponseException();
				}

				// display initial results.
				AsyncResultsCTRL.Initialize(m_server, results);
				m_asyncSent = true;
			}
		}

		/// <summary>
		/// Called when a update request completes.
		/// </summary>
		public void OnUpdateComplete(IOpcRequest request, TsCHdaResultCollection[] results)
		{
			// check if dialog has closed.
			if (IsDisposed)
			{
				return;
			}

			// check if invoke is required.
			if (InvokeRequired)
			{
                BeginInvoke(new TsCHdaUpdateCompleteEventHandler(OnUpdateComplete), new object[] { request, results });
				return;
			}
						
			try
			{
				// display results.
				ResultsCTRL.Initialize(m_server, m_values, results);
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

			MessageBox.Show("Asynchronous update successfully cancelled.");
		}

		/// <summary>
		/// Remove server handles for new items.
		/// </summary>
		private void UndoRead()
		{
			m_values = null;
			m_item   = null;

			ValuesCTRL.Initialize(m_server, null);
		}
		
		/// <summary>
		/// Discards results used for the replace operation.
		/// </summary>
		private void UndoReplace()
		{
			if (m_results != null)
			{
				m_results   = null;
				m_asyncSent = false;

				if (m_request != null)
				{
					m_server.CancelRequest(m_request, new TsCHdaCancelCompleteEventHandler(OnCancelComplete));
					m_request = null;
				}
			}

			// display results.
			ResultsCTRL.Initialize(m_server, m_values, m_results);
		}

		/// <summary>
		/// Toggle control visibility based on the dialog state.
		/// </summary>
		private void SetState()
		{
			// replace operation complete.
			if (m_results != null)
			{
				NextBTN.Enabled          = false;
				BackBTN.Enabled          = true;
				DoneBTN.Visible          = true;
				CancelBTN.Visible        = false;
				BrowseCTRL.Visible       = false;
				ValuesCTRL.Visible       = false;
				ResultsCTRL.Visible      = true;
				AsyncResultsCTRL.Visible = false;
			}
				
			// async request started.
			else if (m_asyncSent)
			{
				NextBTN.Enabled          = m_results != null;
				BackBTN.Enabled          = true;
				DoneBTN.Visible          = false;
				CancelBTN.Visible        = true;
				BrowseCTRL.Visible       = false;
				ValuesCTRL.Visible       = false;
				ResultsCTRL.Visible      = false;
				AsyncResultsCTRL.Visible = true;
			}

			// editing values to use in an replace operation.
			else if (m_item != null)
			{
				NextBTN.Enabled          = true;
				BackBTN.Enabled          = true;
				DoneBTN.Visible          = false;
				CancelBTN.Visible        = true;
				BrowseCTRL.Visible       = false;
				ValuesCTRL.Visible       = true;
				ResultsCTRL.Visible      = false;
				AsyncResultsCTRL.Visible = false;
			}

			// selecting an item to use for the read/replace operation.
			else
			{
				NextBTN.Enabled          = false;
				BackBTN.Enabled          = false;
				DoneBTN.Visible          = false;
				CancelBTN.Visible        = true;
				BrowseCTRL.Visible       = true;
				ValuesCTRL.Visible       = false;
				ResultsCTRL.Visible      = false;
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
				// replace values.
				if (m_values != null)
				{
					DoReplace();
				}
				
				// read initial values.
				else
				{
					DoRead();
				}

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
				// discards any intermediate results.
				if (m_asyncSent || m_results != null)
				{
					UndoReplace();
				}
				else
				{
					UndoRead();
				}

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
