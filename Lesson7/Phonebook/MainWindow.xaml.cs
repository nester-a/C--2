using Phonebook.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private PhonebookDatabase database = new PhonebookDatabase();

        public ObservableCollection<Contact> ContactList { get; set; }

        public Contact SelectedContact { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            ContactList = database.Contacts;
        }

        private void phonebookListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                contactControl.Contact = (Contact)SelectedContact.Clone();
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (phonebookListView.SelectedItems.Count < 1)
                return;
            if (database.Update(contactControl.Contact) > 0)
            {
                MessageBox.Show("Запись успешно обновлена", "Обновление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                ContactList[ContactList.IndexOf(SelectedContact)] = contactControl.Contact;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ContactEditor editor = new ContactEditor();
            if (editor.ShowDialog() == true)
            {
                if (database.Add(editor.Contact) > 0)
                {
                    MessageBox.Show("Запись успешно добавлена", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //database.Contacts.Add(editor.Contact);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (phonebookListView.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Вы действительно желаете удалить контакт?", "Удаление контакта", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (database.Remove((Contact)phonebookListView.SelectedItems[0]) > 0)
                {
                    MessageBox.Show("Запись успешно удалена", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //database.Contacts.Remove((Contact)phonebookListView.SelectedItems[0]);
            }
        }
    }
}
