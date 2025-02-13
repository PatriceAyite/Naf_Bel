using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static nafibel.DATA.Models.Entities.Enums;

namespace nafibel.DATA.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Hairdresser : Person
    {
        public DateTime? Dob { get; set; }

        [Unicode(false)]
        public string? ProfileImage { get; set; }

        [Unicode(true)]
        [MaxLength(4000)]
        public string? ProfileText { get; set; }

        public HaireDresserTypeEnum type { get; set; }


        public List<HairdresserHairStyle> HairStyles { get; set; } = new List<HairdresserHairStyle>();
    }
}
