using Maersk.Movies.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maersk.Movies.Data
{
    public class MovieLocationsContext : DbContext
    {
        public MovieLocationsContext(DbContextOptions<MovieLocationsContext> options)
           : base(options)
        {
        }
        public DbSet<MovieLocation> ListsMovieLocations { get; set; }

    }

}
