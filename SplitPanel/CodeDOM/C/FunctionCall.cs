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
using System.Text;

namespace WindowHelper.CodeDOM.C
{
	public class FunctionCall : CodeObject
	{
		private const string DefaultPrintFmt = "{0}";

		public string           Name        { get; set; }
		public string           PrintFormat { get; set; }
		public Function         Function    { get; set; }
		public List<CodeObject> Parameters  { get; private set; }

		public FunctionCall(string name) : this()
		{
			Name = name;
		}

		public FunctionCall(Function function) : this()
		{
			Function = function;
		}

		private FunctionCall()
		{
			Parameters = new List<CodeObject>();
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text
			StringBuilder text = new StringBuilder();

			// Get print format
			string printFmt = (!String.IsNullOrEmpty(PrintFormat) ? PrintFormat : DefaultPrintFmt);

			// Get name
			string funcName = (((Function != null) && (Function.Name != null)) ? Function.Name : ((Name != null) ? Name : String.Empty));

			// Print function name and starting parenthesis
			text.Append(GetIndentation(indentation) + String.Format(printFmt, funcName) + LeftParenthesisChar);

			// Iterate through parameters
			for (int count = 0; count < Parameters.Count; count++)
			{
				// Print parameter
				text.Append(Parameters[count].GetString());

				// Is this the last parameter?
				if (count < (Parameters.Count - 1))
				{
					// Print comma separator
					text.Append(CommaChar.ToString() + SpaceChar);
				}
			}

			// Add ending parenthesis
			text.Append(RightParenthesisChar);

			// Return text
			return text.ToString();
		}
	}
}