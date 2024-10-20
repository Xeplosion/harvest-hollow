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
	public class CharacterStream : CommonStream
	{
		private int    position;
		private string input;

		public CharacterStream(string input)
		{
			// Initialize the stream
			this.input = input;
		}

		public char Peek()
		{
			// Verify the stream position
			VerifyStreamPosition();

			// Return the character at the current position without incrementing the position
			return input[position];
		}

		public char Read()
		{
			// Verify the stream position
			VerifyStreamPosition();

			// Return the character at the current stream position and increment the position
			return input[position++];
		}

		public override long Length
		{
			get { return input.Length; }
		}

		public override long Position
		{
			get { return position; }
			set { throw new InvalidOperationException(); }
		}
	}
}