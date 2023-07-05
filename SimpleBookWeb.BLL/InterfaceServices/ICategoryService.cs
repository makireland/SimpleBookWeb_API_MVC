using SimpleBookWeb.Domain.Dtos;

namespace SimpleBookWeb.BLL.InterfaceServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task<int> Add(CategoryDto categoryDto);
        Task<CategoryDto> Update(CategoryDto categoryDto);
        Task<CategoryDto> Delete(CategoryDto categoryDto);
    }
}
