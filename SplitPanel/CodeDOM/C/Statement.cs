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
	public class Statement : CodeObject
	{
		public CodeObject Value { get; set; }

		public Statement(CodeObject value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text
			StringBuilder text = new StringBuilder();

			// Is there a value?
			if (Value != null)
			{
				// Print code value
				text.Append(Value.GetString(indentation));
			}

			// Add statement terminator
			text.Append(StatementTerminator + Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}