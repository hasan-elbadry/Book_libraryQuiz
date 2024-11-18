using Book_library.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
               new Author { Id = 1, Name = "J.K. Rowling", PhoneNumber = "1234567890", Email = "jk.rowling@example.com" },
               new Author { Id = 2, Name = "George R.R. Martin", PhoneNumber = "0987654321", Email = "george.martin@example.com" },
               new Author { Id = 3, Name = "J.R.R. Tolkien", PhoneNumber = "4561237890", Email = "tolkien@example.com" },
               new Author { Id = 4, Name = "Stephen King", PhoneNumber = "3216549870", Email = "stephen.king@example.com" },
               new Author { Id = 5, Name = "Agatha Christie", PhoneNumber = "7890123456", Email = "agatha.christie@example.com" },
               new Author { Id = 6, Name = "Mark Twain", PhoneNumber = "2345678901", Email = "mark.twain@example.com" },
               new Author { Id = 7, Name = "Jane Austen", PhoneNumber = "3456789012", Email = "jane.austen@example.com" },
               new Author { Id = 8, Name = "Charles Dickens", PhoneNumber = "4567890123", Email = "charles.dickens@example.com" },
               new Author { Id = 9, Name = "Ernest Hemingway", PhoneNumber = "5678901234", Email = "ernest.hemingway@example.com" },
               new Author { Id = 10, Name = "F. Scott Fitzgerald", PhoneNumber = "6789012345", Email = "scott.fitzgerald@example.com" }
           );

            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Science Fiction" },
                new Genre { Id = 3, Name = "Mystery" },
                new Genre { Id = 4, Name = "Thriller" },
                new Genre { Id = 5, Name = "Romance" },
                new Genre { Id = 6, Name = "Horror" },
                new Genre { Id = 7, Name = "Historical" },
                new Genre { Id = 8, Name = "Adventure" },
                new Genre { Id = 9, Name = "Classics" },
                new Genre { Id = 10, Name = "Biography" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", PublishedYear = new DateTime(1997, 6, 26) },
                new Book { Id = 2, Title = "A Game of Thrones", PublishedYear = new DateTime(1996, 8, 6) },
                new Book { Id = 3, Title = "The Hobbit", PublishedYear = new DateTime(1937, 9, 21) },
                new Book { Id = 4, Title = "The Shining", PublishedYear = new DateTime(1977, 1, 28) },
                new Book { Id = 5, Title = "Murder on the Orient Express", PublishedYear = new DateTime(1934, 1, 1) },
                new Book { Id = 6, Title = "Adventures of Huckleberry Finn", PublishedYear = new DateTime(1884, 12, 10) },
                new Book { Id = 7, Title = "Pride and Prejudice", PublishedYear = new DateTime(1813, 1, 28) },
                new Book { Id = 8, Title = "Great Expectations", PublishedYear = new DateTime(1861, 8, 1) },
                new Book { Id = 9, Title = "The Old Man and the Sea", PublishedYear = new DateTime(1952, 9, 1) },
                new Book { Id = 10, Title = "The Great Gatsby", PublishedYear = new DateTime(1925, 4, 10) }
            );



        }

        public DbSet<Author> Authors { get; set; } 
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
