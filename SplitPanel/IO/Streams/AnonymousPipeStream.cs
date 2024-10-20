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
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowHelper.IO
{
	public class AnonymousPipeStream : Stream, IDisposable
	{
		public FileStream BaseReadStream  { get; private set; }
		public FileStream BaseWriteStream { get; private set; }

		private bool disposed;

		public AnonymousPipeStream()
		{
			// Initialize the stream
			Initialize();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			// Seeking is not supported
			throw new InvalidOperationException();
		}

		public override void SetLength(long value)
		{
			// Setting the length of the stream is not supported
			throw new InvalidOperationException();
		}

		public override void Flush()
		{
			// Flush the pipe write stream
			BaseWriteStream.Flush();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			// Perform a write on the pipe write stream
			BaseWriteStream.Write(buffer, offset, count);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			// Perform a read on the pipe read stream
			return BaseReadStream.Read(buffer, offset, count);
		}

		protected override void Dispose(bool disposing)
		{
			// Has the stream been disposed?
			if (disposed)
			{
				// The stream has already been disposed
				return;
			}

			// Are we disposing the stream?
			else if (disposing)
			{
				// Dispose of the pipe file streams
				BaseReadStream.Dispose();
				BaseWriteStream.Dispose();
			}

			// The stream is now disposed
			disposed = true;
		}

		private void Initialize()
		{
			IntPtr hReadPipe;
			IntPtr hWritePipe;

			// Create pipe security attributes
			NativeCore.SecurityAttributes attr = new NativeCore.SecurityAttributes();
			attr.Length                  = Marshal.SizeOf(typeof(NativeCore.SecurityAttributes));
			attr.InheritHandle           = NativeCore.True;

			// Create a new pipe
			NativePipes.CreatePipe(out hReadPipe, out hWritePipe, ref attr);

			// Create the pipe file streams
			BaseReadStream  = new FileStream(new SafeFileHandle(hReadPipe, true), FileAccess.Read);
			BaseWriteStream = new FileStream(new SafeFileHandle(hWritePipe, true), FileAccess.Write);
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override long Length
		{
			get { throw new InvalidOperationException(); }
		}

		public override long Position
		{
			get { throw new InvalidOperationException(); }
			set { throw new InvalidOperationException(); }
		}
	}
}