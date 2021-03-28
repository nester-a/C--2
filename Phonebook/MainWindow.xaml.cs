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
using System.Collections.ObjectModel;

namespace Phonebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PhoneDatabase dataBase = new PhoneDatabase();

        public ObservableCollection<Contact> ContactList { get; set; }
        public Contact SelectedContact { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            ContactList = dataBase.Contacts;
        }

        private void phonebookListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                contactControl.Contact = (Contact)SelectedContact.Clone();
                //contactControl.SetContact(e.AddedItems[0] as Contact);
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (phonebookListView.SelectedItems.Count < 1)
            {
                return;
            }
            ContactList[ContactList.IndexOf(SelectedContact)] = contactControl.Contact;
            //contactControl.UpdateContact();
            //UpdateBindings();
        }
        //private void UpdateBindings()
        //{
        //    //phonebookListView.ItemsSource = null;
        //    //phonebookListView.ItemsSource = dataBase.Contacts;
        //}

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (phonebookListView.SelectedItems.Count < 1)
            {
                return;
            }
            if(MessageBox.Show("Вы действительно желаете удалить контакт?", "Удаление контакта",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                dataBase.Contacts.Remove((Contact)phonebookListView.SelectedItems[0]);
                //UpdateBindings();
            }
        }
    }
}
