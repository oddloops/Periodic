﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsvHelper;
using CsvHelper.Configuration;

namespace periodic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Parse the CSV
            /* 
             * Data received from:
             * National Center for Biotechnology Information (2023). Periodic Table of Elements. Retrieved May 15, 2023 from https://pubchem.ncbi.nlm.nih.gov/periodic-table/.
            */
            using (var reader = new StreamReader("pubchem-elements.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Create a list of Elements 
                List<Element> elements = csv.GetRecords<Element>().ToList();

                // Set each element's row and column placement (0 - 117 for 118 el & 10 x 18 rows)
                List<PeriodicElement> periodicElements = PeriodicElementInitializer.GetPeriodicTableElements(elements);

                foreach (PeriodicElement element in periodicElements)
                {
                    Element? el = element.Element;
                    if (el != null)
                    {
                        // Create a Stack Panel 
                        StackPanel stackPanel = new StackPanel();
                        stackPanel.Orientation = Orientation.Vertical;

                        // Add the CPK coloring for the element
                        //Color elementColor = (string.IsNullOrEmpty(el.CPKHexColor) ? Colors.Transparent : (Color)ColorConverter.ConvertFromString("#" + el.CPKHexColor));
                        Color elementColor = (Color)ColorConverter.ConvertFromString(element.GroupColor(el.GroupBlock));
                        stackPanel.Background = new SolidColorBrush(elementColor);

                        // Create a horizontal Stack Panel
                        DockPanel atomicData = new DockPanel();

                        // Add Atomic Number to upper left
                        TextBlock atomicNum = new TextBlock();
                        atomicNum.Text = el.AtomicNumber;
                        atomicNum.HorizontalAlignment = HorizontalAlignment.Left;
                        atomicNum.FontSize = 12;
                        atomicNum.Margin = new Thickness(5, 0, 0, 0);
                        atomicData.Children.Add(atomicNum);

                        // Add Atomic Mass to upper right
                        TextBlock atomicMass = new TextBlock();
                        atomicMass.Text = el.AtomicMass;
                        atomicMass.HorizontalAlignment = HorizontalAlignment.Right;
                        atomicMass.FontSize = 9;
                        atomicMass.Margin = new Thickness(0, 0, 5, 0);
                        atomicData.Children.Add(atomicMass);

                        stackPanel.Children.Add(atomicData);

                        // Add the element's symbol
                        TextBlock symbol = new TextBlock();
                        symbol.Text = el.Symbol;
                        symbol.TextAlignment = TextAlignment.Center;
                        symbol.FontSize = 20;
                        stackPanel.Children.Add(symbol);

                        // Add its Name under the symbol
                        TextBlock name = new TextBlock();
                        name.Text = el.Name;
                        name.TextAlignment = TextAlignment.Center;
                        name.FontSize = 12;
                        stackPanel.Children.Add(name);

                        // Add Group under the Name
                        TextBlock group = new TextBlock();
                        group.Text = el.GroupBlock;
                        group.TextAlignment = TextAlignment.Center;
                        group.FontSize = 8;
                        stackPanel.Children.Add(group);

                        // Wrap the StackPanel with a Border
                        Border border = new Border();
                        border.BorderThickness = new Thickness(1);
                        border.BorderBrush = Brushes.Black;
                        border.Child = stackPanel;
                        border.Margin = new Thickness(1);

                        // Add an event handler for when mouse enters/leave
                        border.Loaded += EnlargeElement;

                        // Add the Border to the grid
                        Grid.SetRow(border, element.Row);
                        Grid.SetColumn(border, element.Column);
                        PeriodicTable.Children.Add(border);
                    }
                }
            }
        }
        // value of scaling
        private const double enlargeScale = 1.15;

        // Enlarge animation
        private void EnlargeElement(object sender, RoutedEventArgs e)
        {
            Border border = (Border)sender;
            border.MouseEnter += MouseEnterEnlargeElement;
            border.MouseLeave += MouseLeaveEnlargeElement;
        }
        private void MouseEnterEnlargeElement(object sender, MouseEventArgs e)
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
        private void MouseLeaveEnlargeElement(object sender, MouseEventArgs e)
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
