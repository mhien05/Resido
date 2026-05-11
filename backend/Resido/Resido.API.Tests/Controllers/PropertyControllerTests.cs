using System.Net;
using System.Net.Http.Json;
using Resido.API.Controllers;
using Resido.API.DTOs.Responses;
using Resido.API.Tests.Helpers;
using Xunit.Abstractions;
using FluentAssertions;
using Moq;

namespace Resido.API.Tests.Controllers;

public class PropertyControllerTests :  IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory _factory;

    public PropertyControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory; 
        _client = factory.CreateClient();
    }
    
    // ========== GET /api/property ==========
    [Fact]
    public async Task GetAll_ShouldReturn200_WithListOfProperties()
    {
        // Arrange
        var mockData = new List<PropertyResponse>
        {
            new() { Id = Guid.NewGuid(), Name = "Nhà trọ A", Address = "HCM" },
            new() { Id = Guid.NewGuid(), Name = "Nhà trọ B", Address = "HN" }
        };

        _factory.MockPropertyService
            .Setup(s => s.GetAllAsync())
            .ReturnsAsync(mockData);

        // Act
        var response = await _client.GetAsync("/api/property");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await response.Content.ReadFromJsonAsync<List<PropertyResponse>>();
        body.Should().HaveCount(2);
        body![0].Name.Should().Be("Nhà trọ A");
    }
    
    [Fact]
    public async Task GetAll_WhenEmpty_ShouldReturn200_WithEmptyList()
    {
        // Arrange
        _factory.MockPropertyService
            .Setup(s => s.GetAllAsync())
            .ReturnsAsync(new List<PropertyResponse>());
        
        // Act
        var response = await _client.GetAsync("/api/property");
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<List<PropertyResponse>>();
        body.Should().BeEmpty();
    }
    
    // ========== GET /api/property/{id} ==========

    [Fact]
    public async Task GetById_WhenFound_ShouldReturn200()
    {
        // Arrange
        var id = Guid.NewGuid();
        var mockProperty = new PropertyResponse
        {
            Id = id,
            Name = "Nhà trọ A",
            Address = "HCM"
        };

        _factory.MockPropertyService
            .Setup(s => s.GetByIdAsync(id))
            .ReturnsAsync(mockProperty);

        // Act
        var response = await _client.GetAsync($"/api/property/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<PropertyResponse>();
        body!.Id.Should().Be(id);
        body.Name.Should().Be("Nhà trọ A");
    }

    

}