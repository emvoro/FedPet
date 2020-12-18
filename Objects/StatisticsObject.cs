using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class StatisticsObject
    {
        public int Pet_Id { get; set; }

        public DateTime DateOfFeeding { get; set; }

        public double AmountOfFood { get; set; }

        public StatisticsObject(Statistics statistics)
        {
            Pet_Id = statistics.Pet_Id;
            DateOfFeeding = statistics.DateOfFeeding;
            AmountOfFood = statistics.AmountOfFood;
        }
    }
}
