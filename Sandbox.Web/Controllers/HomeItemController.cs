using Microsoft.AspNetCore.Mvc;
using Sanbox.Services;
using Sandbox.Data.Repository;
using Sandbox.Domain.Models;


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
        [ProducesResponseType(typeof(IEnumerable<HomeItem>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {
            var result = await _service.GetAll().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
