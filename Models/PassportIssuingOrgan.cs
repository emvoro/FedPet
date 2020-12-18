using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class PassportIssuingOrgan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string NameOfVeterinarian { get; set; }

        [Required]
        [MaxLength(50)]
        public string AddressOfIssuing { get; set; }

        [Required]
        public string PostCodeOfIssuing { get; set; }

        [Required]
        [MaxLength(30)]
        public string CityOfIssuing { get; set; }

        [Required]
        [MaxLength(30)]
        public string CountryOfIssuing { get; set; }

        [Required]
        [MaxLength(20)]
        public string IssuingPhone { get; set; }

        [Required]
        [MaxLength(50)]
        public string IssuingEmail { get; set; }

    }
}
