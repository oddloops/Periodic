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
            ElementInformation();
        }

        private void ElementInformation()
        {
            
        }
    }
}