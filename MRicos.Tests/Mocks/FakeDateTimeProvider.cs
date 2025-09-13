using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Shared.Abstractions;

namespace MRicos.Tests.Mocks
{
    public class FakeDateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => new DateTime(2025, 1, 1, 12, 0, 0, DateTimeKind.Utc);

    }
}