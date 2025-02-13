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
    [Index(nameof(Name), IsUnique = true)]
    public class HairStyle : TrackedModel
    {
        [Key]
        public Ulid Id { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Unicode(true)]
        [MaxLength(4000)]
        public string Description { get; set; } = string.Empty;

        public List<HairTypeEnum> HairType { get; set; } =
            new List<HairTypeEnum>();

        public LengthEnum Length { get; set; }

        public SexEnum Sex { get; set; }

        public int? AverageTime { get; set; }

        public MaintenanceLevelEnum MaintenanceLevel { get; set; }

        public ICollection<HairStylePrice> HairStylePrices { get; set; } = new List<HairStylePrice>();

        public ICollection<HairStyleImage> Images { get; set; } = new List<HairStyleImage>();


        public ICollection<HairStyleNameLocale> Locales { get; set; } = new List<HairStyleNameLocale>();

        public List<HairdresserHairStyle> Hairdressers { get; set; } = new List<HairdresserHairStyle>();
    }
}
