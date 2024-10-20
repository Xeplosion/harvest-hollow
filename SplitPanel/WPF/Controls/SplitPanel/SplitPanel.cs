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
using System.Windows.Markup;
using System.Windows.Media;

namespace WindowHelper.WPF.Controls
{
    [ContentProperty(nameof(Children))]
    public partial class SplitPanel : FrameworkElement
    {
        public const double MinSplitProportion = -1;
        public const double MaxSplitProportion = 1;
        public const double DefaultSize = 1;
        public const double DefaultMinChildSize = 0;
        public const Orientation DefaultOrientation = Orientation.Horizontal;
        public const Brush DefaultBrush = null;

        private const string _sizePropertyName = "Size";
        private const string _invalidSplitProportionError = "The split proportion is not valid.";

        public static readonly DependencyPropertyKey ChildrenPropertyKey = s_registerChildrenProperty();

        public static readonly DependencyProperty SizeProperty = s_registerSizeProperty();
        public static readonly DependencyProperty MinChildSizeProperty = s_registerMinChildSizeProperty();
        public static readonly DependencyProperty OrientationProperty = s_registerOrientationProperty();
        public static readonly DependencyProperty BackgroundProperty = s_registerBackgroundProperty();
        public static readonly DependencyProperty ChildrenProperty = ChildrenPropertyKey.DependencyProperty;

        private double _starUnitSize;

        private const float _epsilon = 0.0001f;

        public SplitPanel()
        {
            // Initialize the children
            SetValue(ChildrenPropertyKey, new ElementCollection(this));
        }

        public void SplitChild(int childIndex, UIElement element, double proportion)
        {
            // Verify the child index
            ElementCollection.s_VerifyIndex(childIndex, (Children.Count - 1));

            // Verify the new element
            ElementCollection.s_VerifyElement(element);

            // Verify the split proportion
            s_verifySplitProportion(proportion);

            // Update the sizes of the children
            UpdateSizes();

            // Get the index to insert the new element at
            int index = ((proportion >= 0) ? (childIndex + 1) : childIndex);

            // Update the proportion value
            proportion = Math.Abs(proportion);

            // Get the child to split
            UIElement child = Children[childIndex];

            // Calculate the size of the child and the new element
            double overallSize = getSplitSize(child);
            double elementSize = (overallSize * proportion);
            double childSize = (overallSize - elementSize);

            // Set the size of the existing child and new element
            s_SetSize(child, childSize);
            s_SetSize(element, elementSize);

            // Add the new element to the panel
            Children.Insert(index, element);
        }

