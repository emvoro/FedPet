using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class FeedingObject
    {
        public int Pet_Id { get; set; }

        public int Portion { get; set; }

        public int Interval { get; set; }

        //public virtual ScheduleObject ScheduleObject { get; set; }

        public FeedingObject(Feeding feeding) {
            Pet_Id = feeding.Pet_Id;
            Portion = feeding.Portion;
            Interval = feeding.Interval;
        }
    }
}
