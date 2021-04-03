using Phonebook.Communication.PhonebookService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace Phonebook.Controls
{
    public partial class ContactControl : UserControl, INotifyPropertyChanged
    {

        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void PrepareUI(EditorType editorType)
        {
            switch (editorType)
            {
                case EditorType.Add:
                    this.tbPhone.IsReadOnly = false;
                    this.tbPhone.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")); /*#FFF1EFEF*/
                    break;
                case EditorType.Edit:
                    break;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
