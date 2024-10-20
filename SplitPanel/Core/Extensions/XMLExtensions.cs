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

using System.Xml;
using System.Xml.Linq;

namespace WindowHelper
{
	public static class XmlExtensions
	{
		public static int GetLineNumber(this XObject element)
		{
			// Return the line number of the element
			return ((IXmlLineInfo)element).LineNumber;
		}

		public static int GetColumnNumber(this XObject element)
		{
			// Return the column of the element
			return ((IXmlLineInfo)element).LinePosition;
		}
	}
}