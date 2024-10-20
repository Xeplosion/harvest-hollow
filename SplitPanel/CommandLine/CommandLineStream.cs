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
using System.IO;
using System.Linq;

namespace WindowHelper.CommandLine
{
	public class CommandLineStream : TokenStream
	{
		private const string StreamErrorFormat          = "Unexpectedly reached the end of the command line when trying to parse the option associated with the switch: {0}.";
		private const string ParseErrorFormat           = "There was a problem parsing the option associated with the: {0} switch: {1}";
		private const string RequiredOptionsErrorFormat = "The following command line switches are required for program operation: {0}.";
		private const string DuplicateSetErrorFormat    = "The option associated with the: {0} switch has already been set once from the command line and cannot be set again.";
		private const string GenericErrorFormat         = "Input: \"{0}\", Error: {1}";
		private const string BoolArgumentError          = "Could not recognize the input argument.";
		private const string EnumArgumentError          = "Could not recognize the input argument.";

		private static readonly string RequiredSwitchesSeparator = (", ");

		private static readonly char[] EnumSplitChars = new char[] { ',', ' ' };

		private static readonly Dictionary<string, bool> ExplicitBoolValues = new Dictionary<string, bool>()
		{
			{ "false", false},
			{ "0", false },
			{ "true", true },
			{ "1", true }
		};

		public CommandLineStream() : base(null) { }

		public T Parse<T>(IList<string> args) where T : UserOptions
		{
			// Create a new option collection
			OptionCollection<T> options     = new OptionCollection<T>();
			T                   userOptions = options.UserOptions;

			// Initialize the token stream
			Initialize(args);

			// Iterate through the token stream
			while (!EndOfStream)
			{
				// Read a token from the stream
				string token = Read();

				// Is the token associated with an option?
				if (!options.ContainsKey(token))
				{
					// The token is unrecognized
					userOptions.UnregognizedToken(this, token);

					// Continue the iteration
					continue;
				}

				// Is the option required?
				else if (options.RequiredOptions.ContainsKey(token))
				{
					// Remove the required option from the collection
					options.RequiredOptions.Remove(token);
				}

				// Get the option associated with the token
				Option option = options[token];

				// Verify the option is valid
				if (!option.AllowMultiple && option.HasValue)
				{
					// The option cannot be set multiple times
					throw new Exception(String.Format(DuplicateSetErrorFormat, token));
				}

				try
				{
					// Parse the option
					option.Parse(this);
				}
				catch(EndOfStreamException e)
				{
					// We reached the end of the stream
					throw new Exception(String.Format(StreamErrorFormat, token));
				}
				catch(Exception e)
				{
					// There was a problem parsing the option
					throw new Exception(String.Format(ParseErrorFormat, token, e.Message));
				}
			}

			// Verify required switches
			VerifyRequiredSwitches(options);

			// Notify the user options class that parsing has completed
			userOptions.ParseComplete();

			// Return the generated options
			return userOptions;
		}

		public bool ReadBool()
		{
			// Read the input from the stream
			string boolArg = Read().ToLower();

			// Is the argument valid?
			if (!ExplicitBoolValues.ContainsKey(boolArg))
			{
				// The argument is not valid
				throw new Exception(String.Format(GenericErrorFormat, boolArg, BoolArgumentError));
			}

			// Return the bool value
			return ExplicitBoolValues[boolArg];
		}

		public T ReadEnum<T>()
		{
			// An enum can be parsed using a comma separated list, which we don't want to allow, so we split the argument on any commas
			string enumArg = Read().Split(EnumSplitChars, StringSplitOptions.RemoveEmptyEntries)[0];

			try
			{
				// Parse the enumeration value
				return (T)Enum.Parse(typeof(T), enumArg, true);
			}
			catch (Exception e)
			{
				// The enum argument is not valid
				throw new Exception(String.Format(GenericErrorFormat, enumArg, EnumArgumentError));
			}
		}

		public T ReadNumber<T>()
		{
			// Read the input from the stream
			string input = Read();

			try
			{
				// Parse the numeric value
				return NumericValue.Parse<T>(input);
			}
			catch(Exception e)
			{
				// There was a problem parsing the number
				throw new Exception(String.Format(GenericErrorFormat, input, e.Message));
			}
		}

		public string ReadPath()
		{
			// Read the next token from the stream
			string path = Read();

			try
			{
				// Resolve the path
				return FileUtils.ResolvePath(path);
			}
			catch(Exception e)
			{
				// The input path could not be resolved
				throw new Exception(String.Format(GenericErrorFormat, path, e.Message));
			}
		}

		public string ReadExtension()
		{
			// Resolve the filepath to the extension file
			string filepath = ReadPath();

			// Read the extension file data
			string input = ReadFileData(filepath);

			// Create a new lexer for the input text
			ExtensionLexer lexer = new ExtensionLexer(input);

			// Lex the input
			List<string> tokens = lexer.Lex();

			// Write the new tokens to the stream
			Write(tokens);

			// Return the extension filepath
			return filepath;
		}

		private string ReadFileData(string filepath)
		{
			try
			{
				// Read all of the file text
				return File.ReadAllText(filepath);
			}
			catch (Exception e)
			{
				// Could not read the file
				throw new Exception(String.Format(GenericErrorFormat, filepath, e.Message));
			}
		}

		private void VerifyRequiredSwitches<T>(OptionCollection<T> options) where T : UserOptions
		{
			// Get the required switches
			Dictionary<string, Option> reqOptions = options.RequiredOptions;

			// Are there any switches that get not get set on the command line?
			if (reqOptions.Count == 0)
			{
				// All options were set
				return;
			}

			// Create a new token stream for the required options
			TokenStream tokens = new TokenStream(reqOptions.Keys.ToList(), RequiredSwitchesSeparator);

			// Print the exception message
			throw new Exception(String.Format(RequiredOptionsErrorFormat, tokens));
		}
	}
}