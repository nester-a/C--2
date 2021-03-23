using Phonebook.Data;
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

namespace Phonebook.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        private Contact contact;
        public ContactControl()
        {
            InitializeComponent();

            cbCategory.ItemsSource = Enum.GetValues(typeof(ContactCategory)).Cast<ContactCategory>();

        }
        public void SetContact(Contact contact)
        {
            this.contact = contact;

            tbPhone.Text = contact.Phone;
            tbFirstName.Text = contact.FirstName;
            tbSecondName.Text = contact.SecondName;
            tbLastName.Text = contact.LastName;
            cbLocked.IsChecked = contact.Locked;
            cbCategory.SelectedItem = contact.Category;
            tbComment.Text = contact.Comment;
        }
        public Contact UpdateContact()
        {
            contact.Phone = tbPhone.Text;
            contact.FirstName = tbFirstName.Text;
            contact.SecondName = tbSecondName.Text;
            contact.LastName = tbLastName.Text;
            contact.Locked = (bool)cbLocked.IsChecked;
            contact.Category = (ContactCategory)cbCategory.SelectedItem;
            contact.Comment = tbComment.Text;

            return contact;
        }
    }
}
