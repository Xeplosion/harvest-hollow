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
	public class NewlineItem : CodeObject
	{
		public int Newlines { get; set; }

		public NewlineItem(int newlines = 1)
		{
			Newlines = newlines;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text buffer
			StringBuilder text = new StringBuilder();

			// Get number of newlines
			int newlines = ((Newlines > 0) ? Newlines : 0);

			// Iterate through newlines
			for (int count = 0; count < newlines; count++)
			{
				// Add newline
				text.Append(Environment.NewLine);
			}

			// Return text
			return text.ToString();
		}
	}
}