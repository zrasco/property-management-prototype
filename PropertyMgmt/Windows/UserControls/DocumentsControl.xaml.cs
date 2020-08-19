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
using PropertyMgmt.Utilities;

namespace PropertyMgmt.Windows.UserControls
{
    /// <summary>
    /// Interaction logic for DocumentsControl.xaml
    /// </summary>
    public partial class DocumentsControl : UserControl
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
        private ICollection<FileContainer> _fileContainerCollection = null;

        public DocumentsControl()
        {
            InitializeComponent();

            if (!ViewModelBase.IsInDesignModeStatic)
            {
                datagridDocuments.ItemsSource = _fileContainerCollection =
                ViewModel.WorkingContainer.GetType().GetProperty("FileContainers").GetValue(ViewModel.WorkingContainer) as ICollection<FileContainer>;
            }

        }

        private void datagridDocuments_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string fileToOpen = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + System.IO.Path.GetExtension(ViewModel.WorkingDocument.file_name);

            System.IO.File.WriteAllBytes(fileToOpen, ViewModel.WorkingDocument.File.file_data);
            System.Diagnostics.Process.Start(fileToOpen);
        }

        private void datagridDocuments_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string fileName in files)
                {
                    if (System.IO.File.GetAttributes(fileName).HasFlag(FileAttributes.Directory))
                    {
                        MessageBox.Show(fileName + " is a folder. You can only drag files into the documents container.", "Error - Unable to add item", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                        AddFileToContainer(fileName);
                }
            }
        }

        private void AddFileToContainer(string fileName)
        {
            FileContainer fc = new FileContainer();
            string fileNoPath = System.IO.Path.GetFileName(fileName);

            // Check if file with this name exists in container
            FileContainer result = null;

            result = (from fn in _fileContainerCollection
                          where fn.file_name == fileNoPath
                          select fn).FirstOrDefault();

            if (result == null || result.Visible == Visibility.Collapsed)
            {
                fc.File = new PropertyMgmt.Model.File();
                fc.File.file_data = System.IO.File.ReadAllBytes(fileName);

                fc.file_size = fc.File.file_data.Length;
                fc.date_modified = System.IO.File.GetLastWriteTime(fileName);
                fc.file_name = fileNoPath;

                _fileContainerCollection.Add(fc);
                ViewModel.AddAuditEntry(ViewModel.WorkingContainer, "Added file '" + fc.file_name + "'");

                UpdateGrid();
            }
            else
            {
                MessageBox.Show("The file " + fileNoPath + " is already in the list. Please rename the file before adding", "Error - Unable to add item", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteDocument_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.WorkingDocument != null)
            {
                ViewModel.WorkingDocument.Visible = Visibility.Collapsed;
                ViewModel.WorkingDocument = null;
                UpdateGrid();
            }
        }

        private void UpdateGrid()
        {
            datagridDocuments.ItemsSource = null;
            datagridDocuments.ItemsSource = _fileContainerCollection;
            datagridDocuments.UpdateLayout();
        }

        private void btnAddDocument_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            ofd.Multiselect = true;
            ofd.Title = "Select file(s) to add...";

            if (ofd.ShowDialog() == true)
            {
                foreach (string fileName in ofd.FileNames)
                {
                    AddFileToContainer(fileName);
                }

            }
        }
    }
}
