using Sandbox.Domain.DTOs;

namespace Sanbox.Services
{
    public interface IHomeItemService
    {
        Task<IEnumerable<HomeItemViewDTO>> GetAll();
        Task<HomeItemViewDTO> GetById(int id);
        Task<HomeItemViewDTO> GetByName(string name);
    }
}
