using System;
using Qadia.Core.Enums;

namespace Qadia.Core.Dtos
{
    public class LawsuitDto
    {
        public Guid Id { get; set; }
        public string CaseNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string CourtName { get; set; } = string.Empty;
        public string? Circuit { get; set; }
        public string? Subject { get; set; }
        public string CaseType { get; set; } = string.Empty;
        public string Status { get; set; } = "نشطة";
        public string StatusColor { get; set; } = "#10B981";
        public string TypeColor { get; set; } = "#3B82F6";
    }
}
