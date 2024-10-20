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
	public class StructField : CodeObject
	{
		private const string DefaultNameFmt     = "{0}";
		private const string DefaultBitfieldFmt = "{0}";

		public int                 Bitfield       { get; set; }
		public string              Name           { get; set; }
		public string              NameFormat     { get; set; }
		public string              BitfieldFormat { get; set; }
		public CodeType            Type           { get; set; }
		public List<CodeObject>    Indicies       { get; private set; }
		public List<CodeAttribute> Attributes     { get; private set; }

		public StructField(CodeType type, string name)
		{
			Type       = type;
			Name       = name;
			Attributes = new List<CodeAttribute>();
			Indicies   = new List<CodeObject>();
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

			// Print indentation
			text.Append(GetIndentation(indentation));

			// Print attributes
			foreach(CodeAttribute attr in Attributes)
			{
				// Print attribute
				text.Append(attr.GetString() + SpaceChar);
			}

			// Is there a type?
			if (Type != null)
			{
				// Print type
				text.Append(Type.GetString() + SpaceChar);
			}

			// Print name
			text.Append(String.Format(nameFmt, name));

			// Is there a bitfield?
			if (Bitfield > 0)
			{
				// Get bitfield format
				string bitfieldFmt = (!String.IsNullOrEmpty(BitfieldFormat) ? BitfieldFormat : DefaultBitfieldFmt);

				// Print bitfield
				text.Append(SpaceChar.ToString() + ColonChar + SpaceChar.ToString() + String.Format(bitfieldFmt, Bitfield));
			}

			// Are there array indicies?
			else if (Indicies.Count > 0)
			{
				// Iterate through indicies
				foreach (CodeObject indexObj in Indicies)
				{
					// Print index
					text.Append(String.Format(IndexFmt, indexObj.GetString()));
				}
			}

			// Add terminator
			text.Append(StatementTerminator.ToString() + Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}