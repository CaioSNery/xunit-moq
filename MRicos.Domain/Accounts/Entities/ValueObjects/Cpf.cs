
using MRicos.Domain.Shared.ValueObjects;

namespace MRicos.Domain.Accounts.Entities.ValueObjects
{
    public sealed record Cpf : ValueObject
    {
        #region Constants
        private const int CpfLength = 11;
        #endregion

        #region Constructors
        public Cpf(string value)
        {
            Value = value;
        }
        #endregion

        #region Factory Method
        public static Cpf Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF cannot be empty.");

            value = value.Trim().Replace(".", "").Replace("-", "");

            if (value.Length != CpfLength || !value.All(char.IsDigit))
                throw new ArgumentException("Invalid CPF format.");

            // Additional CPF validation logic can be added here
            if (!IsValidCpf(value))
                throw new ArgumentException("Invalid CPF number.");

            return new Cpf(value);
        }

        public static bool IsValidCpf(string cpf)
        {
            if (cpf.Distinct().Count() == 1) // Check for all digits being the same
                return false;
            return true;
        }



        #endregion

        #region Properties
        public string Value { get; }
        #endregion
    }
}