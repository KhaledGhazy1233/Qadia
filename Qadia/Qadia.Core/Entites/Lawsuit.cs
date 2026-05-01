using Qadia.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qadia.Core.Enums;

namespace Qadia.Infrastructure.Data
{
    public class Lawsuit : BaseEntity, ISoftDeletable
    {
        [Required(ErrorMessage = "رقم القضية مطلوب")]
        [MaxLength(50)]
        public string CaseNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "اسم المحكمة مطلوب")]
        [MaxLength(200)]
        public string CourtName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Circuit { get; set; }

        [MaxLength(500)]
        public string? Subject { get; set; }

        // Nullable Type
        public LawsuitType? Type { get; set; }

        // Default Status
        public LawsuitStatus Status { get; set; } = LawsuitStatus.Active;

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
