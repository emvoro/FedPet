using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class Schedule
    {
        [Key]
        public int Pet_Id { get; set; }

        [ForeignKey("Pet_Id")]
        public virtual Feeding Feeding { get; set; }

        public string FirstFeeding { get; set; }

        public string SecondFeeding { get; set; }

        public string ThirdFeeding { get; set; }
    }
}
