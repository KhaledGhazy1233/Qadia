using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;

namespace Qadia.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        private bool _isPasswordVisible;
        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set { _isPasswordVisible = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand TogglePasswordCommand { get; }

        public event EventHandler LoginSuccess;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            TogglePasswordCommand = new RelayCommand(ExecuteTogglePassword);
        }

        private void ExecuteLogin(object parameter)
        {
            if (Username == "admin" && Password == "123456")
            {
                ErrorMessage = string.Empty;
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ErrorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة";
            }
        }

        private void ExecuteTogglePassword(object parameter)
        {
            IsPasswordVisible = !IsPasswordVisible;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
