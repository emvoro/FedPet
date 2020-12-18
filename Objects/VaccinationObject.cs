using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class VaccinationObject
    {
        public int Id { get; set; }

        public int Pet_Id { get; set; }

        public string ManufacturerAndVaccineName { get; set; }

        public string BatchNumber { get; set; }

        public DateTime DateOfVaccination { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public string AuthorizedVeterinarian { get; set; }

        public VaccinationObject(Vaccination vaccination)
        {
            Id = vaccination.Id;
            Pet_Id = vaccination.Pet_Id;
            ManufacturerAndVaccineName = vaccination.ManufacturerAndVaccineName;
            BatchNumber = vaccination.BatchNumber;
            DateOfVaccination = vaccination.DateOfVaccination;
            ValidFrom = vaccination.ValidFrom;
            ValidUntil = vaccination.ValidUntil;
            AuthorizedVeterinarian = vaccination.AuthorizedVeterinarian;
        }
    }
}
