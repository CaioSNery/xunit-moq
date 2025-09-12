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
                "securepassword");
            Assert.NotNull(student);
            Assert.Equal("Jhon", student.FirstName);
            Assert.Equal("Doe", student.LastName);
            Assert.Equal("12345678900", student.Cpf);
            Assert.Equal("john.doe@example.com", student.Email);
            Assert.Equal("securepassword", student.Password);




        }






    }
}