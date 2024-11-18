using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Book_library.Models
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedYear {  get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}