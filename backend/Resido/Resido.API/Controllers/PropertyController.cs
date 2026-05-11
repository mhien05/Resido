using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resido.API.DTOs.Requests;
using Resido.API.Services.Interfaces;

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
    }
}
