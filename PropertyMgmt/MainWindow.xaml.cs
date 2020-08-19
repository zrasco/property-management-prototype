using System.Windows;
using PropertyMgmt.ViewModel;
using PropertyMgmt.Windows;

namespace PropertyMgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PropertyWindow pw = new PropertyWindow();

            pw.Show();
        }

        private void btnAdministration_Click(object sender, RoutedEventArgs e)
        {
            AdministrationWindow aw = new AdministrationWindow();

            aw.Show();
        }

    }
}