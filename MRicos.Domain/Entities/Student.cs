
using MRicos.Domain.Accounts.Entities.ValueObjects;
using MRicos.Domain.Shared;
using MRicos.Domain.Shared.Abstractions;
using MRicos.Domain.ValueObjects;

namespace MRicos.Domain.Accounts.Entities
{
    public sealed class Student : Entity
    {
        public Student(string firstName, string lastName,
         string cpf,
         string email,
         string password,
         string address,
         IDateTimeProvider dateTimeProvider) : base(Guid.NewGuid())
        {
            Name = new Name(firstName, lastName);
            Cpf = Cpf.Create(cpf);
            Email = Email.Create(email);
            Password = Password.Create(password);
            Address = new Address(address, "", "", "");
            Tracker = Tracker.Create(dateTimeProvider);

        }

        public Name Name { get; }
        public Email Email { get; }
        public Cpf Cpf { get; }
        public Password Password { get; }
        public Address Address { get; }
        public Tracker Tracker { get; private set; }

    }
}