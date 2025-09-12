using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Shared;

namespace MRicos.Domain.Accounts.Entities
{
    public sealed class Student : Entity
    {


        public Student(string firstName,
         string lastName,
         string cpf,
         string email,
         string password) : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Email = email;
            Password = password;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}