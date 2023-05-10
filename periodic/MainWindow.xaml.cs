using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace periodic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Element> elements = new List<Element>
        {
            new Element {AtomicNumber = 1, Symbol = "H", Name = "Hydrogen", AtomicMass = 1.0080F, GroupBlock = "Nonmetal", Row = 0, Column = 0},
            new Element {AtomicNumber = 2, Symbol = "He", Name = "Helium", AtomicMass = 4.00260F, GroupBlock = "Noble Gas", Row = 0, Column = 19}
        };

        public MainWindow()
        {
            InitializeComponent();

            // Add elements to their proper place
            foreach(Element el in elements) {
                // Create a Stack Panel 
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;

                // Create a horizontal Stack Panel
                StackPanel atomicData = new StackPanel();
                atomicData.Orientation = Orientation.Horizontal;
                atomicData.HorizontalAlignment = HorizontalAlignment.Stretch;

                // Add Atomic Number to upper left
                TextBlock atomicNum = new TextBlock();
                atomicNum.Text = el.AtomicNumber.ToString();
                atomicNum.HorizontalAlignment = HorizontalAlignment.Left;
                atomicNum.FontSize = 12;
                atomicData.Children.Add(atomicNum);

                // Add Atomic Mass to upper right
                TextBlock atomicMass = new TextBlock();
                atomicMass.Text = el.AtomicMass.ToString();
                atomicMass.HorizontalAlignment = HorizontalAlignment.Right;
                atomicMass.FontSize = 12;
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

                // Wrap the StackPanel with a Border
                Border border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Child = stackPanel;
                border.Margin = new Thickness(1);

                // Add the Border to the grid
                Grid.SetRow(border, el.Row);
                Grid.SetColumn(border, el.Column);
                PeriodicTable.Children.Add(border);
            }
        }
    }
}
