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
	public class IfNotDefined : CodeObject
	{
		public bool       ConditionParenthesis { get; set; }
		public CodeObject Condition            { get; set; }

		public IfNotDefined(CodeObject condition)
		{
			Condition = condition;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text
			StringBuilder text = new StringBuilder();

			// Add indentation and pragma
			text.Append(GetIndentation(indentation) + PoundChar + IfNotDefinedKeyword + SpaceChar);

			// Are we adding parenthesis?
			if (ConditionParenthesis)
			{
				// Add left parenthesis
				text.Append(LeftParenthesisChar);
			}

			// Is there a condition?
			if (Condition != null)
			{
				// Add condition
				text.Append(Condition.GetString());
			}

			// Are we adding parenthesis?
			if (ConditionParenthesis)
			{
				// Add right parenthesis
				text.Append(RightParenthesisChar);
			}

			// Add newline
			text.Append(Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}