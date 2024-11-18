
using Book_library.Data;
using Book_library.Dtos.AuthorDtos;
using Book_library.Models;
using Book_library.Repositories;

namespace Author_library.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(CreateAuthorDto dto)
        {
            var author = new Author
            {
                Email = dto.Email,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
            };

            _context.Authors.Add(author);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var Author = _context.Authors.Find(id);
            if (Author is null)
                return false;

            _context.Authors.Remove(Author);
            _context.SaveChanges();
            return true;
        }

        public ICollection<AuthorDto> GetAll()
        {
            return _context.Authors
                 .Select(x => new AuthorDto
                 {
                     Id = x.Id,
                     Email = x.Email,
                     PhoneNumber = x.PhoneNumber,
                     Name = x.Name,
                 }).ToList();
        }

        public AuthorDto? GetById(int id)
        {
            var Author = _context.Authors
                .FirstOrDefault(x => x.Id == id);

            if (Author == null)
                return null;

            return new AuthorDto
            {
                Id = Author.Id,
                Name = Author.Name,
                PhoneNumber= Author.PhoneNumber,
                Email = Author.Email    
            };
        }

        public bool Update(int id, CreateAuthorDto dto)
        {
            var Author = _context.Authors.Find(id);
            if (Author is null)
                return false;
            Author.Id = id;
            Author.Email = dto.Email;
            Author.PhoneNumber = dto.PhoneNumber;

            _context.Update(Author);
            _context.SaveChanges();
            return true;
        }
    }
}
