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
	public class Prototype : CodeObject
	{
		public bool                UseFunctionAttributes { get; set; }
		public bool                Static                { get; set; }
		public string              Name                  { get; set; }
		public CodeType            ReturnType            { get; set; }
		public Function            Function              { get; set; }
		public List<Parameter>     Parameters            { get; private set; }
		public List<CodeAttribute> Attributes            { get; private set; }

		public Prototype() : this(String.Empty) { }

		public Prototype(Function function) : this(String.Empty)
		{
			Function = function;
		}

		public Prototype(string name)
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

			// Add indentation
			text.Append(GetIndentation(indentation));

			// Initialize variables
			bool                isStatic   = false;
			string              protoName  = null;
			CodeType            returnType = null;
			List<CodeAttribute> attrs      = null;
			List<Parameter>     parameters = null;

			// Are we using the function's attributes?
			if (UseFunctionAttributes)
			{
				// Make sure attribute list is valid
				attrs = (((Function != null) && (Function.Attributes != null)) ? Function.Attributes : new List<CodeAttribute>());
			}
			else
			{
				// Use attributes defined in prototype
				attrs = Attributes;
			}

			// Iterate through attributes
			foreach(CodeAttribute attr in attrs)
			{
				// Print attribute
				text.Append(attr.GetString() + SpaceChar);
			}

			// Is there a function defined?
			if (Function != null)
			{
				// Load values from function
				isStatic   = Function.Static;
				protoName  = ((Function.Name != null) ? Function.Name : String.Empty);
				returnType = ((Function.ReturnType != null) ? Function.ReturnType : DefaultTypes.VoidType);
				parameters = Function.Parameters;
			}
			else
			{
				// Load values from prototype
				isStatic   = Static;
				protoName  = ((Name != null) ? Name : String.Empty);
				returnType = ((ReturnType != null) ? ReturnType : DefaultTypes.VoidType);
				parameters = Parameters;
			}

			// Is the function declared static?
			if (isStatic)
			{
				text.Append(StaticKeyword + SpaceChar);
			}

			// Print return type and name
			text.Append(returnType.GetString() + SpaceChar + protoName);

			// Add left parenthesis for parameter list
			text.Append(LeftParenthesisChar);

			// Are there any parameters?
			if (parameters.Count > 0)
			{
				// Iterate through parameters
				for (int count = 0; count < parameters.Count; count++)
				{
					// Print parameter
					text.Append(parameters[count].GetString());

					// Is this the last parameter?
					if (count < (parameters.Count - 1))
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

			// Add statement terminator
			text.Append(RightParenthesisChar.ToString() + StatementTerminator + Environment.NewLine);

			// Return text
			return text.ToString();
		}
	}
}