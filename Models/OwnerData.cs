using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class OwnerData
    {
        [Key]
        public string Owner_Login { get; set; }
        
        [ForeignKey("Owner_Login")]
        public virtual Owner Owner { get; set; }

        [Required]
        public string OwnerName { get; set; }

        [Required]
        public string OwnerSurname { get; set; }

        [Required]
        public string OwnerAddress { get; set; }

        [Required]
        public string OwnerPostCode { get; set; }

        [Required]
        public string OwnerCity { get; set; }

        [Required]
        public string OwnerCountry { get; set; }

        [Required]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        public string OwnerSignatureLink { get; set; }
    }
}
