using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class HealthIndicatorsObject
    {
        public int Pet_Id { get; set; }

        public double Weight { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Obesity { get; set; }

        public bool SensitiveDigestion { get; set; }

        public bool Pregnancy { get; set; }

        public bool UrolithiasisDisease { get; set; }

        public bool HairLoss { get; set; }

        public HealthIndicatorsObject(HealthIndicators healthIndicators)
        {
            Pet_Id = healthIndicators.Pet_Id;
            Weight = healthIndicators.Weight;
            DateOfBirth = healthIndicators.DateOfBirth;
            Obesity = healthIndicators.Obesity;
            SensitiveDigestion = healthIndicators.SensitiveDigestion;
            Pregnancy = healthIndicators.Pregnancy;
            UrolithiasisDisease = healthIndicators.UrolithiasisDisease;
            HairLoss = healthIndicators.HairLoss;
        }
    }
}
