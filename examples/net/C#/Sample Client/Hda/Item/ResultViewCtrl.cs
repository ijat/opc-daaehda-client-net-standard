using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// Summary description for ReadParametersCtrl.
	/// </summary>
	public class ResultViewCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label EndTimeLB;
		private System.Windows.Forms.Label ResultLB;
		private System.Windows.Forms.Label StartTimeLB;
		private System.Windows.Forms.Label ItemNameLB;
		private System.Windows.Forms.ComboBox ItemNameCB;
		private System.Windows.Forms.TextBox StartTimeTB;
		private System.Windows.Forms.TextBox EndTimeTB;
		private System.Windows.Forms.TextBox ResultTB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ResultViewCtrl()
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
			this.EndTimeLB = new System.Windows.Forms.Label();
			this.ResultLB = new System.Windows.Forms.Label();
			this.StartTimeLB = new System.Windows.Forms.Label();
			this.ItemNameLB = new System.Windows.Forms.Label();
			this.ItemNameCB = new System.Windows.Forms.ComboBox();
			this.StartTimeTB = new System.Windows.Forms.TextBox();
			this.EndTimeTB = new System.Windows.Forms.TextBox();
			this.ResultTB = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// EndTimeLB
			// 
			this.EndTimeLB.Location = new System.Drawing.Point(0, 48);
			this.EndTimeLB.Name = "EndTimeLB";
			this.EndTimeLB.Size = new System.Drawing.Size(64, 23);
			this.EndTimeLB.TabIndex = 0;
			this.EndTimeLB.Text = "End Time";
			this.EndTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResultLB
			// 
			this.ResultLB.Location = new System.Drawing.Point(0, 72);
			this.ResultLB.Name = "ResultLB";
			this.ResultLB.Size = new System.Drawing.Size(64, 23);
			this.ResultLB.TabIndex = 1;
			this.ResultLB.Text = "Result";
			this.ResultLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StartTimeLB
			// 
			this.StartTimeLB.Location = new System.Drawing.Point(0, 24);
			this.StartTimeLB.Name = "StartTimeLB";
			this.StartTimeLB.Size = new System.Drawing.Size(64, 23);
			this.StartTimeLB.TabIndex = 11;
			this.StartTimeLB.Text = "Start Time";
			this.StartTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameLB
			// 
			this.ItemNameLB.Location = new System.Drawing.Point(0, 0);
			this.ItemNameLB.Name = "ItemNameLB";
			this.ItemNameLB.Size = new System.Drawing.Size(64, 23);
			this.ItemNameLB.TabIndex = 10;
			this.ItemNameLB.Text = "Item Name";
			this.ItemNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemNameCB
			// 
			this.ItemNameCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ItemNameCB.Location = new System.Drawing.Point(64, 0);
			this.ItemNameCB.Name = "ItemNameCB";
			this.ItemNameCB.Size = new System.Drawing.Size(208, 21);
			this.ItemNameCB.TabIndex = 12;
			this.ItemNameCB.SelectedIndexChanged += new System.EventHandler(this.ItemNameCB_SelectedIndexChanged);
			// 
			// StartTimeTB
			// 
			this.StartTimeTB.Location = new System.Drawing.Point(64, 28);
			this.StartTimeTB.Name = "StartTimeTB";
			this.StartTimeTB.ReadOnly = true;
			this.StartTimeTB.Size = new System.Drawing.Size(112, 20);
			this.StartTimeTB.TabIndex = 13;
			this.StartTimeTB.Text = "2005-01-01 00:00:00";
			// 
			// EndTimeTB
			// 
			this.EndTimeTB.Location = new System.Drawing.Point(64, 52);
			this.EndTimeTB.Name = "EndTimeTB";
			this.EndTimeTB.ReadOnly = true;
			this.EndTimeTB.Size = new System.Drawing.Size(112, 20);
			this.EndTimeTB.TabIndex = 14;
			this.EndTimeTB.Text = "2005-01-01 00:00:00";
			// 
			// ResultTB
			// 
			this.ResultTB.Location = new System.Drawing.Point(64, 76);
			this.ResultTB.Name = "ResultTB";
			this.ResultTB.ReadOnly = true;
			this.ResultTB.Size = new System.Drawing.Size(156, 20);
			this.ResultTB.TabIndex = 15;
			this.ResultTB.Text = "S_OK";
			// 
			// ResultViewCtrl
			// 
			this.Controls.Add(this.ResultTB);
			this.Controls.Add(this.EndTimeTB);
			this.Controls.Add(this.StartTimeTB);
			this.Controls.Add(this.ItemNameCB);
			this.Controls.Add(this.StartTimeLB);
			this.Controls.Add(this.ItemNameLB);
			this.Controls.Add(this.ResultLB);
			this.Controls.Add(this.EndTimeLB);
			this.Name = "ResultViewCtrl";
			this.Size = new System.Drawing.Size(272, 96);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Used to receive events when a new result is selected in the control.
		/// </summary>
		public delegate void ResultSelectedEventHandler(OpcItem result);

		/// <summary>
		/// Fired when a new result is selected in the control.
		/// </summary>
		public event ResultSelectedEventHandler ResultSelected = null;

		/// <summary>
		/// Initializes the control with a set of results.
		/// </summary>
		public void Initialize(OpcItem[] results)
		{
			// initialize controls.
			ItemNameCB.Items.Clear();
			StartTimeTB.Text = null;
			EndTimeTB.Text   = null;
			ResultTB.Text    = null;

			if (results != null)
			{
				foreach (OpcItem result in results)
				{
					if (result.ItemName != null)
					{
						ItemNameCB.Items.Add(result.ItemName);
					}
					else
					{
						ItemNameCB.Items.Add("<unknown>");
					}
				}

				ItemNameCB.Tag = results;

				if (ItemNameCB.Items.Count > 0)
				{
					ItemNameCB.SelectedIndex = 0;
				}
			}
		}

		/// <summary>
		/// Appends additional values to the existing collections for the item.
		/// </summary>
		public TsCHdaItemValueCollection[] AppendValues(TsCHdaItemValueCollection[] results)
		{
			bool reinitialize = false;

			ArrayList updatedResults = new ArrayList();

			if (ItemNameCB.Tag == null)
			{
				updatedResults.AddRange(results);
				reinitialize = true;
			}
			else
			{
				foreach (TsCHdaItemValueCollection result in results)
				{
					bool exists = false;

					foreach (TsCHdaItemValueCollection existingResult in (ICollection)ItemNameCB.Tag)
					{
						if (existingResult.ClientHandle != null && existingResult.ClientHandle.Equals(result.ClientHandle))
						{
							existingResult.StartTime = result.StartTime;
							existingResult.EndTime   = result.EndTime;
							existingResult.Result  = result.Result;
							
							existingResult.AddRange(result);
							
							updatedResults.Add(existingResult);
							exists = true;
							break;
						}
					}

					if (!exists)
					{
						updatedResults.Add(result);
						reinitialize = true;
					}
				}
			}

			// must reinitialize the control if new items are in the new result list.
			if (reinitialize)
			{
				Initialize((OpcItem[])updatedResults.ToArray(typeof(TsCHdaItemValueCollection)));
			}

			// just update the existing results and force a selection changed event.
			else
			{
				ItemNameCB.Tag = (OpcItem[])updatedResults.ToArray(typeof(TsCHdaItemValueCollection));

				// update controls directly.
				if (ItemNameCB.SelectedIndex != -1)
				{
					OnResultSelected(ItemNameCB.SelectedIndex);
				}

				// update selected index which causes the controls to be updated.
				else if (ItemNameCB.Items.Count > 0)
				{
					ItemNameCB.SelectedIndex = 0;
				}
			}

			// return the merged results.
			return (TsCHdaItemValueCollection[])ItemNameCB.Tag;
		}
		#endregion

		#region Private Members
		/// <summary>
		/// Updates controls after a new item is selected.
		/// </summary>
		private void OnResultSelected(int index)
		{
			// verify selection.
			OpcItem[] results = (OpcItem[])ItemNameCB.Tag;

			if (index < 0 || index > results.Length)
			{
				return;
			}

			// initialize controls.
			OpcItem result = results[index];
			
			StartTimeTB.Text = null;
			EndTimeTB.Text   = null;
			ResultTB.Text    = null;

			// update times.
			if (typeof(ITsCHdaActualTime).IsInstanceOfType(result))
			{
				StartTimeTB.Text = ((ITsCHdaActualTime)result).StartTime.ToString("yyyy-MM-dd HH:mm:ss");
				EndTimeTB.Text   = ((ITsCHdaActualTime)result).EndTime.ToString("yyyy-MM-dd HH:mm:ss");
			}

			// update result.
			if (typeof(IOpcResult).IsInstanceOfType(result))
			{
				ResultTB.Text = ((IOpcResult)result).Result.Name.Name;
			}

			// fire event.
			if (ResultSelected != null)
			{
				ResultSelected(result);
			}
		}
		#endregion

		/// <summary>
		/// Updates the control when a new item is selected.
		/// </summary>
		private void ItemNameCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// verify selection.
			OpcItem[] results = (OpcItem[])ItemNameCB.Tag;

			if (ItemNameCB.SelectedIndex < 0 || ItemNameCB.SelectedIndex > results.Length)
			{
				return;
			}

			// initialize controls.
			OpcItem result = results[ItemNameCB.SelectedIndex];
			
			StartTimeTB.Text = null;
			EndTimeTB.Text   = null;
			ResultTB.Text    = null;

			// update times.
			if (typeof(ITsCHdaActualTime).IsInstanceOfType(result))
			{
				StartTimeTB.Text = ((ITsCHdaActualTime)result).StartTime.ToString("yyyy-MM-dd HH:mm:ss");
				EndTimeTB.Text   = ((ITsCHdaActualTime)result).EndTime.ToString("yyyy-MM-dd HH:mm:ss");
			}

			// update result.
			if (typeof(IOpcResult).IsInstanceOfType(result))
			{
				ResultTB.Text = ((IOpcResult)result).Result.Name.Name;
			}

			// fire event.
			if (ResultSelected != null)
			{
				ResultSelected(result);
			}
		}
	}
}
