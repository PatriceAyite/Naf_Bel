using Microsoft.EntityFrameworkCore;
using nafibel.DATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class CreatePaymentRequestDto
    {
        [Key]
        public Ulid Id { get; set; }

        [Required]
        public Ulid HaircutId { get; set; }


        [Required]
        [Range(0, Double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string ClientName { get; set; } = string.Empty;

        public Ulid ClientId { get; set; }

        [Required]
        public PaymentTypeEnum PaymentType { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; }

        public string? ExternalId { get; set; }

        public string? ExternalPayload { get; set; }
    }
}
