using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class VetPassport
    {

        // ==============================================DETAILS OF OWNERSHIP

        // ==============================================DESCRIPTION OF ANIMAL
        [Key]
        public int Pet_Id { get; set; }

        [ForeignKey("Pet_Id")]
        public virtual Pet Pet { get; set; }

        public string PassportSerialNumber { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        // ==============================================MARKING OF ANIMAL

        [Required]
        public string TransponderAlphanumericCode { get; set; }

        [Required]
        public DateTime DateOfTransponderApplication { get; set; }

        [Required]
        [MaxLength(20)]
        public string TransponderLocation { get; set; }

        [Required]
        public string TattooAlphanumericalCode { get; set; }

        [Required]
        public DateTime DateOfTattooApplication { get; set; }

        [Required]
        [MaxLength(20)]
        public string TattooLocation { get; set; }

        // ==============================================ISSUING OF THE PASSPORT

        public int PassportIssuingOrgan_Id { get; set; }

        [ForeignKey("PassportIssuingOrgan_Id")]
        public virtual PassportIssuingOrgan PassportIssuingOrgan { get; set; }

        [Required]
        public DateTime DateOfIssuing { get; set; }

        // ==============================================VACCINATION AGAINST RABIES

    }
}