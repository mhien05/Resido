using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resido.API.DTOs.Requests;
using Resido.API.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace Resido.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // Get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _propertyService.GetAllAsync();

            return Ok(response);
        }

        // Get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _propertyService.GetByIdAsync(id);

            return Ok(response);
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> Create(PropertyRequest request)
        {
            await _propertyService.CreateAsync(request);

            return StatusCode(201, new { message = "Thêm property thành công" });
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PropertyRequest request)
        {
            await _propertyService.UpdateAsync(id, request);

            return StatusCode(200, new { message = "Cập nhật thông tin property thành công" });
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _propertyService.DeleteAsync(id);

            return StatusCode(204, new { message = $"Xóa property có id {id} thành công" });
        }
    }
}
