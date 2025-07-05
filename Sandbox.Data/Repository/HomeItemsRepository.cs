using Microsoft.EntityFrameworkCore;
using Sandbox.Domain.Models;
using Sandbox.Domain.Pagination;

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

        public async Task CreateBulkAsync(IEnumerable<HomeItem> entities, CancellationToken cancellationToken)
        {
            await _dbContext.AddRangeAsync(entities, cancellationToken);
            await _dbContext.SaveChangesAsync(CancellationToken.None);//todo
        }

        public async Task<OffsetPaginationResponseModel<HomeItem>> GetPaginationResultAsync(OffsetPaginationRequestModel paginationRequest, CancellationToken cancellationToken)
        {
            var query = _dbContext.HomeItems.AsQueryable();

            var totalCount = await query.CountAsync();
            bool hasNextPage = (paginationRequest.PageNumber * paginationRequest.PageSize) < totalCount;
            bool hasPreviousPage = paginationRequest.PageNumber > 1;
            int pageCount = (int)Math.Ceiling(totalCount / (double)paginationRequest.PageSize);

            var entities = await query
            .Include(h => h.Location)
            .OrderBy(i => i.Id)
            .Skip((paginationRequest.PageNumber - 1) * paginationRequest.PageSize)
            .Take(paginationRequest.PageSize)
            .ToListAsync(cancellationToken);

            return new OffsetPaginationResponseModel<HomeItem>
            {

                Entities = entities,
                HasNextPage = hasNextPage,
                HasPreviousPage = hasPreviousPage,
                PageNumber = paginationRequest.PageNumber,
                PageCount = pageCount,
                TotalRecords = totalCount
            };
        }
    }
}
