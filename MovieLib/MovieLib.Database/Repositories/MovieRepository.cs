using Microsoft.EntityFrameworkCore;
using MovieLib.Core.Entities;
using MovieLib.Core.Repositories;
using MovieLib.Core.DTOs;

namespace MovieLib.Database.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesWithReviewsAsync(
        string? title = null,
        string? director = null,
        int page = 1,
        int pageSize = 10,
        string sortBy = "Title",
        string sortOrder = "asc")
    {
        var query = _context.Movies.Include(m => m.Reviews).AsQueryable();

        // Filtering
        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(m => m.Title.Contains(title));
        }
        if (!string.IsNullOrWhiteSpace(director))
        {
            query = query.Where(m => m.Director.Contains(director));
        }

        // Sorting
        switch (sortBy.ToLower())
        {
            case "releasedate":
                query = sortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(m => m.ReleaseDate)
                    : query.OrderBy(m => m.ReleaseDate);
                break;
            case "director":
                query = sortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(m => m.Director)
                    : query.OrderBy(m => m.Director);
                break;
            default:
                query = sortOrder.ToLower() == "desc"
                    ? query.OrderByDescending(m => m.Title)
                    : query.OrderBy(m => m.Title);
                break;
        }

        // Pagination
        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        return await query.ToListAsync();
    }

    public async Task<Movie?> GetMovieWithReviewsByIdAsync(int id)
    {
        return await _context.Movies
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie?> UpdateMovieAsync(int id, UpdateMovieDto updateDto)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return null;
        }

        // Update only the properties that are provided (not null)
        if (updateDto.Title != null)
        {
            movie.Title = updateDto.Title;
        }
        if (updateDto.Description != null)
        {
            movie.Description = updateDto.Description;
        }
        if (updateDto.ReleaseDate.HasValue)
        {
            movie.ReleaseDate = updateDto.ReleaseDate.Value;
        }
        if (updateDto.Director != null)
        {
            movie.Director = updateDto.Director;
        }

        await _context.SaveChangesAsync();
        return movie;
    }
}