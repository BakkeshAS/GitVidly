using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesCollectionViewModel
    {
        public List<Movie> Movies { get; set; }

        public MoviesCollectionViewModel()
        {
            Movies = new List<Movie>();
        }
    }
}