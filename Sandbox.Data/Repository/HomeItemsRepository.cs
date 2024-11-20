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

        public async Task CreateAsync(HomeItem entity, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<HomeItem> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.HomeItems.Include(h => h.Location).Where(h => h.Id == id).AsNoTracking().FirstAsync(cancellationToken);
        }

        public async Task<IEnumerable<HomeItem>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.HomeItems.Include(h => h.Location).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
