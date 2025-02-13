using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.DATA.Models.Entities
{
    public class HairStylePopularity
    {
        [Key]
        public Ulid HairStyleId { get; set; }

        [Required]
        [Range(0D, 20)]
        public short Popularity { get; set; }
    }
}
