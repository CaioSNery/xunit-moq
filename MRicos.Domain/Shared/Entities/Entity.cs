using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRicos.Domain.Shared
{
    public abstract class Entity : IEquatable<Guid>
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public bool Equals(Guid id) => Id == id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}