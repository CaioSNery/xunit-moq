using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Accounts.Entities.ValueObjects;
using MRicos.Domain.Shared;

namespace MRicos.Domain.Accounts.Entities
{
    public sealed class Student : Entity
    {


        public Student(string firstName, string lastName,
         string cpf,
         string email,
         string password) : base(Guid.NewGuid())
        {
            Name = new Name(firstName, lastName);
            Cpf = cpf;
            Email = Email.Create(email);
            Password = Password.Create(password);
        }

        public Name Name { get; }
        public Email Email { get; }
        public string Cpf { get; set; } = string.Empty;
        public Password Password { get; }

    }
}