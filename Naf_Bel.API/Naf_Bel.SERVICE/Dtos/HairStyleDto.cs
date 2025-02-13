using Microsoft.Identity.Client;
using nafibel.DATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static nafibel.DATA.Models.Entities.Enums;

namespace nafibel.SERVICE.Dtos
{

    public class HairStyleDto
    {
        public Ulid id { get; set; }


        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<HairTypeEnum> HairType { get; set; }


        public LengthEnum Length { get; set; }

        public SexEnum Sex { get; set; }

        public int? AverageTime { get; set; }

        public MaintenanceLevelEnum MaintenanceLevel { get; set; }



        public HairStyleDto(HairStyle hairStyle)
        {

            id = hairStyle.Id;
            Name = hairStyle.Name;
            Sex = hairStyle.Sex;
            AverageTime = hairStyle.AverageTime;
            Description = hairStyle.Description;
            HairType = hairStyle.HairType;
            MaintenanceLevel = hairStyle.MaintenanceLevel;
            Length = hairStyle.Length;

        }

        public HairStyleDto()
        {

        }
    }

    public class HairStyleDtoWithPrices : HairStyleDto
    {
        public List<HairStylePriceDto> Prices { get; set; }

        public HairStyleDtoWithPrices(HairStyle hairStyle)
            :base(hairStyle)
        {
            this.Prices = hairStyle.HairStylePrices.Select(p => new HairStylePriceDto(p)).ToList();
        }
    }

}
