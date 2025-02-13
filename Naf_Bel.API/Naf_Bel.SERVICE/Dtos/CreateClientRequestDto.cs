using Microsoft.EntityFrameworkCore;
using nafibel.DATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class CreateClientRequestDto
    {
        [Key]
        public string? Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;

        [Unicode(true)]
        [MaxLength(255)]
        public string MiddleName { get; set; } = string.Empty;

        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(10)]
        public string CountryCode { get; set; } = "CA";

        public string? State { get; set; }
        public string Region { get; set; } = string.Empty;

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public AgeRangeNum AgeRange { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
