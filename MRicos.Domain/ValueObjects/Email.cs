
using System.Text.RegularExpressions;

using MRicos.Domain.Shared.ValueObjects;

namespace MRicos.Domain.Accounts.Entities.ValueObjects
{
    public sealed partial class Email : ValueObject
    {

        #region Constants
        private const string Pattern = @"^\w+[^@\s]+@[^@\s]+\.[^@\s]+$";
        private const int MaxLength = 100;
        private const int MinLength = 5;

        #endregion

        #region Constructors
        private Email(string address)
        {
            Address = address;
        }
        #endregion

        #region Properties
        public string Address { get; } = string.Empty;

        #endregion

        #region Factory Method
        public static Email Create(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email cannot be empty.");

            if (!Regex.IsMatch(address, Pattern))
                throw new ArgumentException("Invalid email format.");

            address = address.Trim().ToLower();

            if (!EmailRegex().IsMatch(address))
                throw new ArgumentException("Invalid email format.");

            return new Email(address);
        }
        #endregion

        #region Source Generators
        [GeneratedRegex(Pattern)]
        public static partial Regex EmailRegex();
        #endregion

    }
}