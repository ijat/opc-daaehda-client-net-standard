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
	public class TrendEditCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label StartTimeLB;
		private System.Windows.Forms.Label EndTimeLB;
		private System.Windows.Forms.Label MaxValuesLB;
		private System.Windows.Forms.Label IncludeBoundsLB;
		private System.Windows.Forms.NumericUpDown MaxValuesCTRL;
		private System.Windows.Forms.CheckBox IncludeBoundsCB;
		private System.Windows.Forms.CheckBox StartTimeSpecifiedCB;
		private System.Windows.Forms.CheckBox EndTimeSpecifiedCB;
		private OpcClientSdk.Hda.SampleClient.TimeCtrl StartTimeCTRL;
		private OpcClientSdk.Hda.SampleClient.TimeCtrl EndTimeCTRL;
		private System.Windows.Forms.Label AggregateLB;
		private System.Windows.Forms.ComboBox AggregateCB;
		private System.Windows.Forms.Label NameLB;
		private System.Windows.Forms.TextBox NameTB;
		private System.Windows.Forms.NumericUpDown ResampleIntervalCTRL;
		private System.Windows.Forms.Label ResampleIntervalLB;
		private System.Windows.Forms.CheckBox AggregateSpecifiedCB;
		private System.Windows.Forms.NumericUpDown PlaybackDurationCTRL;
		private System.Windows.Forms.Label PlaybackDurationLB;
		private System.Windows.Forms.NumericUpDown UpdateIntervalCTRL;
		private System.Windows.Forms.Label UpdateIntervalLB;
		private System.Windows.Forms.Label UpdateIntervalUnitsLB;
		private System.Windows.Forms.Label PlaybackDurationUnitsLB;
		private System.Windows.Forms.Label ResampleIntervalUnitsLB;
		private System.Windows.Forms.Label PlaybackIntervalUnitsLB;
		private System.Windows.Forms.NumericUpDown PlaybackIntervalCTRL;
		private System.Windows.Forms.Label PlaybackIntervalLB;
		private System.Windows.Forms.Panel PlaybackPN;
		private System.Windows.Forms.Panel SubscribePN;
		private System.Windows.Forms.Panel ProcessedPN;
		private System.Windows.Forms.Panel RawPN;
		private System.Windows.Forms.Panel MaxValuesPN;
		private System.Windows.Forms.Panel EndTimePN;
		private System.Windows.Forms.Panel NamePN;
		private System.Windows.Forms.Panel AggregatePN;
		private System.Windows.Forms.Panel StartTimePN;
		private System.Windows.Forms.Panel TimestampsPN;
		private OpcClientSdk.Hda.SampleClient.ItemTimesCtrl TimestampsCTRL;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TrendEditCtrl()
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
			this.StartTimeLB = new System.Windows.Forms.Label();
			this.EndTimeLB = new System.Windows.Forms.Label();
			this.MaxValuesLB = new System.Windows.Forms.Label();
			this.IncludeBoundsLB = new System.Windows.Forms.Label();
			this.MaxValuesCTRL = new System.Windows.Forms.NumericUpDown();
			this.IncludeBoundsCB = new System.Windows.Forms.CheckBox();
			this.StartTimeSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.EndTimeSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.StartTimeCTRL = new OpcClientSdk.Hda.SampleClient.TimeCtrl();
			this.EndTimeCTRL = new OpcClientSdk.Hda.SampleClient.TimeCtrl();
			this.AggregateLB = new System.Windows.Forms.Label();
			this.AggregateCB = new System.Windows.Forms.ComboBox();
			this.NameLB = new System.Windows.Forms.Label();
			this.NameTB = new System.Windows.Forms.TextBox();
			this.ResampleIntervalCTRL = new System.Windows.Forms.NumericUpDown();
			this.ResampleIntervalLB = new System.Windows.Forms.Label();
			this.AggregateSpecifiedCB = new System.Windows.Forms.CheckBox();
			this.UpdateIntervalCTRL = new System.Windows.Forms.NumericUpDown();
			this.UpdateIntervalLB = new System.Windows.Forms.Label();
			this.PlaybackDurationCTRL = new System.Windows.Forms.NumericUpDown();
			this.PlaybackDurationLB = new System.Windows.Forms.Label();
			this.UpdateIntervalUnitsLB = new System.Windows.Forms.Label();
			this.PlaybackDurationUnitsLB = new System.Windows.Forms.Label();
			this.ResampleIntervalUnitsLB = new System.Windows.Forms.Label();
			this.PlaybackIntervalUnitsLB = new System.Windows.Forms.Label();
			this.PlaybackIntervalCTRL = new System.Windows.Forms.NumericUpDown();
			this.PlaybackIntervalLB = new System.Windows.Forms.Label();
			this.PlaybackPN = new System.Windows.Forms.Panel();
			this.SubscribePN = new System.Windows.Forms.Panel();
			this.ProcessedPN = new System.Windows.Forms.Panel();
			this.RawPN = new System.Windows.Forms.Panel();
			this.MaxValuesPN = new System.Windows.Forms.Panel();
			this.EndTimePN = new System.Windows.Forms.Panel();
			this.NamePN = new System.Windows.Forms.Panel();
			this.AggregatePN = new System.Windows.Forms.Panel();
			this.StartTimePN = new System.Windows.Forms.Panel();
			this.TimestampsPN = new System.Windows.Forms.Panel();
			this.TimestampsCTRL = new OpcClientSdk.Hda.SampleClient.ItemTimesCtrl();
			((System.ComponentModel.ISupportInitialize)(this.MaxValuesCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ResampleIntervalCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PlaybackDurationCTRL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PlaybackIntervalCTRL)).BeginInit();
			this.PlaybackPN.SuspendLayout();
			this.SubscribePN.SuspendLayout();
			this.ProcessedPN.SuspendLayout();
			this.RawPN.SuspendLayout();
			this.MaxValuesPN.SuspendLayout();
			this.EndTimePN.SuspendLayout();
			this.NamePN.SuspendLayout();
			this.AggregatePN.SuspendLayout();
			this.StartTimePN.SuspendLayout();
			this.TimestampsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartTimeLB
			// 
			this.StartTimeLB.Location = new System.Drawing.Point(0, 0);
			this.StartTimeLB.Name = "StartTimeLB";
			this.StartTimeLB.Size = new System.Drawing.Size(96, 23);
			this.StartTimeLB.TabIndex = 0;
			this.StartTimeLB.Text = "Start Time";
			this.StartTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EndTimeLB
			// 
			this.EndTimeLB.Location = new System.Drawing.Point(0, 0);
			this.EndTimeLB.Name = "EndTimeLB";
			this.EndTimeLB.Size = new System.Drawing.Size(96, 23);
			this.EndTimeLB.TabIndex = 1;
			this.EndTimeLB.Text = "End Time";
			this.EndTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxValuesLB
			// 
			this.MaxValuesLB.Location = new System.Drawing.Point(0, 0);
			this.MaxValuesLB.Name = "MaxValuesLB";
			this.MaxValuesLB.Size = new System.Drawing.Size(96, 23);
			this.MaxValuesLB.TabIndex = 2;
			this.MaxValuesLB.Text = "Max Values";
			this.MaxValuesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// IncludeBoundsLB
			// 
			this.IncludeBoundsLB.Location = new System.Drawing.Point(0, 0);
			this.IncludeBoundsLB.Name = "IncludeBoundsLB";
			this.IncludeBoundsLB.Size = new System.Drawing.Size(96, 23);
			this.IncludeBoundsLB.TabIndex = 3;
			this.IncludeBoundsLB.Text = "Include Bounds";
			this.IncludeBoundsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaxValuesCTRL
			// 
			this.MaxValuesCTRL.Location = new System.Drawing.Point(96, 1);
			this.MaxValuesCTRL.Maximum = new System.Decimal(new int[] {
																		  2147483647,
																		  0,
																		  0,
																		  0});
			this.MaxValuesCTRL.Name = "MaxValuesCTRL";
			this.MaxValuesCTRL.Size = new System.Drawing.Size(72, 20);
			this.MaxValuesCTRL.TabIndex = 6;
			// 
			// IncludeBoundsCB
			// 
			this.IncludeBoundsCB.Location = new System.Drawing.Point(96, -1);
			this.IncludeBoundsCB.Name = "IncludeBoundsCB";
			this.IncludeBoundsCB.Size = new System.Drawing.Size(16, 24);
			this.IncludeBoundsCB.TabIndex = 7;
			// 
			// StartTimeSpecifiedCB
			// 
			this.StartTimeSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.StartTimeSpecifiedCB.Location = new System.Drawing.Point(300, -1);
			this.StartTimeSpecifiedCB.Name = "StartTimeSpecifiedCB";
			this.StartTimeSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.StartTimeSpecifiedCB.TabIndex = 8;
			this.StartTimeSpecifiedCB.CheckedChanged += new System.EventHandler(this.TimeSpecifiedCB_CheckedChanged);
			// 
			// EndTimeSpecifiedCB
			// 
			this.EndTimeSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.EndTimeSpecifiedCB.Location = new System.Drawing.Point(300, -1);
			this.EndTimeSpecifiedCB.Name = "EndTimeSpecifiedCB";
			this.EndTimeSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.EndTimeSpecifiedCB.TabIndex = 9;
			this.EndTimeSpecifiedCB.CheckedChanged += new System.EventHandler(this.TimeSpecifiedCB_CheckedChanged);
			// 
			// StartTimeCTRL
			// 
			this.StartTimeCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.StartTimeCTRL.Enabled = false;
			this.StartTimeCTRL.Location = new System.Drawing.Point(96, 0);
			this.StartTimeCTRL.Name = "StartTimeCTRL";
			this.StartTimeCTRL.Size = new System.Drawing.Size(200, 24);
			this.StartTimeCTRL.TabIndex = 10;
			// 
			// EndTimeCTRL
			// 
			this.EndTimeCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.EndTimeCTRL.Enabled = false;
			this.EndTimeCTRL.Location = new System.Drawing.Point(96, 0);
			this.EndTimeCTRL.Name = "EndTimeCTRL";
			this.EndTimeCTRL.Size = new System.Drawing.Size(200, 24);
			this.EndTimeCTRL.TabIndex = 11;
			// 
			// AggregateLB
			// 
			this.AggregateLB.Location = new System.Drawing.Point(0, 0);
			this.AggregateLB.Name = "AggregateLB";
			this.AggregateLB.Size = new System.Drawing.Size(96, 23);
			this.AggregateLB.TabIndex = 12;
			this.AggregateLB.Text = "Aggregate";
			this.AggregateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateCB
			// 
			this.AggregateCB.Enabled = false;
			this.AggregateCB.Location = new System.Drawing.Point(96, 0);
			this.AggregateCB.Name = "AggregateCB";
			this.AggregateCB.Size = new System.Drawing.Size(204, 21);
			this.AggregateCB.TabIndex = 13;
			// 
			// NameLB
			// 
			this.NameLB.Location = new System.Drawing.Point(0, 0);
			this.NameLB.Name = "NameLB";
			this.NameLB.Size = new System.Drawing.Size(96, 23);
			this.NameLB.TabIndex = 14;
			this.NameLB.Text = "Name";
			this.NameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameTB
			// 
			this.NameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.NameTB.Location = new System.Drawing.Point(96, 0);
			this.NameTB.Name = "NameTB";
			this.NameTB.Size = new System.Drawing.Size(216, 20);
			this.NameTB.TabIndex = 15;
			this.NameTB.Text = "";
			// 
			// ResampleIntervalCTRL
			// 
			this.ResampleIntervalCTRL.DecimalPlaces = 6;
			this.ResampleIntervalCTRL.Enabled = false;
			this.ResampleIntervalCTRL.Location = new System.Drawing.Point(96, 1);
			this.ResampleIntervalCTRL.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			this.ResampleIntervalCTRL.Name = "ResampleIntervalCTRL";
			this.ResampleIntervalCTRL.TabIndex = 17;
			// 
			// ResampleIntervalLB
			// 
			this.ResampleIntervalLB.Location = new System.Drawing.Point(0, 0);
			this.ResampleIntervalLB.Name = "ResampleIntervalLB";
			this.ResampleIntervalLB.Size = new System.Drawing.Size(96, 23);
			this.ResampleIntervalLB.TabIndex = 16;
			this.ResampleIntervalLB.Text = "Resample Interval";
			this.ResampleIntervalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AggregateSpecifiedCB
			// 
			this.AggregateSpecifiedCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AggregateSpecifiedCB.Location = new System.Drawing.Point(300, -1);
			this.AggregateSpecifiedCB.Name = "AggregateSpecifiedCB";
			this.AggregateSpecifiedCB.Size = new System.Drawing.Size(16, 24);
			this.AggregateSpecifiedCB.TabIndex = 18;
			this.AggregateSpecifiedCB.CheckedChanged += new System.EventHandler(this.AggregateSpecifiedCB_CheckedChanged);
			// 
			// UpdateIntervalCTRL
			// 
			this.UpdateIntervalCTRL.DecimalPlaces = 6;
			this.UpdateIntervalCTRL.Location = new System.Drawing.Point(96, 1);
			this.UpdateIntervalCTRL.Maximum = new System.Decimal(new int[] {
																			   -1,
																			   2147483647,
																			   0,
																			   0});
			this.UpdateIntervalCTRL.Name = "UpdateIntervalCTRL";
			this.UpdateIntervalCTRL.TabIndex = 20;
			// 
			// UpdateIntervalLB
			// 
			this.UpdateIntervalLB.Location = new System.Drawing.Point(0, 0);
			this.UpdateIntervalLB.Name = "UpdateIntervalLB";
			this.UpdateIntervalLB.Size = new System.Drawing.Size(96, 23);
			this.UpdateIntervalLB.TabIndex = 19;
			this.UpdateIntervalLB.Text = "Update Interval";
			this.UpdateIntervalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackDurationCTRL
			// 
			this.PlaybackDurationCTRL.DecimalPlaces = 6;
			this.PlaybackDurationCTRL.Location = new System.Drawing.Point(96, 25);
			this.PlaybackDurationCTRL.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			this.PlaybackDurationCTRL.Name = "PlaybackDurationCTRL";
			this.PlaybackDurationCTRL.TabIndex = 22;
			// 
			// PlaybackDurationLB
			// 
			this.PlaybackDurationLB.Location = new System.Drawing.Point(0, 24);
			this.PlaybackDurationLB.Name = "PlaybackDurationLB";
			this.PlaybackDurationLB.Size = new System.Drawing.Size(96, 23);
			this.PlaybackDurationLB.TabIndex = 21;
			this.PlaybackDurationLB.Text = "Playback Duration";
			this.PlaybackDurationLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UpdateIntervalUnitsLB
			// 
			this.UpdateIntervalUnitsLB.Location = new System.Drawing.Point(220, 0);
			this.UpdateIntervalUnitsLB.Name = "UpdateIntervalUnitsLB";
			this.UpdateIntervalUnitsLB.Size = new System.Drawing.Size(52, 23);
			this.UpdateIntervalUnitsLB.TabIndex = 23;
			this.UpdateIntervalUnitsLB.Text = "Seconds";
			this.UpdateIntervalUnitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackDurationUnitsLB
			// 
			this.PlaybackDurationUnitsLB.Location = new System.Drawing.Point(220, 24);
			this.PlaybackDurationUnitsLB.Name = "PlaybackDurationUnitsLB";
			this.PlaybackDurationUnitsLB.Size = new System.Drawing.Size(52, 23);
			this.PlaybackDurationUnitsLB.TabIndex = 24;
			this.PlaybackDurationUnitsLB.Text = "Seconds";
			this.PlaybackDurationUnitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResampleIntervalUnitsLB
			// 
			this.ResampleIntervalUnitsLB.Location = new System.Drawing.Point(220, 0);
			this.ResampleIntervalUnitsLB.Name = "ResampleIntervalUnitsLB";
			this.ResampleIntervalUnitsLB.Size = new System.Drawing.Size(52, 23);
			this.ResampleIntervalUnitsLB.TabIndex = 25;
			this.ResampleIntervalUnitsLB.Text = "Seconds";
			this.ResampleIntervalUnitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackIntervalUnitsLB
			// 
			this.PlaybackIntervalUnitsLB.Location = new System.Drawing.Point(220, 0);
			this.PlaybackIntervalUnitsLB.Name = "PlaybackIntervalUnitsLB";
			this.PlaybackIntervalUnitsLB.Size = new System.Drawing.Size(52, 23);
			this.PlaybackIntervalUnitsLB.TabIndex = 28;
			this.PlaybackIntervalUnitsLB.Text = "Seconds";
			this.PlaybackIntervalUnitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackIntervalCTRL
			// 
			this.PlaybackIntervalCTRL.DecimalPlaces = 6;
			this.PlaybackIntervalCTRL.Location = new System.Drawing.Point(96, 1);
			this.PlaybackIntervalCTRL.Maximum = new System.Decimal(new int[] {
																				 -1,
																				 2147483647,
																				 0,
																				 0});
			this.PlaybackIntervalCTRL.Name = "PlaybackIntervalCTRL";
			this.PlaybackIntervalCTRL.TabIndex = 27;
			// 
			// PlaybackIntervalLB
			// 
			this.PlaybackIntervalLB.Location = new System.Drawing.Point(0, 0);
			this.PlaybackIntervalLB.Name = "PlaybackIntervalLB";
			this.PlaybackIntervalLB.Size = new System.Drawing.Size(96, 23);
			this.PlaybackIntervalLB.TabIndex = 26;
			this.PlaybackIntervalLB.Text = "Playback Interval";
			this.PlaybackIntervalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaybackPN
			// 
			this.PlaybackPN.Controls.Add(this.PlaybackDurationLB);
			this.PlaybackPN.Controls.Add(this.PlaybackDurationCTRL);
			this.PlaybackPN.Controls.Add(this.PlaybackDurationUnitsLB);
			this.PlaybackPN.Controls.Add(this.PlaybackIntervalUnitsLB);
			this.PlaybackPN.Controls.Add(this.PlaybackIntervalCTRL);
			this.PlaybackPN.Controls.Add(this.PlaybackIntervalLB);
			this.PlaybackPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.PlaybackPN.Location = new System.Drawing.Point(0, 192);
			this.PlaybackPN.Name = "PlaybackPN";
			this.PlaybackPN.Size = new System.Drawing.Size(316, 48);
			this.PlaybackPN.TabIndex = 29;
			// 
			// SubscribePN
			// 
			this.SubscribePN.Controls.Add(this.UpdateIntervalLB);
			this.SubscribePN.Controls.Add(this.UpdateIntervalUnitsLB);
			this.SubscribePN.Controls.Add(this.UpdateIntervalCTRL);
			this.SubscribePN.Dock = System.Windows.Forms.DockStyle.Top;
			this.SubscribePN.Location = new System.Drawing.Point(0, 168);
			this.SubscribePN.Name = "SubscribePN";
			this.SubscribePN.Size = new System.Drawing.Size(316, 24);
			this.SubscribePN.TabIndex = 30;
			// 
			// ProcessedPN
			// 
			this.ProcessedPN.Controls.Add(this.ResampleIntervalLB);
			this.ProcessedPN.Controls.Add(this.ResampleIntervalCTRL);
			this.ProcessedPN.Controls.Add(this.ResampleIntervalUnitsLB);
			this.ProcessedPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.ProcessedPN.Location = new System.Drawing.Point(0, 144);
			this.ProcessedPN.Name = "ProcessedPN";
			this.ProcessedPN.Size = new System.Drawing.Size(316, 24);
			this.ProcessedPN.TabIndex = 31;
			// 
			// RawPN
			// 
			this.RawPN.Controls.Add(this.IncludeBoundsCB);
			this.RawPN.Controls.Add(this.IncludeBoundsLB);
			this.RawPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.RawPN.Location = new System.Drawing.Point(0, 120);
			this.RawPN.Name = "RawPN";
			this.RawPN.Size = new System.Drawing.Size(316, 24);
			this.RawPN.TabIndex = 32;
			// 
			// MaxValuesPN
			// 
			this.MaxValuesPN.Controls.Add(this.MaxValuesCTRL);
			this.MaxValuesPN.Controls.Add(this.MaxValuesLB);
			this.MaxValuesPN.Dock = System.Windows.Forms.DockStyle.Top;
			this.MaxValuesPN.Location = new System.Drawing.Point(0, 96);
			this.MaxValuesPN.Name = "MaxValuesPN";
			this.MaxValuesPN.Size = new System.Drawing.Size(316, 24);
			this.MaxValuesPN.TabIndex = 33;
			// 
			// EndTimePN
			// 
			this.EndTimePN.Controls.Add(this.EndTimeSpecifiedCB);
			this.EndTimePN.Controls.Add(this.EndTimeLB);
			this.EndTimePN.Controls.Add(this.EndTimeCTRL);
			this.EndTimePN.Dock = System.Windows.Forms.DockStyle.Top;
			this.EndTimePN.Location = new System.Drawing.Point(0, 72);
			this.EndTimePN.Name = "EndTimePN";
			this.EndTimePN.Size = new System.Drawing.Size(316, 24);
			this.EndTimePN.TabIndex = 34;
			// 
			// NamePN
			// 
			this.NamePN.Controls.Add(this.NameLB);
			this.NamePN.Controls.Add(this.NameTB);
			this.NamePN.Dock = System.Windows.Forms.DockStyle.Top;
			this.NamePN.Location = new System.Drawing.Point(0, 0);
			this.NamePN.Name = "NamePN";
			this.NamePN.Size = new System.Drawing.Size(316, 24);
			this.NamePN.TabIndex = 36;
			// 
			// AggregatePN
			// 
			this.AggregatePN.Controls.Add(this.AggregateLB);
			this.AggregatePN.Controls.Add(this.AggregateCB);
			this.AggregatePN.Controls.Add(this.AggregateSpecifiedCB);
			this.AggregatePN.Dock = System.Windows.Forms.DockStyle.Top;
			this.AggregatePN.Location = new System.Drawing.Point(0, 24);
			this.AggregatePN.Name = "AggregatePN";
			this.AggregatePN.Size = new System.Drawing.Size(316, 24);
			this.AggregatePN.TabIndex = 37;
			// 
			// StartTimePN
			// 
			this.StartTimePN.Controls.Add(this.StartTimeSpecifiedCB);
			this.StartTimePN.Controls.Add(this.StartTimeCTRL);
			this.StartTimePN.Controls.Add(this.StartTimeLB);
			this.StartTimePN.Dock = System.Windows.Forms.DockStyle.Top;
			this.StartTimePN.Location = new System.Drawing.Point(0, 48);
			this.StartTimePN.Name = "StartTimePN";
			this.StartTimePN.Size = new System.Drawing.Size(316, 24);
			this.StartTimePN.TabIndex = 38;
			// 
			// TimestampsPN
			// 
			this.TimestampsPN.Controls.Add(this.TimestampsCTRL);
			this.TimestampsPN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TimestampsPN.Location = new System.Drawing.Point(0, 240);
			this.TimestampsPN.Name = "TimestampsPN";
			this.TimestampsPN.Size = new System.Drawing.Size(316, 256);
			this.TimestampsPN.TabIndex = 39;
			// 
			// TimestampsCTRL
			// 
			this.TimestampsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TimestampsCTRL.Location = new System.Drawing.Point(0, 0);
			this.TimestampsCTRL.Name = "TimestampsCTRL";
			this.TimestampsCTRL.Size = new System.Drawing.Size(316, 256);
			this.TimestampsCTRL.TabIndex = 0;
			// 
			// TrendEditCtrl
			// 
			this.Controls.Add(this.TimestampsPN);
			this.Controls.Add(this.PlaybackPN);
			this.Controls.Add(this.SubscribePN);
			this.Controls.Add(this.ProcessedPN);
			this.Controls.Add(this.RawPN);
			this.Controls.Add(this.MaxValuesPN);
			this.Controls.Add(this.EndTimePN);
			this.Controls.Add(this.StartTimePN);
			this.Controls.Add(this.AggregatePN);
			this.Controls.Add(this.NamePN);
			this.Name = "TrendEditCtrl";
			this.Size = new System.Drawing.Size(316, 496);
			((System.ComponentModel.ISupportInitialize)(this.MaxValuesCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ResampleIntervalCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PlaybackDurationCTRL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PlaybackIntervalCTRL)).EndInit();
			this.PlaybackPN.ResumeLayout(false);
			this.SubscribePN.ResumeLayout(false);
			this.ProcessedPN.ResumeLayout(false);
			this.RawPN.ResumeLayout(false);
			this.MaxValuesPN.ResumeLayout(false);
			this.EndTimePN.ResumeLayout(false);
			this.NamePN.ResumeLayout(false);
			this.AggregatePN.ResumeLayout(false);
			this.StartTimePN.ResumeLayout(false);
			this.TimestampsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface
		/// <summary>
		/// Updates control visibility according the request type.
		/// </summary>
		public RequestType RequestType
		{
			get { return m_type; }
			set { m_type = value; SetState(m_type); }
		}

		/// <summary>
		/// Initializes the control with the specified trend.
		/// </summary>
		public void Initialize(TsCHdaTrend trend, RequestType type)
		{
			// set controls to default values.
			NameTB.Text                  = "";
			AggregateSpecifiedCB.Checked = false;
			StartTimeCTRL.Set(new TsCHdaTime("YEAR"));
			StartTimeSpecifiedCB.Checked = true;
			EndTimeCTRL.Set(new TsCHdaTime("YEAR+1H"));
			EndTimeSpecifiedCB.Checked   = true;
			MaxValuesCTRL.Value          = 0;
			IncludeBoundsCB.Checked      = false;
			ResampleIntervalCTRL.Value   = 0;
			UpdateIntervalCTRL.Value     = 0;
			PlaybackIntervalCTRL.Value   = 0;
			PlaybackDurationCTRL.Value   = 0;

			AggregateCB.Items.Clear();

			// update controls with trend properties.
			if (trend != null)
			{
				foreach (TsCHdaAggregate aggregate in trend.Server.Aggregates)
				{
					AggregateCB.Items.Add(aggregate);

					if (aggregate.Id == trend.Aggregate)
					{
						AggregateCB.SelectedItem = aggregate;
					}
				}

				NameTB.Text                  = trend.Name;
				AggregateSpecifiedCB.Checked = trend.Aggregate != TsCHdaAggregateID.NoAggregate;
				StartTimeCTRL.Set(trend.StartTime);
				StartTimeSpecifiedCB.Checked = trend.StartTime != null;
				EndTimeCTRL.Set(trend.EndTime);
				EndTimeSpecifiedCB.Checked   = trend.EndTime != null;
				MaxValuesCTRL.Value          = trend.MaxValues;
				IncludeBoundsCB.Checked      = trend.IncludeBounds;
				ResampleIntervalCTRL.Value   = trend.ResampleInterval;
				UpdateIntervalCTRL.Value     = trend.UpdateInterval;
				PlaybackIntervalCTRL.Value   = trend.PlaybackInterval;
				PlaybackDurationCTRL.Value   = trend.PlaybackDuration;

				TimestampsCTRL.Initialize(trend.Server, trend.Timestamps);
			}

			// update control visibility.
			RequestType = type;
		}
		
		/// <summary>
		/// Updates specified trend with values in the controls.
		/// </summary>
		public void Update(TsCHdaTrend trend)
		{
			trend.Name             = NameTB.Text;
			trend.Aggregate = TsCHdaAggregateID.NoAggregate;
			trend.StartTime        = StartTimeCTRL.Get();
			trend.EndTime          = EndTimeCTRL.Get();
			trend.MaxValues        = (int)MaxValuesCTRL.Value;
			trend.IncludeBounds    = IncludeBoundsCB.Checked;
			trend.ResampleInterval = ResampleIntervalCTRL.Value;
			trend.UpdateInterval   = UpdateIntervalCTRL.Value;
			trend.PlaybackInterval = PlaybackIntervalCTRL.Value;
			trend.PlaybackDuration = PlaybackDurationCTRL.Value;
			trend.Timestamps       = TimestampsCTRL.GetTimes();

			if (!StartTimeSpecifiedCB.Checked)
			{
				trend.StartTime = null;
			}

			if (!EndTimeSpecifiedCB.Checked)
			{
				trend.EndTime = null;
			}

			if (AggregateSpecifiedCB.Checked)
			{
				TsCHdaAggregate aggregate = (TsCHdaAggregate)AggregateCB.SelectedItem;

				if (aggregate != null)
				{
					trend.Aggregate = aggregate.Id;
				}
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Constants for unit labels.
		/// </summary>
		private const string SECONDS   = "Seconds";
		private const string INTERVALS = "Intervals";

		private RequestType m_type = RequestType.ReadRaw;

		private void SetState(RequestType type)
		{
			NamePN.Visible       = false;
			AggregatePN.Visible  = false;
			StartTimePN.Visible  = false;
			EndTimePN.Visible    = false;
			MaxValuesPN.Visible  = false;
			RawPN.Visible        = false;
			ProcessedPN.Visible  = false;
			SubscribePN.Visible  = false;
			PlaybackPN.Visible   = false;
			TimestampsPN.Visible = false;

			switch (type)
			{				
				case RequestType.None:
				{					
					NamePN.Visible      = true;
					AggregatePN.Visible = true;
					StartTimePN.Visible = true;
					EndTimePN.Visible   = true;
					MaxValuesPN.Visible = true;
					RawPN.Visible       = true;
					ProcessedPN.Visible = true;
					SubscribePN.Visible = true;
					PlaybackPN.Visible  = true;
					break;
				}

				case RequestType.ReadRaw:
				{					
					StartTimePN.Visible = true;
					EndTimePN.Visible   = true;
					MaxValuesPN.Visible = true;
					RawPN.Visible       = true;
					
					AggregateSpecifiedCB.Checked = false;
					break;
				}

				case RequestType.AdviseRaw:
				{					
					StartTimePN.Visible = true;
					SubscribePN.Visible = true;

					AggregateSpecifiedCB.Checked = false;
					StartTimeSpecifiedCB.Checked = true;
					StartTimeSpecifiedCB.Enabled = false;
					break;
				}

				case RequestType.PlaybackRaw:
				{					
					StartTimePN.Visible  = true;
					EndTimePN.Visible    = true;
					MaxValuesPN.Visible  = true;
					PlaybackPN.Visible   = true;

					AggregateSpecifiedCB.Checked = false;
					StartTimeSpecifiedCB.Checked = true;
					StartTimeSpecifiedCB.Enabled = false;
					break;
				}

				case RequestType.ReadProcessed:
				{					
					AggregatePN.Visible = true;
					StartTimePN.Visible = true;
					EndTimePN.Visible   = true;
					ProcessedPN.Visible = true;

					AggregateSpecifiedCB.Checked = true;
					break;
				}

				case RequestType.AdviseProcessed:
				{					
					AggregatePN.Visible = true;
					StartTimePN.Visible = true;
					ProcessedPN.Visible = true;
					SubscribePN.Visible = true;

					AggregateSpecifiedCB.Checked = true;
					break;
				}

				case RequestType.PlaybackProcessed:
				{					
					AggregatePN.Visible = true;
					StartTimePN.Visible = true;
					EndTimePN.Visible   = true;
					ProcessedPN.Visible = true;
					PlaybackPN.Visible  = true;

					AggregateSpecifiedCB.Checked = true;
					break;
				}

				case RequestType.ReadModified:
				{					
					StartTimePN.Visible = true;
					EndTimePN.Visible   = true;
					MaxValuesPN.Visible = true;

					AggregateSpecifiedCB.Checked = false;
					break;
				}

				case RequestType.ReadAtTime:
				case RequestType.DeleteAtTime:
				{
					TimestampsPN.Visible = true;
					break;
				}

				case RequestType.ReadAttributes:
				case RequestType.ReadAnnotations:
				case RequestType.DeleteRaw:
				{					
					StartTimePN.Visible = true;
					EndTimePN.Visible   = true;

					AggregateSpecifiedCB.Checked = false;
					StartTimeSpecifiedCB.Enabled = true;
					EndTimeSpecifiedCB.Enabled   = true;
					
					break;
				}
			}
		}
		#endregion

		/// <summary>
		/// Toggles the enabled state of various controls.
		/// </summary>
		private void TimeSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			StartTimeCTRL.Enabled = StartTimeSpecifiedCB.Checked;
			EndTimeCTRL.Enabled   = EndTimeSpecifiedCB.Checked;
		}

		/// <summary>
		/// Toggles between raw data and processed data modes.
		/// </summary>
		private void AggregateSpecifiedCB_CheckedChanged(object sender, System.EventArgs e)
		{
			if (AggregateSpecifiedCB.Checked)
			{
				MaxValuesCTRL.Enabled              = false;
				IncludeBoundsCB.Enabled            = false;
				AggregateCB.Enabled                = true;
				ResampleIntervalCTRL.Enabled       = true;
				StartTimeSpecifiedCB.Checked       = true;
				StartTimeSpecifiedCB.Enabled       = false;
				EndTimeSpecifiedCB.Checked         = true;
				EndTimeSpecifiedCB.Enabled         = false;
				UpdateIntervalCTRL.DecimalPlaces   = 0;
				UpdateIntervalUnitsLB.Text         = INTERVALS;
				PlaybackDurationCTRL.DecimalPlaces = 0;
				PlaybackDurationUnitsLB.Text       = INTERVALS;

				if (AggregateCB.SelectedIndex < 0 && AggregateCB.Items.Count > 0)
				{
					AggregateCB.SelectedIndex = 0;
				}
			}
			else
			{
				MaxValuesCTRL.Enabled              = true;
				IncludeBoundsCB.Enabled            = true;
				AggregateCB.Enabled                = false;
				ResampleIntervalCTRL.Enabled       = false;
				StartTimeSpecifiedCB.Enabled       = true;
				EndTimeSpecifiedCB.Enabled         = true;
				UpdateIntervalCTRL.DecimalPlaces   = 6;
				UpdateIntervalUnitsLB.Text         = SECONDS;
				PlaybackDurationCTRL.DecimalPlaces = 6;
				PlaybackDurationUnitsLB.Text       = SECONDS;
			}
		}
	}

	/// <summary>
	/// The set of possible operations for a trend.
	/// </summary>
	public enum RequestType
	{
		/// <summary>
		/// No specific request. All properties are used.
		/// </summary>
		None,

		/// <summary>
		/// A read raw or a read processed request.
		/// </summary>
		Read,

		/// <summary>
		/// A read raw data request.
		/// </summary>
		ReadRaw,

		/// <summary>
		/// A subscription for raw data.
		/// </summary>
		AdviseRaw,

		/// <summary>
		/// A request to playback raw data.
		/// </summary>
		PlaybackRaw,

		/// <summary>
		/// A read processed data request.
		/// </summary>
		ReadProcessed,

		/// <summary>
		/// A subscription for processed data.
		/// </summary>
		AdviseProcessed,

		/// <summary>
		/// A request to playback processed data.
		/// </summary>
		PlaybackProcessed,
		
		/// <summary>
		/// A read modified data request.
		/// </summary>
		ReadModified,
		
		/// <summary>
		/// A request to read data at specific times.
		/// </summary>
		ReadAtTime,

		/// <summary>
		/// A read attributes request.
		/// </summary>
		ReadAttributes,

		/// <summary>
		/// A read annotations request.
		/// </summary>
		ReadAnnotations,

		/// <summary>
		/// A insert annotations request.
		/// </summary>
		InsertAnnotations,
		
		/// <summary>
		/// An insert new data request.
		/// </summary>
		Insert,

		/// <summary>
		/// An insert new or replace existing data request.
		/// </summary>
		InsertReplace,

		/// <summary>
		/// A replace existing data request.
		/// </summary>
		Replace,

		/// <summary>
		/// A delete raw data request.
		/// </summary>
		DeleteRaw,

		/// <summary>
		/// A request to delete data at specific times.
		/// </summary>
		DeleteAtTime
	}
}
