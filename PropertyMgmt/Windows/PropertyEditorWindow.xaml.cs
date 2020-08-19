using PropertyMgmt.Windows.Popups;
using PropertyMgmt.ViewModel;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Threading;
using PropertyMgmt.Utilities;
using PropertyMgmt.Model;
using System.Collections.Generic;

namespace PropertyMgmt.Windows
{
    /// <summary>
    /// Description for PropertyEditorWindow.
    /// </summary>
    public partial class PropertyEditorWindow : Window
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
        /// Initializes a new instance of the PropertyEditorWindow class.
        /// </summary>
        public PropertyEditorWindow()
        {
            InitializeComponent();
            ViewModel.EventItemSaved += ViewModel_EventItemSaved;
            ViewModel.EventGateCodeAdded += ViewModel_EventGateCodeAdded;
            ViewModel.EventParkingStallAdded += ViewModel_EventParkingStallAdded;
            ViewModel.EventOpenItemDialog += ViewModel_EventOpenItemDialog;
        }

        void ViewModel_EventOpenItemDialog(ItemType itemType)
        {
            if (itemType == ItemType.ServiceCall)
            {
                ServiceCallInfoPopup scip = new ServiceCallInfoPopup();

                scip.ShowDialog();
            }
        }

        void ViewModel_EventParkingStallAdded()
        {
            datagridParkingStalls.Focus();
            datagridParkingStalls.SelectedItem = datagridParkingStalls.Items[datagridParkingStalls.Items.Count - 1];
            datagridParkingStalls.CurrentCell = new DataGridCellInfo(datagridParkingStalls.SelectedItem, datagridParkingStalls.Columns[0]);
            datagridParkingStalls.BeginEdit();
        }

        void ViewModel_EventGateCodeAdded()
        {
            datagridGateCodes.Focus();
            datagridGateCodes.SelectedItem = datagridGateCodes.Items[datagridGateCodes.Items.Count - 1];
            datagridGateCodes.CurrentCell = new DataGridCellInfo(datagridGateCodes.SelectedItem, datagridGateCodes.Columns[0]);
            datagridGateCodes.BeginEdit();
        }


        void ViewModel_EventItemSaved(ItemType itemType)
        {
            if (itemType == ItemType.Property)
            {
                MessageBox.Show("Item saved!");
                this.Close();
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            ViewModel.EventItemSaved -= ViewModel_EventItemSaved;
            ViewModel.EventGateCodeAdded -= ViewModel_EventGateCodeAdded;
            ViewModel.EventParkingStallAdded -= ViewModel_EventParkingStallAdded;
            ViewModel.EventOpenItemDialog -= ViewModel_EventOpenItemDialog;

            ViewModel.CancelItemCommand.Execute(ItemType.Property);
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            string theText = (txtAddress1 == null ? "" : txtAddress1.Text) + " " + (txtAddress2 == null ? "" : txtAddress2.Text);
            
            this.Title = "Property information for " + (theText.Length > 1 ? theText : "(no address)");
        }

        private void datagridServiceCalls_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.OpenItemCommand.Execute(ItemType.ServiceCall);
        }

        private void datagridRentalHistory_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (MessageBox.Show("You are about to navigate away from this property and to the tenant [" + ViewModel.WorkingProperty.WorkingTenant.Contact.FullName + "]\r\n" +
                            "Select Yes to save changes or No to discard",
                            "Attention!",
                            MessageBoxButton.YesNoCancel,
                            MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    {
                        ViewModel.SaveItemCommand.Execute(ItemType.Property);
                        goto case MessageBoxResult.No;
                    }
                case MessageBoxResult.No:
                    {
                        ViewModel.WorkingContainer = ViewModel.WorkingTenant = ViewModel.WorkingProperty.WorkingTenant;
                        this.Close();
                        Task.Run(() => { DispatcherHelper.CheckBeginInvokeOnUI(delegate { ViewModel.OpenItemCommand.Execute(ItemType.Tenant); }); });
                        break;
                    }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        
    }
}