using System.ComponentModel.DataAnnotations;
using static nafibel.DATA.Models.Entities.Enums;

namespace nafibel.SERVICE.Dtos
{
    public class CreateHairDresserRequestDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string MiddleName { get; set; } = string.Empty;


        public string PhoneNumber { get; set; } = string.Empty;

        public HaireDresserTypeEnum type { get; set; }

        public string CountryCode { get; set; } = "CA";
        public string? State { get; set; }
        public string? Region { get; set; }

        // Latitude et Longitude pour l'entrée utilisateur
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public DateTime? Dob { get; set; }
        public string? ProfileImage { get; set; }
        public string? ProfileText { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        [Required]
        public DateTime ModifiedOn { get; set; }

    }
}
