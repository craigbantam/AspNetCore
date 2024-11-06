using Microsoft.EntityFrameworkCore;
using Sandbox.Domain.Models;

namespace Sandbox.Data.Repository
{
    public class HomeItemsRepository : IHomeItemsRepository
    {
        private readonly HomeItemsDbContext _dbContext;

        public HomeItemsRepository(HomeItemsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HomeItem> Get(int id)
        {
            return await _dbContext.HomeItems.Include(h => h.Location).Where(h => h.Id == id).AsNoTracking().FirstAsync();
        }

        public async Task<IEnumerable<HomeItem>> GetAll()
        {
            return await _dbContext.HomeItems.Include(h => h.Location).AsNoTracking().ToListAsync();
        }
    }
}
