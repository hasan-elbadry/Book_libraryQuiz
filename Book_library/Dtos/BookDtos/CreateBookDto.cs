using Book_library.Dtos.AuthorDtos;
using Book_library.Dtos.GenreDtos;
using System.ComponentModel.DataAnnotations;

namespace Book_library.Dtos.BookDtos
{
    public class CreateBookDto
    {
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedYear { get; set; }
            
        public IEnumerable<int> AuthorIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> GenreIds { get; set; } = Enumerable.Empty<int>();
    }
}