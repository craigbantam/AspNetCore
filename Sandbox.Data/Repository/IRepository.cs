using Sandbox.Domain.Pagination;

namespace Sandbox.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<OffsetPaginationResponseModel<T>> GetPaginationResultAsync(OffsetPaginationRequestModel paginationRequest, CancellationToken cancellationToken);
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        Task CreateBulkAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    }    
}
