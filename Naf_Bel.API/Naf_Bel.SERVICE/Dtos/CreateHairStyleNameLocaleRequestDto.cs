using System.ComponentModel.DataAnnotations;

namespace nafibel.SERVICE.Dtos
{
    public class CreateHairStyleNameLocaleRequestDto
    {
        [Required]
        public Ulid HairstyleId { get; set; } 

        [Required]
        public string Locale { get; set; } = string.Empty; 

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty; 

        [MaxLength(4000)]
        public string Description { get; set; } = string.Empty; 
    }
}
