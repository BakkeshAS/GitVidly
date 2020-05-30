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
        #region AppDbContext
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = _context.Movies.Include(c => c.GenreType).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Random",movie);// will return viewresult object derived from viewresultbase which inturn derived from ActionResults.
            return View("UserMoviesView", movie);
        }

        public ActionResult MovieDetails(int Id)
        {
            var movie = _context.Movies.Include(c => c.GenreType).SingleOrDefault(c => c.Id == Id);

            return View(movie);
        }
        // GET: Movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var viewModel = new MovieFormViewModel(movie)
            {
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " " + month);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (0 == movie.Id)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.Stock = movie.Stock;

            }
            _context.SaveChanges();

            return RedirectToAction("Random", "Movies");
        }

        
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            var viewModel = new MovieFormViewModel
            {
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View(viewModel);
        }
        

    }
}