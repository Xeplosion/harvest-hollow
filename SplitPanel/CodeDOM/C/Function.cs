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
	public class Function : CodeBlock
	{
		public bool                Static     { get; set; }
		public string              Name       { get; set; }
		public CodeType            ReturnType { get; set; }
		public List<CodeAttribute> Attributes { get; private set; }
		public List<Parameter>     Parameters { get; private set; }

		public Function() : this(String.Empty) { }

		public Function(string name)
		{
			Name       = name;
			Parameters = new List<Parameter>();
			Attributes = new List<CodeAttribute>();
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text
			StringBuilder text = new StringBuilder();

			// Get return type to print
			CodeType returnType = ((ReturnType != null) ? ReturnType : DefaultTypes.VoidType);

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

			// Is the function declared static?
			if (Static)
			{
				text.Append(StaticKeyword + SpaceChar);
			}

			// Print return type and name
			text.Append(returnType.GetString() + SpaceChar + name);

			// Add left parenthesis for parameter list
			text.Append(LeftParenthesisChar);

			// Are there any parameters?
			if (Parameters.Count > 0)
			{
				// Iterate through parameters
				for (int count = 0; count < Parameters.Count; count++)
				{
					// Print parameter
					text.Append(Parameters[count].GetString());

					// Is this the last parameter?
					if (count < (Parameters.Count - 1))
					{
						// Print comma
						text.Append(CommaChar);

						// Print space
						text.Append(SpaceChar);
					}
				}
			}
			else
			{
				// Print void parameter list
				text.Append(DefaultTypes.VoidType.GetString());
			}

			// Add right parenthesis for parameter list
			text.Append(RightParenthesisChar + Environment.NewLine);

			// Print code block
			text.Append(base.GetString(indentation) + Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}