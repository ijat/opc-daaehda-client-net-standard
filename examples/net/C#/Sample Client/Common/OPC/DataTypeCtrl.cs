//============================================================================
// TITLE: DataTypeCtrl.cs
//
// CONTENTS:
// 
// A control used to select a well known data type.
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
// 2003/04/09 RSA   Initial implementation.

using System;
using System.ComponentModel;

namespace OpcClientSdk.Controls
{
	/// <summary>
	/// Used to receive data type changed notifications.
	/// </summary>
	public delegate void DataTypeChangedCallback(System.Type type);

	/// <summary>
	/// A control used to select a well known data type.
	/// </summary>
	public class DataTypeCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ComboBox DataTypeCB;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataTypeCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			m_types = OpcClientSdk.OpcType.Enumerate();

			foreach (System.Type type in m_types)
			{
				DataTypeCB.Items.Add(type.Name);
			}

			DataTypeCB.SelectedIndex = -1;
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
			this.DataTypeCB = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// DataTypeCB
			// 
			this.DataTypeCB.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.DataTypeCB.Name = "DataTypeCB";
			this.DataTypeCB.Size = new System.Drawing.Size(112, 21);
			this.DataTypeCB.TabIndex = 0;
			this.DataTypeCB.SelectedValueChanged += new System.EventHandler(this.DataTypeCB_SelectedValueChanged);
			// 
			// DataTypeCtrl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.DataTypeCB});
			this.Name = "DataTypeCtrl";
			this.Size = new System.Drawing.Size(112, 24);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// A list of known data types.
		/// </summary>
		public System.Type[] m_types = null;

		/// <summary>
		/// Raised when the data type changes.
		/// </summary>
		public event DataTypeChangedCallback DataTypeChanged = null;

		/// <summary>
		/// Whether the control is read only.
		/// </summary>
		public bool ReadOnly {set{ DataTypeCB.Enabled = !value; }}

		/// <summary>
		/// Gets or sets the selected data type.
		/// </summary>
		[Browsable(false)]
		public System.Type SelectedType
		{
			get
			{
				if (DataTypeCB.SelectedIndex >= 0) 
				{
					return m_types[DataTypeCB.SelectedIndex];
				}

				return null;
			}

			set
			{
				for (int ii = 0; ii < m_types.Length; ii++)
				{
					if (value == m_types[ii])
					{
						DataTypeCB.SelectedIndex = ii;
						return;
					}
				}

				DataTypeCB.SelectedIndex = -1;
			}
		}
	
		/// <summary>
		/// Called when the selected data type changes.
		/// </summary>
		private void DataTypeCB_SelectedValueChanged(object sender, EventArgs e)
		{
			if (DataTypeChanged != null)
			{
				DataTypeChanged(SelectedType);
			}
		}
	}
}
