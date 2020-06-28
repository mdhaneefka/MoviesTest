using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maersk.MovieLocations.Api.Filters;
using Maersk.Movies.Application.Interface;
using Maersk.Movies.Application.Persistenance;
using Maersk.Movies.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Maersk.MovieLocations.Api
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
            services.AddControllers();
           // services.AddControllersWithViews(options => options.Filters.Add(new ApiExceptionFilter())); // need to test
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                    /* Apply CORS policy for any type of origin */
                    .AllowAnyMethod()
                    /* Apply CORS policy for any type of http methods  */
                    .AllowAnyHeader());
                    /* Apply CORS policy for any headers */
                   // .AllowCredentials());
                /* Apply CORS policy for all users  */
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Moviw Location API",
                    Version = "v2",
                    Description = "Service For Filter Movies Dara",
                });
            });
            //services.AddMvc()
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            //     .AddJsonOptions(options =>
            //     {
            //         options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            //         options.JsonSerializerOptions.IgnoreNullValues =true;
            //     });
            services.AddDbContext<MovieLocationsContext>(opt => opt.UseInMemoryDatabase("MoviesData"));
         
            services.AddTransient<IMovieLocationsQueries, MovieLocationQueriese>();
            services.AddTransient<MovieLocationsContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CORSPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Movie Info Services"));
           
            
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();

            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller}/{action=Index}/{id?}");

            //});
            //  app.UseMvc();

        }
    }
}