        public void CombineChildren(int startIndex, int count)
        {
            // Do we have to perform the operation?
            if (count == 0)
            {
                // We don't have to perform the operation
                return;
            }

            // Get the child index for the operation
            int childIndex = verifyCombineParameters(startIndex, count);

            // Update the sizes of the children
            UpdateSizes();

            // Update the count value
            count = Math.Abs(count);

            // Initialize variables
            UIElement child = Children[childIndex++];
            double combinedSize = (s_GetSize(child) + (Children.Splitters[0].GetSize() * count));

            // Iterate through the children to combine
            for (int combinedChildren = 0; combinedChildren < count; combinedChildren++)
            {
                // Increment the combined size of the remaining child
                combinedSize += s_GetSize(Children[childIndex]);

                // Remove the child from the Children collection
                Children.RemoveAt(childIndex);
            }

            // Set the size of the remaining child
            s_SetSize(child, combinedSize);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            // Draw the background of the control
            drawingContext.DrawRectangle(Background, null, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            // Initialize star size
            _starUnitSize = 0;

            // Measure based on the orientation
            return ((Orientation == Orientation.Horizontal) ? measureHorizontalSize(availableSize) : measureVertical(availableSize));
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // Arrange based on the orientation
            return ((Orientation == Orientation.Horizontal) ? arrangeHorizontal(finalSize) : arrangeVertical(finalSize));
        }

        protected override Visual GetVisualChild(int index)
        {
            // Return the visual from the children
            return Children.Visuals[index];
        }

        internal void UpdateSizes()
        {
            // Iterate through the elements in the panel
            foreach (UIElement child in Children)
            {
                // Get the size to set based on the orientation
                double size = ((Orientation == Orientation.Horizontal) ? child.RenderSize.Width : child.RenderSize.Height);

                // Set the size of the element based
                s_SetSize(child, size);
            }
        }

        private double getSplitSize(UIElement child)
        {
            // Initialize splitter size
            double splitterSize = 0;

            // Get the size of the child
            double size = s_GetSize(child);

            // Are there any splitters in the panel?
            if (Children.Count > 1)
            {
                // Update the splitter size
                splitterSize = Children.Splitters[0].GetSize();
            }

            // Calculate the split size
            size -= splitterSize;

            // Return the split size
            return ((size > 0) ? size : 0);
        }

        private void startMeasure(double constraint)
        {
            // Iterate through the children
            foreach (UIElement child in Children)
            {
                // Update the star size
                _starUnitSize += s_GetSize(child);
            }

            // Is the star size valid?
            if (_starUnitSize < _epsilon)
            {
                // Set the star size to the width of the constraint
                _starUnitSize = constraint;

                // Set the size of the last child in the collection
                s_SetSize(Children.LastElement, _starUnitSize);
            }

            // Calculate the star size
            _starUnitSize = (constraint / _starUnitSize);
        }

        private void horizontalChildrenMeasure(Size constraint)
        {
            // Initialize variables
            double width = constraint.Width;

            // Do we need to calculate the star size?
            if ((width > _epsilon) && (Children.Count > 0))
            {
                // Calculate the star size
                startMeasure(width);
            }

            // Iterate through the children
            foreach (UIElement child in Children)
            {
                // Set the constraint
                constraint.Width = (s_GetSize(child) * _starUnitSize);

                // Measure the child
                child.Measure(constraint);
            }
        }

        private void verticleChildrenMeasure(Size constraint)
        {
            // Initialize variables
            double height = constraint.Height;

            // Do we need to calculate the star size?
            if ((height > _epsilon) && (Children.Count > 0))
            {
                // Calculate the star size
                startMeasure(height);
            }

            // Iterate through the children
            foreach (UIElement child in Children)
            {
                // Set the constraint
                constraint.Height = (s_GetSize(child) * _starUnitSize);

                // Measure the child
                child.Measure(constraint);
            }
        }

        private static void s_verifySplitProportion(double proportion)
        {
            // Make sure the proportion is valid
            if ((proportion < MinSplitProportion) || (proportion > MaxSplitProportion))
            {
                // The proportion is not valid
                throw new ArgumentException(_invalidSplitProportionError);
            }
        }

        private int verifyCombineParameters(int index, int count)
        {
            // Calculate the child index for the combine operation
            int childIndex = ((count > 0) ? index : (index + count));

            // Is the child index valid?
            if ((childIndex < 0) || ((childIndex + Math.Abs(count)) >= Children.Count))
            {
                // The index is not valid
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            // Return the child index
            return childIndex;
        }

        private double horizontalSplittersMeasure(Size constraint)
        {
            // Initialize variables
            double width = 0;

            // Iterate through all of the splitters
            foreach (Splitter splitter in Children.Splitters)
            {
                // Measure the splitter
                splitter.Measure(constraint);

                // Get the width of the splitter
                double splitterWidth = splitter.DesiredSize.Width;

                // Update width based on the splitter desired size
                width += splitterWidth;
                constraint.Width -= splitterWidth;
            }

            // Return the measured width
            return width;
        }

        private double verticalSplittersMeasure(Size constraint)
        {
            // Initialize variables
            double height = 0;

            // Iterate through all of the splitters
            foreach (Splitter splitter in Children.Splitters)
            {
                // Measure the splitter
                splitter.Measure(constraint);

                // Get the height of the splitter
                double splitterHeight = splitter.DesiredSize.Height;

                // Update height based on the splitter desired size
                height += splitterHeight;
                constraint.Height -= splitterHeight;
            }

            // Return the measured height
            return height;
        }

        private double horizontalChildArrange(UIElement child, double offset, double height)
        {
            // Do we have to arrange the child?
            if (_starUnitSize < _epsilon)
            {
                // We do not have to arrange the child
                return offset;
            }

            // Calculate the width of the child
            double width = (s_GetSize(child) * _starUnitSize);

            // Arrange the child
            child.Arrange(new Rect(offset, 0, width, height));

            // Return the new offset
            return (offset + width);
        }

        private double verticalChildArrange(UIElement child, double offset, double width)
        {
            // Do we have to arrange the child?
            if (_starUnitSize < _epsilon)
            {
                // We do not have to arrange the child
                return offset;
            }

            // Calculate the height of the child
            double height = (s_GetSize(child) * _starUnitSize);

            // Arrange the child
            child.Arrange(new Rect(0, offset, width, height));

            // Return the new offset
            return (offset + height);
        }

        private static double s_horizontalSplitterArrange(Splitter splitter, double offset, double height)
        {
            // Get the width of the splitter
            double width = splitter.DesiredSize.Width;

            // Arrange the splitter
            splitter.Arrange(new Rect(offset, 0, width, height));

            // Return the new offset
            return (offset + width);
        }

        private static double s_verticalSplitterArrange(Splitter splitter, double offset, double width)
        {
            // Get the height of the splitter
            double height = splitter.DesiredSize.Height;

            // Arrange the splitter
            splitter.Arrange(new Rect(0, offset, width, height));

            // Return the new offset
            return (offset + height);
        }

        private Size measureHorizontalSize(Size constraint)
        {
            // Save the panel size
            Size panelSize = constraint;

            // Measure the splitters
            double width = horizontalSplittersMeasure(constraint);

            // Update the constraint
            constraint.Width -= width;

            // Measure the children
            horizontalChildrenMeasure(constraint);

            // The panel occupies all of the available space
            return panelSize;
        }

        private Size measureVertical(Size constraint)
        {
            // Save the panel size
            Size panelSize = constraint;

            // Measure the splitters
            double height = verticalSplittersMeasure(constraint);

            // Update the constraint
            constraint.Height -= height;

            // Measure the children
            verticleChildrenMeasure(constraint);

            // The panel occupies all of the available space
            return panelSize;
        }

        private Size arrangeHorizontal(Size size)
        {
            // Initialize variables
            int numChildren = Children.Count;
            double offset = 0;
            double height = size.Height;

            // Iterate through all of the children but don't handle the last one
            for (int count = 0; count < (numChildren - 1); count++)
            {
                // Arrange the child
                offset = horizontalChildArrange(Children[count], offset, height);

                // Arrange the corresponding splitter
                offset = s_horizontalSplitterArrange(Children.Splitters[count], offset, height);
            }

            // If there is at least one child in the panel, then we need to arrange the last child, because the the previous iteration arranges
            // child / splitter pairs
            if (numChildren > 0)
            {
                // Arrange the last child
                horizontalChildArrange(Children.LastElement, offset, height);
            }

            // Return the size of the panel
            return size;
        }

        private Size arrangeVertical(Size size)
        {
            // Initialize variables
            int numChildren = Children.Count;
            double offset = 0;
            double width = size.Width;

            // Iterate through all of the children but don't handle the last one
            for (int count = 0; count < (numChildren - 1); count++)
            {
                // Arrange the child
                offset = verticalChildArrange(Children[count], offset, width);

                // Arrange the corresponding splitter
                offset = s_verticalSplitterArrange(Children.Splitters[count], offset, width);
            }

            // If there is at least one child in the panel, then we need to arrange the last child, because the the previous iteration arranges
            // child / splitter pairs
            if (numChildren > 0)
            {
                // Arrange the last child
                verticalChildArrange(Children.LastElement, offset, width);
            }

            // Return the size of the panel
            return size;
        }

        public static void s_SetSize(UIElement element, double size)
        {
            // Set the size of the element
            element.SetValue(SizeProperty, size);
        }

        private static bool s_validateSize(object value)
        {
            // Get the size value
            double size = (double)value;

            // Make sure the size value is valid
            return (!Double.IsNaN(size) && !Double.IsInfinity(size) && (size >= 0));
        }

        public static double s_GetSize(UIElement element)
        {
            // Get the size of the element
            return (double)element.GetValue(SizeProperty);
        }

        private static DependencyProperty s_registerSizeProperty()
        {
            // Create the property metadata
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata()
            {
                DefaultValue = DefaultSize,
                AffectsParentMeasure = true
            };

            // Register the property
            return DependencyProperty.RegisterAttached(_sizePropertyName, typeof(double), typeof(SplitPanel), metadata, s_validateSize);
        }

        private static DependencyProperty s_registerMinChildSizeProperty()
        {
            // Create the property metadata
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata()
            {
                DefaultValue = DefaultMinChildSize
            };

            // Register the property
            return DependencyProperty.Register(nameof(MinChildSize), typeof(double), typeof(SplitPanel), metadata);
        }

        private static DependencyProperty s_registerOrientationProperty()
        {
            // Create the property metadata
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata()
            {
                DefaultValue = DefaultOrientation,
                AffectsMeasure = true,
            };

            // Register the property
            return DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(SplitPanel), metadata);
        }

        private static DependencyProperty s_registerBackgroundProperty()
        {
            // Create the property metadata
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata()
            {
                DefaultValue = DefaultBrush,
                AffectsRender = true
            };

            // Register the property
            return DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(SplitPanel), metadata);
        }

        private static DependencyPropertyKey s_registerChildrenProperty()
        {
            // Create the property metadata
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();

            // Register the property
            return DependencyProperty.RegisterReadOnly(nameof(Children), typeof(ElementCollection), typeof(SplitPanel), metadata);
        }

        public double MinChildSize
        {
            get { return (double)GetValue(MinChildSizeProperty); }
            set { SetValue(MinChildSizeProperty, value); }
        }

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public ElementCollection Children
        {
            get { return (ElementCollection)GetValue(ChildrenProperty); }
        }

        protected override int VisualChildrenCount
        {
            get { return Children.Visuals.Count; }
        }
    }
}