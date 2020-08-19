using System.Windows;
using PropertyMgmt.Windows.Popups;
using PropertyMgmt.ViewModel;
using GalaSoft.MvvmLight.Threading;
using System.Threading.Tasks;

namespace PropertyMgmt.Windows
{
    /// <summary>
    /// Description for OwnerEditorWindow.
    /// </summary>
    public partial class OwnerEditorWindow : Window
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
        /// Initializes a new instance of the OwnerEditorWindow class.
        /// </summary>
        public OwnerEditorWindow()
        {
            InitializeComponent();
            ViewModel.EventItemSaved += ViewModel_EventItemSaved;
            ViewModel.EventOpenItemDialog += ViewModel_EventOpenItemDialog;
        }

        void ViewModel_EventOpenItemDialog(ItemType itemType)
        {
            if (itemType == ItemType.Contact)
            {
                ContactInfoPopup cip = new ContactInfoPopup();

                cip.ShowDialog();
            }
        }

        void ViewModel_EventItemSaved(ItemType itemType)
        {
            if (itemType == ItemType.Owner)
            {
                MessageBox.Show("Item saved!");
                this.Close();
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

            this.Title = "Owner information for " + (!string.IsNullOrEmpty(theText) ? theText : "(no name)");
        }

        private void datagridContacts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.Contact);
        }

        private void datagridOwnerProperties_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (MessageBox.Show("You are about to navigate away from this owner and to the property [" + ViewModel.WorkingOwner.WorkingOwnerProperty.FullAddress + "]\r\n" +
                            "Select Yes to save changes or No to discard",
                            "Attention!",
                            MessageBoxButton.YesNoCancel,
                            MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    {
                        ViewModel.SaveItemCommand.Execute(ItemType.Owner);
                        goto case MessageBoxResult.No;
                    }
                case MessageBoxResult.No:
                    {
                        ViewModel.WorkingContainer = ViewModel.WorkingProperty = ViewModel.WorkingOwner.WorkingOwnerProperty;
                        this.Close();

                        // Why not call OpenItemCommand directly? Repeated click-throughs will cause the call stack to grow too large. Run async instead
                        Task.Run(() => { DispatcherHelper.CheckBeginInvokeOnUI(delegate { ViewModel.OpenItemCommand.Execute(ItemType.Property); }); });

                        break;
                    }
            }
        }
    }
}