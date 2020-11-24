using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorMovies.Data;
using RazorMovies.Models;

namespace RazorMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorMovies.Data.RazorMovieContext _context;

        public IndexModel(RazorMovies.Data.RazorMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        // The search query
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // The list of genres
        public SelectList Genres { get; set; }

        // The select genre
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Get the list of queryable genres using System.Linq
            // We will use this to make the genre selection available to the user
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            // Get all the movies using System.Linq
            // The query is only defined at this point, it has not been run against the database
            var movies = from m in _context.Movie select m;

            // If there is a search query, then filter the movie list
            if (!string.IsNullOrEmpty(SearchString))
            {
                // On SQL Server, Contains maps to SQL LIKE
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            // If there is a selected genre, then filter the movie list
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            // Run the query against the database
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
