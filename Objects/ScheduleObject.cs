using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class ScheduleObject
    {
        public int Pet_Id { get; set; }

        public string FirstFeeding { get; set; }

        public string SecondFeeding { get; set; }

        public string ThirdFeeding { get; set; }

        public ScheduleObject(Schedule schedule) {
            Pet_Id = schedule.Pet_Id;
            FirstFeeding = schedule.FirstFeeding;
            SecondFeeding = schedule.SecondFeeding;
            ThirdFeeding = schedule.ThirdFeeding;
        }
    }
}
