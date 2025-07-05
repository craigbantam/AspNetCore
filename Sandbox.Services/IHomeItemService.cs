using Sandbox.Domain.DTOs;
using Sandbox.Domain.Pagination;

namespace Sandbox.Services
{
    public interface IHomeItemService
    {
        Task<IEnumerable<HomeItemViewDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<OffsetPaginationResponseModel<HomeItemViewDTO>> GetPaginationResultAsync(OffsetPaginationRequestModel paginationRequest, CancellationToken cancellationToken);
        Task<HomeItemViewDTO> GetById(int id, CancellationToken cancellationToken);
        Task<HomeItemViewDTO> GetByName(string name, CancellationToken cancellationToken);
        Task CreateAsync(HomeItemCreateDTO newHomeItem, CancellationToken cancellationToken);
    }
}
