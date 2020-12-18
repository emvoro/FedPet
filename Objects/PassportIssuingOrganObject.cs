using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class PassportIssuingOrganObject
    {
        public int Id { get; set; }

        public string NameOfVeterinarian { get; set; }

        public string AddressOfIssuing { get; set; }

        public string PostCodeOfIssuing { get; set; }

        public string CityOfIssuing { get; set; }

        public string CountryOfIssuing { get; set; }

        public string IssuingPhone { get; set; }

        public string IssuingEmail { get; set; }

        public PassportIssuingOrganObject(PassportIssuingOrgan passportIssuingOrgan)
        {
            Id = passportIssuingOrgan.Id;
            NameOfVeterinarian = passportIssuingOrgan.NameOfVeterinarian;
            AddressOfIssuing = passportIssuingOrgan.AddressOfIssuing;
            PostCodeOfIssuing = passportIssuingOrgan.PostCodeOfIssuing;
            CityOfIssuing = passportIssuingOrgan.CityOfIssuing;
            CountryOfIssuing = passportIssuingOrgan.CountryOfIssuing;
            IssuingPhone = passportIssuingOrgan.IssuingPhone;
            IssuingEmail = passportIssuingOrgan.IssuingEmail;
        }
    }
}
