using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maersk.Movies.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Maersk.Movies.Domain.Models;
using FluentValidation.AspNetCore;
using Maersk.Movies.Application.Interface;
using Maersk.Movies.Application.Persistenance;
//using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace Maersk.Movies.Api
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
         
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CORSPolicy", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
            //        /* Apply CORS policy for any type of origin */
            //        .AllowAnyMethod()
            //        /* Apply CORS policy for any type of http methods  */
            //        .AllowAnyHeader()
            //        /* Apply CORS policy for any headers */
            //        .AllowCredentials());
            //    /* Apply CORS policy for all users  */
            //});
            services.AddMvc(option => option.EnableEndpointRouting = false)
             .AddFluentValidation();
            services.AddDbContext<MovieLocationsContext>(opt => opt.UseInMemoryDatabase("MoviesData"));
            services.AddSwaggerGen(options =>
            {
                //options.EnableAnnotations();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Movies API",
                        Version = "v1",
                        Description = "Movies Information",
                        Contact = new OpenApiContact { Name = "Access Informaton for Movies.", Email = "mdhaneef.ka@gmail.com" }
                    });
                c.DescribeAllParametersInCamelCase();
              //  c.OperationFilter<ExamplesOperationFilter>();
            });


            services.AddTransient<IMovieLocationsQueries, MovieLocationQueriese>();
            services.AddTransient<MovieLocationsContext, MovieLocationsContext>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});


            //app.UseCors("CORSPolicy");
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseSwagger();

            
            app.UseSwagger(c =>
            {
                /*Change the path of the end point , should also update UI middle ware for this change   */
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                /*Include virtual directory if site is configured so */
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("v1/swagger.json", "Movies API");
            });

            app.UseMvc();
        }

    }
}
