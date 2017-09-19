using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ContosoAir.Data;
using ContosoAir.Data.Seed;
using System.IO;
using ContosoAir.Site.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ContosoAir.Site.Models;

namespace ContosoAir.Site
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(env.ContentRootPath)
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                     .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<MySettings>(Configuration);

            services.AddMvc();
            services.AddCors();
            
            //services.AddTransient<NotificationsService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            ConfigureDb(services);

            services.Configure<AppSettings>(Configuration);
            services.Configure<NotificationHubSettings>(Configuration.GetSection("NoficationHub"));

            return services.BuildServiceProvider();
        }

        public void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<Db>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("*"));

            InitalizeDatabase(serviceProvider);

            app.UseMvc();
        }

        private void InitalizeDatabase(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<Db>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            ContosoAirDbSeed.Seed(db);
        }
    }
}
