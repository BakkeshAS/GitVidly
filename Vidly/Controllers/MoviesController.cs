using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movies
        public ActionResult Random()
        {
            //var movie = new List<Movie>();
            //movie.Add(new Movie() { Name = "Shrek" });
            //movie.Add(new Movie() { Name = "Avengers" });
            var movie = new MoviesCollectionViewModel();
            
            movie.Movies.Add(new Movie() {Id=1, Name = "Shrek" });
            movie.Movies.Add(new Movie() {Id=2, Name = "Avengers" });

            return View(movie);// will return viewresult object derived from viewresultbase which inturn derived from ActionResults.
        }

        // GET: Movies
        public ActionResult Edit(int Id)
        {
            var movie = new Movie() {Id=Id, Name = "Likhi" };
            return View(movie);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +" "+ month);
        }
    }
}