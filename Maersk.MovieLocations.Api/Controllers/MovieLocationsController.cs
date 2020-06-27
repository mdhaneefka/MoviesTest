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
        public IActionResult GetMovieLocations([FromQuery] PageParameters pageParameters, string SearchBy = "", string SearchByValue = "")
        {
            SeedAndCacheDataWhenFirstRequestComes();
            List<MovieLocation> resultCollections = null;
            var results = _movieLocationsQueries.GetMovieLocationsAsync(pageParameters); //seed should be place in separate class,insert data whne invoke soultion 
            if (results != null)
            {
                resultCollections = new List<MovieLocation>();
                List<GridHelper.Filter> filters = new List<GridHelper.Filter>();
                GridHelper.Filter gridHelper = new GridHelper.Filter();
                gridHelper.PropertyName = SearchBy;
                gridHelper.Value = SearchByValue;
                gridHelper.Operator = GridHelper.Operator.Contains;
                filters.Add(gridHelper);
                var filterExpression = ExpressionBuilder.GetExpression<MovieLocation>(filters);
                 resultCollections = _context.ListsMovieLocations.Where(filterExpression).ToList();

                //string selectStatement = "new ( " + SearchBy + ")";    //as per the scnerio need to get all rows match with value
                //var _filterResults = _context.ListsMovieLocations.Select(selectStatement);
                //_context.ListsMovieLocations.Where(x=>)

            }
            return Ok(resultCollections);





        }



        private static Func<Maersk.Movies.Domain.Models.MovieLocation, bool> GetDynamicQueryWithExpresionTrees(string propertyName, string val)
        {
            //x =>
            var param = Expression.Parameter(typeof(Maersk.Movies.Domain.Models.MovieLocation), "x");

            #region Convert to specific data type
            MemberExpression member = Expression.Property(param, propertyName);
            UnaryExpression valueExpression = GetValueExpression(propertyName, val, param);
            #endregion
            Expression body = Expression.Equal(member, valueExpression);
            var final = Expression.Lambda<Func<Maersk.Movies.Domain.Models.MovieLocation, bool>>(body: body, parameters: param);
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
                var movieLocations = new Maersk.Movies.Domain.Models.MovieLocation
                {
                    Id = 1,
                    Title = "Zodiac",
                    ReleaseYear = 2007,
                    Locations = "SF Chronicle Building (901 Mission St)",
                    FunFacts = "",
                    ProductionCompany = "Paramount Pictures",
                    Distributor = "Paramount Pictures",
                    Director = "David Fincher",
                    Writer = "James Vanderbilt",
                    Actor1 = "Jake Gyllenhaal",
                    Actor2 = "Mark Ruffalo",
                    Actor3 = "",
                };
                _context.ListsMovieLocations.Add(movieLocations);
                var movieLocations1 = new Maersk.Movies.Domain.Models.MovieLocation
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


    #region MovedToApplicationFolder
    //public class ExpressionBuilder
    //{
    //    // Define some of our default filtering options
    //    private static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
    //    private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
    //    private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

    //    public static Expression<Func<T, bool>> GetExpression<T>(List<GridHelper.Filter> filters)
    //    {
    //        // No filters passed in #KickIT
    //        if (filters.Count == 0)
    //            return null;

    //        // Create the parameter for the ObjectType (typically the 'x' in your expression (x => 'x')
    //        // The "parm" string is used strictly for debugging purposes
    //        ParameterExpression param = Expression.Parameter(typeof(T), "parm");

    //        // Store the result of a calculated Expression
    //        Expression exp = null;

    //        if (filters.Count == 1)
    //            exp = GetExpression<T>(param, filters[0]); // Create expression from a single instance
    //        else if (filters.Count == 2)
    //            exp = GetExpression<T>(param, filters[0], filters[1]); // Create expression that utilizes AndAlso mentality
    //        else
    //        {
    //            // Loop through filters until we have created an expression for each
    //            while (filters.Count > 0)
    //            {
    //                // Grab initial filters remaining in our List
    //                var f1 = filters[0];
    //                var f2 = filters[1];

    //                // Check if we have already set our Expression
    //                if (exp == null)
    //                    exp = GetExpression<T>(param, filters[0], filters[1]); // First iteration through our filters
    //                else
    //                    exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1])); // Add to our existing expression

    //                filters.Remove(f1);
    //                filters.Remove(f2);

    //                // Odd number, handle this seperately
    //                if (filters.Count == 1)
    //                {
    //                    // Pass in our existing expression and our newly created expression from our last remaining filter
    //                    exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));

    //                    // Remove filter to break out of while loop
    //                    filters.RemoveAt(0);
    //                }
    //            }
    //        }

    //        return Expression.Lambda<Func<T, bool>>(exp, param);
    //    }

    //    private static Expression GetExpression<T>(ParameterExpression param, GridHelper.Filter filter)
    //    {
    //        // The member you want to evaluate (x => x.FirstName)
    //        MemberExpression member = Expression.Property(param, filter.PropertyName);

    //        // The value you want to evaluate
    //        ConstantExpression constant = Expression.Constant(filter.Value);


    //        // Determine how we want to apply the expression
    //        switch (filter.Operator)
    //        {
    //            case GridHelper.Operator.Equals:
    //                return Expression.Equal(member, constant);

    //            case GridHelper.Operator.Contains:
    //                return Expression.Call(member, containsMethod, constant);

    //            case GridHelper.Operator.GreaterThan:
    //                return Expression.GreaterThan(member, constant);

    //            case GridHelper.Operator.GreaterThanOrEqual:
    //                return Expression.GreaterThanOrEqual(member, constant);

    //            case GridHelper.Operator.LessThan:
    //                return Expression.LessThan(member, constant);

    //            case GridHelper.Operator.LessThanOrEqualTo:
    //                return Expression.LessThanOrEqual(member, constant);

    //            case GridHelper.Operator.StartsWith:
    //                return Expression.Call(member, startsWithMethod, constant);

    //            case GridHelper.Operator.EndsWith:
    //                return Expression.Call(member, endsWithMethod, constant);
    //        }

    //        return null;
    //    }

    //    private static BinaryExpression GetExpression<T>(ParameterExpression param, GridHelper.Filter filter1, GridHelper.Filter filter2)
    //    {
    //        Expression result1 = GetExpression<T>(param, filter1);
    //        Expression result2 = GetExpression<T>(param, filter2);
    //        return Expression.AndAlso(result1, result2);
    //    }


    //}
    //public class GridHelper
    //{
    //    public enum Operator
    //    {
    //        Contains,
    //        GreaterThan,
    //        GreaterThanOrEqual,
    //        LessThan,
    //        LessThanOrEqualTo,
    //        StartsWith,
    //        EndsWith,
    //        Equals,
    //        NotEqual
    //    }

    //    public class Filter
    //    {
    //        public string PropertyName { get; set; }
    //        public string Value { get; set; }
    //        private Operator _op = Operator.Contains;
    //        public Operator Operator
    //        {
    //            get
    //            {
    //                return _op;
    //            }
    //            set
    //            {
    //                _op = value;
    //            }
    //        }
    //    }
    //}
    #endregion
}