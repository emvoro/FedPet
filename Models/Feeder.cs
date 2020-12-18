using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class Feeder
    {
        [Key]
        public int Pet_Id { get; set; }
        
        [ForeignKey("Pet_Id")]
        public virtual Pet Pet { get; set; }

        public bool AddFood { get; set; }

        public double CurrentWeight { get; set; }
    }
}
