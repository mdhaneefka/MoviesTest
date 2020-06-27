using System;
using System.Collections.Generic;
using System.Text;

namespace Maersk.Movies.Domain.Models
{
    public class MovieLocations : BaseEntity
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// ReleaseYear
        /// </summary>
        public Int32 ReleaseYear { get; set; }
        /// <summary>
        /// Locations
        /// </summary>
        public string Locations { get; set; }
        /// <summary>
        /// ReleaseYear
        /// </summary>
        public string FunFacts { get; set; }
        /// <summary>
        /// FunFacts
        /// </summary>
        public string ProductionCompany { get; set; }
        /// <summary>
        /// Distributor
        /// </summary>
        public string Distributor { get; set; }
        /// <summary>
        /// director
        /// </summary>
        public string Director { get; set; }
        /// <summary>
        /// Writer
        /// </summary>
        public string Writer { get; set; }
        /// <summary>
        /// Actor1
        /// </summary>
        public string Actor1 { get; set; }
        /// <summary>
        /// Actor2
        /// </summary>
        public string Actor2 { get; set; }
        /// <summary>
        /// Actor3
        /// </summary>
        public string Actor3 { get; set; }

    }
}
