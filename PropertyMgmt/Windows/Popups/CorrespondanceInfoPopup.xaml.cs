using PropertyMgmt.Model;
using PropertyMgmt.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace PropertyMgmt.Windows.Popups
{
    /// <summary>
    /// Description for CorrespondenceInfoPopup.
    /// </summary>
    public partial class CorrespondenceInfoPopup : Window
    {
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

        /// <summary>
        /// Initializes a new instance of the CorrespondenceInfoPopup class.
        /// </summary>
        public CorrespondenceInfoPopup()
        {
            InitializeComponent();
            ViewModel.EventItemSaved += ViewModel_EventItemSaved;
        }
        
        void ViewModel_EventItemSaved(ItemType itemType)
        {
            if (itemType == ItemType.Correspondence)
            {
                MessageBox.Show("Item saved!");
                this.Close();
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            ViewModel.EventItemSaved -= ViewModel_EventItemSaved;
        }

        private void cbTenant_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Tenant selectedTenant = cbTenant.SelectedItem as Tenant;

            if (selectedTenant != null)
            {
                string theText = (cbTenant.SelectedItem as Tenant).NameAndProperty;

                this.Title = "Correspondence information for " + (!string.IsNullOrEmpty(theText) ? theText : "(no name)");
            }
        }
    }
}