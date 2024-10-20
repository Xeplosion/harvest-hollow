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
	public class BooleanValue : CodeValue
	{
		private bool value;

		private static Dictionary<bool, string> KeywordTable = new Dictionary<bool, string>()
		{
			{ true, "true" },
			{ false, "false" }
		};

		public BooleanValue(bool value) : base(KeywordTable[value]) { }

		public bool Value
		{
			get { return value; }
			set
			{
				ValueObject = KeywordTable[value];
				this.value  = value;
			}
		}
	}
}