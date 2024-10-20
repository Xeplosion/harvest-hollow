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
using System.Windows;
using System.Windows.Media;

namespace WindowHelper.WPF.Controls
{
    public partial class SplitPanel
    {
        public class ElementCollection : IList<UIElement>, IList
        {
            private const string _elementTypeErrorMessage = "The element must be of type: {0}.";
            private const string _lastElementError = "There are no elements in the collection.";

            public SplitPanel Panel { get; private set; }

            internal List<Splitter> Splitters { get; private set; }
            internal List<Visual> Visuals { get; private set; }

            private readonly List<UIElement> _elements;

            public ElementCollection(SplitPanel panel)
            {
                // Initialize the collection
                Panel = panel;
                _elements = new List<UIElement>();
                Splitters = new List<Splitter>();
                Visuals = new List<Visual>();
            }

            public void CopyTo(Array array, int index)
            {
                // Copy the collection to the array
                ((IList)_elements).CopyTo(array, index);
            }

            public void CopyTo(UIElement[] array, int arrayIndex)
            {
                // Copy the collection to the array
                _elements.CopyTo(array, arrayIndex);
            }

            public void Clear()
            {
                // Get the number of elements in the collection
                int numElements = Count;

                // Iterate through the collection
                for (int count = 0; count < numElements; count++)
                {
                    // Remove the element from the collection
                    RemoveAt(0);
                }
            }

            public void Add(UIElement element)
            {
                // Insert the element into the collection
                Insert(Count, element);
            }

            public void Insert(int index, object value)
            {
                // Insert the element into the collection
                Insert(index, s_CastToElement(value));
            }

            public void Insert(int index, UIElement element)
            {
                // Verify the element
                s_VerifyElement(element);

                // Verify the index is valid
                s_VerifyIndex(index, Count);

                // Insert the element in the collection
                _elements.Insert(index, element);

                // Attach the element to the panel
                attachElementToPanel(element);

                // Add a splitter to the panel
                addSplitter();

                // Execute a layout pass
                Panel.InvalidateMeasure();
            }


            public void RemoveAt(int index)
            {
                // Verify the index for the operation
                s_VerifyIndex(index, (Count - 1));

                // Get the element to remove from the collection
                UIElement element = _elements[index];

                // Remove the element from the collection
                _elements.RemoveAt(index);

                // Detach the element from the panel
                DetachElementFromPanel(element);

                // Remove a splitter from the panel
                removeSplitter();

                // Execute a layout pass
                Panel.InvalidateMeasure();
            }

            public void Remove(object value)
            {
                // Remove the element from the collection
                Remove(s_CastToElement(value));
            }

            public bool Remove(UIElement element)
            {
                // Get the index of the element to remove
                int index = IndexOf(element);

                // Is the index valid?
                if (index < 0)
                {
                    // The element is not in the collection
                    return false;
                }

                // Remove the element from the collection
                RemoveAt(index);

                // The operation was successful
                return true;
            }

            public bool Contains(object value)
            {
                // Determine if the collection contains the element
                return ((IList)_elements).Contains(value);
            }

            public bool Contains(UIElement element)
            {
                // Determine if the collection contains the element
                return _elements.Contains(element);
            }

            public int Add(object value)
            {
                // Add the element to the collection
                Add((UIElement)value);

                // Return the index of the added element
                return (Count - 1);
            }

            public int IndexOf(object value)
            {
                // Return the index of the element
                return ((IList)_elements).IndexOf(value);
            }

            public int IndexOf(UIElement element)
            {
                // Return the index of the element
                return _elements.IndexOf(element);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                // Return an enumerator for the collection
                return GetEnumerator();
            }

            public IEnumerator<UIElement> GetEnumerator()
            {
                // Return an enumerator for the collection
                return _elements.GetEnumerator();
            }

            public static void s_VerifyIndex(int index, int end)
            {
                // Make sure the index is valid
                if ((index < 0) || (index > end))
                {
                    // The index is not valid
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }

            public static void s_VerifyElement(object element)
            {
                // Is the element valid?
                if (element == null)
                {
                    // The element is not valid
                    throw new ArgumentNullException(nameof(element));
                }
            }

            public static UIElement s_CastToElement(object input)
            {
                // Make sure the element is valid
                s_VerifyElement(input);

                // Cast the input to an element
                UIElement element = (input as UIElement);

                // Is the element valid?
                if (element == null)
                {
                    // The element is not valid
                    throw new InvalidCastException(String.Format(_elementTypeErrorMessage, typeof(UIElement)));
                }

                // Return the element
                return element;
            }

            private void addSplitter()
            {
                // Do we need to add a splitter to the collection?
                if (Count <= 1)
                {
                    // We do not need to add a splitter to the collection
                    return;
                }

                // Create a new splitter
                Splitter splitter = new Splitter(Panel);

                // Add the splitter to the Splitters collection
                Splitters.Add(splitter);

                // Attach the splitter to the panel
                attachElementToPanel(splitter);
            }

            private void removeSplitter()
            {
                // Do we need to remove a splitter from the collection?
                if (Count == 0)
                {
                    // A splitter does not need to be removed from the collection
                    return;
                }

                // Get the first splitter in the collection
                Splitter splitter = Splitters[0];

                // Remove the splitter from the Splitters collection
                Splitters.RemoveAt(0);

                // Detach the splitter from the panel
                DetachElementFromPanel(splitter);
            }

            private void internalReplace(int index, UIElement element)
            {
                // Verify the element
                s_VerifyElement(element);

                // Verify the index for the operation
                s_VerifyIndex(index, (Count - 1));

                // Get element to replace in the collection
                UIElement replaceElement = _elements[index];
                double size = s_GetSize(replaceElement);

                // Set the size of the new element
                s_SetSize(element, size);

                // Replace the element in the collection
                _elements[index] = element;

                // Detach the old element from the panel
                DetachElementFromPanel(replaceElement);

                // Attach the new element to the panel
                attachElementToPanel(element);

                // Execute a layout pass on the panel
                Panel.InvalidateMeasure();
            }

            private void attachElementToPanel(UIElement element)
            {
                // Add the element as a logical child of the panel
                Panel.AddLogicalChild(element);

                // Add the element as a visual child of the panel
                Panel.AddVisualChild(element);

                // Add the element to the visuals collection
                Visuals.Add(element);
            }

            internal void DetachElementFromPanel(UIElement element)
            {
                // Remove the element as a logical child of the panel
                Panel.RemoveLogicalChild(element);

                // Remove the element as a visual child of the panel
                Panel.RemoveVisualChild(element);

                // Remove the element from the visuals collection
                Visuals.Remove(element);
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public bool IsFixedSize
            {
                get { return false; }
            }

            public bool IsSynchronized
            {
                get { return false; }
            }

            public int Count
            {
                get { return _elements.Count; }
            }

            public object SyncRoot
            {
                get { return this; }
            }

            object IList.this[int index]
            {
                get { return _elements[index]; }
                set { this[index] = s_CastToElement(value); }
            }

            public UIElement this[int index]
            {
                get { return _elements[index]; }
                set { internalReplace(index, value); }
            }

            public UIElement LastElement
            {
                get
                {
                    // Make sure the collection is not empty
                    if (Count == 0)
                    {
                        // The collection has no elements
                        throw new InvalidOperationException(_lastElementError);
                    }

                    // Return the last element in the collection
                    return _elements[(Count - 1)];
                }
            }
        }
    }
}