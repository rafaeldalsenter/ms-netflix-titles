using MsNetflixTitles.CrossCutting;
using MsNetflixTitles.CrossCutting.Dtos;
using MsNetflixTitles.Domain;
using MsNetflixTitles.Domain.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsNetflixTitles.Application.Services
{
    public class CreateNetflixTitleServices : ICreateNetflixTitleServices
    {
        private readonly ICassandraContext _cassandraContext;

        public CreateNetflixTitleServices(ICassandraContext cassandraContext)
        {
            _cassandraContext = cassandraContext;
        }

        public async Task<NetflixTitleDto> Create(NetflixTitleDto dto)
        {
            try
            {
                dto.Id = Guid.NewGuid();

                var netFlixTitleDomain = new NetflixTitleBuilder()
                    .WithTitle(dto.Title)
                    .WithDirector(dto.Director)
                    .WithCountry(dto.Country)
                    .WithDurationMin(dto.DurationMin)
                    .WithCast(dto.Cast)
                    .WithId(dto.Id)
                    .Build();

                if (!netFlixTitleDomain.IsValid())
                {
                    return new NetflixTitleDto
                    {
                        ErrorMessage = netFlixTitleDomain.ErrorMessages.FirstOrDefault()
                    };
                }

                await _cassandraContext.InsertAsync(netFlixTitleDomain);
            }
            catch (Exception ex)
            {
                dto.ErrorMessage = $"Exceção não tratada: {ex.Message}";
            }

            return dto;
        }
    }
}