using System.Windows;
using Qadia.ViewModels;

namespace Qadia.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow(LoginViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}