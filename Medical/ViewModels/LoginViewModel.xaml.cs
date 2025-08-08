using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Medical.Views
{
    /// <summary>
    /// LoginView.xaml에 대한 상호 작용 논리
    /// </summary>
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; }

        private string password;
        public string Password 
        { 
            get => password;
            set 
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
                
             
        }    
        
        public ICommand LoginCommand { get; set; }

       
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            if (Username == "admin" && Password == "1234")
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                   
                    var mainWindow = new MainWindow(Username);
                    mainWindow.Show();
                });
                foreach (Window window in Application.Current.Windows)
                {
                    if(window is LoginView)
                    {
                        window.Close();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("로그인실패");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        
    }
    
}
