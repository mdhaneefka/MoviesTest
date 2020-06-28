using Maersk.Movies.Application.Dto;
using Maersk.Movies.Application.Helpers;
using Maersk.Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maersk.Movies.Application.Interface
{
	public interface IMovieLocationsQueries
	{
		PagedList<MovieLocation> GetMovieLocationsAsync(PageParameters pageParameters);
		Task<MovieLocation> GetMovieLocationsAsync(Expression<Func<MovieLocation, bool>> predicate);
	}
}
