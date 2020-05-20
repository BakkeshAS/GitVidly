using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movies
        public ActionResult Random()
        {
            // var movie = _context.Movies.Include(c => c.GenreType).ToList();

            //return View(movie);// will return viewresult object derived from viewresultbase which inturn derived from ActionResults.
            return View();
        }

        public ActionResult MovieDetails(int Id)
        {
           // var movie = _context.Movies.Include(c => c.GenreType).SingleOrDefault(c => c.Id == Id);

            //return View(movie);
            return View();
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

        [HttpPost]
        public ActionResult Save()
        {
            return View();
        }

        public ActionResult MovieForm()
        {
            return View();
        }
       
    }
}