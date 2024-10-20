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
	public class PointerType : CodeType
	{
		private const int MinIndirections = 1;

		public int Indirections { get; set; }

		public PointerType(CodeType type, int indirections = MinIndirections) : this(type.Name, indirections) { }

		public PointerType(string name, int indirections = MinIndirections) : base(name)
		{
			Indirections = indirections;
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

			// Get number of indirections
			int indirections = ((Indirections < MinIndirections) ? MinIndirections : Indirections);

			// Is the type constant?
			if (Constant)
			{
				// Add constant specifier
				text.Append(ConstKeyword + SpaceChar);
			}

			// Print name
			text.Append(GetIndentation(indentation) + String.Format(nameFmt, (name + new string(IndirectionChar, indirections))));

			// Return text
			return text.ToString();
		}
	}
}