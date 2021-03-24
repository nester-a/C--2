using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SApp_01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Title = "Hello, WPF!";
            if (e.Args.Length == 1)
                MessageBox.Show("Параметр: \n\n" + e.Args[0]);
            mainWindow.Show();
        }
    }
}
