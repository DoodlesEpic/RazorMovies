using Microsoft.EntityFrameworkCore;

namespace RazorMovies.Data
{
    public class RazorMovieContext : DbContext
    {
        public RazorMovieContext(
            DbContextOptions<RazorMovieContext> options)
            : base(options)
        {
        }

        public DbSet<RazorMovies.Models.Movie> Movie { get; set; }
    }
}