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
	public class LocationPragma : CodeObject
	{
		private const string LocationKeyword = "location";

		private static readonly string PrintFmt = (PoundChar + PragmaKeyword + SpaceChar + LocationKeyword + SpaceChar.ToString() + AssignmentChar + 
			                                       SpaceChar.ToString() + "\"{0}\"");

		public string Location { get; set; }

		public LocationPragma(string location)
		{
			Location = location;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Get location
			string location = ((Location != null) ? Location : String.Empty);

			// Print location pragma
			return (GetIndentation(indentation) + String.Format(PrintFmt, location) + Environment.NewLine);
		}
	}
}