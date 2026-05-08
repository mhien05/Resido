using Microsoft.AspNetCore.Mvc;
using Resido.API.Services.Interfaces;
using System.Runtime.InteropServices;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roomService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _roomService.GetByIdAsync(id);

            return Ok(response);
        }
    }
}
