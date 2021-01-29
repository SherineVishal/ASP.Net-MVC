using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var movie = _context.Movies.Include(c=>c.Genre).ToList();
            return Ok(movie);
        }

        //GET /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDB= _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDB == null)
                return NotFound();
            return Ok(movieInDB);
        }


        //POST /api/movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok();
        }


        //PUT /api/movies/id
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDB == null)
                return NotFound();
            movieInDB.Name = movie.Name;
            movieInDB.ReleaseDate = movie.ReleaseDate;
            movieInDB.NumberInSock = movie.NumberInSock;
            movieInDB.GenreId = movie.GenreId;
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/movies/id
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            
            if (movieInDB == null)
                return NotFound();
            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();
            
            return Ok();
        }
    }
}
