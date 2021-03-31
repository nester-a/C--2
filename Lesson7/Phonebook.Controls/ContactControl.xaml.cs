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
