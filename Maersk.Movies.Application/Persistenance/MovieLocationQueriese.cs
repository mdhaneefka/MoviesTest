using Maersk.Movies.Application.Dto;
using Maersk.Movies.Application.Helpers;
using Maersk.Movies.Application.Interface;
using Maersk.Movies.Data;
using Maersk.Movies.Domain;
using Maersk.Movies.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<MovieLocation> GetMovieLocationsAsync(MovieLocationsDto movieLocationsDto)
        {
            List<MovieLocation> resultCollections = null;
            try
            {

                resultCollections = new List<MovieLocation>();
                List<GridHelper.Filter> filters = new List<GridHelper.Filter>();
                GridHelper.Filter gridHelper = new GridHelper.Filter();
                gridHelper.PropertyName = movieLocationsDto.SearchBy;
                gridHelper.Value = movieLocationsDto.SearchByValue;
                if (!string.IsNullOrEmpty(movieLocationsDto.SearchByFilter))
                    gridHelper.Operator = GridHelper.Operator.Contains;   //set it only for Single Contain to work 
                filters.Add(gridHelper);
                var filterExpression = ExpressionBuilder.GetExpression<MovieLocation>(filters);
                resultCollections = _db.ListsMovieLocations.Where(filterExpression).ToList();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Error occuered:"+ ex.Message.ToString());
            }
            return resultCollections;
        }

        private IQueryable<MovieLocation> GetQueryableLibraries(MovieLocationsDto movieLocationsDto)
        {
            return (from lst in _db.ListsMovieLocations
                    select new MovieLocation
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
