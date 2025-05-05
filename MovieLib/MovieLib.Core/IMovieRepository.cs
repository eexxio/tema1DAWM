using MovieLib.Core.Entities;

namespace MovieLib.Core.Repositories;

public interface IMovieRepository
{
    /// <summary>
    /// Gets all movies with their associated reviews
    /// </summary>
    /// <returns>A collection of movies with their reviews</returns>
    Task<IEnumerable<Movie>> GetAllMoviesWithReviewsAsync();
    
    /// <summary>
    /// Gets a specific movie with its associated reviews by ID
    /// </summary>
    /// <param name="id">The ID of the movie to retrieve</param>
    /// <returns>The movie with its reviews, or null if not found</returns>
    Task<Movie?> GetMovieWithReviewsByIdAsync(int id);
}