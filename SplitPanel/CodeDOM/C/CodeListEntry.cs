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
	public class CodeListEntry : CodeObject
	{
		public CodeObject Value { get; private set; }

		public CodeListEntry(CodeObject value)
		{
			if (value == null)
			{
				throw new InvalidOperationException();
			}

			Value = value;
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Just print original value
			return Value.GetString(indentation);
		}
	}
}