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
	public class VariableDeclaration : CodeBlock
	{
		private const string DefaultNameFmt = "{0}";

		public bool                Static       { get; set; }
		public bool                Constant     { get; set; }
		public string              Name         { get; set; }
		public string              NameFormat   { get; set; }
		public CodeType            Type         { get; set; }
		public CodeObject          InitialValue { get; set; }
		public List<CodeAttribute> Attributes   { get; private set; }
		public List<CodeObject>    Indicies     { get; private set; }

		public VariableDeclaration(CodeType type, string name)
		{
			Name       = name;
			Type       = type;
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

			// Print indentation
			text.Append(GetIndentation(indentation));

			// Print attributes
			foreach (CodeAttribute attr in Attributes)
			{
				// Print attribute
				text.Append(attr.GetString() + SpaceChar);
			}

			// Is the variable static?
			if (Static)
			{
				// Add static specifier
				text.Append(StaticKeyword + SpaceChar);
			}

			// Is there a variable type?
			if (Type != null)
			{
				// Add variable type
				text.Append(Type.GetString() + SpaceChar);
			}

			// Is the variable constant?
			if (Constant)
			{
				// Add constant specifier
				text.Append(ConstKeyword + SpaceChar);
			}

			// Is there a variable name?
			if (Name != null)
			{
				// Get name format
				string nameFmt = (!String.IsNullOrEmpty(NameFormat) ? NameFormat : DefaultNameFmt);

				// Add variable name
				text.Append(String.Format(nameFmt, Name));
			}

			// Are there any indicies to print?
			foreach (CodeObject indexObj in Indicies)
			{
				// Print index
				text.Append(String.Format(IndexFmt, indexObj.GetString()));
			}

			// See if we have an initial value. The initial value is only used if the code block is empty and there are no indicies
			if ((Count == 0) && (Indicies.Count == 0) && (InitialValue != null))
			{
				// Add assignment
				text.Append(SpaceChar.ToString() + AssignmentChar + SpaceChar.ToString() + InitialValue.GetString());

				// Add terminator
				text.Append(StatementTerminator + Environment.NewLine);
			}

			// Otherwise see if we have items in the code block
			else if (Count > 0)
			{
				// Add assignment
				text.Append(SpaceChar.ToString() + AssignmentChar + Environment.NewLine);

				// Print code block
				text.Append(base.GetString(indentation));

				// Add terminator
				text.Append(StatementTerminator + Environment.NewLine);
			}

			// Return text
			return text.ToString();
		}
	}
}