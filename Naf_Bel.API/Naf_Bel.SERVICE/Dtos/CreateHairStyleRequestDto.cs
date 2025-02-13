using System.ComponentModel.DataAnnotations;
using static nafibel.DATA.Models.Entities.Enums;

namespace nafibel.SERVICE.Dtos
{
    public class CreateHairStyleRequestDto
    {
      
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(4000)]
        public string Description { get; set; } = string.Empty;

        public List<HairTypeEnum> HairType { get; set; }


        public LengthEnum Length { get; set; }

        public SexEnum Sex { get; set; }

        public int? AverageTime { get; set; }

        public MaintenanceLevelEnum MaintenanceLevel { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        [Required]
        public DateTime ModifiedOn { get; set; }

    }
}
