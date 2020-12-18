using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class VetPassportObject
    {
        public string PassportSerialNumber { get; set; }

        public int Pet_Id { get; set; }

        public string Breed { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string TransponderAlphanumericCode { get; set; }

        public DateTime DateOfTransponderApplication { get; set; }

        public string TransponderLocation { get; set; }

        public string TattooAlphanumericalCode { get; set; }

        public DateTime DateOfTattooApplication { get; set; }

        public string TattooLocation { get; set; }

        public DateTime DateOfIssuing { get; set; }

        public VetPassportObject(VetPassport vetPassport) {
            PassportSerialNumber = vetPassport.PassportSerialNumber;
            Pet_Id = vetPassport.Pet_Id;
            Breed = vetPassport.Breed;
            DateOfBirth = vetPassport.DateOfBirth;
            TransponderAlphanumericCode = vetPassport.TransponderAlphanumericCode;
            DateOfTransponderApplication = vetPassport.DateOfTransponderApplication;
            TransponderLocation = vetPassport.TransponderLocation;
            TattooAlphanumericalCode = vetPassport.TattooAlphanumericalCode;
            DateOfTattooApplication = vetPassport.DateOfTattooApplication;
            TattooLocation = vetPassport.TattooLocation;
            DateOfIssuing = vetPassport.DateOfIssuing;
        }
    }
}
