using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(255, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        // Requires that the first character be an uppercase letter.
        // White space, numbers, and special characters are not allowed.
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(30)]
        [Required]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // Requires that the first character be an uppercase letter.
        // Allows special characters and numbers in subsequent spaces.
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}