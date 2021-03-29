using System;
using System.Collections.Generic;
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

namespace SApp01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding();
            binding.ElementName = "txtValue"; // Элемент-источник
            binding.Path = new PropertyPath("Text"); // Свойство источника

            textBlock2.SetBinding(TextBlock.TextProperty, binding); // Установка привязки для элемента-приемника



          
        }
    }
}
