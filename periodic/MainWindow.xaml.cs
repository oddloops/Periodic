using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using Models;
using ElementEvents;

namespace periodic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Popup elementPopup;

        public MainWindow()
        {
            InitializeComponent();

            elementPopup = new Popup();
            elementPopup.Width = 300;
            elementPopup.Placement = PlacementMode.Mouse;
            elementPopup.StaysOpen = false;

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

                        // Add the element to the the table's data context
                        border.DataContext = el;

                        // Add an event handler for when mouse enters/leave and clicked
                        border.Loaded += EnlargeEvent.EnlargeElement;
                        border.MouseLeftButtonUp += ElementClick;

                        // Add the Border to the grid
                        Grid.SetRow(border, element.Row);
                        Grid.SetColumn(border, element.Column);
                        PeriodicTable.Children.Add(border);
                    }
                }
            }
        }

        void ElementClick(object sender, RoutedEventArgs e)
        {
            Border border = (Border)sender;
            Element clickedElement = (Element)border.DataContext;
            ShowElementPopup(clickedElement, border);
        }

        private void ShowElementPopup(Element element, FrameworkElement elementTarget)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;
            stackPanel.Background = new SolidColorBrush(Colors.White);
            stackPanel.Margin = new Thickness(1);

            // Create the popup
            var elementProperties = typeof(Element).GetProperties();
            foreach (var property in elementProperties)
            {
                TextBlock elementData = new TextBlock();
                Run propertyName = new Run(property.Name + ": ");
                propertyName.FontWeight = FontWeights.Bold;
                Run propertyData = new Run((property.GetValue(element) ?? string.Empty).ToString());
                elementData.Inlines.Add(propertyName);
                elementData.Inlines.Add(propertyData);
                elementData.FontSize = 14;
                stackPanel.Children.Add(elementData);
            }
            elementPopup.Child = stackPanel;

            // Position the Popup relative to the placementTarget
            elementPopup.PlacementTarget = elementTarget;
            elementPopup.Placement = PlacementMode.Right;

            // Open the Popup
            elementPopup.IsOpen = true;
        }
    }
}
