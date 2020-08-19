using PropertyMgmt.Windows.Popups;
using PropertyMgmt.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;
using PropertyMgmt.Model;

namespace PropertyMgmt.Windows
{
    /// <summary>
    /// Description for PropertyWindow.
    /// </summary>
    public partial class PropertyWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the PropertyWindow class.
        /// </summary>
        public PropertyWindow()
        {
            InitializeComponent();
            ViewModel.EventNewItemDialog += ViewModel_NewItemDialog;
            ViewModel.EventOpenItemDialog += ViewModel_EventOpenItemDialog;
        }

        void ViewModel_EventOpenItemDialog(ItemType itemType)
        {
            Window aWindow = null;

            var invokeMethods = new Action[] {
                                                   //delegate { ViewModel.WorkingContainer = ViewModel.WorkingProperty; aWindow = new PropertyEditorWindow(); },
                                                   //delegate { ViewModel.WorkingContainer = ViewModel.WorkingTenant; aWindow = new TenantEditorWindow(); },
                                                   //delegate { ViewModel.WorkingContainer = ViewModel.WorkingOwner; aWindow = new OwnerEditorWindow(); },
                                                   //delegate { ViewModel.WorkingContainer = ViewModel.WorkingHOA; aWindow = new HOAEditorWindow(); },
                                                   //delegate { ViewModel.WorkingContainer = ViewModel.WorkingVendor; aWindow = new VendorEditorWindow(); },
                                                   //delegate { ViewModel.WorkingContainer = ViewModel.WorkingPropertyMgmtCompany; aWindow = new PropertyMgmtEditorWindow(); },
                                                   //delegate { ViewModel.WorkingContainer = null;  aWindow = new ServiceCallInfoPopup(); },
                                                   //delegate { /* Contacts should never open from here */ },
                                                   //delegate { /* Correspondences should never open from here */ }

                                                   delegate { aWindow = new PropertyEditorWindow(); },
                                                   delegate { aWindow = new TenantEditorWindow(); },
                                                   delegate { aWindow = new OwnerEditorWindow(); },
                                                   delegate { aWindow = new HOAEditorWindow(); },
                                                   delegate { aWindow = new VendorEditorWindow(); },
                                                   delegate { aWindow = new PropertyMgmtEditorWindow(); },
                                                   delegate { aWindow = new ServiceCallInfoPopup(); },
                                                   delegate { /* Contacts should never open from here */ },
                                                   delegate { /* Correspondences should never open from here */ },
                                                   delegate { /* Ledgers should never be open from here */ }
                                                };
            invokeMethods[(int)itemType]();

            if (aWindow != null)
            {                
                // Safeguard to not open extra contact/service call windows
                if ((ViewModel.WorkingContainer == null && itemType == ItemType.ServiceCall) || // Service call from main window
                    (ViewModel.WorkingContainer != null && itemType < ItemType.ServiceCall))    // "Proper" item type from main window
                    aWindow.ShowDialog();
            }
        }

        void ViewModel_NewItemDialog(ItemType itemType)
        {
            // NOTE: Indexes coupled with enum values!
            var invokeMethods = new Func<Window>[] {
                                                   delegate { return new PropertyEditorWindow(); },
                                                   delegate { return new TenantEditorWindow(); },
                                                   delegate { return new OwnerEditorWindow(); },
                                                   delegate { return new HOAEditorWindow(); },
                                                   delegate { return new VendorEditorWindow(); },
                                                   delegate { return new PropertyMgmtEditorWindow(); },
                                                   delegate { return new ServiceCallInfoPopup(); },
                                                   delegate { return new ContactInfoPopup(); },
                                                   delegate { return new CorrespondenceInfoPopup(); },
                                                   delegate { return new LedgerRecordInfoPopup(); }
                                                };

            Window theWindow = invokeMethods[(int)itemType]();

            if (theWindow != null)
                theWindow.ShowDialog();
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

        private void tabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem focusedItem = tabctlItems.SelectedItem as TabItem;
            // NOTE: Indexes coupled with enum values!
            Button [] allTheButtons = { 
                                          btnNewProperty,
                                          btnNewTenant,
                                          btnNewOwner,
                                          btnNewHOA,
                                          btnNewVendor,
                                          btnNewPropertyManagementCompany
                                      };

            foreach (Button btn in allTheButtons)
                btn.Visibility = Visibility.Collapsed;

            if (focusedItem.Tag != null)
                allTheButtons[(int)focusedItem.Tag].Visibility = Visibility.Visible;

            if (focusedItem == tabItemServiceCalls)
                ViewModel.WorkingContainer = null;

        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridRow source = sender as DataGridRow;
            int index = 0;

            // Tight coupling between these two arrays
            DataGrid[] allTheDataGrids = { 
                                          datagridPropertyList, 
                                          datagridTenantList, 
                                          datagridOwnerList, 
                                          datagridHOAList, 
                                          datagridVendorList, 
                                          datagridPropertyMgmtList,
                                          datagridServiceCalls
                                      };
            var invokeMethods = new Action [] {
                                                   delegate { ViewModel.WorkingContainer = ViewModel.WorkingProperty; },
                                                   delegate { ViewModel.WorkingContainer = ViewModel.WorkingTenant; },
                                                   delegate { ViewModel.WorkingContainer = ViewModel.WorkingOwner; },
                                                   delegate { ViewModel.WorkingContainer = ViewModel.WorkingHOA; },
                                                   delegate { ViewModel.WorkingContainer = ViewModel.WorkingVendor; },
                                                   delegate { ViewModel.WorkingContainer = ViewModel.WorkingPropertyMgmtCompany; },
                                                   delegate { ViewModel.WorkingContainer = null; },
                                                };

            for (index = 0; index < allTheDataGrids.Count(); index++)
            {
                if (allTheDataGrids[index].IsAncestorOf(source))
                {
                    invokeMethods[index]();
                    break;
                }
            }

            // *Should* be OK because of coupling
            ViewModel.OpenItemCommand.Execute((ItemType)index);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ViewModel.EventNewItemDialog -= ViewModel_NewItemDialog;
            ViewModel.EventOpenItemDialog -= ViewModel_EventOpenItemDialog;
        }
    }
}