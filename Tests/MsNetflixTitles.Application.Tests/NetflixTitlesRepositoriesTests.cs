using Moq;
using MsNetflixTitles.Application.Repositories;
using MsNetflixTitles.CrossCutting;
using MsNetflixTitles.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MsNetflixTitles.Application.Tests
{
    public class NetflixTitlesRepositoriesTests
    {
        private INetflixTitlesRepository MockQueryForGetDirectorsByCountry(List<string> result)
        {
            var mockCassandraContext = new Mock<ICassandraContext>();

            var taskResult = Task.FromResult<IEnumerable<string>>(result);

            mockCassandraContext
                .Setup(m => m.SelectAsync<string>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => taskResult);

            return new NetflixTitlesRepository(mockCassandraContext.Object);
        }

        private INetflixTitlesRepository MockExceptionForGetDirectorsByCountry()
        {
            var mockCassandraContext = new Mock<ICassandraContext>();

            mockCassandraContext
                .Setup(m => m.SelectAsync<string>(It.IsAny<string>()))
                .Throws(new Exception());

            return new NetflixTitlesRepository(mockCassandraContext.Object);
        }

        [Fact]
        public async Task GetDirectorsByCountry_WithoutInfo()
        {
            var resultFromCassandra = new List<string>();

            var mock = MockQueryForGetDirectorsByCountry(resultFromCassandra);

            var result = await mock.GetDirectorsByCountry("Brazil");

            Assert.False(result.IsValid());
        }

        [Fact]
        public async Task GetDirectorsByCountry_WithInfo()
        {
            var resultFromCassandra = new List<string>
            {
                "Director1"
            };

            var mock = MockQueryForGetDirectorsByCountry(resultFromCassandra);

            var result = await mock.GetDirectorsByCountry("Brazil");

            Assert.True(result.IsValid());
        }

        [Fact]
        public async Task GetDirectorsByCountry_WithCountryEmpty()
        {
            var resultFromCassandra = new List<string>
            {
                "Director1"
            };

            var mock = MockQueryForGetDirectorsByCountry(resultFromCassandra);

            var result = await mock.GetDirectorsByCountry("");

            Assert.False(result.IsValid());
        }

        [Fact]
        public async Task GetDirectorsByCountry_Exception()
        {
            var mock = MockExceptionForGetDirectorsByCountry();

            var result = await mock.GetDirectorsByCountry("Brazil");

            Assert.False(result.IsValid());
        }
    }
}