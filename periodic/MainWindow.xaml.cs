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
        /*
         public int AtomicNumber { get; set; }
    public string Symbol { get; set; } = "";
    public string Name { get; set; } = "";
    public float AtomicMass { get; set; } 
    public string ElementColor { get; set; } = "";
    public string ElectronConfiguration { get; set; } = "";
    public float Electronegativity { get; set; }
    public int AtomicRadius { get; set; }
    public float IonizationEnergy { get; set; }
    public float ElectionAffinity { get; set; }
    public List<string> OxidationStates { get; set; } = new List<string>();
    public string StandardState { get; set; } = "";
    public float MeltingPoint { get; set; }
    public float BoilingPoint { get; set; }
    public double Density { get; set; }
    public string GroupBlock { get; set; } = "";
    public int YearDiscovered { get; set; }
         */
        private List<Element> elements = new List<Element>
        {
            new Element {AtomicNumber = 1, Symbol = "H", Name = "Hydrogen", AtomicMass = 1.0080F, ElementColor = "", 
                ElectronConfiguration = "1s^1", Electronegativity = 2.2F, AtomicRadius = 120, IonizationEnergy = 13.598F, ElectionAffinity = 0.754F, 
                OxidationStates = new List<string>(){"+1", "-1"}, StandardState = "Gas", MeltingPoint = 13.81F, BoilingPoint = 20.28F,
                Density = 0.00008988, GroupBlock = "Nonmetal", YearDiscovered = 1766, Row = 0, Column = 0},
            new Element {AtomicNumber = 2, Symbol = "He", Name = "Helium", AtomicMass = 4.00260F, ElementColor = "",
                ElectronConfiguration = "1s^2", Electronegativity = 2.2F, AtomicRadius = 140, IonizationEnergy = 24.587F, ElectionAffinity = -0.5F,
                OxidationStates = {"0"}, StandardState = "Gas", MeltingPoint = 0.95F, BoilingPoint = 4.22F,
                Density = 0.0001785, GroupBlock = "Noble Gas", YearDiscovered = 1868, Row = 0, Column = 19},
            new Element {AtomicNumber = 3, Symbol = "Li", Name = "Lithium", AtomicMass = 7.0F, ElementColor = "",
                ElectronConfiguration = "[He]2s^1", Electronegativity = 0.98F, AtomicRadius = 182, IonizationEnergy = 5.392F, ElectionAffinity = 5.392F,
                OxidationStates = {"+1"}, StandardState = "Solid", MeltingPoint = 453.65F, BoilingPoint = 1615F,
                Density = 0.534, GroupBlock = "Alkali Metal", YearDiscovered = 1817, Row = 1, Column = 0}
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
                DockPanel atomicData = new DockPanel();

                // Add Atomic Number to upper left
                TextBlock atomicNum = new TextBlock();
                atomicNum.Text = el.AtomicNumber.ToString();
                atomicNum.HorizontalAlignment = HorizontalAlignment.Left;
                atomicNum.FontSize = 12;
                atomicNum.Margin = new Thickness(5, 0, 0, 0);
                atomicData.Children.Add(atomicNum);

                // Add Atomic Mass to upper right
                TextBlock atomicMass = new TextBlock();
                atomicMass.Text = el.AtomicMass.ToString();
                atomicMass.HorizontalAlignment = HorizontalAlignment.Right;
                atomicMass.FontSize = 12;
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
