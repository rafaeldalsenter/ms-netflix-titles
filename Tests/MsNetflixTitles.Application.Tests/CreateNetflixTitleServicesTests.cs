using Moq;
using MsNetflixTitles.Application.Services;
using MsNetflixTitles.CrossCutting;
using MsNetflixTitles.CrossCutting.Dtos;
using MsNetflixTitles.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MsNetflixTitles.Application.Tests
{
    public class CreateNetflixTitleServicesTests
    {
        private ICreateNetflixTitleServices MockServiceForCreate()
        {
            var mockCassandraContext = new Mock<ICassandraContext>();

            mockCassandraContext
                .Setup(m => m.InsertAsync<NetflixTitle>(It.IsAny<NetflixTitle>()))
                .Returns(() => Task.CompletedTask);

            return new CreateNetflixTitleServices(mockCassandraContext.Object);
        }

        [Fact]
        public async Task Create_DomainIsValid()
        {
            var dto = new NetflixTitleDto
            {
                Director = "director",
                Country = "country",
                DurationMin = 1,
                Cast = "cast",
                Title = "title"
            };

            var mockService = MockServiceForCreate();

            var result = await mockService.Create(dto);

            Assert.True(result.IsValid());
        }

        [Fact]
        public async Task Create_DomainIsInvalid()
        {
            var dto = new NetflixTitleDto
            {
                Director = "director",
                Country = "country",
                DurationMin = 1,
                Cast = "cast"
            };

            var mockService = MockServiceForCreate();

            var result = await mockService.Create(dto);

            Assert.False(result.IsValid());
        }
    }
}