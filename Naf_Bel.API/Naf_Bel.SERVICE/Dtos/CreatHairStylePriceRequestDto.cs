using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class CreatHairStylePriceRequestDto
    {
        [Required]
        public Ulid HairStyleId { get; set; }


        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;
   
    }
}
