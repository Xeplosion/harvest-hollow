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
using System.Collections.Generic;
using System.Text;

namespace WindowHelper.CodeDOM.C
{
	public class Parameter : CodeObject
	{
		private const string PrintFmt = "{0} {1}";

		public string           Name     { get; set; }
		public CodeType         Type     { get; set; }
		public List<CodeObject> Indicies { get; private set; }

		public Parameter() : this(null, String.Empty) { }

		public Parameter(CodeType type, string name)
		{
			Type     = type;
			Name     = name;
			Indicies = new List<CodeObject>();
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text
			StringBuilder text = new StringBuilder();

			// Get name
			string name = ((Name != null) ? Name : String.Empty);

			// Print indentation
			text.Append(GetIndentation(indentation));

			// Is there a type?
			if (Type != null)
			{
				// Print type
				text.Append(Type.GetString() + SpaceChar);
			}

			// Print name
			text.Append(name);

			// Are there any indicies to print?
			foreach(CodeObject indexObj in Indicies)
			{
				// Print index
				text.Append(String.Format(IndexFmt, indexObj.GetString()));
			}

			// Return text
			return text.ToString();
		}
	}
}