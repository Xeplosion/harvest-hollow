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
	public abstract class CompoundType : CodeBlock
	{
		public bool         TypeDefined { get; set; }
		public List<string> Names       { get; private set; } 

		protected string typename;
		
		protected CompoundType(string typename)
		{
			this.typename = typename;
			Names         = new List<string>();
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text buffer
			StringBuilder text = new StringBuilder();

			// Get indentation
			text.Append(GetIndentation(indentation));

			// Is the type defined?
			if (TypeDefined)
			{
				// Add type define
				text.Append(TypedefKeyword + SpaceChar);
			}

			// Add type name
			text.Append(typename + Environment.NewLine);

			// Print block
			text.Append(base.GetString(indentation));

			// Are there any names?
			if (Names.Count > 0)
			{
				// Add space
				text.Append(SpaceChar);

				// Iterate through names
				for (int count = 0; count < Names.Count; count++)
				{
					// Add name
					text.Append(Names[count]);

					// Is this the last name?
					if (count < (Names.Count - 1))
					{
						// Add comma and space
						text.Append(CommaChar);
						text.Append(SpaceChar);
					}
				}
			}

			// Add statement terminator
			text.Append(StatementTerminator + Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}