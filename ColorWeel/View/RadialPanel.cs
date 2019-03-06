using System;
using System.Windows;
using System.Windows.Controls;

namespace ColorWeel.View
{
    // This Panel lays its children out in a circle
    // keeping the angular distance from each child
    // equal; MeasureOverride is called before ArrangeOverride.
    public class RadialPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement elem in Children)
            {

                //Give Infinite size as the avaiable size for all the children
                elem.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            }

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0) return finalSize;

            double
                centerX = finalSize.Width / 2,
                centerY = finalSize.Height / 2,
                innerRadius = finalSize.Height / 4,
                outerRadius = finalSize.Height / 2,
                stepAngle = 360.0 / Children.Count,
                //set center of the top element to angle = 0
                startAngle = 360.0 - stepAngle / 2;
            
            foreach (UIElement uie in Children)
            {
                if (uie is PieShape ps)
                {
                    ps.CenterX = centerX;
                    ps.CenterY = centerY;
                    ps.InnerRadius = innerRadius;
                    ps.OuterRadius = outerRadius;
                    ps.StartAngle = startAngle;
                    ps.AngleDelta = stepAngle;
                    ps.Padding = Children.Count == 1 ? 0 : 3;
                }

                uie.Arrange(new Rect(new Point(0, 0), finalSize));
                startAngle += stepAngle;
            }

            return finalSize;
        }
    }
}
