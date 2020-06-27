using Maersk.Movies.Application.Dto;
using Maersk.Movies.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maersk.Movies.Application.Interface
{
	public interface IMovieLocationsQueries
	{
		PagedList<MovieLocationsDto> GetMovieLocationsAsync(PageParameters pageParameters);
		Task<MovieLocationsDto> GetMovieLocationsAsync(Expression<Func<MovieLocationsDto, bool>> predicate);
	}
}
