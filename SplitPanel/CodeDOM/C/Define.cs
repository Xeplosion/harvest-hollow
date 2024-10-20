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
	public class Define : CodeObject
	{
		private const string DefaultNameFmt = "{0}";

		public bool       ValueParenthesis { get; set; }
		public string     Name             { get; set; }
		public string     NameFormat       { get; set; }
		public CodeObject Value            { get; set; }

		public Define(bool valueParenthesis = false) : this(String.Empty, null, valueParenthesis) { }

		public Define(string name, CodeObject value = null, bool valueParenthesis = false)
		{
			Name             = name;
			Value            = value;
			ValueParenthesis = valueParenthesis;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text
			StringBuilder text = new StringBuilder();

			// Get name format
			string nameFmt = (!String.IsNullOrEmpty(NameFormat) ? NameFormat : DefaultNameFmt);

			// Get name
			string name = ((Name != null) ? Name : String.Empty);

			// Add define string
			text.Append(GetIndentation(indentation) + PoundChar + DefineKeyword + SpaceChar);

			// Add name
			text.Append(String.Format(nameFmt, name));

			// Is there a value?
			if (Value != null)
			{
				// Add space
				text.Append(SpaceChar);

				// Add left parenthesis
				if (ValueParenthesis)
				{
					text.Append(LeftParenthesisChar);
				}

				// Print value
				text.Append(Value.GetString());

				// Add right parenthesis
				if (ValueParenthesis)
				{
					text.Append(RightParenthesisChar);
				}
			}

			// Add newline
			text.Append(Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}