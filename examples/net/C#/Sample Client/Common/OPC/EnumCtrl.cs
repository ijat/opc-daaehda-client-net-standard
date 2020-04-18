//============================================================================
// TITLE: EnumCtrl.cs
//
// CONTENTS:
// 
// A control used to select a valid value for any enumeration.
//
// (c) Copyright 2002-2003 The OPC Foundation
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
// 2002/09/03 RSA   First release.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace OpcClientSdk.Controls
{
	/// <summary>
	/// A control used to select a valid value for any enumeration.
	/// </summary>
	public class EnumCtrl : System.Windows.Forms.UserControl
	{ 
		private System.Windows.Forms.ComboBox EnumCB;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip ToolTips;

		// the type of the OpcEnumCtrl displayed
		object m_value = null;

		public EnumCtrl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		// provides access to the underlying combo box.
		public ComboBox Control {get{return EnumCB;}}

		/// <summary>
		/// Called when the value in the control changes.
		/// </summary>
		public event ValueChangedCallback ValueChanged = null;

		// sets the OpcEnumCtrl type used by the combo box
		[Browsable(false)]
		public object Value
		{
			get 
			{
				if (m_value == null)
				{
					return null;
				}

				return EnumCB.SelectedItem;
			}

			set {m_value = value; UpdateView();}
		}

		// update the combo box
		private void UpdateView()
		{
			EnumCB.Items.Clear();

			// check if an enum type was specified 
			if (m_value == null)
			{
				return;
			}

			// add the OpcEnumCtrl value to the drop dowwnlist
			Array values = Enum.GetValues(m_value.GetType());

			foreach (object enumValue in values)
			{
				EnumCB.Items.Add(enumValue);
			}

			// set to the current value
			EnumCB.SelectedItem = m_value;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
		
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.EnumCB = new System.Windows.Forms.ComboBox();
			this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// EnumCB
			// 
			this.EnumCB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EnumCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EnumCB.Location = new System.Drawing.Point(0, 0);
			this.EnumCB.Name = "EnumCB";
			this.EnumCB.Size = new System.Drawing.Size(152, 21);
			this.EnumCB.TabIndex = 0;
			this.EnumCB.SelectedIndexChanged += new System.EventHandler(this.EnumCB_SelectedIndexChanged);
			// 
			// EnumCtrl
			// 
			this.Controls.Add(this.EnumCB);
			this.Name = "EnumCtrl";
			this.Size = new System.Drawing.Size(152, 24);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles a change to the value.
		/// </summary>
		private void EnumCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			if (EnumCB.SelectedItem != null)
			{
				if (ValueChanged != null)
				{
					ValueChanged(this, EnumCB.SelectedItem);
				}
			}
		}
	}
}
  