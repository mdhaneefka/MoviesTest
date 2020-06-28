using AutoMapper;
using Maersk.Movies.Application.Dto;
using Maersk.Movies.Application.Helpers;
using Maersk.Movies.Application.Interface;
using Maersk.Movies.Data;
using Maersk.Movies.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maersk.Movies.Application.Persistenance.QueriesUsingMediator
{
    public class MovieLocationQueries
    {

        public class GetMovieLocationQueries : IRequest<IEnumerable<MovieLocation>>
        {
   
            public string SearchBy { get; set; }
            public string SearchByValue { get; set; }
            public string SearchByFilter { get; set; }
            public PageParameters pageParameters { get; set; }

        }

        public class GetMovieLocationQueriesHandler : IRequestHandler<GetMovieLocationQueries, IEnumerable<MovieLocation>>
        {
            private readonly MovieLocationsContext _db;
            private readonly IMapper _mapper;


            public GetMovieLocationQueriesHandler(MovieLocationsContext db)
            {
                _db = db;
            }
            public Task<IEnumerable<MovieLocation>> Handle(GetMovieLocationQueries request, CancellationToken cancellationToken)
            {

              var  resultCollections = new List<MovieLocation>();
                List<GridHelper.Filter> filters = new List<GridHelper.Filter>();
                GridHelper.Filter gridHelper = new GridHelper.Filter();
                gridHelper.PropertyName = request.SearchBy;
                gridHelper.Value = request.SearchByValue;
                if (!string.IsNullOrEmpty(request.SearchByFilter))
                    gridHelper.Operator = GridHelper.Operator.Contains;   //set it only for Single Contain to work 
                filters.Add(gridHelper);
                var filterExpression = ExpressionBuilder.GetExpression<MovieLocation>(filters);
                var filteResults = _db.ListsMovieLocations.Where(filterExpression).ToList();
               return Task.FromResult(filteResults as IEnumerable<MovieLocation>);
            }
        }
    }
}
