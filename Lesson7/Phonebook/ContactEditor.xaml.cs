using Phonebook.Communication.PhonebookService;
using Phonebook.Controls;
using System.Windows;

namespace Phonebook
{
    /// <summary>
    /// Interaction logic for ContactEditor.xaml
    /// </summary>
    public partial class ContactEditor : Window
    {

        private EditorType editorType;

        public ContactEditor()
        {
            InitializeComponent();

            editorType = EditorType.Add;
            //contactControl.SetContact(Contact);
            PrepareUI();
        }

        public ContactEditor(EditorType editorType)
        {
            InitializeComponent();

            this.editorType = editorType;
            //contactControl.SetContact(Contact);
            PrepareUI();
        }

        private void PrepareUI()
        {
            switch (editorType)
            {
                case EditorType.Add:
                    this.Title = $"{this.Title} [Добавление]";
                    break;
                case EditorType.Edit:
                    this.Title = $"{this.Title} [Правка]";
                    break;
            }
            contactControl.PrepareUI(editorType);
        }

        public Contact Contact { get; set; } = new Contact();

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            
            //contactControl.UpdateContact();
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
