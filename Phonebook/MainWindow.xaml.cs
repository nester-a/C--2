using Phonebook.Data;
using Phonebook.Converters;
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

namespace Phonebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PhoneDatabase dataBase = new PhoneDatabase();
        public MainWindow()
        {
            InitializeComponent();

            UpdateBindings();
        }

        private void phonebookListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                contactControl.SetContact(e.AddedItems[0] as Contact);
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (phonebookListView.SelectedItems.Count < 1)
            {
                return;
            }
            contactControl.UpdateContact();
            UpdateBindings();
        }
        private void UpdateBindings()
        {
            phonebookListView.ItemsSource = null;
            phonebookListView.ItemsSource = dataBase.Contacts;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (phonebookListView.SelectedItems.Count < 1)
            {
                return;
            }
            if(MessageBox.Show("Вы действительно желаете удалить контакт?", "Удаление контакта",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                dataBase.Contacts.Remove((Contact)phonebookListView.SelectedItems[0]);
                UpdateBindings();
            }
        }
    }
}
