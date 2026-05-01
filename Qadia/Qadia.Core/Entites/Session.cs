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
    public class Session : BaseEntity, ISoftDeletable
    {
        [Required]
        public DateTime SessionDate { get; set; }

        [MaxLength(1000)]
        public string? Requirements { get; set; }

        // Nullable Decision Type (لأنها تتحدد بعد الجلسة)
        public SessionDecisionType? DecisionType { get; set; }

        [MaxLength(2000)]
        public string? Decision { get; set; }

        public bool IsActioned { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        [Required]
        public Guid LawsuitId { get; set; }
        [ForeignKey(nameof(LawsuitId))]
        public virtual Lawsuit Lawsuit { get; set; } = null!;
    }
}
