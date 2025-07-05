using Microsoft.AspNetCore.Mvc;
using Sandbox.Services;
using Sandbox.Domain.DTOs;
using Sandbox.Domain.Pagination;

namespace Sandbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeItemController : ControllerBase
    {
        private readonly IHomeItemService _service;
        private readonly ILogger<HomeItemController> _logger;

        public HomeItemController(IHomeItemService service, ILogger<HomeItemController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("/")]
        [ProducesResponseType(typeof(IEnumerable<HomeItemViewDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HomeItemViewDTO>>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get home items start");

                var result = await _service.GetAllAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Get home items complete");
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error fetching home items");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet]
        [Route("ByPaging")]
        [ProducesResponseType(typeof(IEnumerable<HomeItemViewDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HomeItemViewDTO>>> GetAllByPaging([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get home items start");

                var result = await _service.GetPaginationResultAsync(new OffsetPaginationRequestModel(pageNumber, pageSize), cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Get home items complete");
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error fetching home items");
                return StatusCode(500, "Internal server error");
            }

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
