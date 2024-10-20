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
	public class SectionPragma : CodeObject
	{
		private const string SectionKeyword = "section";

		private static readonly string PrintFmt = (PoundChar + PragmaKeyword + SpaceChar + SectionKeyword + SpaceChar.ToString() + AssignmentChar + 
			                                       SpaceChar.ToString() + "\"{0}\"");

		public string Section { get; set; }

		public SectionPragma(string section)
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

			// Print section pragma
			return (GetIndentation(indentation) + String.Format(PrintFmt, section) + Environment.NewLine);
		}
	}
}