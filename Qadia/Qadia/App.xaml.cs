using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qadia.Infrastructure;
using Qadia.Views;
using Qadia.ViewModels;
using System.IO;
using System.Windows;

namespace Qadia
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public IConfiguration Configuration { get; private set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ربط الـ Infrastructure (الـ DbContext والـ Services)
            services.AddInfrastructure(Configuration);

            // تسجيل الـ ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<LoginViewModel>();

            // تسجيل الشاشات
            services.AddSingleton<MainWindow>();
            services.AddTransient<LoginWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                var loginViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
                var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();

                loginViewModel.LoginSuccess += (s, args) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                        Application.Current.MainWindow = mainWindow;
                        mainWindow.Show();
                        loginWindow.Close();
                    });
                };

                Application.Current.MainWindow = loginWindow;
                loginWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء تشغيل البرنامج: {ex.Message}\n{ex.InnerException?.Message}",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    // إنشاء وفتح شاشة تسجيل الدخول بدلاً من الشاشة الرئيسية
        //    var loginWindow = new Qadia.Views.LoginWindow();
        //    loginWindow.Show();
        //}
    }
}