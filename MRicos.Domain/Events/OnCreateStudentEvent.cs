using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Shared.Events;

namespace MRicos.Domain.Events
{
    public sealed record OnCreateStudentEvent(Guid id, string Name, string Email) : IDomainEvents;

}