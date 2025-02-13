using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.DATA.Models.Entities
{
    public class Rating
    {
        public Ulid Id { get; set; }

        [Required]
        public Ulid AppointmentId { get; set; }

        [Required]
        public Ulid HairdresserId { get; set; }

        [Required]
        public Ulid HairStyleId { get; set; }

        [Required]
        [Range(0D, 5)]
        public short Rate { get; set; }

        [Unicode(true)]
        [MaxLength(4000)]
        public string? Comments { get; set; }
    }
}
