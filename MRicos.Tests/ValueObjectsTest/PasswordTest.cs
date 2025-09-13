using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Accounts.Entities.ValueObjects;
using Xunit;

namespace MRicos.Tests.ValueObjectsTest
{
    public class PasswordTest
    {
        [Fact]
        public void ShouldReturnSuccessIfPasswordIsValid()
        {
            var password = Password.Create("ValidPassword123!");
            Assert.True(password.Challenge("ValidPassword123!"));
        }

        [Fact]
        public void ShouldFailChallengeWithWrongPassword()
        {
            var password = Password.Create("ValidPassword123!");
            Assert.False(password.Challenge("WrongPassword123!"));
        }

        [Fact]
        public void ShouldGeneratePasswordWhenNoneProvided()
        {
            var password = Password.Create();
            Assert.False(string.IsNullOrEmpty(password.Hash));
        }


    }
}