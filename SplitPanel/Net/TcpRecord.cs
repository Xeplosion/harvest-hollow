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
using System.Net.NetworkInformation;

namespace WindowHelper.Net
{
	public struct TcpRecord
	{
		public uint       PID            { get; private set; }
		public TcpState   State          { get; private set; }
		public IPEndPoint LocalEndpoint  { get; private set; }
		public IPEndPoint RemoteEndpoint { get; private set; }

		internal TcpRecord(NativeTcp.TcpTableRow row)
		{
			// Initialize the record data
			PID            = row.PID;
			State          = row.State;
			LocalEndpoint  = new IPEndPoint(row.LocalAddress, NetworkOrderPortToPort(row.LocalPort));
			RemoteEndpoint = new IPEndPoint(row.RemoteAddress, NetworkOrderPortToPort(row.RemotePort));
		}

		private static ushort NetworkOrderPortToPort(ushort port)
		{
			// The port is in network byte order, so we need to convert it
			return (ushort)(((port & 0xFF) << 8) | ((port & 0xFF00) >> 8));
		}
	}
}