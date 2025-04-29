using Microsoft.AspNetCore.Mvc;
using MovieRental.Models.Customer;
using MovieRental.Models.Movie;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly IMovieFeatures _features;

        public MovieController(IMovieFeatures features)
        {
            _features = features;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movies = _features.GetAll();

            if (movies == null || !movies.Any())
            {
                return NotFound(new { message = "Movies not found" });
            }

            return Ok(movies);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Movie.Movie movie)
        {
            if (movie == null)
            {
                return BadRequest(new { message = "Invalid movie data." });
            }

            try
            {
                var savedMovie = _features.Save(movie);
                return Ok(savedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while saving the movie." });
            }

        }
    }
}
