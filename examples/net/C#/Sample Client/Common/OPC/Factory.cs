//============================================================================
// TITLE: Opc.SampleClient.Factory.cs
//
// CONTENTS:
// 
// A interface and a class used to instantiate server objects.
//
// (c) Copyright 2003-2004 The OPC Foundation
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
// 2003/08/18 RSA   Initial implementation.

using System;
using System.Xml;
using System.Net;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;

using OpcClientSdk.Ae;
using OpcClientSdk.Da;
using OpcClientSdk.Hda;

namespace OpcClientSdk.Controls
{
	/// <summary>
	/// Defines utility functions used to instantiate servers.
	/// </summary>
	public class Factory
	{		
		/// <summary>
		/// Creates a server object for the specified URL.
		/// </summary>
		public static OpcServer GetServerForURL(OpcUrl url)
		{
			if (url == null) throw new ArgumentNullException("url");

			OpcServer server = null;

			// create an unconnected server object for XML based servers.
			if (url.Scheme == OpcUrlScheme.HTTP)
			{
                new NotSupportedException("XML not supported with .NET 4.6 and later.");
			}

			// create an unconnected server object for COM based servers.
			else
			{
				// DA
				if (url.Scheme == OpcUrlScheme.DA)  
				{ 
					server = new TsCDaServer(new Com.Factory(), url); 
				}

				// AE
				else if (url.Scheme == OpcUrlScheme.AE)  
				{ 
					server = new TsCAeServer(new Com.Factory(), url); 
				}

				// HDA
				else if (url.Scheme == OpcUrlScheme.HDA) 
				{ 
					server = new TsCHdaServer(new Com.Factory(), url); 
				}

				// Other specifications not supported yet.
				else
				{
					throw new NotSupportedException(url.Scheme);
				}
			}

			return server;
		}
	}
}
