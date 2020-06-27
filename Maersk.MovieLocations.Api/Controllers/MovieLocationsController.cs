using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maersk.Movies.Application.Helpers;
using Maersk.Movies.Application.Interface;
using Maersk.Movies.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Maersk.Movies.Domain.Models;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace Maersk.MovieLocations.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieLocationsController : ControllerBase
    {
      	private readonly IMovieLocationsQueries _movieLocationsQueries;

        private readonly MovieLocationsContext _context;
        public MovieLocationsController(IMovieLocationsQueries movieLocationsQueries, MovieLocationsContext context)
        {
            _movieLocationsQueries = movieLocationsQueries;
            _context = context;

        }

        [HttpGet]
        public IActionResult GetMovieLocations([FromQuery] PageParameters pageParameters,string SearchBy="",string SearchByValue ="")
        {
            SeedAndCacheDataWhenFirstRequestComes();
            var results = _movieLocationsQueries.GetMovieLocationsAsync(pageParameters); //seed should be place in separate class,insert data whne invoke soultion 
            if (results != null)
            {
                var dn = GetDynamicQueryWithExpresionTrees(SearchBy, SearchByValue);
                var output = _context.ListsMovieLocations.Where(dn).ToList();
                //string selectStatement = "new ( " + SearchBy + ")";    //as per the scnerio need to get all rows match with value
                //var _filterResults = _context.ListsMovieLocations.Select(selectStatement);
                //_context.ListsMovieLocations.Where(x=>)

            }
            return Ok(results);



        

            }



    private static Func<Maersk.Movies.Domain.Models.MovieLocations, bool> GetDynamicQueryWithExpresionTrees(string propertyName, string val)
    {
        //x =>
        var param = Expression.Parameter(typeof(Maersk.Movies.Domain.Models.MovieLocations), "x");

        #region Convert to specific data type
        MemberExpression member = Expression.Property(param, propertyName);
        UnaryExpression valueExpression = GetValueExpression(propertyName, val, param);
        #endregion
        Expression body = Expression.Equal(member, valueExpression);
        var final = Expression.Lambda<Func<Maersk.Movies.Domain.Models.MovieLocations, bool>>(body: body, parameters: param);
        return final.Compile();
    }

    private static UnaryExpression GetValueExpression(string propertyName, string val, ParameterExpression param)
    {
        var member = Expression.Property(param, propertyName);
        var propertyType = ((PropertyInfo)member.Member).PropertyType;
        var converter = TypeDescriptor.GetConverter(propertyType);

        if (!converter.CanConvertFrom(typeof(string)))
            throw new NotSupportedException();

        var propertyValue = converter.ConvertFromInvariantString(val);
        var constant = Expression.Constant(propertyValue);
        return Expression.Convert(constant, propertyType);
    }




private void SeedAndCacheDataWhenFirstRequestComes()
        {
            if (!_context.ListsMovieLocations.Any())
            {
                var movieLocations = new Maersk.Movies.Domain.Models.MovieLocations
                {
                    Id = 1,
                    Title = "Zodiac",
                    ReleaseYear = 2007,
                    Locations = "SF Chronicle Building (901 Mission St)",
                    FunFacts = "",
                    ProductionCompany = "Paramount Pictures",
                    Distributor = "Paramount Pictures"
,
                    Director = "David Fincher",
                    Writer = "James Vanderbilt",
                    Actor1 = "Jake Gyllenhaal",
                    Actor2 = "Mark Ruffalo",
                    Actor3 = "",
                };
                _context.ListsMovieLocations.Add(movieLocations);
                var movieLocations1 = new Maersk.Movies.Domain.Models.MovieLocations
                {
                    Id = 2,
                    Title = "Yours, Mine and Ours",
                    ReleaseYear = 1968,
                    FunFacts = "",
                    ProductionCompany = "Desilu Productions",
                    Distributor = "United Artists",
                    Director = "Melville Shavelson",
                    Writer = "Bob Carroll, Jr.",
                    Actor1 = "Lucille Ball",
                    Actor2 = "Henry Fonda",
                    Actor3 = "Van Johnson"
                };
                _context.ListsMovieLocations.Add(movieLocations1);
                _context.SaveChangesAsync();

            }
        }
    }
}