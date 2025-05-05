using MovieLib.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLib.Core
{
    public interface IMovieService
    {
        /// <summary>
        /// Gets all movies with their associated reviews
        /// </summary>
        /// <returns>A collection of movies with reviews</returns>
        Task<IEnumerable<MovieWithReviewsDto>> GetAllMoviesWithReviewsAsync();

        /// <summary>
        /// Gets a specific movie with its reviews by id
        /// </summary>
        /// <param name="id">The id of the movie to retrieve</param>
        /// <returns>The movie with reviews or null if not found</returns>
        Task<MovieWithReviewsDto?> GetMovieWithReviewsByIdAsync(int id);
    }
}