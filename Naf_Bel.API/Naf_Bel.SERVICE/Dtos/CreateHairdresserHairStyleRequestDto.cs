using nafibel.DATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class CreateHairdresserHairStyleRequestDto
    {
        [Required]
        public Ulid HairdresserId { get; set; }

        public Hairdresser? Hairdresser { get; set; }

        [Required]
        public Ulid HairStyleId { get; set; }

        public HairStyle? HairStyle { get; set; }


        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
