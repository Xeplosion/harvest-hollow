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

using WindowHelper.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowHelper.CommandLine
{
	public class ExtensionLexer
	{
		private const char MultiTokenChar = '"';

		private static HashSet<char> DiscardCharacters;

		private static readonly char[] AdditionalDiscardCharacters = new char[] { ' ' };

		private CharacterStream stream;
		private StringBuilder   tokenBuilder;

		static ExtensionLexer()
		{
			// Create discard characters
			CreateDiscardCharacters();
		}

		public ExtensionLexer(string input)
		{
			// Initialize the lexer
			stream       = new CharacterStream(input);
			tokenBuilder = new StringBuilder();
		}

		public List<string> Lex()
		{
			// Create a new list of tokens
			List<string> tokens = new List<string>();

			// Iterate until we reach the end of the stream
			while(!stream.EndOfStream)
			{
				// Peek a character in the stream
				char peekChar = stream.Peek();

				// Is the character one of the characters we can discard?
				if (DiscardCharacters.Contains(peekChar))
				{
					// Discard the character from the stream
					stream.Read();

					// Continue the iteration
					continue;
				}

				// Otherwise read a token from the stream
				string token = ReadToken();

				// Add the token to the list of tokens
				tokens.Add(token);
			}

			// Return the list of tokens
			return tokens;
		}

		private string ReadToken()
		{
			// Initialize variables
			bool tokenFound = false;
			bool quoteStart = false;

			// Iterate until we reach the end of the stream or we find a token
			while (!stream.EndOfStream && !tokenFound)
			{
				// Read a character from the stream
				char tokChar = stream.Read();

				// Determine if we have found the end of the token
				if ((DiscardCharacters.Contains(tokChar) && !quoteStart) || 
				   ((tokChar == MultiTokenChar) && quoteStart))
				{
					// The end of the token was found
					tokenFound = true;
					continue;
				}

				// Is the character a quote?
				else if (tokChar == MultiTokenChar)
				{
					// We are tracking a token which contains spaces
					quoteStart = true;
				}

				// Only add non control characters to the token
				else if (!Char.IsControl(tokChar))
				{
					// Add the character to the token builder
					tokenBuilder.Append(tokChar);
				}
			}

			// Get the built token
			string token = tokenBuilder.ToString();

			// Clear the token builder
			tokenBuilder.Clear();

			// Return the built token
			return token;
		}

		private static void CreateDiscardCharacters()
		{
			// Create discard characters table
			DiscardCharacters = new HashSet<char>(AdditionalDiscardCharacters);

			// Iterate through all of the control characters
			for (int count = Characters.ControlStart; count <= Characters.ControlEnd; count++)
			{
				// Add the control character to the discard characters
				DiscardCharacters.Add((char)count);
			}
		}
	}
}