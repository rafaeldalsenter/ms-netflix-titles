using MsNetflixTitles.CrossCutting;
using MsNetflixTitles.CrossCutting.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MsNetflixTitles.Application.Queries
{
    public class NetflixTitlesQueries : INetflixTitlesQueries
    {
        private readonly ICassandraContext _cassandraContext;

        public NetflixTitlesQueries(ICassandraContext cassandraContext)
        {
            _cassandraContext = cassandraContext;
        }

        public async Task<DirectorsByCountryDto> GetDirectorsByCountry(string countryName)
        {
            try
            {
                var cqlQuery = @"";

                var returnQuery = await _cassandraContext.SelectAsync<DirectorByCountryDto>(cqlQuery);

                return new DirectorsByCountryDto
                {
                    Country = countryName,
                    Directors = returnQuery,
                    ErrorMessage = !returnQuery.Any() ? $"Não foi encontrado nenhum diretor para o país '{countryName}'" : null
                };
            }
            catch (Exception ex)
            {
                return new DirectorsByCountryDto
                {
                    ErrorMessage = $"Exceção não tratada: {ex.Message}"
                };
            }
        }
    }
}