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
using System.Text;

namespace WindowHelper.CodeDOM.C
{
	public class TypeCast : CodeObject
	{
		public CodeType   Cast  { get; set; }
		public CodeObject Value { get; set; }

		public TypeCast(CodeType cast, CodeObject value)
		{
			Cast  = cast;
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

			// Add indentation and left parenthesis
			text.Append(GetIndentation(indentation) + LeftParenthesisChar);

			// Is there a cast?
			if (Cast != null)
			{
				// Add cast
				text.Append(Cast.GetString());
			}

			// Add right parenthesis
			text.Append(RightParenthesisChar);

			// Is there a value?
			if (Value != null)
			{
				// Add value
				text.Append(Value.GetString());
			}

			// Return text
			return text.ToString();
		}
	}
}