using Maersk.Movies.Application.Dto;
using Maersk.Movies.Application.Helpers;
using Maersk.Movies.Application.Interface;
using Maersk.Movies.Application.Persistenance;
using Maersk.Movies.Data;
using Maersk.Movies.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Results;


namespace Maersk.Movies.Api.Controllers
{
    [Route("[controller]")]
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
        public IActionResult GetMovieLocations(PageParameters pageParameters)
		{
            if (!_context.ListsMovieLocations.Any())
            {
                var movieLocations = new MovieLocations
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
                var movieLocations1 = new MovieLocations
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
            var results = _movieLocationsQueries.GetMovieLocationsAsync(pageParameters);
			return Ok(results);
		}

	}
}
