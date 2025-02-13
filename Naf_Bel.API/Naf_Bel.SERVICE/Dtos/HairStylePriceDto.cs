using nafibel.DATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class HairStylePriceDto
    {

        public Ulid Id { get; set; }
        public Ulid HairStyleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Price { get; set; }

        public HairStylePriceDto()
        {

        }

        public HairStylePriceDto(HairStylePrice hairStylePrice)
        {
            Id = hairStylePrice.Id;
            StartDate = hairStylePrice.StartDate;
            EndDate = hairStylePrice.EndDate;
            Price = hairStylePrice.Price;
            HairStyleId = hairStylePrice.HairStyleId;

        }
    }
}
