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

namespace WindowHelper.CodeDOM.C
{
	public class FunctionReference : CodeObject
	{
		private const string DefaultPrintFmt = "{0}";

		public string   Name        { get; set; }
		public string   PrintFormat { get; set; }
		public Function Function    { get; set; }

		public FunctionReference(string name)
		{
			Name = name;
		}

		public FunctionReference(Function function)
		{
			Function = function;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Get print format
			string printFmt = (!String.IsNullOrEmpty(PrintFormat) ? PrintFormat : DefaultPrintFmt);

			// Get name
			string funcName = (((Function != null) && (Function.Name != null)) ? Function.Name : ((Name != null) ? Name : String.Empty));

			// Print function name
			return (GetIndentation(indentation) + String.Format(printFmt, funcName));
		}
	}
}