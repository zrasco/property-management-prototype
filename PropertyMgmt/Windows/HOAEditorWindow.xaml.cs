using System.Windows;
using PropertyMgmt.Windows.Popups;
using PropertyMgmt.ViewModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Threading;

namespace PropertyMgmt.Windows
{
    /// <summary>
    /// Description for HOAEditorWindow.
    /// </summary>
    public partial class HOAEditorWindow : Window
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
        /// Initializes a new instance of the HOAEditorWindow class.
        /// </summary>
        public HOAEditorWindow()
        {
            InitializeComponent();
            ViewModel.EventItemSaved += ViewModel_EventItemSaved;
            ViewModel.EventOpenItemDialog += ViewModel_EventOpenItemDialog;
        }

        void ViewModel_EventItemSaved(ItemType itemType)
        {
            if (itemType == ItemType.HOA)
            {
                MessageBox.Show("Item saved!");
                this.Close();
            }
        }

        void ViewModel_EventOpenItemDialog(ItemType itemType)
        {
            if (itemType == ItemType.Contact)
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

            this.Title = "HOA information for " + (!string.IsNullOrEmpty(theText) ? theText : "(no name)");
        }

        private void datagridContacts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.Contact);
        }

        private void datagridProperties_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (MessageBox.Show("You are about to navigate away from this HOA and to the property [" + ViewModel.WorkingHOA.WorkingProperty.FullAddress + "]\r\n" +
                            "Select Yes to save changes or No to discard",
                            "Attention!",
                            MessageBoxButton.YesNoCancel,
                            MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    {
                        ViewModel.SaveItemCommand.Execute(ItemType.HOA);
                        goto case MessageBoxResult.No;
                    }
                case MessageBoxResult.No:
                    {
                        ViewModel.WorkingContainer = ViewModel.WorkingProperty = ViewModel.WorkingHOA.WorkingProperty;
                        this.Close();

                        // Why not call OpenItemCommand directly? Repeated click-throughs will cause the call stack to grow too large. Run async instead
                        Task.Run(() => { DispatcherHelper.CheckBeginInvokeOnUI(delegate { ViewModel.OpenItemCommand.Execute(ItemType.Property); }); });

                        break;
                    }
            }
        }
    }
}