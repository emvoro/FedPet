using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class Pet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter pet name!")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Species { get; set; }

        public string PhotoLink { get; set; }

        public string Info { get; set; }

        [Required]
        [MaxLength(40)]
        public string Owner_Login { get; set; }

        [ForeignKey("Owner_Login")]
        public virtual Owner Owner { get; set; }

        //public ICollection<Vaccination> Vaccinations { get; set; }
    }
}
