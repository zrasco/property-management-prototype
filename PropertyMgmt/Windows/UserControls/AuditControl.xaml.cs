using System;
using System.Collections.Generic;
using System.Linq;
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
using PropertyMgmt.Model;
using System.Collections.ObjectModel;
using System.IO;
using PropertyMgmt.ViewModel;
using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace PropertyMgmt.Windows.UserControls
{
    /// <summary>
    /// Interaction logic for AuditControl.xaml
    /// </summary>
    public partial class AuditControl : UserControl
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

        private ICollection<AuditEntry> _auditContainerCollection = null;

        public AuditControl()
        {
            InitializeComponent();

            if (!ViewModelBase.IsInDesignModeStatic)
            {
                datagridAuditEntries.ItemsSource = _auditContainerCollection =
                ViewModel.WorkingContainer.GetType().GetProperty("AuditEntries").GetValue(ViewModel.WorkingContainer) as ICollection<AuditEntry>;
            }
        }

        private void UpdateGrid()
        {
            datagridAuditEntries.ItemsSource = null;
            datagridAuditEntries.ItemsSource = _auditContainerCollection;
            datagridAuditEntries.UpdateLayout();
        }
    }
}
