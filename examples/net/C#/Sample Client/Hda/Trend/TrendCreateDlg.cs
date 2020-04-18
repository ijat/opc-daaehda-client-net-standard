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
	public class TrendCreateDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Splitter SplitterV;
		private System.Windows.Forms.Panel RightPN;
		private OpcClientSdk.Hda.SampleClient.ItemListCtrl ItemsCTRL;
		private System.Windows.Forms.Panel LeftPN;
		private OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl BrowseCTRL;
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button BackBTN;
		private System.Windows.Forms.Button NextBTN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button DoneBTN;
		private OpcClientSdk.Hda.SampleClient.ResultListCtrl ResultsCTRL;
		private OpcClientSdk.Hda.SampleClient.TrendEditCtrl TrendCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TrendCreateDlg()
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
			this.ResultsCTRL = new OpcClientSdk.Hda.SampleClient.ResultListCtrl();
			this.ItemsCTRL = new OpcClientSdk.Hda.SampleClient.ItemListCtrl();
			this.LeftPN = new System.Windows.Forms.Panel();
			this.TrendCTRL = new OpcClientSdk.Hda.SampleClient.TrendEditCtrl();
			this.BrowseCTRL = new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.BackBTN = new System.Windows.Forms.Button();
			this.NextBTN = new System.Windows.Forms.Button();
			this.DoneBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
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
			this.RightPN.Controls.Add(this.ResultsCTRL);
			this.RightPN.Controls.Add(this.ItemsCTRL);
			this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RightPN.DockPadding.Right = 4;
			this.RightPN.DockPadding.Top = 4;
			this.RightPN.Location = new System.Drawing.Point(363, 0);
			this.RightPN.Name = "RightPN";
			this.RightPN.Size = new System.Drawing.Size(509, 386);
			this.RightPN.TabIndex = 13;
			// 
			// ResultsCTRL
			// 
			this.ResultsCTRL.AllowDrop = true;
			this.ResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsCTRL.Location = new System.Drawing.Point(0, 4);
			this.ResultsCTRL.Name = "ResultsCTRL";
			this.ResultsCTRL.Size = new System.Drawing.Size(505, 382);
			this.ResultsCTRL.TabIndex = 1;
			// 
			// ItemsCTRL
			// 
			this.ItemsCTRL.AllowDrop = true;
			this.ItemsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemsCTRL.Location = new System.Drawing.Point(0, 4);
			this.ItemsCTRL.Name = "ItemsCTRL";
			this.ItemsCTRL.Size = new System.Drawing.Size(505, 382);
			this.ItemsCTRL.TabIndex = 0;
			// 
			// LeftPN
			// 
			this.LeftPN.Controls.Add(this.BrowseCTRL);
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
			this.TrendCTRL.Size = new System.Drawing.Size(356, 382);
			this.TrendCTRL.TabIndex = 2;
			// 
			// BrowseCTRL
			// 
			this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseCTRL.Location = new System.Drawing.Point(4, 4);
			this.BrowseCTRL.Name = "BrowseCTRL";
			this.BrowseCTRL.Size = new System.Drawing.Size(356, 382);
			this.BrowseCTRL.TabIndex = 1;
			this.BrowseCTRL.ItemPicked += new OpcClientSdk.Hda.SampleClient.BrowseTreeCtrl.ItemPickedEventHandler(this.BrowseCTRL_ItemPicked);
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
			// TrendCreateDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(872, 422);
			this.Controls.Add(this.RightPN);
			this.Controls.Add(this.SplitterV);
			this.Controls.Add(this.LeftPN);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "TrendCreateDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Trend";
			this.RightPN.ResumeLayout(false);
			this.LeftPN.ResumeLayout(false);
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// The historian database server.
		/// </summary>
		private TsCHdaServer m_server = null;

		/// <summary>
		/// The set of new items which will be added to the trend.
		/// </summary>
		private OpcItemResult[] m_results = null;

		/// <summary>
		/// Prompts the user to select items and specify trend properties.
		/// </summary>
		public TsCHdaTrend ShowDialog(TsCHdaServer server)
		{
			if (server == null) throw new ArgumentNullException("server");

			m_server  = server;
			m_results = null;

			// create new trend.
			TsCHdaTrend trend = new TsCHdaTrend(m_server);

			// set reasonable defaults.
			trend.StartTime = new TsCHdaTime("YEAR");
			trend.EndTime   = new TsCHdaTime("YEAR+1H");

			BrowseCTRL.Browse(m_server, null);
			TrendCTRL.Initialize(trend, RequestType.None);
			ItemsCTRL.Initialize(m_server, (OpcItem[])null);
			ResultsCTRL.Initialize(m_server, m_results);

			// update dialog state.
			SetState(false);

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// create or update the trend.
			TrendCTRL.Update(trend);

			// add new items.
			if (m_results != null)
			{
				foreach (OpcItemResult item in m_results)
				{
					if (item.Result.Succeeded())
					{
						trend.Items.Add(new TsCHdaItem(item));
					}
				}
			}

			// return new trend.
			return trend;
		}

		/// <summary>
		/// Prompts the user to select items and specify trend properties.
		/// </summary>
		public OpcItem[] ShowDialog(TsCHdaTrend trend)
		{
			if (trend == null) throw new ArgumentNullException("trend");

			m_server  = trend.Server;
			m_results = null;

			BrowseCTRL.Browse(m_server, null);
			TrendCTRL.Initialize(trend, RequestType.None);
			ItemsCTRL.Initialize(m_server, (OpcItem[])null);
			ResultsCTRL.Initialize(m_server, m_results);

			// update dialog state.
			SetState(false);

			// show dialog.
			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			// create or update the trend.
			TrendCTRL.Update(trend);

			// add new items.
			if (m_results != null)
			{
				foreach (OpcItemResult item in m_results)
				{
					if (item.Result.Succeeded())
					{
						trend.Items.Add(new TsCHdaItem(item));
					}
				}
			}

			// return new items
			return m_results;
		}

		#region Private Methods
		/// <summary>
		/// Create server handles for new items.
		/// </summary>
		private void DoAddItems()
		{
			// get set of items from control.
			OpcItem[] items = ItemsCTRL.GetItemIDs(false);

			if (items == null)
			{
				return;
			}

			// assign unique client handles.
			foreach (OpcItem item in items)
			{
				item.ClientHandle = Guid.NewGuid().ToString();
			}

			// create item handles on server.
			m_results = m_server.CreateItems(items);
		}

		/// <summary>
		/// Remove server handles for new items.
		/// </summary>
		private void UndoAddItems()
		{
			if (m_results != null)
			{
				m_server.ReleaseItems(m_results);
			}

			m_results = null;
		}

		/// <summary>
		/// Toggle control visibility based on the dialog state.
		/// </summary>
		private void SetState(bool done)
		{
			NextBTN.Enabled     = !done;
			BackBTN.Enabled     = done;
			DoneBTN.Visible     = done;
			CancelBTN.Visible   = !done;
			BrowseCTRL.Visible  = !done;
			TrendCTRL.Visible   = done;
			ItemsCTRL.Visible   = !done;
			ResultsCTRL.Visible = done;
		}
		#endregion

		/// <summary>
		/// Adds the current set of items to server.
		/// </summary>
		private void NextBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				// create handles for items.
				DoAddItems();

				// display results.
				ResultsCTRL.Initialize(m_server, m_results);

				// update dialog state.
				SetState(true);
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
				UndoAddItems();

				// display results.
				ResultsCTRL.Initialize(m_server, m_results);

				// update dialog state.
				SetState(false);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		/// Called when an item is picked in the browse control.
		/// </summary>
		private void BrowseCTRL_ItemPicked(OpcItem[] items)
		{
			try
			{	
				ItemsCTRL.AddItems(items);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}
