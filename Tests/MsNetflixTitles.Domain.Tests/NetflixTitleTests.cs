using MsNetflixTitles.Domain.Builder;
using System;
using Xunit;

namespace MsNetflixTitles.Domain.Tests
{
    public class NetflixTitleTests
    {
        [Fact]
        public void WithoutId_IsInvalid()
        {
            var domain = new NetflixTitleBuilder()
                .WithCast("cast example")
                .WithDescription("description example")
                .WithTitle("title example")
                .Build();

            Assert.False(domain.IsValid());
        }

        [Fact]
        public void WithoutTitle_IsInvalid()
        {
            var domain = new NetflixTitleBuilder()
                .WithCast("cast example")
                .WithDescription("description example")
                .WithId(Guid.NewGuid())
                .Build();

            Assert.False(domain.IsValid());
        }

        [Fact]
        public void WithoutDirector_IsValid()
        {
            var domain = new NetflixTitleBuilder()
                .WithDurationMin(1)
                .WithCountry("Brazil")
                .WithCast("cast example")
                .WithDescription("description example")
                .WithTitle("title example")
                .WithId(Guid.NewGuid())
                .Build();

            Assert.True(domain.IsValid());
        }

        [Fact]
        public void WithoutCast_IsValid()
        {
            var domain = new NetflixTitleBuilder()
                .WithDurationMin(1)
                .WithCountry("Brazil")
                .WithDescription("description example")
                .WithTitle("title example")
                .WithDirector("director example")
                .WithId(Guid.NewGuid())
                .Build();

            Assert.True(domain.IsValid());
        }

        [Fact]
        public void WithoutCountry_IsValid()
        {
            var domain = new NetflixTitleBuilder()
                .WithDurationMin(1)
                .WithDescription("description example")
                .WithTitle("title example")
                .WithDirector("director example")
                .WithCast("cast example")
                .WithId(Guid.NewGuid())
                .Build();

            Assert.True(domain.IsValid());
        }

        [Fact]
        public void WithoutDurationMin_IsValid()
        {
            var domain = new NetflixTitleBuilder()
                .WithDescription("description example")
                .WithTitle("title example")
                .WithDirector("director example")
                .WithCast("cast example")
                .WithId(Guid.NewGuid())
                .Build();

            Assert.True(domain.IsValid());
        }

        [Fact]
        public void WithoutDescription_IsValid()
        {
            var domain = new NetflixTitleBuilder()
                .WithDurationMin(1)
                .WithCountry("Brazil")
                .WithCast("cast example")
                .WithTitle("title example")
                .WithDirector("director example")
                .WithId(Guid.NewGuid())
                .Build();

            Assert.True(domain.IsValid());
        }
    }
}