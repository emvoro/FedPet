using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class Statistics
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        public int Pet_Id { get; set; }

        [ForeignKey("Pet_Id")]
        public virtual Pet Pet { get; set; }

        public DateTime DateOfFeeding { get; set; }

        public double AmountOfFood { get; set; }
    }
}
