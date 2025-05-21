using MovieLib.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLib.Core
{
    public interface IMovieService
    {
        /// <summary>
        /// Gets all movies with their associated reviews, with optional filtering, pagination, and sorting
        /// </summary>
        /// <param name="title">Optional filter by movie title</param>
        /// <param name="director">Optional filter by director</param>
        /// <param name="page">Page number for pagination</param>
        /// <param name="pageSize">Number of items per page</param>
        /// <param name="sortBy">Field to sort by (e.g., Title, ReleaseDate, Director)</param>
        /// <param name="sortOrder">Sort order (asc or desc)</param>
        /// <returns>A collection of movies with reviews</returns>
        Task<IEnumerable<MovieWithReviewsDto>> GetAllMoviesWithReviewsAsync(
            string? title = null,
            string? director = null,
            int page = 1,
            int pageSize = 10,
            string sortBy = "Title",
            string sortOrder = "asc");

        /// <summary>
        /// Gets a specific movie with its reviews by id
        /// </summary>
        /// <param name="id">The id of the movie to retrieve</param>
        /// <returns>The movie with reviews or null if not found</returns>
        Task<MovieWithReviewsDto?> GetMovieWithReviewsByIdAsync(int id);
    }
}