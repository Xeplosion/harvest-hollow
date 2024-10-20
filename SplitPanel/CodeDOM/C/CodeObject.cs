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
	public abstract class CodeObject
	{
		protected const char   LeftParenthesisChar  = '(';
		protected const char   RightParenthesisChar = ')';
		protected const char   SpaceChar            = ' ';
		protected const char   IndentationChar      = '\t';
		protected const char   CommaChar            = ',';
		protected const char   StatementTerminator  = ';';
		protected const char   IndirectionChar      = '*';
		protected const char   ColonChar            = ':';
		protected const char   PoundChar            = '#';
		protected const char   AssignmentChar       = '=';
		protected const string VolatileKeyword      = "volatile";
		protected const string PragmaKeyword        = "pragma";
		protected const string IfDefinedKeyword     = "ifdef";
		protected const string IfNotDefinedKeyword  = "ifndef";
		protected const string EndIfKeyword         = "endif";
		protected const string IncludeKeyword       = "include";
		protected const string DefineKeyword        = "define";
		protected const string ConstKeyword         = "const";
		protected const string TypedefKeyword       = "typedef";
		protected const string VoidKeyword          = "void";
		protected const string StaticKeyword        = "static";
		protected const string WhileKeyword         = "while";
		protected const string IndexFmt             = "[{0}]";

		internal abstract string GetString(int indentation = 0);

		protected string GetIndentation(int indentation)
		{
			// Validate indentation
			indentation = ((indentation > 0) ? indentation : 0);

			// Get indentation
			return new string(IndentationChar, indentation);
		}
	}
}