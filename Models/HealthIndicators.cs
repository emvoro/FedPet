using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FedPet.Models
{
    public class HealthIndicators
    {
        [Key]
        public int Pet_Id { get; set; }

        [ForeignKey("Pet_Id")]
        public virtual Pet Pet { get; set; }

        public double Weight { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Obesity { get; set; }

        public bool SensitiveDigestion { get; set; }

        public bool Pregnancy { get; set; }

        public bool UrolithiasisDisease { get; set; }

        public bool HairLoss { get; set; }
    }
}
