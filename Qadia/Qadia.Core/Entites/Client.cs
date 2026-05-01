using Qadia.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qadia.Infrastructure.Data
{
    public class Client : BaseEntity, ISoftDeletable
    {
        [Required(ErrorMessage = "اسم الموكل مطلوب")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(14)]
        public string? NationalId { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Lawsuit> Lawsuits { get; set; } = new List<Lawsuit>();
    }
}
