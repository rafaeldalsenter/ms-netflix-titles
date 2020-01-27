using MsNetflixTitles.CrossCutting.Dtos;
using System.Threading.Tasks;

namespace MsNetflixTitles.Application.Repositories
{
    public interface INetflixTitlesRepository
    {
        Task<DirectorsByCountryDto> GetDirectorsByCountry(string countryName);
    }
}