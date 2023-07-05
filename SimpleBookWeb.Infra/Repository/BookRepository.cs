using Microsoft.EntityFrameworkCore;
using SimpleBookWeb.Domain.Models;
using SimpleBookWeb.Infra.Context;
using SimpleBookWeb.Infra.InterfacesRepo;

namespace SimpleBookWeb.Infra.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Book> GetById(int id)
        {
            return await _dbSet.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public override async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbSet.Include(x => x.Category).AsNoTracking().ToListAsync();
        }
    }
}
