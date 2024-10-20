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
	public class StringValue : CodeValue
	{
		private const string QuoteFormat   = "\"{0}\"";
		private const string NoQuoteFormat = "{0}";

		public bool   IncludeQuotes { get; set; }
		public string Value         { get; set; }

		public StringValue(string value, bool includeQuotes = true) : base(null)
		{
			Value         = value;
			IncludeQuotes = includeQuotes;
		}

		internal override string GetString(int indentation = 0)
		{
			// Get print format
			string valueFmt = (!String.IsNullOrEmpty(ValueFormat) ? ValueFormat : DefaultValueFmt);

			// Get string literal format
			string stringFmt = (IncludeQuotes ? QuoteFormat : NoQuoteFormat);

			// Get value
			string value = ((Value != null) ? Value : String.Empty);

			// Print string
			return (GetIndentation(indentation) + String.Format(valueFmt, String.Format(stringFmt, value)));
		}
	}
}