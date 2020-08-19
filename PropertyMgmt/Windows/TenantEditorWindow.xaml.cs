using PropertyMgmt.Windows.Popups;
using PropertyMgmt.ViewModel;
using System.Windows;
using PropertyMgmt.Model;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Threading;
using System.Threading.Tasks;

namespace PropertyMgmt.Windows
{
    /// <summary>
    /// Description for TenantEditorWindow.
    /// </summary>
    public partial class TenantEditorWindow : Window
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
        /// Initializes a new instance of the TenantEditorWindow class.
        /// </summary>
        public TenantEditorWindow()
        {
            InitializeComponent();
            ViewModel.EventItemSaved += ViewModel_EventItemSaved;
            ViewModel.EventOpenItemDialog += ViewModel_EventOpenItemDialog;
        }

        void ViewModel_EventOpenItemDialog(ItemType itemType)
        {
            if (itemType == ItemType.ServiceCall)
            {
                ServiceCallInfoPopup scip = new ServiceCallInfoPopup();

                scip.ShowDialog();
            }
            else if (itemType == ItemType.Correspondence)
            {
                CorrespondenceInfoPopup cip = new CorrespondenceInfoPopup();

                cip.ShowDialog();
            }
            else if (itemType == ItemType.LedgerRecord)
            {
                LedgerRecordInfoPopup lrip = new LedgerRecordInfoPopup();

                lrip.ShowDialog();
            }
        }

        void ViewModel_EventItemSaved(ItemType itemType)
        {
            if (itemType == ItemType.Tenant)
            {
                MessageBox.Show("Item saved!");
                this.Close();
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            ViewModel.EventItemSaved -= ViewModel_EventItemSaved;
            ViewModel.EventOpenItemDialog -= ViewModel_EventOpenItemDialog;

            ViewModel.CancelItemCommand.Execute(ItemType.Tenant);
        }
        
        private void cbProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Property selectedProperty = (sender as ComboBox).SelectedItem as Property;

            if (selectedProperty != null)
            {
                string theText = selectedProperty.FullAddress;

                this.Title = "Tenant information for " + (!string.IsNullOrEmpty(theText) ? theText : "(no property)");
            }
        }

        private void datagridContactInfo_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Should probably be in ViewModel, but will require wiring up a command
            if (ViewModel.WorkingTenant.PropertyListed != null && string.IsNullOrEmpty(ViewModel.WorkingTenant.Contact.address1))
            {
                ViewModel.WorkingTenant.Contact.address1 = ViewModel.WorkingTenant.PropertyListed.address1;
                ViewModel.WorkingTenant.Contact.address2 = ViewModel.WorkingTenant.PropertyListed.address2;
                ViewModel.WorkingTenant.Contact.city = ViewModel.WorkingTenant.PropertyListed.city;
                ViewModel.WorkingTenant.Contact.state = ViewModel.WorkingTenant.PropertyListed.state;
                ViewModel.WorkingTenant.Contact.zip = ViewModel.WorkingTenant.PropertyListed.zip;
            }

            ViewModel.WorkingContact = ViewModel.WorkingTenant.ContactListed;

            ContactInfoPopup cip = new ContactInfoPopup();
            cip.ShowDialog();
        }

        private void datagridServiceCalls_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.ServiceCall);
        }

        private void datagridCorresponances_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.Correspondence);
        }
        private void datagridLedger_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.LedgerRecord);
        }        

        private void datagridPropertyInfo_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (MessageBox.Show("You are about to navigate away from this tenant and to the property [" + ViewModel.WorkingTenant.Property.FullAddress  + "]\r\n" +
                            "Select Yes to save changes or No to discard",
                            "Attention!",
                            MessageBoxButton.YesNoCancel,
                            MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    {
                        ViewModel.SaveItemCommand.Execute(ItemType.Tenant);
                        goto case MessageBoxResult.No;
                    }
                case MessageBoxResult.No:
                    {
                        ViewModel.WorkingContainer = ViewModel.WorkingProperty = ViewModel.WorkingTenant.Property;
                        this.Close();

                        // Why not call OpenItemCommand directly? Repeated click-throughs will cause the call stack to grow too large. Run async instead
                        Task.Run(() => { DispatcherHelper.CheckBeginInvokeOnUI(delegate { ViewModel.OpenItemCommand.Execute(ItemType.Property); });});
                        
                        break;
                    }
            }
        }
    }
}