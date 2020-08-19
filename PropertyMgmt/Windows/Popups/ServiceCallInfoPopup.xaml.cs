using PropertyMgmt.Model;
using PropertyMgmt.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace PropertyMgmt.Windows.Popups
{
    /// <summary>
    /// Description for ServiceCallInfoPopup.
    /// </summary>
    public partial class ServiceCallInfoPopup : Window
    {
        /// <summary>
        /// Initializes a new instance of the ServiceCallInfoPopup class.
        /// </summary>
        public ServiceCallInfoPopup()
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
            if (itemType == ItemType.ServiceCall)
            {
                MessageBox.Show("Item saved!");
                this.Close();
            }

        }
        
        private void Window_Closed(object sender, System.EventArgs e)
        {
            ViewModel.EventItemSaved -= ViewModel_EventItemSaved;
        }

        private void cbProperty_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Property selectedProperty = (sender as ComboBox).SelectedItem as Property;

            if (selectedProperty != null)
            {
                string theText = selectedProperty.FullAddress;

                this.Title = "Service call information for " + (!string.IsNullOrEmpty(theText) ? theText : "(no selection)");
            }

        }
    }
}