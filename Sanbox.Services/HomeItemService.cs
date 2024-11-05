using Sandbox.Data.Repository;
using Sandbox.Domain.DTOs;
using Sandbox.Domain.Mappers;

namespace Sanbox.Services
{
    public class HomeItemService : IHomeItemService
    {
        private readonly IHomeItemsRepository _repository;

        public HomeItemService(IHomeItemsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<HomeItemViewDTO>> GetAll()
        {
            var modelCollectionResponse = await _repository.GetAll().ConfigureAwait(false);

            return modelCollectionResponse.MapToDto();
        }

        public async Task<HomeItemViewDTO> GetById(int id)
        {
            var modelResponse = await _repository.Get(id).ConfigureAwait(false);

            return modelResponse.MapToDto();
        }

        public async Task<HomeItemViewDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
