using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRicos.Domain.Shared.Abstractions
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}