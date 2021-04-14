using System.Windows;
using ProxyEditAssistant.Logic;
using ProxyEditAssistant.Models;

namespace ProxyEditAssistant
{
    public partial class MainWindow
    {
        public MainScreenModel Model { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            Model = new MainScreenModel();
            DataContext = Model;
        }

        private void CreateProxies(object sender, RoutedEventArgs e)
        {
            Model.GenerateProxies();
        }
    }
}