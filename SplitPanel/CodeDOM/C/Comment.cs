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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindowHelper.CodeDOM.C
{
	public class Comment : CodeObject, IList<string>
	{
		private const string CommentFmt = "// {0}";

		private List<string> lines;

		public Comment()                      : this(String.Empty, false) { }
		public Comment(string initialComment) : this(initialComment, true) { }

		public Comment(string initialComment, bool hasInitialComment)
		{
			lines = new List<string>();

			// Is there an initial comment?
			if (hasInitialComment)
			{
				// Make sure comment is not empty
				if (String.IsNullOrEmpty(initialComment))
				{
					throw new InvalidOperationException();
				}

				// Add initial comment
				lines.Add(initialComment);
			}
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text buffer
			StringBuilder text = new StringBuilder();

			// Iterate through lines
			foreach(string line in lines)
			{
				// Add comment line
				text.Append(GetIndentation(indentation) + String.Format(CommentFmt, line) + Environment.NewLine);
			}

			// Return text
			return text.ToString();
		}

		public void AddFromFile(string filename)
		{
			try
			{
				// Add comment line from file
				lines.AddRange(File.ReadAllLines(filename));
			}
			catch (Exception e) { }
		}

		public void Add(string item)
		{
			lines.Add(item);
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(string item)
		{
			return lines.Contains(item);
		}

		public void CopyTo(string[] array, int arrayIndex)
		{
			lines.CopyTo(array, arrayIndex);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return lines.GetEnumerator();
		}

		public int IndexOf(string item)
		{
			return lines.IndexOf(item);
		}

		public void Insert(int index, string item)
		{
			lines.Insert(index, item);
		}

		public bool Remove(string item)
		{
			return lines.Remove(item);
		}

		public void RemoveAt(int index)
		{
			lines.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public string this[int index]
		{
			get { return lines[index]; }
			set { lines[index] = value; }
		}

		public int Count
		{
			get { return lines.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}
	}
}