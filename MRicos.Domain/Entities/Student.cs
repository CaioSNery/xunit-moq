
using MRicos.Domain.Accounts.Entities.ValueObjects;
using MRicos.Domain.Shared;
using MRicos.Domain.Shared.Abstractions;
using MRicos.Domain.ValueObjects;

namespace MRicos.Domain.Accounts.Entities
{
    public sealed class Student : Entity
    {

        private Student(string firstName, string lastName,
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

        private Student(Name name,
        Email email,
        Cpf cpf,
        Password password,
        Address address,
        IDateTimeProvider dateTimeProvider) : base(Guid.NewGuid())
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Password = password;
            Address = address;
            Tracker = Tracker.Create(dateTimeProvider);

        }



        public static Student Create(string firstName, string lastName,
         string cpf,
         string email,
         string password,
         string address,
         IDateTimeProvider dateTimeProvider)
        {
            var student = new Student(firstName, lastName, cpf, email, password, address, dateTimeProvider);
            student.RaiseEvent(new Events.OnCreateStudentEvent(student.Id, student.Name, student.Email));
            return student;
        }

        public static Student Create(Name name,
        Email email,
        Cpf cpf,
        Password password,
        Address address,
        IDateTimeProvider dateTimeProvider)
        {

            var student = new Student(name, email, cpf, password, address, dateTimeProvider);
            student.RaiseEvent(new Events.OnCreateStudentEvent(student.Id, student.Name, student.Email));
            return student;
        }

        public Name Name { get; }
        public Email Email { get; }
        public Cpf Cpf { get; }
        public Password Password { get; }
        public Address Address { get; }
        public Tracker Tracker { get; private set; }

        public override string ToString() => Name;

    }
}