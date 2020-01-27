using Microsoft.Extensions.DependencyInjection;
using MsNetflixTitles.Application.Repositories;
using MsNetflixTitles.Application.Services;
using MsNetflixTitles.CrossCutting;

namespace MsNetflixTitles.Api
{
    public class IocStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICassandraContext, CassandraContext>();
            services.AddScoped<INetflixTitlesRepository, NetflixTitlesRepository>();
            services.AddScoped<ICreateNetflixTitleServices, CreateNetflixTitleServices>();
        }
    }
}