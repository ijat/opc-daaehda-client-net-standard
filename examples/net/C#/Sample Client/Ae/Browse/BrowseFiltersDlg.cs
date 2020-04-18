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
	public class BrowseFiltersDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Label MaxElementsLB;
		private System.Windows.Forms.Label NameFilterLB;
		private System.Windows.Forms.TextBox NameFilterTB;
		private System.Windows.Forms.Button OkBTN;
		private System.Windows.Forms.NumericUpDown MaxElementsCTRL;
		private System.Windows.Forms.Button ApplyBTN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BrowseFiltersDlg()
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
			this.MaxElementsLB = new System.Windows.Forms.Label();
			this.NameFilterLB = new System.Windows.Forms.Label();
			this.NameFilterTB = new System.Windows.Forms.TextBox();
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.ApplyBTN = new System.Windows.Forms.Button();
			this.OkBTN = new System.Windows.Forms.Button();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.MaxElementsCTRL = new System.Windows.Forms.NumericUpDown();
			this.ButtonsPN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxElementsCTRL)).BeginInit();
			this.SuspendLayout();
			// 
			// MaxElementsLB
			// 
			this.MaxElementsLB.Location = new System.Drawing.Point(4, 32);
			this.MaxElementsLB.Name = "MaxElementsLB";
			this.MaxElementsLB.Size = new System.Drawing.Size(76, 20);
			this.MaxElementsLB.TabIndex = 3;
			this.MaxElementsLB.Text = "Max Elements";
			this.MaxElementsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameFilterLB
			// 
			this.NameFilterLB.Location = new System.Drawing.Point(4, 4);
			this.NameFilterLB.Name = "NameFilterLB";
			this.NameFilterLB.Size = new System.Drawing.Size(76, 20);
			this.NameFilterLB.TabIndex = 1;
			this.NameFilterLB.Text = "Name Filter";
			this.NameFilterLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NameFilterTB
			// 
			this.NameFilterTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.NameFilterTB.Location = new System.Drawing.Point(80, 4);
			this.NameFilterTB.Name = "NameFilterTB";
			this.NameFilterTB.Size = new System.Drawing.Size(216, 20);
			this.NameFilterTB.TabIndex = 2;
			this.NameFilterTB.Text = "";
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.ApplyBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 58);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(304, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// ApplyBTN
			// 
			this.ApplyBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.ApplyBTN.Location = new System.Drawing.Point(115, 8);
			this.ApplyBTN.Name = "ApplyBTN";
			this.ApplyBTN.TabIndex = 2;
			this.ApplyBTN.Text = "Apply";
			this.ApplyBTN.Click += new System.EventHandler(this.ApplyBTN_Click);
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
			this.CancelBTN.Location = new System.Drawing.Point(224, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// MaxElementsCTRL
			// 
			this.MaxElementsCTRL.Location = new System.Drawing.Point(80, 32);
			this.MaxElementsCTRL.Name = "MaxElementsCTRL";
			this.MaxElementsCTRL.TabIndex = 4;
			// 
			// BrowseFiltersDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBTN;
			this.ClientSize = new System.Drawing.Size(304, 94);
			this.Controls.Add(this.MaxElementsCTRL);
			this.Controls.Add(this.NameFilterTB);
			this.Controls.Add(this.ButtonsPN);
			this.Controls.Add(this.MaxElementsLB);
			this.Controls.Add(this.NameFilterLB);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(312, 128);
			this.MinimumSize = new System.Drawing.Size(312, 128);
			this.Name = "BrowseFiltersDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Browse Filters";
			this.ButtonsPN.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MaxElementsCTRL)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private event EventHandler m_FiltersChanged = null;
		#endregion

		#region Public Interface
		/// <summary>
		/// Raised when the apply button is clicked.
		/// </summary>
		public event EventHandler FiltersChanged
		{
			add    { m_FiltersChanged += value; }
			remove { m_FiltersChanged -= value; }
		}

		/// <summary>
		/// The current filter string.
		/// </summary>
		public string Filter
		{
			get { return NameFilterTB.Text;  }
			set { NameFilterTB.Text = value; }
		}

		/// <summary>
		/// The current max elements value.
		/// </summary>
		public int MaxElements
		{
			get { return (int)MaxElementsCTRL.Value;  }
			set { MaxElementsCTRL.Value = value;     }
		}

		/// <summary>
		/// Prompts the user to change the browse filter settings.
		/// </summary>
		public bool ShowDialog(ref string filter, ref int maxElements, EventHandler callback)
		{
			Filter      = filter;
			MaxElements = maxElements;

			if (callback != null)
			{
				FiltersChanged += callback;
			}

			if (ShowDialog() == DialogResult.OK)
			{
				filter      = Filter;
				maxElements = MaxElements;
				return true;
			}

			return false;
		}
		#endregion

		/// <summary>
		/// Invokes a callback if provided.
		/// </summary>
		private void ApplyBTN_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_FiltersChanged != null)
				{
					m_FiltersChanged(this, e);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Apply Browse Filters");
			}
		}
	}
}
