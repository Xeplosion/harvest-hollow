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
using System.Text;

namespace WindowHelper.CodeDOM.C
{
	public class CodeBlock : CodeObject, IList<CodeObject>
	{
		private const char LeftBraceChar  = '{';
		private const char RightBraceChar = '}';

		private IList<CodeObject> items;

		public CodeBlock()
		{
			items = new List<CodeObject>();
		}

		public override string ToString()
		{
			return GetString();
		}

		internal override string GetString(int indentation = 0)
		{
			// Create text buffer
			StringBuilder text = new StringBuilder();

			// Add left brace
			text.Append(GetIndentation(indentation) + LeftBraceChar + Environment.NewLine);

			// Get item indentation
			int itemIndentation = (indentation + 1);

			// Iterate through code items
			foreach(CodeObject item in items)
			{
				// Print item
				text.Append(item.GetString(itemIndentation));
			}

			// Add right brace
			text.Append(GetIndentation(indentation) + RightBraceChar);

			// Return text
			return text.ToString();
		}

		public void Add(CodeObject item)
		{
			items.Add(item);
		}

		public void Clear()
		{
			items.Clear();
		}

		public bool Contains(CodeObject item)
		{
			return items.Contains(item);
		}

		public void CopyTo(CodeObject[] array, int arrayIndex)
		{
			items.CopyTo(array, arrayIndex);
		}

		public IEnumerator<CodeObject> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public int IndexOf(CodeObject item)
		{
			return items.IndexOf(item);
		}

		public void Insert(int index, CodeObject item)
		{
			items.Insert(index, item);
		}

		public bool Remove(CodeObject item)
		{
			return items.Remove(item);
		}

		public void RemoveAt(int index)
		{
			items.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public CodeObject this[int index]
		{
			get { return items[index]; }
			set { items[index] = value; }
		}

		public int Count
		{
			get { return items.Count; }
		}

		public bool IsReadOnly
		{
			get { return items.IsReadOnly; }
		}
	}
}