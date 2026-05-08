using Microsoft.AspNetCore.Mvc;
using Resido.API.DTOs.Requests;
using Resido.API.Repositories.Implements;
using Resido.API.Services.Interfaces;
using System.Runtime.CompilerServices;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomRequest roomRequest)
        {
            await _roomService.CreateAsync(roomRequest);

            return StatusCode(201, new { message = "Tạo phòng thành công" });
        }
    }
}
