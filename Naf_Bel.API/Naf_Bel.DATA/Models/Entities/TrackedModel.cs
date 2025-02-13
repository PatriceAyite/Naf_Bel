using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.DATA.Models.Entities
{
    public class TrackedModel
    {

        [Required]
        public string CreatedBy { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string ModifiedBy { get; set; } = string.Empty;
        [Required]
        public DateTime ModifiedOn { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
