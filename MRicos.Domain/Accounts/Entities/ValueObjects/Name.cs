using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Shared.ValueObjects;

namespace MRicos.Domain.Accounts.Entities.ValueObjects
{
    public record Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public static implicit operator string(Name name) => name.ToString();

        public override string ToString() => $"{FirstName} {LastName}";
    }
}