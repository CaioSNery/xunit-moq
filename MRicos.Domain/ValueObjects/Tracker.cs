using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Domain.Shared.Abstractions;
using MRicos.Domain.Shared.ValueObjects;

namespace MRicos.Domain.ValueObjects
{
    public sealed class Tracker : ValueObject
    {
        #region Properties
        public DateTime CreatedAtUtc { get; }

        public DateTime UpdateAtUtc { get; private set; }

        #endregion
        #region Constructors
        public Tracker(DateTime createdAtUtc, DateTime updateAtUtc)
        {

            CreatedAtUtc = createdAtUtc;
            UpdateAtUtc = updateAtUtc;
        }
        #endregion
        #region Factory 
        public static Tracker Create(IDateTimeProvider dateTimeProvider)
        {
            var now = dateTimeProvider.UtcNow;
            return new Tracker(now, now);
        }

        public static Tracker Create(DateTime createdAtUtc, DateTime updateAtUtc)
        {
            return new Tracker(createdAtUtc, updateAtUtc);
        }

        #endregion

        #region Methods
        public void Update(IDateTimeProvider dateTimeProvider)
        {
            UpdateAtUtc = dateTimeProvider.UtcNow;
        }
        #endregion
    }
}