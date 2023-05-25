using System.Windows;
using System.Windows.Controls;
using Models;

namespace ElementWindows
{
    public partial class ElementPopupWindow : Window
    {
        private Element el;
        public ElementPopupWindow(Element element)
        {
            this.el = element;
            ElementInformation(el);
        }

        private void ElementInformation(Element el)
        {
            // 2 column grid to display element information
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

        }
    }
}