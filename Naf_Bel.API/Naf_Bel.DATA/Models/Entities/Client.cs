using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.DATA.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Client : Person
    {
        public AgeRangeNum AgeRange { get; set; }

    }

    public enum AgeRangeNum
    {
        BelowTen,
        TenEighteen,
        EighteenThirty,
        ThirtyFortyFive,
        FortyFiveSixty,
        SixtyAbove,
    }
}
