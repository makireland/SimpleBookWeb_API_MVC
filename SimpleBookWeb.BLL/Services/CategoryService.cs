using SimpleBookWeb.BLL.InterfaceServices;
using SimpleBookWeb.Domain.Dtos;
using SimpleBookWeb.Domain.Models;
using SimpleBookWeb.Infra.InterfacesRepo;

namespace SimpleBookWeb.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<int> Add(CategoryDto categoryDto)
        {
            var categoryEntity = ConvertToCategoryEntity(categoryDto);

            await _categoryRepo.Add(categoryEntity);

            await _categoryRepo.SaveChangesAsync();

            return categoryEntity.Id;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var request = await _categoryRepo.GetAll();
            return ConvertEntityListToDtoList(request);
        }       

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepo.GetById(id);
            return ConvertToCategoryDto(category);
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            var categoryEntity = ConvertToCategoryEntity(categoryDto);

            _categoryRepo.Update(categoryEntity);

            await _categoryRepo.SaveChangesAsync();

            return categoryDto;
        }

        public Category ConvertToCategoryEntity(CategoryDto categoryDto)
        {
            var categoryEntity = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };

            return categoryEntity;
        }

        public CategoryDto ConvertToCategoryDto(Category category)
        {
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryDto;
        }
        private IEnumerable<CategoryDto> ConvertEntityListToDtoList(IEnumerable<Category> request)
        {
            var listDto = new List<CategoryDto>();

            foreach (var category in request)
            {
                listDto.Add(ConvertToCategoryDto(category));
            }

            return listDto;
        }

        public async Task<CategoryDto> Delete(CategoryDto categoryDto)
        {
            var categoryEntity = ConvertToCategoryEntity(categoryDto);

            _categoryRepo.Delete(categoryEntity);

            await _categoryRepo.SaveChangesAsync();

            return categoryDto;
        }
    }
}
