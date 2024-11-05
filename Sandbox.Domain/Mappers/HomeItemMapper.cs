using Sandbox.Domain.DTOs;
using Sandbox.Domain.Models;

namespace Sandbox.Domain.Mappers
{
    public static class HomeItemMapper
    {
        public static HomeItemViewDTO MapToDto(this HomeItem model)
        {
            return new()
            {
                Description = model.Description,
                Id = model.Id,
                Location = model.Location.Name,
                Name = model.Name
            };
        }

        public static IEnumerable<HomeItemViewDTO> MapToDto(this IEnumerable<HomeItem> model)
        {
            return model.Select(MapToDto).ToList();
        }
    }
}
