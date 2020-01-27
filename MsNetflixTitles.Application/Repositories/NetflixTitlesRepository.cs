using MsNetflixTitles.CrossCutting;
using MsNetflixTitles.CrossCutting.Dtos;
using MsNetflixTitles.CrossCutting.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MsNetflixTitles.Application.Repositories
{
    public class NetflixTitlesRepository : INetflixTitlesRepository
    {
        private readonly ICassandraContext _cassandraContext;

        public NetflixTitlesRepository(ICassandraContext cassandraContext)
        {
            _cassandraContext = cassandraContext;
        }

        public async Task<DirectorsByCountryDto> GetDirectorsByCountry(string countryName)
        {
            if (countryName.IsNullOrWhiteSpace())
            {
                return new DirectorsByCountryDto
                {
                    ErrorMessage = $"Parâmetro 'countryName' obrigatório"
                };
            }

            try
            {
                var cqlQuery = @"select director as Name from netflix_titles where country=? allow filtering";

                var returnQuery = await _cassandraContext.SelectAsync<string>(cqlQuery, countryName);

                var directors = returnQuery.ToList();

                return new DirectorsByCountryDto
                {
                    Country = countryName,
                    Directors = directors,
                    ErrorMessage = !directors.Any() ? $"Não foi encontrado nenhum diretor para o país '{countryName}'" : null
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