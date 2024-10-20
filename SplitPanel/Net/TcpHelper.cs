// ------------------------------------------------------
// ---------- Copyright (c) 2017 Colton Murphy ----------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------
// ------------------------------------------------------

using WindowHelper.Native.Win32;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace WindowHelper.Net
{
	public static class TcpHelper
	{
		public const ushort MinPort     = 0;
		public const ushort MaxPort     = ushort.MaxValue;
		public const ushort InvalidPort = MinPort;

		private const int UniquePort      = 0;
		private const int EndpointTokens  = 5;
		private const int IPAddressTokens = 4;

		private static readonly char[] EndpointSplitCharacters = new char[] { '.', ':' };

		public static IPEndPoint GetUniqueEndpoint(IPAddress address)
		{
			// Create the IP endpoint
			TcpListener listener = new TcpListener(address, UniquePort);

			// Start the listener to bind to a uniqe port
			listener.Start();

			// Get the endpoint assigned to the listener
			IPEndPoint endpoint = (IPEndPoint)listener.LocalEndpoint;

			// Stop the listener to unbind from the port
			listener.Stop();

			// Return the endpoint
			return endpoint;
		}

		public static IPEndPoint StringToEndpoint(string input)
		{
			// Split the input text into tokens
			string[] tokens = input.Split(EndpointSplitCharacters, StringSplitOptions.RemoveEmptyEntries);

			// Do we have the proper number of IP tokens?
			if (tokens.Length != EndpointTokens)
			{
				// The input is not a valid IP address
				throw new FormatException();
			}

			// Create IP address byte array
			byte[] IPData = new byte[IPAddressTokens];

			// Iterate through all of the IP tokens
			for (int count = 0; count < IPAddressTokens; count++)
			{
				// Convert the IP token
				IPData[count] = Convert.ToByte(tokens[count]);
			}

			// Convert the port token
			ushort port = Convert.ToUInt16(tokens[(EndpointTokens - 1)]);

			// Create a new server endpoint
			return new IPEndPoint(new IPAddress(IPData), port);
		}

		public static List<TcpRecord> GetAllConnections()
		{
			// Create a new list of TCP records
			List<TcpRecord> records = new List<TcpRecord>();

			// Initialize table size
			int tableSize = 0;

			// Get the size of the Tcp table
			NativeTcp.GetExtendedTcpTable(IntPtr.Zero, ref tableSize, false, AddressFamily.InterNetwork, NativeTcp.TcpTableClass.OwnerPIDAll);

			// Allocate memory for the record table
			IntPtr memoryPtr = Marshal.AllocHGlobal(tableSize * 2);

			// Populate the Tcp table memory with the Tcp inforamtion
			NativeTcp.GetExtendedTcpTable(memoryPtr, ref tableSize, false, AddressFamily.InterNetwork, NativeTcp.TcpTableClass.OwnerPIDAll);

			// Get the number of entries and initialize table row pointer
			uint   entries     = (uint)Marshal.ReadInt32(memoryPtr);
			IntPtr tableRowPtr = (IntPtr)((long)memoryPtr + sizeof(uint));

			// Iterate through table rows
			for (int count = 0; count < entries; count++)
			{
				// Get the table row
				NativeTcp.TcpTableRow row = (NativeTcp.TcpTableRow)Marshal.PtrToStructure(tableRowPtr, typeof(NativeTcp.TcpTableRow));

				// Create a new Tcp record
				records.Add(new TcpRecord(row));

				// Update the table row pointer
				tableRowPtr = (IntPtr)((long)tableRowPtr + Marshal.SizeOf(row));
			}

			// Free the record table memory
			Marshal.FreeHGlobal(memoryPtr);

			// Return the list of records
			return records;
		}
	}
}