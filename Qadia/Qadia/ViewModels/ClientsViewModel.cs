using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Qadia.Core.Dtos;

namespace Qadia.ViewModels
{
    public class ClientsViewModel : INotifyPropertyChanged
    {
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }
        
        private bool _isAddClientDialogOpen;
        public bool IsAddClientDialogOpen
        {
            get => _isAddClientDialogOpen;
            set { _isAddClientDialogOpen = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ClientDto> Clients { get; set; }

        public ICommand AddClientCommand { get; }
        public ICommand ViewProfileCommand { get; }
        public ICommand EditClientCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand ExportCommand { get; }
        public ICommand CloseDialogCommand { get; }

        public ClientsViewModel()
        {
            Clients = new ObservableCollection<ClientDto>
            {
                new ClientDto { Id = 1, Name = "شركة المسار للاستثمار", PhoneNumber = "02-2345-6789", NationalId = "سجل تجاري: 123456", Address = "برج النيل، المعادي، القاهرة", ActiveCasesCount = 12, Status = "نشط", LastAction = "منذ 3 أيام" },
                new ClientDto { Id = 2, Name = "سارة يوسف النجار", PhoneNumber = "0100-987-6543", NationalId = "29512151234568", Address = "كمبوند سوديك، مدينة الشيخ زايد", ActiveCasesCount = 0, Status = "غير نشط", LastAction = "بالأمس" },
                new ClientDto { Id = 3, Name = "أحمد محمود الشناوي", PhoneNumber = "0123-456-7890", NationalId = "29001011234567", Address = "15 شارع الثورة، الدقي، الجيزة", ActiveCasesCount = 5, Status = "نشط", LastAction = "منذ ساعتين" },
                new ClientDto { Id = 4, Name = "محمد علي حسن", PhoneNumber = "0111-222-3334", NationalId = "28506121400987", Address = "الإسكندرية", ActiveCasesCount = 3, Status = "نشط", LastAction = "تحديث مستند توكيل" },
                new ClientDto { Id = 5, Name = "فاطمة زينهم كمال", PhoneNumber = "0155-888-9990", NationalId = "29210200100554", Address = "مدينة نصر", ActiveCasesCount = 1, Status = "نشط", LastAction = "جلسة استماع غداً" }
            };

            AddClientCommand = new RelayCommand(o => {
                IsAddClientDialogOpen = true;
            });
            
            CloseDialogCommand = new RelayCommand(o => {
                IsAddClientDialogOpen = false;
            });

            ViewProfileCommand = new RelayCommand(o => { });
            EditClientCommand = new RelayCommand(o => { });
            FilterCommand = new RelayCommand(o => { });
            ExportCommand = new RelayCommand(o => { });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
