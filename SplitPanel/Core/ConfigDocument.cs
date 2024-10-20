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
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WindowHelper
{
	public static class ConfigDocument
	{
		//private const string LoadErrorFormat = "There was a problem loading the XML document: {0}. {1} Line {2}, Column {3}";

		public static XDocument Load(string filepath, string schemapath)
		{
			//// Initialize document
			//XDocument document = null;

			//try
			//{
			//	// Load schema
			//	XmlReader reader = XmlReader.Create(schemapath);

			//	// Load schema into set
			//	XmlSchemaSet schemaSet = new XmlSchemaSet();

			//	// Add schema
			//	schemaSet.Add(String.Empty, reader);

			//	// Load the document
			//	document = XDocument.Load(filepath, (LoadOptions.SetBaseUri | LoadOptions.SetLineInfo));

			//	// Validate input XML file
			//	document.Validate(schemaSet, null);
			//}
			//catch (XmlSchemaValidationException e)
			//{
			//	// There was a problem loading the document
			//	throw new Exception(String.Format(LoadErrorFormat, filepath, e.Message, e.LineNumber, e.LinePosition), e);
			//}

			//// Return loaded document
			//return document;

			return null;
		}
	}
}