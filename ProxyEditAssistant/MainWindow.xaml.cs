﻿using System.Windows;

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
            var program = new Program();
            
            program.BuildProxies();
        }
    }
}