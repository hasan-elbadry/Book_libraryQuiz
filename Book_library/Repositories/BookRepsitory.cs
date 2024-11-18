using Book_library.Data;
using Book_library.Dtos.AuthorDtos;
using Book_library.Dtos.BookDtos;
using Book_library.Dtos.GenreDtos;
using Book_library.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_library.Repositories
{
    public class BookRepsitory : IBookRepsitory
    {
        private readonly AppDbContext _context;

        public BookRepsitory(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(CreateBookDto dto)
        {
            var authors = _context.Authors.Where(x=> dto.AuthorIds.Contains(x.Id)).ToList();
            var genres = _context.Genres.Where(x => dto.GenreIds.Contains(x.Id)).ToList();

            var book = new Book
            {
                Title = dto.Title,
                PublishedYear = dto.PublishedYear,
                Authors = authors,
                Genres = genres,                
            };

            _context.Books.Add(book);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book is null)
                return false;
            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public ICollection<BookDto> GetAll()
        {
            // ahsandifskfhqelkr.fgerjh;oilkc
           return _context.Books
                .Include(x => x.Genres)
                .Include(x => x.Authors)
                .Select(x => new BookDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    PublishedYear = x.PublishedYear,
                    Authors = x.Authors.Select(x => new AuthorDto
                    {
                        Id = x.Id,
                        Email = x.Email,
                        Name = x.Name,
                        PhoneNumber = x.PhoneNumber
                    }).ToList(),
                    Genres = x.Genres.Select(x => new GenreDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                    }).ToList()

                }).ToList();
        }

        public BookDto? GetById(int id)
        {
            var book = _context.Books
                .Include(x => x.Genres)
                .Include(x => x.Authors)
                .FirstOrDefault(x=>x.Id == id);

            if(book == null)
                return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                PublishedYear = book.PublishedYear,
                Authors = book.Authors.Select(x => new AuthorDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber
                }).ToList(),
                Genres = book.Genres.Select(x=>new GenreDto
                {
                    Id=x.Id,
                    Name = x.Name,
                }).ToList()
            };
        }

        public bool Update(int id, CreateBookDto dto)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return false;

            var authors = _context.Authors.Where(x => dto.AuthorIds.Contains(x.Id)).ToList();
            var genres = _context.Genres.Where(x => dto.GenreIds.Contains(x.Id)).ToList();

            book.Id = id;
            book.Title = dto.Title;
            book.PublishedYear = dto.PublishedYear;
            book.Authors = authors;
            book.Genres = genres;

            _context.Update(book);
            _context.SaveChanges();
            return true;
        }
    }
}
