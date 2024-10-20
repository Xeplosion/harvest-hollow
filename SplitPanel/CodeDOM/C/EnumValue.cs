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
	public class EnumValue : CodeObject
	{
		private const string DefaultNameFmt = "{0}";
		private const string ValuePrintFmt  = " = {0}";

		public string     Name       { get; set; }
		public string     NameFormat { get; set; }
		public CodeObject Value      { get; set; }

		public EnumValue(string name)                   : this(name, null, false) { }
		public EnumValue(string name, CodeObject value) : this(name, value, true) { }

		protected EnumValue(string name, CodeObject value, bool hasValue)
		{
			Name  = name;
			Value = value;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text
			StringBuilder text = new StringBuilder();

			// Get indentation
			text.Append(GetIndentation(indentation));

			// Get name format
			string nameFmt = (!String.IsNullOrEmpty(NameFormat) ? NameFormat : DefaultNameFmt);

			// Get name
			string name = ((Name != null) ? Name : String.Empty);

			// Add name
			text.Append(String.Format(nameFmt, name));

			// Is there a value?
			if (Value != null)
			{
				// Add to text
				text.Append(String.Format(ValuePrintFmt, Value.GetString()));
			}

			// Return text
			return text.ToString();
		}
	}
}