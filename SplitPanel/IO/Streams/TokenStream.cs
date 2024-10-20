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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowHelper.IO
{
	public class TokenStream : CommonStream
	{
		private const string NullSeparatorError = "The separator cannot be null.";
		private const string NullTokenError     = "The token cannot be null.";

		public static readonly string DefaultSeparator = " ";

		private int          position;
		private string       separator;
		private List<string> tokens;

		public TokenStream(IList<string> tokens = null) : this(tokens, DefaultSeparator) { }

		public TokenStream(IList<string> tokens, string separator)
		{
			// Initialize the stream
			this.separator = separator;
			this.tokens    = new List<string>(tokens ?? Enumerable.Empty<string>());
		}

		public void Initialize(IList<string> tokens)
		{
			// Remove all of the current tokens from the stream
			this.tokens.Clear();

			// Add the tokens to the stream
			Write(tokens);
		}

		public void Write(IList<string> tokens)
		{
			// Add the tokens to the stream
			this.tokens.AddRange(tokens);
		}

		public void Write(params string[] tokens)
		{
			// Add the tokens to the stream
			Write((IList<string>)tokens);
		}

		public string Peek()
		{
			// Verify the stream position
			VerifyStreamPosition();

			// Return the token at the current position without incrementing the position
			return tokens[position];
		}

		public string Read()
		{
			// Verify the stream position
			VerifyStreamPosition();

			// Return the token at the current stream position and increment the position
			return tokens[position++];
		}

		public override string ToString()
		{
			// Are there any tokens in the stream?
			if (tokens.Count == 0)
			{
				// There are no tokens in the stream
				return String.Empty;
			}

			// Create a new text builder
			StringBuilder text = new StringBuilder();

			// Iterate through all of the tokens in the stream but the last one
			for (int count = 0; count < (tokens.Count - 1); count++)
			{
				// Add the token to the text with a separator
				text.Append(tokens[count] + separator);
			}

			// Add the last token to the text without a separator
			text.Append(tokens[(tokens.Count - 1)]);

			// Return the built text
			return text.ToString();
		}

		public override long Length
		{
			get { return tokens.Count; }
		}

		public override long Position
		{
			get { return position; }
			set { throw new InvalidOperationException(); }
		}

		public string Separator
		{
			get { return separator; }
			set
			{
				// Set the separator value
				separator = value ?? throw new Exception(NullSeparatorError);
			}
		}
	}
}