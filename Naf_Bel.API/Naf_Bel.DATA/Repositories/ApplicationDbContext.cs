using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nafibel.DATA.Models.Entities;
using nafibel.DATA.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Naf_Bel.DATA.Repositories.UildConverter;

namespace Naf_Bel.DATA.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<HairStyle> HairStyles { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Haircut> Haircuts { get; set; }
        public DbSet<HairStylePrice> HairStylePrices { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<HairdresserHairStyle> HairdresserHairStyles { get; set; }
        public DbSet<HairStyleImage> HairStyleImages { get; set; }
        public DbSet<HairStyleNameLocale> HairStyleNameLocales { get; set; }
        public DbSet<HairStylePopularity> HairStylePopularities { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Ulid>()
                .HaveConversion<UlidToStringConverter>()
                .HaveConversion<UlidToBytesConverter>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Assure la création des tables pour Identity

            // Votre configuration d'entités existante
            modelBuilder.Entity<HairStyle>()
                .HasMany(e => e.HairStylePrices)
                .WithOne(e => e.HairStyle)
                .HasForeignKey(e => e.HairStyleId)
                .IsRequired();
        }
    }
}
