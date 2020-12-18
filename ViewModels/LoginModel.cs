using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FedPet.ViewModels
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage = "Enter your login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
