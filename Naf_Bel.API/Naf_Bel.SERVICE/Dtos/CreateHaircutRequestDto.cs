using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class CreateHaircutRequestDto
    {
        [Required]
        public Ulid Id { get; set; }

        [Required]
        public Ulid AppointmentId { get; set; }

        public DateTime? StartHaircutDatetime { get; set; }

        public DateTime? EndHaircutDatetime { get; set; }

        [Required]
        public Ulid HairStyleId { get; set; }
    }
}
