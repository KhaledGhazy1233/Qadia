namespace Qadia.Core.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public int ActiveCasesCount { get; set; }
        public string Status { get; set; }
        public string LastAction { get; set; }
        
        // For visual representation
        public string Initial => string.IsNullOrEmpty(Name) ? "" : Name.Substring(0, 1);
        public string StatusColor => Status == "نشط" ? "#10B981" : "#6B7280";
        public string StatusBgColor => Status == "نشط" ? "#D1FAE5" : "#F3F4F6";
    }
}
