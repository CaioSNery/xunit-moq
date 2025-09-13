
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

            // Mantém uma cópia do valor original para checar o formato
            var original = value.Trim();

            // Remove formatação
            value = original.Replace(".", "").Replace("-", "");

            if (value.Length != CpfLength || !value.All(char.IsDigit))
                throw new ArgumentException("Invalid CPF format.");

            if (!IsValidCpf(value))
                throw new ArgumentException("Invalid CPF number.");



            return new Cpf(value); // sempre armazena "limpo"
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
        public string Formatted =>
    $"{Value.Substring(0, 3)}.{Value.Substring(3, 3)}.{Value.Substring(6, 3)}-{Value.Substring(9, 2)}";
        #endregion
    }
}