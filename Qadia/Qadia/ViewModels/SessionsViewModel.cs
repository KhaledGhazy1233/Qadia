using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Qadia.Core.Dtos;
using System.Collections.Generic;

namespace Qadia.ViewModels
{
    public class SessionsViewModel : INotifyPropertyChanged
    {
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SessionDto> Sessions { get; set; }

        public int CompletedThisMonth { get; set; } = 31;
        public int PendingDecisions { get; set; } = 12;
        public int SessionsToday { get; set; } = 4;

        public ICommand FilterCommand { get; }
        public ICommand NewSessionCommand { get; }
        public ICommand EditSessionCommand { get; }
        public ICommand DeleteSessionCommand { get; }
        public ICommand ViewHistoryCommand { get; }

        public SessionsViewModel()
        {
            Sessions = new ObservableCollection<SessionDto>
            {
                new SessionDto 
                { 
                    Id = Guid.NewGuid(),
                    SessionDate = new DateTime(2024, 10, 15, 9, 30, 0),
                    LawsuitNumber = "#2024/9842",
                    ClientName = "مؤسسة الحلول المبتكرة",
                    Requirements = new List<string> { "مذكرة رد", "سجل تجاري" },
                    Decision = "حكم قطعي",
                    DecisionType = "حكم",
                    StatusColor = "#10B981", // Green check
                    DecisionColor = "#DCFCE7",
                    DecisionTextColor = "#15803D"
                },
                new SessionDto 
                { 
                    Id = Guid.NewGuid(),
                    SessionDate = new DateTime(2024, 10, 18, 11, 0, 0),
                    LawsuitNumber = "#2024/5412",
                    ClientName = "عبدالله بن جاسم",
                    Requirements = new List<string> { "شهادة الشهود" },
                    Decision = "تأجيل للمرافعة",
                    DecisionType = "تأجيل",
                    StatusColor = "#F59E0B", // Orange clock
                    DecisionColor = "#F1F5F9",
                    DecisionTextColor = "#475569"
                },
                new SessionDto 
                { 
                    Id = Guid.NewGuid(),
                    SessionDate = new DateTime(2024, 10, 22, 8, 0, 0),
                    LawsuitNumber = "#2023/1105",
                    ClientName = "شركة المسار للمقاولات",
                    Requirements = new List<string> { "لا توجد متطلبات" },
                    Decision = "شطب الدعوى",
                    DecisionType = "شطب",
                    StatusColor = "#10B981", // Green check
                    DecisionColor = "#FEE2E2",
                    DecisionTextColor = "#B91C1C"
                }
            };

            FilterCommand = new RelayCommand(o => { });
            NewSessionCommand = new RelayCommand(o => { });
            EditSessionCommand = new RelayCommand(o => { });
            DeleteSessionCommand = new RelayCommand(o => { });
            ViewHistoryCommand = new RelayCommand(o => { });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
