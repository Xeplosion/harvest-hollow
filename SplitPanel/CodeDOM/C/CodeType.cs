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
	public class CodeType : CodeObject
	{
		protected const string DefaultNameFmt = "{0}";
		
		public bool   Volatile   { get; set; }
		public bool   Constant   { get; set; }
		public string Name       { get; set; }
		public string NameFormat { get; set; }

		public CodeType() : this(String.Empty) { }

		public CodeType(string name)
		{
			Name = name;
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

			// Is the type volatile?
			if (Volatile)
			{
				// Add volatile specifier
				text.Append(VolatileKeyword + SpaceChar);
			}

			// Is the type constant?
			if (Constant)
			{
				// Add constant specifier
				text.Append(ConstKeyword + SpaceChar);
			}

			// Print name
			text.Append(GetIndentation(indentation) + String.Format(nameFmt, name));

			// Return text
			return text.ToString();
		}
	}
}