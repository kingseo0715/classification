using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Medical.Views.Pages;

namespace Medical
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly string _username;
        public MainWindow(string username)
        {
            InitializeComponent();
            _username = username;

            try
            {
                var dashboard = new DashboardPage(username);
                MainFrame.Navigate(dashboard);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Navigate 실패: {ex.Message}\n{ex.StackTrace}");
            }

            
        }
    }
}