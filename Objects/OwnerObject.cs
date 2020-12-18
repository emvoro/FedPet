using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class OwnerObject
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public OwnerObject(Owner owner)
        {
            Login = owner.Login;
            Password = owner.Password;
        }
    }
}
