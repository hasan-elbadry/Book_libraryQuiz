using Book_library.Dtos.BookDtos;
using Book_library.Models;
using System.ComponentModel.DataAnnotations;

namespace Book_library.Dtos.AuthorDtos
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [Phone, StringLength(200)]
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;
    }
}
