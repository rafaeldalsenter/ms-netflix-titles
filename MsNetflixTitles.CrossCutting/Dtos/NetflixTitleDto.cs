using System;

namespace MsNetflixTitles.CrossCutting.Dtos
{
    public class NetflixTitleDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Country { get; set; }
        public int DurationMin { get; set; }
        public string Description { get; set; }
    }
}