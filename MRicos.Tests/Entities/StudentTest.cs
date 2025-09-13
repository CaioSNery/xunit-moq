using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Accounts.Entities;
using MRicos.Domain.Accounts.Entities.ValueObjects;
using MRicos.Domain.Shared.Abstractions;
using MRicos.Domain.ValueObjects;
using MRicos.Tests.Mocks;
using Xunit;

namespace Tests.Domain.Tests
{
    public class StudentTest
    {
        private readonly IDateTimeProvider _dateTimeProvider = new FakeDateTimeProvider();
        [Fact]
        public void ShouldCreateStudent()
        {
            var student = Student.Create(
                "Jhon",
                "Doe",
                "12345678900",
                "john.doe@example.com",
                "securepassword#!@22",
                "123 Main St, Springfield, IL 62701",
                _dateTimeProvider);
            Assert.Single(student.DomainEvents);

        }

        [Fact]
        public void ShouldCreateStudentWithValueObjects()
        {
            var name = Name.Create("Jhon", "Doe");
            var email = Email.Create("john.doe@example.com");
            var password = Password.Create("securepassword#!@22");
            var address = Address.Create("123 Main St, Springfield, IL 62701");
            var cpf = Cpf.Create("12345678900");

            var student = Student.Create(
                name,
                email,
                cpf,
                password,
                address,
                _dateTimeProvider);


            Assert.Single(student.DomainEvents);
        }
    }
}


