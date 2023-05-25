using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace ElementEvents
{
    public static class EnlargeEvent {
        /* Animation for enlarging an element */
        // value of scaling
        private const double enlargeScale = 1.15;

        // Enlarge animation
        public static void EnlargeElement(object sender, RoutedEventArgs e)
        {
            Border border = (Border)sender;
            border.MouseEnter += MouseEnterEnlargeElement;
            border.MouseLeave += MouseLeaveEnlargeElement;
        }
        private static void MouseEnterEnlargeElement(object sender, MouseEventArgs e)
        {

            // Enlarge animation for element
            Border border = (Border)sender;
            border.Cursor = Cursors.Hand;
            border.RenderTransform = new ScaleTransform(enlargeScale, enlargeScale);

            // allow overlapping
            Grid.SetZIndex(border, 1);
            double xOffset = (border.ActualWidth * (enlargeScale - 1)) / 2;
            double yOffset = (border.ActualHeight * (enlargeScale - 1)) / 2;

            DoubleAnimation animation = new DoubleAnimation
            {
                To = enlargeScale,
                Duration = TimeSpan.FromMilliseconds(200)
            };

            border.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            border.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
            border.Margin = new Thickness(
                border.Margin.Left - xOffset,
                border.Margin.Top - yOffset,
                border.Margin.Right - xOffset,
                border.Margin.Bottom - yOffset
            );
        }
        private static void MouseLeaveEnlargeElement(object sender, MouseEventArgs e)
        {
            // Returns to initial state
            Border border = (Border)sender;
            border.RenderTransform = null;
            border.Width = double.NaN;
            border.Height = double.NaN;
            border.Margin = new Thickness(1);

            // Reset position
            Grid.SetZIndex(border, 0);
        }
    }
}