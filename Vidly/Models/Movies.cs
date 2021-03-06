﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display (Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display (Name ="Number in stock")]
        [Range(1,20,ErrorMessage = "Please enter the stock between 1-20")]
        public int Stock { get; set; }
        
        public GenreType GenreType { get; set; }

        [Display(Name = "Genre")]
        public int GenreTypeId { get; set; }
    }
}