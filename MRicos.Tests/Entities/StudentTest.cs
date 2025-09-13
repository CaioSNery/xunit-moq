using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Accounts.Entities;
using Xunit;

namespace Tests.Domain.Tests
{
    public class StudentTest
    {
        [Fact]
        public void DeveCriarUmEstudante()
        {
            var student = new Student(
                "Jhon",
                "Doe",
                "12345678900",
                "john.doe@example.com",
                "securepassword#!@22");
            Assert.NotNull(student);
            Assert.Equal("Jhon Doe", student.Name.ToString());
            Assert.Equal("12345678900", student.Cpf.ToString());
            Assert.Equal("john.doe@example.com", student.Email.Address.ToString());
            Assert.True(student.Password.Challenge("securepassword#!@22"));

        }






    }
}