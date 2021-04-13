using System.Windows;
using ProxyEditAssistant.Logic;

namespace ProxyEditAssistant
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var program = new ProxyBuilder();
            
            program.BuildProxies();
        }
    }
}