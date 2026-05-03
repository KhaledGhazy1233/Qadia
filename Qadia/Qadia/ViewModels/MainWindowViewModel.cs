using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Qadia.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string UserName { get; set; } = "أحمد المنصور";
        public string UserRole { get; set; } = "مستشار قانوني";
        public string UserInitials { get; set; } = "أ";

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; }
        public ICommand ClientsCommand { get; }
        public ICommand CasesCommand { get; }
        public ICommand SessionsCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand NewFileCommand { get; }

        public ObservableCollection<SessionModel> TodaySessions { get; set; }
        public ObservableCollection<AlertModel> UrgentAlerts { get; set; }

        public MainWindowViewModel()
        {
            HomeCommand = new RelayCommand(o => CurrentViewModel = null);
            ClientsCommand = new RelayCommand(o => CurrentViewModel = new ClientsViewModel());
            CasesCommand = new RelayCommand(o => CurrentViewModel = new CasesViewModel());
            SessionsCommand = new RelayCommand(o => CurrentViewModel = new SessionsViewModel());
            SettingsCommand = new RelayCommand(o => { });
            NewFileCommand = new RelayCommand(o => { });

            // Set initial view
            CurrentViewModel = null;

            TodaySessions = new ObservableCollection<SessionModel>
            {
                new SessionModel { Time = "09:00 ص", ClientCase = "مجموعة الفطيم العقارية\nدعوى بطلان عقد - م ق رقم 432 لسنة 2023", Court = "جنايات القاهرة - ق 12", Requirements = "تقرير مذكرات", Decision = "تم الإجراء", ShowDatePicker = false, Status = "مكتمل", StatusColor = "#10B981" },
                new SessionModel { Time = "10:30 ص", ClientCase = "شركة إعمار مصر\nمنازعة ضريبية - م رقم 3415", Court = "القضاء الإداري - ق 7", Requirements = "سداد رسوم", Decision = "تأجيل لـ...", ShowDatePicker = true, DecisionDate = "11/15/2023", Status = "جار التنفيذ", StatusColor = "#3B82F6" },
                new SessionModel { Time = "12:00 م", ClientCase = "ياسين إبراهيم خليل\nقضية جنائية رقم 9095", Court = "محكمة استئناف عالي", Requirements = "مرافعة ختامية", Decision = "اختر القرار...", ShowDatePicker = false, Status = "في الانتظار", StatusColor = "#6B7280" }
            };

            UrgentAlerts = new ObservableCollection<AlertModel>
            {
                new AlertModel { Title = "نهاية ميعاد طعن بالنقض", Details = "قضية 543/2023 - تنتهي اليوم", BorderColor = "#EF4444" },
                new AlertModel { Title = "جلسة خبراء غداً", Details = "مكتب خبراء وزارة العدل - 10 ص", BorderColor = "#E5E7EB" },
                new AlertModel { Title = "توقيع مستندات", Details = "موكل: م/ حسن زيدان", BorderColor = "#10B981" },
                new AlertModel { Title = "إشعار محضر جديد", Details = "قضية تعويضات 442", BorderColor = "#E5E7EB" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
    }

    public class SessionModel
    {
        public string Time { get; set; }
        public string ClientCase { get; set; }
        public string Court { get; set; }
        public string Requirements { get; set; }
        public string Decision { get; set; }
        public bool ShowDatePicker { get; set; }
        public string DecisionDate { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
    }

    public class AlertModel
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string BorderColor { get; set; }
    }
}