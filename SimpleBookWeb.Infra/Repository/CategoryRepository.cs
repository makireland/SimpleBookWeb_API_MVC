using SimpleBookWeb.Domain.Models;
using SimpleBookWeb.Infra.Context;
using SimpleBookWeb.Infra.InterfacesRepo;

namespace SimpleBookWeb.Infra.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
