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
	public class SectionEnd : CodeObject
	{
		private const string PrintFmt = "__section_end(\"{0}\")";

		public string Section { get; set; }

		public SectionEnd(string section)
		{
			Section = section;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Get section
			string section = ((Section != null) ? Section : String.Empty);

			// Print section end statement
			return (GetIndentation(indentation) + String.Format(PrintFmt, section));
		}
	}
}