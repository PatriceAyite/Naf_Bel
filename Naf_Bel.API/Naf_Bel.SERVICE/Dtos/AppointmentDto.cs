namespace Naf_Bel.SERVICE.Dtos
{
    public class AppointmentDto
    {
        public Ulid Id { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
        public Ulid HairdresserId { get; set; }
        public Ulid HairStyleId { get; set; }
        public Ulid? ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = "CA";
        public string? State { get; set; }
        public string? Region { get; set; }
        public LocationTypeEnum LocationType { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public AppointmentDto(Appointment appointment)
        {
            Id = appointment.Id;
            AppointmentDate = appointment.AppointmentDate;
            From = appointment.From;
            To = appointment.To;
            HairdresserId = appointment.HairdresserId;
            HairStyleId = appointment.HairStyleId;
            ClientId = appointment.ClientId;
            ClientName = appointment.ClientName;
            CountryCode = appointment.CountryCode;
            State = appointment.State;
            Region = appointment.Region;
            LocationType = appointment.LocationType;
            Latitude = appointment.Latitude;
            Longitude = appointment.Longitude;
        }

        public AppointmentDto() { }
    }
}
