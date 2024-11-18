using System.ComponentModel.DataAnnotations;

namespace Book_library.Models
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [Phone,StringLength(200)]
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress,StringLength(200)]
        public string Email { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }
    }
}
