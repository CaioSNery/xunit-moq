
using MRicos.Domain.Shared.ValueObjects;

namespace MRicos.Domain.Accounts.Entities.ValueObjects
{
    public sealed record Name : ValueObject
    {
        public const int MinLeghth = 2;
        public const int MaxLeghth = 50;

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;


        }

        public static Name Create(string firstName, string lastName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.");

            if (firstName.Length < MinLeghth || firstName.Length > MaxLeghth)
                throw new ArgumentException($"First name must be between {MinLeghth} and {MaxLeghth} characters.");

            if (lastName.Length < MinLeghth || lastName.Length > MaxLeghth)
                throw new ArgumentException($"Last name must be between {MinLeghth} and {MaxLeghth} characters.");

            return new Name(firstName, lastName);
        }

        public string FirstName { get; }
        public string LastName { get; }

        public static implicit operator string(Name name) => name.ToString();

        public override string ToString() => $"{FirstName} {LastName}";
    }
}