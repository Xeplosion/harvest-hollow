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
	public class CodeList : CodeObject, IList<CodeObject>
	{
		private IList<CodeObject> items;

		public CodeList()
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

			// Store last entry offset
			int offset = 0;

			// Iterate through items
			for (int count = 0; count < items.Count; count++)
			{
				// Get code item
				CodeObject item = items[count];

				// Print item
				text.Append(item.GetString(indentation));

				// Is this a list entry?
				if (item is CodeListEntry)
				{
					// Are we tracking a previous offset?
					if (offset > 0)
					{
						// Insert into previous position
						text.Insert(offset, CommaChar);
					}

					// Save the offset
					offset = text.Length;

					// Add newline
					text.Append(Environment.NewLine);
				}
			}

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