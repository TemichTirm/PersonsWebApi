using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using PersonsWebApi.Data.Implementation;
using PersonsWebApi.Data.Interfaces;
using PersonsWebApi.Domain.Implementation;
using PersonsWebApi.Domain.Interfaces;
using PersonsWebApi.Models;
using System.IO;

namespace PersonsWebApi
{
    public class Startup
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IDatabaseHandler<Person>, DatabaseHandler>();
            services.AddSingleton<IPersonsRepository, PersonsPepository>();
            services.AddScoped<IPersonsManager, PersonsManager>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonsWebApi", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "PersonsWebApi.xml");
                try
                {
                    c.IncludeXmlComments(filePath);
                }
                catch (FileNotFoundException e)
                {
                    _logger.Error($"File not found! {e.Message}");
                }
            });
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonsWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
