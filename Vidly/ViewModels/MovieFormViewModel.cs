using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 20, ErrorMessage = "Please enter the stock between 1-20")]
        public int? Stock { get; set; }

        [Display(Name = "Genre")]
        public int? GenreTypeId { get; set; }

        public IEnumerable<GenreType> GenreTypes { get; set; }
        //public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                return 0 == Id ? "Add Movie" : "Edit Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreTypeId = movie.GenreTypeId;
            Stock = movie.Stock;
        }
    }
}