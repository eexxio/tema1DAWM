using MovieLib.Core.Entities;
using MovieLib.Core.DTOs;

namespace MovieLib.Core.Repositories;

public interface IMovieRepository
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
    /// <returns>A collection of movies with their reviews</returns>
    Task<IEnumerable<Movie>> GetAllMoviesWithReviewsAsync(
        string? title = null,
        string? director = null,
        int page = 1,
        int pageSize = 10,
        string sortBy = "Title",
        string sortOrder = "asc");
    
    /// <summary>
    /// Gets a specific movie with its associated reviews by ID
    /// </summary>
    /// <param name="id">The ID of the movie to retrieve</param>
    /// <returns>The movie with its reviews, or null if not found</returns>
    Task<Movie?> GetMovieWithReviewsByIdAsync(int id);

    /// <summary>
    /// Updates a movie with the specified ID using the provided update data
    /// </summary>
    /// <param name="id">The ID of the movie to update</param>
    /// <param name="updateDto">The data to update the movie with</param>
    /// <returns>The updated movie, or null if not found</returns>
    Task<Movie?> UpdateMovieAsync(int id, UpdateMovieDto updateDto);
}