using SimpleBookWeb.Domain.Dtos;

namespace SimpleBookWeb.BLL.InterfaceServices
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task<int> Add(BookDto bookDto);
        Task<BookDto> Update(BookDto bookDto);
        Task<BookDto> Delete(BookDto bookDto);
    }
}
