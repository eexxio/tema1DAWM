using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieLib.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLib.Database
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            // Apply any pending migrations
            await dbContext.Database.MigrateAsync();
            
            // Check if we already have movies
            if (await dbContext.Movies.AnyAsync())
            {
                return; // Database has been seeded
            }
            
            // Sample movies
            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    ReleaseDate = new DateTime(1994, 9, 23),
                    Director = "Frank Darabont"
                },
                new Movie
                {
                    Title = "Inception",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    ReleaseDate = new DateTime(2010, 7, 16),
                    Director = "Christopher Nolan"
                },
                new Movie
                {
                    Title = "The Matrix",
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    ReleaseDate = new DateTime(1999, 3, 31),
                    Director = "Lana and Lilly Wachowski"
                }
            };
            
            await dbContext.Movies.AddRangeAsync(movies);
            await dbContext.SaveChangesAsync();
            
            // Sample reviews
            var reviews = new List<Review>
            {
                // Reviews for Shawshank Redemption
                new Review
                {
                    MovieId = movies[0].Id,
                    Rating = 5,
                    Comment = "A masterpiece of storytelling and acting. Morgan Freeman and Tim Robbins deliver outstanding performances.",
                    ReviewerName = "MovieCritic123",
                    CreatedAt = DateTime.Now.AddDays(-20)
                },
                new Review
                {
                    MovieId = movies[0].Id,
                    Rating = 5,
                    Comment = "One of the best movies ever made. The story is powerful and inspirational.",
                    ReviewerName = "CinemaLover",
                    CreatedAt = DateTime.Now.AddDays(-15)
                },
                
                // Reviews for Inception
                new Review
                {
                    MovieId = movies[1].Id,
                    Rating = 4,
                    Comment = "Mind-bending plot with amazing visual effects. Christopher Nolan at his best.",
                    ReviewerName = "DreamExplorer",
                    CreatedAt = DateTime.Now.AddDays(-10)
                },
                new Review
                {
                    MovieId = movies[1].Id,
                    Rating = 5,
                    Comment = "Complex narrative that keeps you engaged throughout. The ending leaves you thinking.",
                    ReviewerName = "ThoughtfulViewer",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                
                // Reviews for The Matrix
                new Review
                {
                    MovieId = movies[2].Id,
                    Rating = 5,
                    Comment = "Revolutionary for its time and still holds up today. The effects and concept are groundbreaking.",
                    ReviewerName = "SciFiEnthusiast",
                    CreatedAt = DateTime.Now.AddDays(-30)
                },
                new Review
                {
                    MovieId = movies[2].Id,
                    Rating = 4,
                    Comment = "Innovative storytelling and special effects. The action sequences are phenomenal.",
                    ReviewerName = "ActionFan",
                    CreatedAt = DateTime.Now.AddDays(-25)
                }
            };
            
            await dbContext.Reviews.AddRangeAsync(reviews);
            await dbContext.SaveChangesAsync();
        }
    }
}