using Microsoft.AspNetCore.Mvc;
using MsNetflixTitles.Application.Repositories;
using MsNetflixTitles.CrossCutting.Dtos;
using System.Net;
using System.Threading.Tasks;

namespace MsNetflixTitles.Api.Controllers
{
    [Route("netflix-titles")]
    public class NetflixTitlesController : ControllerBase
    {
        private readonly INetflixTitlesRepository _netflixTitlesRepository;

        public NetflixTitlesController(INetflixTitlesRepository netflixTitlesRepository)
        {
            _netflixTitlesRepository = netflixTitlesRepository;
        }

        [Route("get-by-country")]
        [HttpGet]
        [ProducesResponseType(typeof(DirectorsByCountryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByCountry(string countryName)
            => Ok(await _netflixTitlesRepository.GetDirectorsByCountry(countryName));
    }
}