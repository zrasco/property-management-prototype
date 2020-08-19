using PropertyMgmt.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace PropertyMgmt.Windows.Popups
{
    /// <summary>
    /// Description for ContactInfoPopup.
    /// </summary>
    public partial class ContactInfoPopup : Window
    {
        /// <summary>
        /// Initializes a new instance of the ContactInfoPopup class.
        /// </summary>
        public ContactInfoPopup()
        {
            InitializeComponent();
            ViewModel.EventItemSaved += ViewModel_EventItemSaved;
        }

        /// <summary>
        /// Gets the view's ViewModel.
        /// </summary>
        public MainViewModel ViewModel
        {
            get
            {
                return (MainViewModel)DataContext;
            }
        }
        
        void ViewModel_EventItemSaved(ItemType itemType)
        {
            if (itemType == ItemType.Contact)
            {
                MessageBox.Show("Item saved!");
                this.Close();
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            ViewModel.EventItemSaved -= ViewModel_EventItemSaved;
        }

        private void Name_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string theText = (txtLastName == null ? "" : txtLastName.Text)  + ", " + (txtFirstName == null ? "" : txtFirstName.Text) + " " + (txtMiddleName == null ? "" : txtMiddleName.Text);

            this.Title = "Contact information for " + (theText.Length > 3 ? theText : "(no name)");
        }
    }
}