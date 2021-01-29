using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Linq;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            Movie movie = new Movie()
            {
                Name = "Sherk!"
            };

            //Different action results

            //return View(movie);
            //return Content("hello world!!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home",new { page=1,sortBy="name"});

            //methods to pass data to views

            //Method 1: pass the methos instance as argument;
            //return View(movie);

            //Method 2: using ViewData
            /*ViewData["Movie"] = movie;
            return View();*/

            //Method 3: using ViewBag
            /*ViewBag.Movie = movie;
            return View();*/

            //returning viewModel

            List<Customer> customers = new List<Customer>
            {
                new Customer{ Name="Customer 1"},
                new Customer{Name="Customer 2"}
            };

            RandomMovieViewModel viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        //passing action arguments
        /*
        public ActionResult Edit(int id)
        {
            return Content("id ="+id);
        }
        */

        //optional parameters
        /*public ActionResult Index(int? pageIndex,string sortBy)
        {
            if(!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }*/

        //Action which takes 2 parameters
        //Custom route through attributes
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m=>m.Genre).ToList();
            //return View(movies);
            //return View();

            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        public ActionResult MovieDetails(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();
            else
                return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var genre = _context.Genres.ToList();
            var movie= _context.Movies.Single(m => m.Id == id);
            
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie= movie,
                Genre = genre
            };
            return View("MovieForm", viewModel);            
        }
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                //Movie = new Movie(),
                Genre = genre
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genres
                };
                return View("MovieForm", viewModel);
            }
            movie.DateAdded = DateTime.Now;
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInSock = movie.NumberInSock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
    }
}