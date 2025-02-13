using nafibel.DATA.Models.Entities;

namespace nafibel.SERVICE.Dtos
{
    public class HaircutDto
    {
        public Ulid Id { get; set; }
        public Ulid AppointmentId { get; set; }
        public DateTime? StartHaircutDatetime { get; set; }
        public DateTime? EndHaircutDatetime { get; set; }
        public Ulid HairStyleId { get; set; }   

        public HaircutDto(Haircut haircut)
        {
            Id = haircut.Id;
            AppointmentId = haircut.AppointmentId;
            StartHaircutDatetime = haircut.StartHaircutDatetime;
            EndHaircutDatetime = haircut.EndHaircutDatetime;
            HairStyleId = haircut.HairStyleId;
        }

        public HaircutDto() { }
    }
}
