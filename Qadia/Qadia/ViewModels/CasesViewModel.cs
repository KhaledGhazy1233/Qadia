using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Qadia.Core.Dtos;

namespace Qadia.ViewModels
{
    public class CasesViewModel : INotifyPropertyChanged
    {
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        private bool _isAddCaseDialogOpen;
        public bool IsAddCaseDialogOpen
        {
            get => _isAddCaseDialogOpen;
            set { _isAddCaseDialogOpen = value; OnPropertyChanged(); }
        }

        public ObservableCollection<LawsuitDto> Cases { get; set; }

        public int SessionsToday { get; set; } = 89;
        public int TotalCases { get; set; } = 142;

        public ICommand FilterCommand { get; }
        public ICommand NewCaseCommand { get; }
        public ICommand EditCaseCommand { get; }
        public ICommand DeleteCaseCommand { get; }
        public ICommand ViewSessionsCommand { get; }
        public ICommand CloseDialogCommand { get; }

        public CasesViewModel()
        {
            Cases = new ObservableCollection<LawsuitDto>
            {
                new LawsuitDto 
                { 
                    CaseNumber = "/2024/5832 ج", 
                    ClientName = "أحمد عبد الله المري", 
                    CourtName = "محكمة دبي الابتدائية", 
                    Circuit = "الدائرة 15", 
                    Subject = "نزاع تجاري حول توريد معدات صناعية...", 
                    CaseType = "تجاري", 
                    Status = "نشطة", 
                    StatusColor = "#10B981", 
                    TypeColor = "#DBEAFE" 
                },
                new LawsuitDto 
                { 
                    CaseNumber = "/2023/11492 م", 
                    ClientName = "مؤسسة الكيان للتطوير", 
                    CourtName = "محكمة الاستئناف", 
                    Circuit = "دائرة العقود", 
                    Subject = "استئناف حكم تعويض عن إخلال تعاقدي", 
                    CaseType = "مدني", 
                    Status = "مغلقة", 
                    StatusColor = "#9CA3AF", 
                    TypeColor = "#F3F4F6" 
                },
                new LawsuitDto 
                { 
                    CaseNumber = "/2024/901 ج", 
                    ClientName = "سارة راشد الفاسي", 
                    CourtName = "محكمة الأسرة", 
                    Circuit = "الدائرة الثالثة", 
                    Subject = "قضية حضانة ونفقة صغار", 
                    CaseType = "أحوال", 
                    Status = "نشطة", 
                    StatusColor = "#10B981", 
                    TypeColor = "#FEF3C7" 
                }
            };

            FilterCommand = new RelayCommand(o => { });
            NewCaseCommand = new RelayCommand(o => IsAddCaseDialogOpen = true);
            CloseDialogCommand = new RelayCommand(o => IsAddCaseDialogOpen = false);
            EditCaseCommand = new RelayCommand(o => { });
            DeleteCaseCommand = new RelayCommand(o => { });
            ViewSessionsCommand = new RelayCommand(o => { });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
