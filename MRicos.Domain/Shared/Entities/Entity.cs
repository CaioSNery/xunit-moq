using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Shared.Events;

namespace MRicos.Domain.Shared
{
    public abstract class Entity : IEquatable<Guid>
    {
        #region Domain Events
        private readonly List<IDomainEvents> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvents> DomainEvents => _domainEvents;
        public void ClearDomainEvents() => _domainEvents.Clear();
        public void RaiseEvent(IDomainEvents @domainEvent) => _domainEvents.Add(@domainEvent);
        #endregion

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public bool Equals(Guid id) => Id == id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}