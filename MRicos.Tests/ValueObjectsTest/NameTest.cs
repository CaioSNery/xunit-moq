
using System;
using MRicos.Domain.Accounts.Entities.ValueObjects;
using Xunit;

namespace Tests.ValueObjectsTest
{
    public class NameTest
    {
        private readonly Name _name = Name.Create("John", "Doe");


        [Fact]
        public void ShouldOverrideToStringMethod()
        {
            Assert.Equal("John Doe", _name.ToString());
        }

        [Fact]
        public void ImplicitOperatorNameToString()
        {
            var name = new Name("John", "Doe");
            string data = name;
            Assert.Equal("John Doe", data);
        }

        [Fact]
        public void CreateNewName()
        {
            var name = Name.Create("John", "Doe");
            string data = name;
            Assert.Equal("John Doe", data);
        }

        [Fact]
        public void ShouldFailWhenNumberCharactersAreInvalid()
        {
            Assert.Throws<ArgumentException>(() => Name.Create("John", "q"));
            Assert.Throws<ArgumentException>(() => Name.Create("J", "Doe"));
            Assert.Throws<ArgumentException>(() => Name.Create(new string('a', 51), "Doe"));
            Assert.Throws<ArgumentException>(() => Name.Create("John", new string('a', 51)));
        }
    }
}