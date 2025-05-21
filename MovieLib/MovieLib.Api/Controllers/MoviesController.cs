using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLib.Core;
using MovieLib.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLib.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Gets all movies with their associated reviews
        /// </summary>
        /// <returns>A collection of movies with their reviews</returns>
        /// <response code="200">Returns the list of movies with reviews</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieWithReviewsDto>>> GetAllMovies(
            [FromQuery] string? title = null,
            [FromQuery] string? director = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Title",
            [FromQuery] string sortOrder = "asc")
        {
            var movies = await _movieService.GetAllMoviesWithReviewsAsync(title, director, page, pageSize, sortBy, sortOrder);
            return Ok(movies);
        }

        /// <summary>
        /// Gets a specific movie with its reviews by ID
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve</param>
        /// <returns>The movie with its reviews</returns>
        /// <response code="200">Returns the movie with its reviews</response>
        /// <response code="404">If the movie is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieWithReviewsDto>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieWithReviewsByIdAsync(id);
            
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found");
            }
            
            return Ok(movie);
        }

        /// <summary>
        /// Updates a movie with the specified ID
        /// </summary>
        /// <param name="id">The ID of the movie to update</param>
        /// <param name="updateDto">The data to update the movie with</param>
        /// <returns>The updated movie with its reviews</returns>
        /// <response code="200">Returns the updated movie with its reviews</response>
        /// <response code="404">If the movie is not found</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieWithReviewsDto>> UpdateMovie(int id, UpdateMovieDto updateDto)
        {
            var movie = await _movieService.UpdateMovieAsync(id, updateDto);
            
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found");
            }
            
            return Ok(movie);
        }
    }
}