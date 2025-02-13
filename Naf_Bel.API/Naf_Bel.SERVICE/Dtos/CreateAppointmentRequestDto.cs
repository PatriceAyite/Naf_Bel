using System.ComponentModel.DataAnnotations;

namespace nafibel.SERVICE.Dtos
{
    public class CreateAppointmentRequestDto
    {
        [Required]
        public DateOnly AppointmentDate { get; set; }

        [Required]
        public TimeOnly From { get; set; }

        [Required]
        public TimeOnly To { get; set; }

        [Required]
        public Ulid HairdresserId { get; set; }

        [Required]
        public Ulid HairStyleId { get; set; }

        public Ulid? ClientId { get; set; }

        [Required]
        [MaxLength(500)]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; } = "CA";

        public string? State { get; set; }
        public string? Region { get; set; }
        [Required]
        public LocationTypeEnum LocationType { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}