using System;
using Xunit;

namespace Hangfire.MySql.Tests
{
    public class StorageOptionsTests
    {
        [Fact]
        public void Ctor_SetsTheDefaultOptions()
        {
            var options = new MySqlStorageOptions();

            Assert.True(options.QueuePollInterval > TimeSpan.Zero);
            // warning CS0618: 'MySqlStorageOptions.InvisibilityTimeout' is obsolete: 'Does not make sense anymore. Background jobs re-queued instantly even after ungraceful shutdown now. Will be removed in 2.0.0.'
            // Assert.True(options.InvisibilityTimeout > TimeSpan.Zero);
            Assert.True(options.JobExpirationCheckInterval > TimeSpan.Zero);
            Assert.True(options.PrepareSchemaIfNecessary);
        }

        [Fact]
        public void Set_QueuePollInterval_ShouldThrowAnException_WhenGivenIntervalIsEqualToZero()
        {
            var options = new MySqlStorageOptions();
            Assert.Throws<ArgumentException>(
                () => options.QueuePollInterval = TimeSpan.Zero);
        }

        [Fact]
        public void Set_QueuePollInterval_ShouldThrowAnException_WhenGivenIntervalIsNegative()
        {
            var options = new MySqlStorageOptions();
            Assert.Throws<ArgumentException>(
                () => options.QueuePollInterval = TimeSpan.FromSeconds(-1));
        }

        [Fact]
        public void Set_QueuePollInterval_SetsTheValue()
        {
            var options = new MySqlStorageOptions();
            options.QueuePollInterval = TimeSpan.FromSeconds(1);
            Assert.Equal(TimeSpan.FromSeconds(1), options.QueuePollInterval);
        }
    }
}
