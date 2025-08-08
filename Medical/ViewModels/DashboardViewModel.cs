using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.ViewModels
{
    public class DashboardViewModel : ObservableObject
    {
        private string _loggedInUserName;
        public string LoggedInUserName
        {
            get => _loggedInUserName;
            set => SetProperty(ref _loggedInUserName, value);
        }

        public DashboardViewModel(string username)
        {
            LoggedInUserName = username;
        }
    }
}
