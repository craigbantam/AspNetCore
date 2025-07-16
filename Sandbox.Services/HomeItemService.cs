using Sandbox.Data.Repository;
using Sandbox.Domain.DTOs;
using Sandbox.Domain.Mappers;
using Sandbox.Domain.Models;
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

            if (!modelCollectionResponse.Any())
            {
                var bulkItems = Enumerable.Range(1, 20)
                    .Select(i => new HomeItem
                    {
                        Name = $"Item {i}",
                        Description = $"Description for Item {i}",
                        LocationId = 1 // Use a valid LocationId as appropriate
                    })
                    .ToList();

                await _repository.CreateBulkAsync(bulkItems, cancellationToken).ConfigureAwait(false);

                // Fetch the newly created items
                modelCollectionResponse = await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            }

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
                PageCount = paginationResponseModel.PageCount,
                PageNumber = paginationResponseModel.PageNumber,
                TotalRecords = paginationResponseModel.TotalRecords
            };
        }
    }
}
