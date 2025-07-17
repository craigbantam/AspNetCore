using Microsoft.AspNetCore.Mvc;
using Sandbox.Services;
using Sandbox.Domain.DTOs;
using Sandbox.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace Sandbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("ByPaging")]
        [ProducesResponseType(typeof(OffsetPaginationResponseModel<HomeItemViewDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<OffsetPaginationResponseModel<HomeItemViewDTO>>> GetAllByPaging([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
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
        [ProducesResponseType(typeof(HomeItemViewDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HomeItemViewDTO>> Create([FromBody] HomeItemCreateDTO newHomeItem, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var createdItem = await _service.CreateAsync(newHomeItem, cancellationToken).ConfigureAwait(false);
            //return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HomeItemViewDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HomeItemViewDTO>> GetById(int id, CancellationToken cancellationToken)
        {
            var item = await _service.GetById(id, cancellationToken);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
    }
}
