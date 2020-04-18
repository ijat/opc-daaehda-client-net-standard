using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OpcClientSdk;

namespace OpcClientSdk.Hda.SampleClient
{
	/// <summary>
	/// Summary description for TimeCtrl.
	/// </summary>
	public class TimeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.DateTimePicker AbsoluteTimeCTRL;
		private System.Windows.Forms.TextBox OffsetTB;
		private System.Windows.Forms.ComboBox TimeTypeCB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TimeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			TimeTypeCB.Items.Clear();
			TimeTypeCB.Items.Add(Absolute);

			foreach (TsCHdaRelativeTime time in Enum.GetValues(typeof(TsCHdaRelativeTime)))
			{
				TimeTypeCB.Items.Add(time);
			}

			TimeTypeCB.SelectedItem = Absolute;
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
			this.AbsoluteTimeCTRL = new System.Windows.Forms.DateTimePicker();
			this.TimeTypeCB = new System.Windows.Forms.ComboBox();
			this.OffsetTB = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// AbsoluteTimeCTRL
			// 
			this.AbsoluteTimeCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.AbsoluteTimeCTRL.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.AbsoluteTimeCTRL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.AbsoluteTimeCTRL.Location = new System.Drawing.Point(76, 0);
			this.AbsoluteTimeCTRL.Name = "AbsoluteTimeCTRL";
			this.AbsoluteTimeCTRL.Size = new System.Drawing.Size(132, 20);
			this.AbsoluteTimeCTRL.TabIndex = 0;
			// 
			// TimeTypeCB
			// 
			this.TimeTypeCB.Location = new System.Drawing.Point(0, 0);
			this.TimeTypeCB.Name = "TimeTypeCB";
			this.TimeTypeCB.Size = new System.Drawing.Size(72, 21);
			this.TimeTypeCB.TabIndex = 1;
			this.TimeTypeCB.Text = "Absolute";
			this.TimeTypeCB.SelectedIndexChanged += new System.EventHandler(this.TimeTypeCB_SelectedIndexChanged);
			// 
			// OffsetTB
			// 
			this.OffsetTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.OffsetTB.Location = new System.Drawing.Point(76, 0);
			this.OffsetTB.Name = "OffsetTB";
			this.OffsetTB.Size = new System.Drawing.Size(132, 20);
			this.OffsetTB.TabIndex = 2;
			this.OffsetTB.Text = "+50MO-6D+1S";
			// 
			// TimeCtrl
			// 
			this.Controls.Add(this.TimeTypeCB);
			this.Controls.Add(this.AbsoluteTimeCTRL);
			this.Controls.Add(this.OffsetTB);
			this.Name = "TimeCtrl";
			this.Size = new System.Drawing.Size(208, 24);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// A constant used to select absolute time instead of a relative time.
		/// </summary>
		private const string Absolute = "Absolute";

		/// <summary>
		/// Creates a Time object from the current contents of the controls.
		/// </summary>
		public TsCHdaTime Get()
		{
			TsCHdaTime time = new TsCHdaTime();

			if (TimeTypeCB.SelectedItem == (object)Absolute)
			{
				if (AbsoluteTimeCTRL.Value > AbsoluteTimeCTRL.MinDate)
				{
					time.AbsoluteTime = AbsoluteTimeCTRL.Value;
				}
				else
				{
					time.AbsoluteTime = DateTime.MinValue;
				}
			}
			else
			{
				time.BaseTime = (TsCHdaRelativeTime)TimeTypeCB.SelectedItem;
				time.Offsets.Parse(OffsetTB.Text);
			}

			return time;
		}

		/// <summary>
		/// Initializes the control with the time object.
		/// </summary>
		public void Set(TsCHdaTime value)
		{
			if (value == null)
			{
				TimeTypeCB.SelectedIndex = 1;
				AbsoluteTimeCTRL.Value   = AbsoluteTimeCTRL.MinDate;
				TimeTypeCB.SelectedItem  = TsCHdaRelativeTime.Now;
				OffsetTB.Text            = "";
			}

			else if (value.IsRelative)
			{
				TimeTypeCB.SelectedIndex = 1;
				AbsoluteTimeCTRL.Value   = AbsoluteTimeCTRL.MinDate;
				TimeTypeCB.SelectedItem  = value.BaseTime;
				OffsetTB.Text            = value.Offsets.ToString();			
			}

			else
			{
				TimeTypeCB.SelectedIndex = 0;
				AbsoluteTimeCTRL.Value   = (value.AbsoluteTime < AbsoluteTimeCTRL.MinDate)?AbsoluteTimeCTRL.MinDate:value.AbsoluteTime;
				TimeTypeCB.SelectedItem  = Absolute;
				OffsetTB.Text            = "";
			}
		}

		/// <summary>
		/// Updates the visibility of the controls based on the selected time type. 
		/// </summary>
		private void TimeTypeCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			AbsoluteTimeCTRL.Visible = (TimeTypeCB.SelectedItem == (object)Absolute);
			OffsetTB.Visible = !AbsoluteTimeCTRL.Visible;
			
			if (AbsoluteTimeCTRL.Visible)
			{
				if (AbsoluteTimeCTRL.Value == AbsoluteTimeCTRL.MinDate)
				{
					AbsoluteTimeCTRL.Value = DateTime.Now;
				}
			}
		}
	}
}
