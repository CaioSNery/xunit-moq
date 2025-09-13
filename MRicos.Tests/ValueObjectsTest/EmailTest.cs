using System;
using MRicos.Domain.Accounts.Entities.ValueObjects;
using Xunit;

namespace MRicos.Tests.ValueObjectsTest
{
    public class EmailTest
    {
        [Theory]
        [InlineData("caio@balta.com")]
        [InlineData("test@example.com")]
        [InlineData("invalid@email.com")]
        public void ShouldReturnSucessIfEmailIsValid(string email)
        {
            var result = Email.Create(email);
            Assert.Equal(email, result.Address);
        }


        [Theory]
        [InlineData("")]
        [InlineData("tcom")]
        [InlineData("invalid.com")]
        public void ShouldFailToCreateAnInvalidEmail(string email)
        {
            Assert.Throws<ArgumentException>(() => Email.Create(email));
        }


        [Theory]
        [InlineData("a@b.c")]
        [InlineData("a@bc.c")]
        [InlineData("a@bcd.c")]
        public void ShouldReturnFailIfEmailIsInValid(string email)
        {
            Assert.Throws<ArgumentException>(() => Email.Create(email));
        }

        [Theory]
        [InlineData("a@b")]
        [InlineData("a@bc")]
        [InlineData("a@bcd")]
        public void ShouldFailToCreateAnEmailWithInvalidNumberOfCharacters(string email)
        {
            Assert.Throws<ArgumentException>(() => Email.Create(email));
        }


        [Fact]
        public void ShouldFailToCreateAnEmailWithInvalidFormat()
        {
            Assert.Throws<ArgumentException>(() => Email.Create("invalidemail.com"));
        }



    }
}