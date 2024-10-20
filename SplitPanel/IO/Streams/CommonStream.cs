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

using System;
using System.IO;

namespace WindowHelper.IO
{
	public abstract class CommonStream : Stream
	{
		public override void Flush()
		{
			// The stream does not support flushing
			throw new InvalidOperationException();
		}

		public override void SetLength(long value)
		{
			// The stream does not support setting of the length
			throw new InvalidOperationException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			// The stream does not support seeking
			throw new InvalidOperationException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			// The stream does not support writing
			throw new InvalidOperationException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			// The stream does not support reading
			throw new InvalidOperationException();
		}

		protected void VerifyStreamPosition(int lookAhead = 1)
		{
			// Determine if we will reach the end of the stream if we perform the operation
			if ((Position + lookAhead) > Length)
			{
				// The end of the stream will be reached if the operation is performed
				throw new EndOfStreamException();
			}
		}

		public override bool CanRead
		{
			get { return false; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public virtual bool EndOfStream
		{
			get { return (Position == Length); }
		}
	}
}