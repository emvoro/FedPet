using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class Feeding
    {
        [Key]
        public int Pet_Id { get; set; }

        [ForeignKey("Pet_Id")]
        public virtual Feeder Feeder { get; set; }

        [Required]
        public int Portion { get; set; }

        public int Interval { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
