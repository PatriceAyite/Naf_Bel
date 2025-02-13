using Microsoft.EntityFrameworkCore;
using nafibel.DATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class HairStyleNameLocaleDto
    {
        public Ulid Id { get; set; }

        public Ulid HairstyleId { get; set; }

        public string Locale { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public HairStyleNameLocaleDto()
        {

        }

        public HairStyleNameLocaleDto(HairStyleNameLocale hairStyleNameLocale)
        {
            Id = hairStyleNameLocale.Id;
            Description = hairStyleNameLocale.Description;
            Locale = hairStyleNameLocale.Locale;
            Name = hairStyleNameLocale.Name;
            HairstyleId = hairStyleNameLocale.HairstyleId;
        }
    }
}
