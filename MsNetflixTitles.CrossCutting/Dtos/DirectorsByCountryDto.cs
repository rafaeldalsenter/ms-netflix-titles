using System.Collections.Generic;

namespace MsNetflixTitles.CrossCutting.Dtos
{
    public class DirectorsByCountryDto : BaseDto
    {
        public string Country { get; set; }
        public IEnumerable<string> Directors { get; set; }
    }
}