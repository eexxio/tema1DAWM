using MovieLib.Core;
using MovieLib.Core.DTOs;
using MovieLib.Core.Entities;
using MovieLib.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLib.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieWithReviewsDto>> GetAllMoviesWithReviewsAsync()
        {
            var movies = await _movieRepository.GetAllMoviesWithReviewsAsync();
            return movies.Select(MapToMovieWithReviewsDto);
        }

        public async Task<MovieWithReviewsDto?> GetMovieWithReviewsByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieWithReviewsByIdAsync(id);
            return movie != null ? MapToMovieWithReviewsDto(movie) : null;
        }

        private MovieWithReviewsDto MapToMovieWithReviewsDto(Movie movie)
        {
            return new MovieWithReviewsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Director = movie.Director,
                Reviews = movie.Reviews?.Select(review => new ReviewDto
                {
                    Id = review.Id,
                    MovieId = review.MovieId,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    ReviewerName = review.ReviewerName
                }).ToList()
            };
        }
    }
}