using Maersk.Movies.Application.Dto;
using Maersk.Movies.Application.Helpers;
using Maersk.Movies.Application.Interface;
using Maersk.Movies.Data;
using Maersk.Movies.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maersk.Movies.Application.Persistenance
{
    public class MovieLocationQueriese : IMovieLocationsQueries
    {
        private readonly MovieLocationsContext _db;

        public MovieLocationQueriese(MovieLocationsContext db)
        {
            _db = db;
        }

        public PagedList<MovieLocationsDto> GetMovieLocationsAsync(PageParameters pageParameters)
        {
            return PagedList<MovieLocationsDto>
                                .Create(GetQueryableLibraries(), pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async System.Threading.Tasks.Task<MovieLocationsDto> GetMovieLocationsAsync(System.Linq.Expressions.Expression<Func<MovieLocationsDto, bool>> predicate)
            => await GetQueryableLibraries().Where(predicate).FirstOrDefaultAsync();

        private IQueryable<MovieLocationsDto> GetQueryableLibraries()
        {
            return (from lst in _db.ListsMovieLocations
                    select new MovieLocationsDto
                    {   Id= lst.Id,
                        Title = lst.Title,
                        ReleaseYear = lst.ReleaseYear,
                        Locations = lst.Locations,
                        Director = lst.Director

                    })
                   .OrderBy(x => x.ReleaseYear);


            }
    }

}
