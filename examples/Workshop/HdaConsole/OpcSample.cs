#region Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved
// Web: https://technosoftware.com 
//
// Purpose:
//
//
// The Software is subject to the Technosoftware GmbH Software License Agreement,
// which can be found here:
// https://technosoftware.com /documents/Technosoftware_SLA.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2020 Technosoftware GmbH. All rights reserved

#region Using Directives

using System;
using OpcClientSdk;
using OpcClientSdk.Hda;
using OpcClientSdk.Da;

#endregion

namespace Technosoftware.HdaConsole
{

	/// <summary>
	/// Simple OPC HDA Client Application
	/// </summary>
	class OpcSample
	{

		#region Event Handlers

		/// <summary>
		/// Called when a read request completes.
		/// </summary>
		public void OnReadComplete(IOpcRequest request, TsCHdaItemValueCollection[] results)
		{
			Console.WriteLine("OnReadComplete():");

		}

		#endregion

		#region OPC Sample Functionality

		public void Run()
		{
			try
			{
				const string serverUrl = "opchda://localhost/OPCSample.OpcHdaServer";

				Console.WriteLine();
				Console.WriteLine("Simple OPC HDA Client based on the OPC DA/AE/HDA Client SDK .NET Standard");
				Console.WriteLine("----------------------------------------------------------------");
				Console.Write("   Press <Enter> to connect to "); Console.WriteLine(serverUrl);
				Console.ReadLine();
				Console.WriteLine("   Please wait...");

				//OpcBase.ValidateLicense("License Key");

				TsCHdaServer myHdaServer = new TsCHdaServer();

				myHdaServer.Connect(serverUrl);

				Console.WriteLine("   Connected, press <Enter> to add a trend.");
				Console.ReadLine();

                // Add a trend and set the properties for reading
                TsCHdaTrend trend = new TsCHdaTrend(myHdaServer) { StartTime = new TsCHdaTime(new DateTime(2004, 01, 01, 00, 00, 00)), EndTime = new TsCHdaTime(new DateTime(2004, 01, 01, 06, 00, 00)), IncludeBounds = true, MaxValues = 1000 };

				OpcItem itemID = new OpcItem("Static Data/Ramp [15 min]");

                trend.Timestamps.Add(new DateTime(2016, 01, 01, 00, 00, 00));
                OpcItemResult[] results = null;
				IOpcRequest request = null;

				results = trend.ReadRaw(new TsCHdaItem[] { trend.AddItem(itemID) }, null, new TsCHdaReadValuesCompleteEventHandler(OnReadComplete), out request);

				// read the historic data of the specified item
				TsCHdaItemValueCollection[] items = trend.ReadRaw(new TsCHdaItem[] { trend.AddItem(itemID) });
				foreach (TsCHdaItemValueCollection item in items)
				{
					Console.WriteLine(String.Format("{0}", item.ItemName));

					foreach (TsCHdaItemValue val in item)
					{
						if (((int)val.Quality.GetCode() & (int)TsDaQualityMasks.QualityMask) != (int)TsDaQualityBits.Good)
							Console.WriteLine(string.Format("      {0}, {1}", val.Timestamp, val.Quality));
						else
							Console.WriteLine(string.Format("      {0}, {1}", val.Timestamp, val.Value.ToString()));
					}
				}

                trend.Timestamps.Add(new DateTime(2016, 01, 01, 00, 00, 00));
                items = trend.ReadAtTime(new TsCHdaItem[] { trend.AddItem(itemID) });
                foreach (TsCHdaItemValueCollection item in items)
                {
                    Console.WriteLine(String.Format("{0}", item.ItemName));


                    foreach (TsCHdaItemValue val in item)
                    {
                        if (((int)val.Quality.GetCode() & (int)TsDaQualityMasks.QualityMask) != (int)TsDaQualityBits.Good)
                            Console.WriteLine(string.Format("      {0}, {1}", val.Timestamp, val.Quality));
                        else
                            Console.WriteLine(string.Format("      {0}, {1}", val.Timestamp, val.Value.ToString()));
                    }
                }
                Console.WriteLine("   Historical Data Trend read, press <Enter> to disconnect from the server.");
				myHdaServer.Disconnect(); 
                myHdaServer.Dispose();
				Console.ReadLine();
				Console.WriteLine("   Disconnected from the server.");
				Console.WriteLine();

			}
			catch (OpcResultException e)
			{
				Console.WriteLine("   " + e.Message);
				Console.ReadLine();
				return;
			}
			catch (Exception e)
			{
				Console.WriteLine("   " + e.Message);
				Console.ReadLine();
				return;
			}
		}

        #endregion
    }
}
