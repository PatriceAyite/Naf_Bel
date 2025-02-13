using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.DATA.Models.Entities
{
    public class Notification
    {
        [Key]
        public Ulid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime NotificationDate { get; set; }

        public string Description { get; set; } = string.Empty;

        public NotificationTypeEnum NotificationType { get; set; }
    }


    public enum NotificationTypeEnum
    {
        NewAppointment,
        AppointmentStarted,
        HaircutDone,
    }
}
