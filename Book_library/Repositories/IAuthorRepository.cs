using Book_library.Dtos.AuthorDtos;

namespace Book_library.Repositories
{
    public interface IAuthorRepository
    {
        ICollection<AuthorDto> GetAll();
        AuthorDto? GetById(int id);
        bool Add(CreateAuthorDto dto);
        bool Update(int id, CreateAuthorDto dto);
        bool Delete(int id);
    }
}
