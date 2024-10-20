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
using System.Reflection;

namespace WindowHelper.CommandLine
{
	internal class Option
	{
		private const string FunctionResolveErrorFormat = "There was a problem resolving the parse function: {0}. Make sure the method signature is valid.";

		private delegate void ParseFunctionDelegate(CommandLineStream stream);
		
		public bool        HasValue      { get; private set; }
		public bool        Required      { get; private set; }
		public bool        AllowMultiple { get; private set; }
		public string      Switch        { get; private set; }
		public UserOptions UserOptions   { get; private set; }

		private ParseFunctionDelegate ParseFunction;

		public Option(UserOptions userOptions, MethodInfo method, ParseFunctionAttribute attr)
		{
			// Initialize option properties
			Required      = attr.Required;
			AllowMultiple = attr.AllowMultiple;
			Switch        = attr.Switch;
			UserOptions   = userOptions;

			// Resolve the parse function
			ResolveParseFunction(method);
		}

		public void Parse(CommandLineStream stream)
		{
			// Execute the parse function
			ParseFunction(stream);
		}

		private void ResolveParseFunction(MethodInfo method)
		{
			try
			{
				// Create the parse function from the method
				ParseFunction = (ParseFunctionDelegate)Delegate.CreateDelegate(typeof(ParseFunctionDelegate), UserOptions, method, true);
			}
			catch(Exception e)
			{
				// The parse function could not be resolved
				throw new Exception(String.Format(FunctionResolveErrorFormat, method.Name));
			}
		}
	}
}