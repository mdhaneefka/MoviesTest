using Maersk.Movies.Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Maersk.Movies.Application.Dto
{
   public class MovieLocationsDto 
    {
        [Required]
        public string SearchBy { get; set; }
        [Required]
        public string SearchByValue { get; set; }
        [Required]
        public string SearchByFilter { get; set; }
        public PageParameters pageParameters { get; set; }
    }
}
