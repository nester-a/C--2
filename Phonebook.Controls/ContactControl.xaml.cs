using Phonebook.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Phonebook.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl, INotifyPropertyChanged
    {
        private Contact _contact;
        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<ContactCategory> CategoryList { get; set; } = new ObservableCollection<ContactCategory>();

        public ContactControl()
        {
            InitializeComponent();
            this.DataContext = this;

            CategoryList.Add(ContactCategory.General);
            CategoryList.Add(ContactCategory.Personal);
            CategoryList.Add(ContactCategory.Working);

            cbCategory.ItemsSource = Enum.GetValues(typeof(ContactCategory)).Cast<ContactCategory>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //public void SetContact(Contact contact)
        //{
        //    this.Contact = contact;

        //    tbPhone.Text = contact.Phone;
        //    tbFirstName.Text = contact.FirstName;
        //    tbSecondName.Text = contact.SecondName;
        //    tbLastName.Text = contact.LastName;
        //    cbLocked.IsChecked = contact.Locked;
        //    cbCategory.SelectedItem = contact.Category;
        //    tbComment.Text = contact.Comment;
        //}
        //public Contact UpdateContact()
        //{
        //    Contact.Phone = tbPhone.Text;
        //    Contact.FirstName = tbFirstName.Text;
        //    Contact.SecondName = tbSecondName.Text;
        //    Contact.LastName = tbLastName.Text;
        //    Contact.Locked = (bool)cbLocked.IsChecked;
        //    Contact.Category = (ContactCategory)cbCategory.SelectedItem;
        //    Contact.Comment = tbComment.Text;

        //    return Contact;
        //}
    }
}
