using MsNetflixTitles.CrossCutting.Dtos;
using System.Threading.Tasks;

namespace MsNetflixTitles.Application.Queries
{
    public interface INetflixTitlesQueries
    {
        Task<DirectorsByCountryDto> GetDirectorsByCountry(string countryName);
    }
}