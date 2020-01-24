using MsNetflixTitles.Domain.Base;
using System;

namespace MsNetflixTitles.Domain
{
    public class NetflixTitle : BaseDomain
    {
        public NetflixTitle(Guid id, string title, string director, string cast, string country, int durationMin, string description)
        {
            AddId(id);
            AddTitle(title);
            AddDirector(director);
            AddCast(cast);
            AddCountry(country);
            AddDurationMin(durationMin);
            AddDescription(description);
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Director { get; private set; }
        public string Cast { get; private set; }
        public string Country { get; private set; }
        public int DurationMin { get; private set; }
        public string Description { get; private set; }

        public void AddId(Guid id)
        {
            if (id == default)
            {
                AddError("Without id");
                return;
            }

            Id = id;
        }

        public void AddTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                AddError("Without title");
                return;
            }

            Title = title;
        }

        public void AddDirector(string director)
        {
            Director = director;
        }

        public void AddCast(string cast)
        {
            Cast = cast;
        }

        public void AddCountry(string country)
        {
            Country = country;
        }

        public void AddDurationMin(int durationMin)
        {
            DurationMin = durationMin;
        }

        public void AddDescription(string description)
        {
            Description = description;
        }
    }
}