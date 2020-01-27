using Microsoft.AspNetCore.Mvc;
using MsNetflixTitles.Application.Repositories;
using MsNetflixTitles.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MsNetflixTitles.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class NetflixTitlesController : ControllerBase
    {
        private readonly INetflixTitlesRepository _netflixTitlesQueries;

        public NetflixTitlesController(INetflixTitlesRepository netflixTitlesQueries)
        {
            _netflixTitlesQueries = netflixTitlesQueries;
        }

        [Route("{countryName:string}")]
        [HttpGet]
        [ProducesResponseType(typeof(DirectorsByCountryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByCountry(string countryName)
            => Ok(await _netflixTitlesQueries.GetDirectorsByCountry(countryName));
    }
}