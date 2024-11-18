using Book_library.Models;
using System.ComponentModel.DataAnnotations;

namespace Book_library.Dtos.GenreDtos
{
    public class GenreDto
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
    }
}