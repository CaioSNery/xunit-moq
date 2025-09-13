using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;
using MRicos.Domain.Shared.ValueObjects;

namespace MRicos.Domain.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public Address(string street, string city, string state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;

            AddNotifications(new Contract<Address>()
                .Requires()
                .IsNotNullOrEmpty(Street, "Street", "Street cannot be empty.")
                .IsNotNullOrEmpty(City, "City", "City cannot be empty.")
                .IsNotNullOrEmpty(State, "State", "State cannot be empty.")
                .IsNotNullOrEmpty(ZipCode, "ZipCode", "ZipCode cannot be empty.")
            );
        }

        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }


    }
}