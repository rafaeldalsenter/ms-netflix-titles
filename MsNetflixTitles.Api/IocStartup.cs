using Microsoft.Extensions.DependencyInjection;
using MsNetflixTitles.Application.Queries;
using MsNetflixTitles.Application.Services;
using MsNetflixTitles.CrossCutting;

namespace MsNetflixTitles.Api
{
    public class IocStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICassandraContext, CassandraContext>();
            services.AddScoped<INetflixTitlesQueries, NetflixTitlesQueries>();
            services.AddScoped<ICreateNetflixTitleServices, CreateNetflixTitleServices>();
        }
    }
}