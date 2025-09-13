using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MRicos.Tests.ValueObjectsTest
{
    public class AddressTests
    {
        [Fact]
        public void DeveCriarUmEnderecoValido()
        {
            var address = new Domain.ValueObjects.Address(
                "123 Main St",
                "Springfield",
                "IL",
                "62701");

            Assert.NotNull(address);
            Assert.Equal("123 Main St", address.Street);
            Assert.Equal("Springfield", address.City);
            Assert.Equal("IL", address.State);
            Assert.Equal("62701", address.ZipCode);
        }
    }
}