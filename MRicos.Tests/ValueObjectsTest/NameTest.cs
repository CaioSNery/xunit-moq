using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Accounts.Entities.ValueObjects;
using Xunit;

namespace Tests.ValueObjectsTest
{
    public class NameTest
    {
        [Fact]
        public void ShouldOverrideToStringMethod()
        {
            var name = new Name("John", "Doe");
            Assert.Equal("John Doe", name.ToString());
        }
    }
}