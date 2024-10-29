using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Domain.DTOs;
using Sandbox.Repository;

namespace Sandbox.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeItemController : ControllerBase
    {
        private readonly IHomeItemsRepository _repository;

        public HomeItemController(IHomeItemsRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<HomeItemViewDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }
    }
}
