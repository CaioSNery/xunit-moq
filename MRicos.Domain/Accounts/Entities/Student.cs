
using MRicos.Domain.Accounts.Entities.ValueObjects;
using MRicos.Domain.Shared;

namespace MRicos.Domain.Accounts.Entities
{
    public sealed class Student : Entity
    {


        public Student(string firstName, string lastName,
         string cpf,
         string email,
         string password) : base(Guid.NewGuid())
        {
            Name = new Name(firstName, lastName);
            Cpf = Cpf.Create(cpf);
            Email = Email.Create(email);
            Password = Password.Create(password);

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("Password must have at least 6 characters.");
        }

        public Name Name { get; }
        public Email Email { get; }
        public Cpf Cpf { get; }
        public Password Password { get; }

    }
}