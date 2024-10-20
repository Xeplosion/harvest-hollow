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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace WindowHelper.WPF.Controls
{
    public partial class SplitPanel
    {
        public class Splitter : Control
        {
            public const Orientation DefaultOrientation = Orientation.Horizontal;

            public static readonly DependencyProperty SplitterOrientationProperty;

            private delegate void ResizeDelegate(double deltaX, double deltaY);

            public SplitPanel Panel { get; private set; }

            private static readonly Dictionary<Orientation, Orientation> _panelToSplitterOrientationMap = new Dictionary<Orientation, Orientation>()
            {
                { Orientation.Horizontal, Orientation.Vertical },
                { Orientation.Vertical, Orientation.Horizontal }
            };

            private static readonly Dictionary<Orientation, Cursor> _resizeCursors = new Dictionary<Orientation, Cursor>()
            {
                { Orientation.Horizontal, Cursors.SizeNS },
                { Orientation.Vertical, Cursors.SizeWE }
            };

            private ElementResizeInfo _firstElement;
            private ElementResizeInfo _secondElement;
            private Point? _anchor;
            private ResizeDelegate _resizeFunction;

            static Splitter()
            {
                // Initialize the splitter
                DefaultStyleKeyProperty.OverrideMetadata(typeof(Splitter), new FrameworkPropertyMetadata(typeof(Splitter)));

                // Register dependency properties
                SplitterOrientationProperty = s_registerOrientationProperty();
            }

            internal Splitter(SplitPanel panel)
            {
                // Initialize the splitter
                Panel = panel;

                // Bind the splitter orientation to the panel
                bindPanelOrientation();
            }

            public double GetSize()
            {
                // Return the size of the splitter based on the orientation
                return (Orientation == Orientation.Horizontal ? ActualHeight : ActualWidth);
            }

            protected override void OnMouseEnter(MouseEventArgs args)
            {
                // Call base method
                base.OnMouseEnter(args);

                // Set the cursor based on the orientation
                Mouse.OverrideCursor = _resizeCursors[Orientation];
            }

            protected override void OnMouseLeave(MouseEventArgs args)
            {
                // Call base method
                base.OnMouseLeave(args);

                // Clear the cursor
                Mouse.OverrideCursor = null;
            }

            protected override void OnMouseLeftButtonDown(MouseButtonEventArgs args)
            {
                // Call base method
                base.OnMouseLeftButtonDown(args);

                // Get the Children collection from the panel
                ElementCollection panelChildren = Panel.Children;

                // Update the sizes of the elements in the panel
                Panel.UpdateSizes();

                // Get the index of the splitter within the panel children
                int index = panelChildren.Splitters.IndexOf(this);

                // Get the elements to resize from the panel children
                _firstElement = new ElementResizeInfo(panelChildren[index]);
                _secondElement = new ElementResizeInfo(panelChildren[(index + 1)]);

                // Get the mouse anchor point
                _anchor = args.GetPosition(null);

                // Capture the mouse
                CaptureMouse();
            }

            protected override void OnMouseMove(MouseEventArgs args)
            {
                // Call base method
                base.OnMouseMove(args);

                // Are we currently executing a resize operation?
                if (_anchor == null)
                {
                    // We are not executing a resize
                    return;
                }

                // Get the new mouse position
                Point position = args.GetPosition(null);

                // Calculate the position delta
                double deltaX = (position.X - _anchor.Value.X);
                double deltaY = (position.Y - _anchor.Value.Y);

                // Resize the elements
                _resizeFunction(deltaX, deltaY);
            }

            protected override void OnMouseLeftButtonUp(MouseButtonEventArgs args)
            {
                // Call base method
                base.OnMouseLeftButtonUp(args);

                // Clear the anchor
                _anchor = null;

                // Release the mouse capture
                ReleaseMouseCapture();
            }

            private void horizontalResize(double deltaX, double deltaY)
            {
                // Get the element information
                ElementResizeInfo shrinkElement = ((deltaX < 0) ? _firstElement : _secondElement);
                ElementResizeInfo growElement = ((deltaX < 0) ? _secondElement : _firstElement);

                // Get the absolute value of the delta
                deltaX = Math.Abs(deltaX);

                // Apply the delta to the elements
                double minElementWidth = Panel.MinChildSize;
                double shrinkElementWidth = shrinkElement.BaseSize.Width;
                double growElementWidth = growElement.BaseSize.Width;
                double shrinkSizeWidth = (shrinkElementWidth - deltaX);
                double growSizeWidth = (growElementWidth + deltaX);

                // Is the shrink size valid?
                if (shrinkSizeWidth < minElementWidth)
                {
                    // Bound the new sizes
                    shrinkSizeWidth = ((shrinkElementWidth < minElementWidth) ? shrinkElementWidth : minElementWidth);
                    growSizeWidth = (growElementWidth + (shrinkElementWidth - shrinkSizeWidth));
                }

                // Resize the shrink element
                s_SetSize(shrinkElement.Element, shrinkSizeWidth);

                // Resize the grow element
                s_SetSize(growElement.Element, growSizeWidth);
            }

            private void verticalResize(double deltaX, double deltaY)
            {
                // Get the element information
                ElementResizeInfo shrinkElement = ((deltaY < 0) ? _firstElement : _secondElement);
                ElementResizeInfo growElement = ((deltaY < 0) ? _secondElement : _firstElement);

                // Get the absolute value of the delta
                deltaY = Math.Abs(deltaY);

                // Apply the delta to the elements
                double minElementHeight = Panel.MinChildSize;
                double shrinkElementHeight = shrinkElement.BaseSize.Height;
                double growElementHeight = growElement.BaseSize.Height;
                double shrinkSizeHeight = (shrinkElementHeight - deltaY);
                double growSizeHeight = (growElementHeight + deltaY);

                // Is the shrink size valid?
                if (shrinkSizeHeight < minElementHeight)
                {
                    // Bound the new sizes
                    shrinkSizeHeight = ((shrinkElementHeight < minElementHeight) ? shrinkElementHeight : minElementHeight);
                    growSizeHeight = (growElementHeight + (shrinkElementHeight - shrinkSizeHeight));
                }

                // Resize the shrink element
                s_SetSize(shrinkElement.Element, shrinkSizeHeight);

                // Resize the grow element
                s_SetSize(growElement.Element, growSizeHeight);
            }

            private void bindPanelOrientation()
            {
                // Create a new binding for the orientation
                Binding binding = new Binding(nameof(SplitPanel.Orientation))
                {
                    Source = Panel
                };

                // Set the binding on the splitter orientation
                SetBinding(SplitterOrientationProperty, binding);
            }

            private static object s_coerceOrientation(DependencyObject element, object baseValue)
            {
                // Get the splitter information
                Splitter splitter = (Splitter)element;
                Orientation panelOrientation = (Orientation)baseValue;

                // Get the orientation of the splitter
                Orientation orientation = _panelToSplitterOrientationMap[panelOrientation];

                // Set the resize function
                splitter._resizeFunction = ((orientation == Orientation.Horizontal) ? (ResizeDelegate)splitter.verticalResize : splitter.horizontalResize);

                // Return the splitter orientation
                return orientation;
            }

            private static DependencyProperty s_registerOrientationProperty()
            {
                // Create the property metadata
                FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata()
                {
                    DefaultValue = DefaultOrientation,
                    CoerceValueCallback = s_coerceOrientation
                };

                // Register the property
                return DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(Splitter), metadata);
            }

            public Orientation Orientation
            {
                get { return (Orientation)GetValue(SplitterOrientationProperty); }
                private set { SetValue(SplitterOrientationProperty, value); }
            }

            private struct ElementResizeInfo
            {
                public Size BaseSize { get; private set; }
                public UIElement Element { get; private set; }

                public ElementResizeInfo(UIElement element)
                {
                    // Initialize the resize information
                    Element = element;
                    BaseSize = element.RenderSize;
                }
            }
        }
    }
}