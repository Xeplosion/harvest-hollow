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
	public class CodeValue : CodeObject
	{
		protected const string DefaultValueFmt = "{0}";
		
		public object ValueObject { get; set; }
		public string ValueFormat { get; set; }

		public CodeValue(object valueObject)
		{
			ValueObject = valueObject;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create new buffer
			StringBuilder text = new StringBuilder();

			// Add indentation
			text.Append(GetIndentation(indentation));

			// Get print format
			string valueFmt = (!String.IsNullOrEmpty(ValueFormat) ? ValueFormat : DefaultValueFmt);

			// Get value
			object value = ((ValueObject != null) ? ValueObject : String.Empty);

			// Print value
			text.Append(String.Format(valueFmt, ValueObject));

			// Return text
			return text.ToString();
		}
	}
}