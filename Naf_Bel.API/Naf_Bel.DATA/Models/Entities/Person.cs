using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace nafibel.DATA.Models.Entities
{
    public class Person : TrackedModel
    {
        [Key]
        public Ulid Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Unicode(true)]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;

        [Unicode(true)]
        [MaxLength(255)]
        public string MiddleName { get; set; } = string.Empty;

        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(10)]
        public string CountryCode { get; set; } = "CA";
        public string? State { get; set; }
        public string Region { get; set; } = null;

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        /// <summary>
        /// Retourne le nom complet basé sur un format donné
        /// </summary>
        /// <param name="fullNameFormat">Exemple : {FirstName} {LastName}</param>
        /// <returns>Nom complet formaté</returns>
        public string GetFullName(string fullNameFormat)
        {
            // Remplacer les placeholders {FirstName} et {LastName} par les valeurs correspondantes
            return fullNameFormat.Replace("{FirstName}", FirstName)
                                  .Replace("{LastName}", LastName)
                                  .Replace("{MiddleName}", MiddleName);
        }
    }
}
