using Book_library.Dtos.BookDtos;

namespace Book_library.Repositories
{
    public interface IBookRepsitory
    {
        ICollection<BookDto> GetAll();
        BookDto? GetById(int id);
        bool Add(CreateBookDto dto);
        bool Update(int id,CreateBookDto dto);
        bool Delete(int id);
    }
}
