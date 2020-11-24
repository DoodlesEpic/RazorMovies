using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorMovies.Data;
using System;
using System.Linq;

namespace RazorMovies.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorMovieContext>>()))
            {
                // Look for any movies
                if (context.Movie.Any())
                {
                    // DB has been seeded already
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Good, The Bad, and The Ugly",
                        ReleaseDate = DateTime.Parse("1967-12-29"),
                        Genre = "Western",
                        Price = 1.20M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "The Book of Eli",
                        ReleaseDate = DateTime.Parse("2010-11-01"),
                        Genre = "Action and Adventure",
                        Price = 1.50M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}