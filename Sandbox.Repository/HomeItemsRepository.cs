using Sandbox.Domain.DTOs;
using Sandbox.Domain.Models;

namespace Sandbox.Repository
{
    public class HomeItemsRepository : IHomeItemsRepository
    {
        public HomeItemViewDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HomeItemViewDTO> GetAll()
        {
            yield return new() { Id = 1, Description = "Sample description 1", Location = "Sample location 1", Name = "Sample 1" };
            yield return new() { Id = 2, Description = "Sample description 2", Location = "Sample location 2", Name = "Sample 2" };
            yield return new() { Id = 3, Description = "Sample description 3", Location = "Sample location 3", Name = "Sample 3" };
        }
    }
}
