using System;
using System.Collections.Generic;

namespace Qadia.Core.Dtos
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionDateString => SessionDate.ToString("dd MMMM yyyy");
        public string SessionTimeString => SessionDate.ToString("hh:mm tt");
        public string LawsuitNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public List<string> Requirements { get; set; } = new List<string>();
        public string Decision { get; set; } = "قيد الانتظار";
        public string DecisionType { get; set; } = "انتظار"; // انتظار, حكم, تأجيل, شطب
        public string StatusColor { get; set; } = "#F59E0B"; // Default orange for pending
        public string DecisionColor { get; set; } = "#F1F5F9"; // Default light gray background
        public string DecisionTextColor { get; set; } = "#64748B";
    }
}
