using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreMvc.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? PurchaseYear { get; set; }

        public string? BookImage { get; set; }  // stores book image name with extension (eg, book0034.jpg)
        [Required]
        public string? Characters { get; set; }
        [Required]
        public string? Writer { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int>? Genres { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? GenreList { get; set; }
        [NotMapped]
        public string? GenreNames { get; set; }

        [NotMapped]
        public MultiSelectList? MultiGenreList { get; set; }

    }
}
