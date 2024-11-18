using System.ComponentModel.DataAnnotations;

namespace Book_library.Models
{
    public class Genre 
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }
    }
}
