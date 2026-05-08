using Microsoft.AspNetCore.Mvc;
using Resido.API.Services.Interfaces;

namespace Resido.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("room")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roomService.GetAllAsync();

            return Ok(response);
        }
    }
}
