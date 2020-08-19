using PropertyMgmt.Windows.Popups;
using PropertyMgmt.ViewModel;
using System.Windows;

namespace PropertyMgmt.Windows
{

    /// <summary>
    /// Description for VendorEditorWindow.
    /// </summary>
    public partial class VendorEditorWindow : Window
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
        /// Initializes a new instance of the VendorEditorWindow class.
        /// </summary>
        public VendorEditorWindow()
        {
            InitializeComponent();
            ViewModel.EventItemSaved += ViewModel_EventItemSaved;
            ViewModel.EventOpenItemDialog += ViewModel_EventOpenItemDialog;
        }
        
        void ViewModel_EventItemSaved(ItemType itemType)
        {
            if (itemType == ItemType.Vendor)
            {
                MessageBox.Show("Item saved!");
                this.Close();
            }
        }

        void ViewModel_EventOpenItemDialog(ItemType itemType)
        {
            if (itemType == ItemType.ServiceCall)
            {
                ServiceCallInfoPopup scip = new ServiceCallInfoPopup();

                scip.ShowDialog();
            }
            else if (itemType == ItemType.Contact)
            {
                ContactInfoPopup cip = new ContactInfoPopup();

                cip.ShowDialog();
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            ViewModel.EventItemSaved -= ViewModel_EventItemSaved;
            ViewModel.EventOpenItemDialog -= ViewModel_EventOpenItemDialog;
        }

        private void txtCompanyName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string theText = txtCompanyName.Text;

            this.Title = "Vendor information for " + (!string.IsNullOrEmpty(theText) ? theText : "(no name)");
        }

        private void datagridServiceCalls_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.ServiceCall);
        }

        private void datagridContacts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.Contact);
        }
    }
}