using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class Owner
    {
        [Key]
        [MaxLength(40)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual OwnerData OwnerData { get; set; }
    }
}
