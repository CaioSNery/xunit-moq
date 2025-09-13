using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MRicos.Tests.ValueObjectsTest
{
    public class CpfTests
    {
        [Fact]
        public void Create_ValidCpf_ReturnsCpfObject()
        {
            var validCpf = "123.456.789-09";
            var cpf = Domain.Accounts.Entities.ValueObjects.Cpf.Create(validCpf);
            Assert.NotNull(cpf);
            Assert.Equal("12345678909", cpf.Value);
            Assert.Equal("123.456.789-09", cpf.Formatted);
        }

        [Fact]
        public void Create_EmptyCpf_ThrowsArgumentException()
        {

            var emptyCpf = "";


            var exception = Assert.Throws<ArgumentException>(() => Domain.Accounts.Entities.ValueObjects.Cpf.Create(emptyCpf));
            Assert.Equal("CPF cannot be empty.", exception.Message);
        }

        [Fact]
        public void Create_InvalidFormatCpf_ThrowsArgumentException()
        {

            var invalidFormatCpf = "123.456.789-0A";
            var exception = Assert.Throws<ArgumentException>(() => Domain.Accounts.Entities.ValueObjects.Cpf.Create(invalidFormatCpf));
            Assert.Equal("Invalid CPF format.", exception.Message);
        }
        [Fact]
        public void Create_InvalidNumberCpf_ThrowsArgumentException()
        {

            var invalidNumberCpf = "11111111111";
            var exception = Assert.Throws<ArgumentException>(() => Domain.Accounts.Entities.ValueObjects.Cpf.Create(invalidNumberCpf));
            Assert.Equal("Invalid CPF number.", exception.Message);
        }

    }
}