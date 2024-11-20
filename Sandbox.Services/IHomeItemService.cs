using Sandbox.Domain.DTOs;

namespace Sandbox.Services
{
    public interface IHomeItemService
    {
        Task<IEnumerable<HomeItemViewDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<HomeItemViewDTO> GetById(int id, CancellationToken cancellationToken);
        Task<HomeItemViewDTO> GetByName(string name, CancellationToken cancellationToken);
        Task CreateAsync(HomeItemCreateDTO newHomeItem, CancellationToken cancellationToken);
    }
}
