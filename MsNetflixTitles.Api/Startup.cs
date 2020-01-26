using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MsNetflixTitles.Api
{
    public class Startup
    {
        private readonly IocStartup _ioc;

        public Startup(IConfiguration configuration)
        {
            _ioc = new IocStartup();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _ioc.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
        }
    }
}