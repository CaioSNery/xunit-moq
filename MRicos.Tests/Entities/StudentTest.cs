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
                "securepassword#!@22",
                "123 Main St, Springfield, IL 62701");
            Assert.NotNull(student);
            Assert.Equal("Jhon Doe", student.Name.ToString());
            Assert.Equal("12345678900", student.Cpf.Value);
            Assert.Equal("john.doe@example.com", student.Email.Address.ToString());
            Assert.True(student.Password.Challenge("securepassword#!@22"));

        }

        [Fact]
        public void NaoDeveCriarUmEstudanteComCpfInvalido()
        {
            Assert.Throws<ArgumentException>(() => new Student(
                "Jhon",
                "Doe",
                "123",
                "john.doe@example.com",
                "securepassword#!@22",
                "123 Main St, Springfield, IL 62701"));
        }
        [Fact]
        public void NaoDeveCriarUmEstudanteComEmailInvalido()
        {
            Assert.Throws<ArgumentException>(() => new Student(
                "Jhon",
                "Doe",
                "12345678900",
                "john.doeexample.com",
                "securepassword#!@22",
                "123 Main St, Springfield, IL 62701"));
        }
        [Fact]
        public void NaoDeveCriarUmEstudanteComSenhaInvalida()
        {
            Assert.Throws<ArgumentException>(() => new Student(
                "Jhon",
                "Doe",
                "12345678900",
                "john.doe@example.com",
                "123",
                "123 Main St, Springfield, IL 62701"));
        }
        [Fact]
        public void NaoDeveCriarUmEstudanteComNomeInvalido()
        {
            Assert.Throws<ArgumentException>(() => new Student(
                "",
                "Doe",
                "12345678900",
                "john.doe@example.com",
                "securepassword#!@22",
                "123 Main St, Springfield, IL 62701"));
        }
    }
}


