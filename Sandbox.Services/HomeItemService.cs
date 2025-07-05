using Sandbox.Data.Repository;
using Sandbox.Domain.DTOs;
using Sandbox.Domain.Mappers;
using Sandbox.Domain.Pagination;

namespace Sandbox.Services
{
    //todo: transactioning/unit of work
    public class HomeItemService : IHomeItemService
    {
        private readonly IHomeItemsRepository _repository;

        public HomeItemService(IHomeItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(HomeItemCreateDTO newHomeItem, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(newHomeItem.MapToModel(), cancellationToken);
        }

        public async Task<IEnumerable<HomeItemViewDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var modelCollectionResponse = await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);

            return modelCollectionResponse.MapToDto();
        }

        public async Task<HomeItemViewDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var modelResponse = await _repository.GetAsync(id, cancellationToken).ConfigureAwait(false);

            return modelResponse.MapToDto();
        }

        public async Task<HomeItemViewDTO> GetByName(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<OffsetPaginationResponseModel<HomeItemViewDTO>> GetPaginationResultAsync(OffsetPaginationRequestModel paginationRequest, CancellationToken cancellationToken)
        {
            var paginationResponseModel = await _repository.GetPaginationResultAsync(paginationRequest, cancellationToken).ConfigureAwait(false);

            return new OffsetPaginationResponseModel<HomeItemViewDTO>
            {
                Entities = paginationResponseModel.Entities.MapToDto(),
                HasNextPage = paginationResponseModel.HasNextPage,
                HasPreviousPage = paginationResponseModel.HasPreviousPage,
                PageNumber = paginationResponseModel.PageNumber,
                TotalRecords = paginationResponseModel.TotalRecords
            };
        }
    }
}
