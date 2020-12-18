using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class FeederObject
    {
        public int Pet_Id { get; set; }

        public bool AddFood { get; set; }

        public double CurrentWeight { get; set; }

        public FeederObject(Feeder feeder)
        {
            Pet_Id = feeder.Pet_Id;
            AddFood = feeder.AddFood;
            CurrentWeight = feeder.CurrentWeight;
        }
    }
}
