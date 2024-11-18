using Book_library.Dtos.AuthorDtos;
using Book_library.Dtos.GenreDtos;
using Book_library.Models;
using System.ComponentModel.DataAnnotations;

namespace Book_library.Dtos.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedYear { get; set; }

        public ICollection<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
    }
}
