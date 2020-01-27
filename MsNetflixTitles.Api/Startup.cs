using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace MsNetflixTitles.Api
{
    public class Startup
    {
        private readonly IocStartup _ioc;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _ioc = new IocStartup();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            _ioc.ConfigureServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Netflix Titles API",
                    Description = "API para consulta de dataset Netflix Titles.",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Dalsenter",
                        Email = "rafaeldalsenter@gmail.com",
                        Url = new Uri("https://rafaeldalsenter.github.io"),
                    },
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Netflix Titles API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}