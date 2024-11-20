using Microsoft.AspNetCore.Mvc;
using Sandbox.Services;
using Sandbox.Domain.DTOs;

namespace Sandbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeItemController : ControllerBase
    {
        private readonly IHomeItemService _service;

        public HomeItemController(IHomeItemService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HomeItemViewDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _service.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create(HomeItemCreateDTO newHomeItem, CancellationToken cancellationToken)
        {
            await _service.CreateAsync(newHomeItem, cancellationToken).ConfigureAwait(false);
            return Ok();
        }
    }
}
