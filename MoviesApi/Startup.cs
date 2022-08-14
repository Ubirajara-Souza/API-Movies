using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoviesApi.Infra.Repositories.BaseContext;
using MoviesApi.Infra.Repositories;
using MoviesApi.Services;
using System;

namespace MoviesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MoviesApiContext>(opts =>
                       opts.UseLazyLoadingProxies().UseNpgsql(Configuration.GetConnectionString("MoviesApiConnection")));

            services.AddScoped<MovieRepository, MovieRepository>();
            services.AddScoped<AddressRepository, AddressRepository>();
            services.AddScoped<ManagerRepository, ManagerRepository>();
            services.AddScoped<MovieTheaterRepository, MovieTheaterRepository>();
            services.AddScoped<SessionRepository, SessionRepository>();

            services.AddScoped<MovieService, MovieService>();
            services.AddScoped<AddressService, AddressService>();
            services.AddScoped<ManagerService, ManagerService>();
            services.AddScoped<MovieTheaterService, MovieTheaterService>();
            services.AddScoped<SessionService, SessionService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviesApi", Version = "v1" });
            });
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
