using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MRicos.Tests.Mocks;
using Xunit;

namespace MRicos.Tests.ValueObjectsTest
{
    public class TrackerTests

    {
        private readonly FakeDateTimeProvider _dateTimeProvider;
        public TrackerTests()
        {
            _dateTimeProvider = new FakeDateTimeProvider();
        }

        [Fact]
        public void CreateTracker_ShouldInitializeProperties()
        {
            // Arrange
            var now = _dateTimeProvider.UtcNow;

            // Act
            var tracker = Domain.ValueObjects.Tracker.Create(_dateTimeProvider);

            // Assert
            Assert.Equal(now, tracker.CreatedAtUtc);
            Assert.Equal(now, tracker.UpdateAtUtc);
        }


    }
}