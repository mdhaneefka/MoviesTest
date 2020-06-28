using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maersk.Movies.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Maersk.Movies.Application.Persistenance.QueriesUsingMediator.MovieLocationQueries;

namespace Maersk.MovieLocations.Api.Controllers
{
    public class MovieLocationUsingMediatorController : AbstractBaseCustomController
    {
        [HttpPost]
        public async Task<IEnumerable<MovieLocation>> Get(GetMovieLocationQueries getMovieLocationQueries)
        {
            return await Mediator.Send<IEnumerable<MovieLocation>>(getMovieLocationQueries);

            // i have to chane the request typq
        }

    }
}