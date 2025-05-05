using Microsoft.EntityFrameworkCore;
using MovieLib.Core.Entities;
using MovieLib.Core.Repositories;

namespace MovieLib.Database.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesWithReviewsAsync()
    {
        return await _context.Movies
            .Include(m => m.Reviews)
            .ToListAsync();
    }

    public async Task<Movie?> GetMovieWithReviewsByIdAsync(int id)
    {
        return await _context.Movies
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}