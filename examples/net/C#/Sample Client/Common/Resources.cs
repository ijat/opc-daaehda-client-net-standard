//============================================================================
// TITLE: Resources.cs
//
// CONTENTS:
// 
// A class that defines resource constants such as image indexes.
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
// 2002/11/16 RSA   First release.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpcClientSdk.Controls
{
	/// <summary>
	/// A class that defines resource constants such as image indexes.
	/// </summary>
	public class Resources : System.Windows.Forms.Form
	{
		public System.Windows.Forms.ImageList ToolBarImageList;
		public System.Windows.Forms.ImageList ImageList;

		private System.ComponentModel.IContainer components;

		public Resources()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Resources));
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.ToolBarImageList = new System.Windows.Forms.ImageList(this.components);
			// 
			// ImageList
			// 
			this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
			this.ImageList.TransparentColor = System.Drawing.Color.Teal;
			// 
			// ToolBarImageList
			// 
			this.ToolBarImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.ToolBarImageList.ImageSize = new System.Drawing.Size(16, 18);
			this.ToolBarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ToolBarImageList.ImageStream")));
			this.ToolBarImageList.TransparentColor = System.Drawing.Color.Teal;
			// 
			// Resources
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Resources";
			this.Text = "Resources";

		}
		#endregion

		// global constants
		public static readonly int IMAGE_CLOSED_YELLOW_FOLDER  = 0;
		public static readonly int IMAGE_OPEN_YELLOW_FOLDER    = 1;
		public static readonly int IMAGE_GREEN_SCROLL          = 2;
		public static readonly int IMAGE_EXPLODING_BOX         = 3;
		public static readonly int IMAGE_CLOSED_BLUE_FOLDER    = 4;
		public static readonly int IMAGE_OPEN_BLUE_FOLDER      = 5;
		public static readonly int IMAGE_ENVELOPE              = 6;
		public static readonly int IMAGE_HIGHLIGHTED_ENVELOPE  = 7;
		public static readonly int IMAGE_LIST_BOX              = 8;
		public static readonly int IMAGE_YELLOW_SCROLL         = 9;
		public static readonly int IMAGE_LOCAL_COMPUTER        = 10;
		public static readonly int IMAGE_LOCAL_NETWORK         = 11;
		public static readonly int IMAGE_LOCAL_SERVER          = 12;

		public static Resources Instance = new Resources();
	}
}
