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
	public class Include : CodeObject
	{
		private const string DefaultPrintFmt = "{0}";
		private const string RelativePathFmt = "\"{0}\"";
		private const string SystemPathFmt   = "<{0}>";

		private static readonly string IncludeFmt = (PoundChar + IncludeKeyword + SpaceChar);

		public bool   Relative    { get; set; }
		public string Path        { get; set; }
		public string PrintFormat { get; set; }

		public Include() : this(String.Empty) { }

		public Include(string path, bool relative = false)
		{
			Path     = path;
			Relative = relative;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Get path format
			string pathFmt = (Relative ? RelativePathFmt : SystemPathFmt);

			// Get print format
			string printFmt = (!String.IsNullOrEmpty(PrintFormat) ? PrintFormat : DefaultPrintFmt);

			// Get path
			string path = ((Path != null) ? Path : String.Empty);

			// Return text
			return (GetIndentation(indentation) + IncludeFmt + String.Format(printFmt, String.Format(pathFmt, path)) + Environment.NewLine);
		}
	}
}