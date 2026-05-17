using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Resido.API.Constants;
using Resido.API.DTOs.Requests;
using Resido.API.Enums;
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

        // Get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roomService.GetAllAsync();

            return Ok(response);
        }

        // Get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _roomService.GetByIdAsync(id);

            return Ok(response);
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomRequest roomRequest)
        {
            await _roomService.CreateAsync(roomRequest);
            
            // "Tạo phòng thành công"
            return StatusCode(201, new { message = Constants.Messages.RoomMessage.Created });
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoomRequest roomRequest)
        {
            await _roomService.UpdateAsync(id, roomRequest);

            return StatusCode(200, new { message = Constants.Messages.RoomMessage.Updated });
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _roomService.DeleteAsync(id);

            return StatusCode(204, new { message = Constants.Messages.RoomMessage.Deleted });
        }

        // Get by status
        [HttpGet("by-property/{propertyId}")]
        public async Task<IActionResult> GetByPropertyId(Guid propertyId)
        {
            var response = await _roomService.GetByPropertyIdAsync(propertyId);

            return Ok(response);
        }

        // Get by property id
        [HttpGet("by-status/{status}")]
        public async Task<IActionResult> GetByStatus(RoomStatus status)
        {
            var response = await _roomService.GetByStatusAsync(status);

            return Ok(response);
        }
    }
}
