using Moq;
using MsNetflixTitles.Application.Queries;
using MsNetflixTitles.CrossCutting;
using MsNetflixTitles.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MsNetflixTitles.Application.Tests
{
    public class NetflixTitlesQueriesTests
    {
        private INetflixTitlesQueries MockQueryForGetDirectorsByCountry(List<DirectorByCountryDto> result)
        {
            var mockCassandraContext = new Mock<ICassandraContext>();

            var taskResult = Task.FromResult<IEnumerable<DirectorByCountryDto>>(result);

            mockCassandraContext
                .Setup(m => m.SelectAsync<DirectorByCountryDto>(It.IsAny<string>()))
                .Returns(() => taskResult);

            return new NetflixTitlesQueries(mockCassandraContext.Object);
        }

        private INetflixTitlesQueries MockExceptionForGetDirectorsByCountry()
        {
            var mockCassandraContext = new Mock<ICassandraContext>();

            mockCassandraContext
                .Setup(m => m.SelectAsync<DirectorByCountryDto>(It.IsAny<string>()))
                .Throws(new Exception());

            return new NetflixTitlesQueries(mockCassandraContext.Object);
        }

        [Fact]
        public async Task GetDirectorsByCountry_WithoutInfo()
        {
            var resultFromCassandra = new List<DirectorByCountryDto>();

            var mock = MockQueryForGetDirectorsByCountry(resultFromCassandra);

            var result = await mock.GetDirectorsByCountry("");

            Assert.False(result.IsValid());
        }

        [Fact]
        public async Task GetDirectorsByCountry_WithInfo()
        {
            var resultFromCassandra = new List<DirectorByCountryDto>
            {
                new DirectorByCountryDto(){ Name = "Director1", FilmsCount = 1 }
            };

            var mock = MockQueryForGetDirectorsByCountry(resultFromCassandra);

            var result = await mock.GetDirectorsByCountry("");

            Assert.True(result.IsValid());
        }

        [Fact]
        public async Task GetDirectorsByCountry_Exception()
        {
            var mock = MockExceptionForGetDirectorsByCountry();

            var result = await mock.GetDirectorsByCountry("");

            Assert.False(result.IsValid());
        }
    }
}