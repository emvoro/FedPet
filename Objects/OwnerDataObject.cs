using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;

namespace FedPet.Objects
{
    public class OwnerDataObject
    {
        public string Owner_Login { get; set; }

        public string OwnerName { get; set; }

        public string OwnerSurname { get; set; }

        public string OwnerAddress { get; set; }

        public string OwnerPostCode { get; set; }

        public string OwnerCity { get; set; }

        public string OwnerCountry { get; set; }

        public string OwnerPhoneNumber { get; set; }

        public string OwnerSignatureLink { get; set; }
        
        public OwnerDataObject(OwnerData ownerData)
        {
            Owner_Login = ownerData.Owner_Login;
            OwnerName = ownerData.OwnerName;
            OwnerSurname = ownerData.OwnerSurname;
            OwnerAddress = ownerData.OwnerAddress;
            OwnerPostCode = ownerData.OwnerPostCode;
            OwnerCity = ownerData.OwnerCity;
            OwnerCountry = ownerData.OwnerCountry;
            OwnerPhoneNumber = ownerData.OwnerPhoneNumber;
            OwnerSignatureLink = ownerData.OwnerSignatureLink;
        }
    }
}
