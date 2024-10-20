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
	public class WhileLoop : CodeBlock
	{
		public CodeObject Condition { get; set; }

		public WhileLoop() : this(null) { }

		public WhileLoop(CodeObject condition)
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

			// Add indentation
			text.Append(GetIndentation(indentation));

			// Add start of loop
			text.Append(WhileKeyword + SpaceChar.ToString() + LeftParenthesisChar);

			// Is there a condition?
			if (Condition != null)
			{
				text.Append(Condition.GetString());
			}

			// Add right parenthesis
			text.Append(RightParenthesisChar);

			// Is there anything in the code block?
			if (Count != 0)
			{
				// Add newline
				text.Append(Environment.NewLine);

				// Print code block
				text.Append(base.GetString(indentation));
			}
			else
			{
				// Add statement terminator
				text.Append(StatementTerminator);
			}

			// Add newline
			text.Append(Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}