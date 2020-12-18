using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class PetObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string PhotoLink { get; set; }

        public string Info { get; set; }

        public string Owner_Login { get; set; }

        public PetObject(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            Species = pet.Species;
            PhotoLink = pet.PhotoLink;
            Info = pet.Info;
            Owner_Login = pet.Owner_Login;
        }
    }
}
