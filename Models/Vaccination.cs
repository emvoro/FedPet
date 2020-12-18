using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class Vaccination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Pet_Id { get; set; }

        [ForeignKey("Pet_Id")]
        public virtual Pet Pet { get; set; }

        [Required]
        public string ManufacturerAndVaccineName { get; set; }

        [Required]
        public string BatchNumber { get; set; }

        [Required]
        public DateTime DateOfVaccination { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }

        [Required]
        public string AuthorizedVeterinarian { get; set; }
    }
}
