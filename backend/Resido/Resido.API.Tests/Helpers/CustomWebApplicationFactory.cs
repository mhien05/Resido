using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Resido.API.Services.Interfaces;

namespace Resido.API.Tests.Helpers;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    // Expose mock ra ngoài để test có thể Setup
    public Mock<IPropertyService> MockPropertyService { get; } = new Mock<IPropertyService>();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Xóa IPropertyService thật
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(IPropertyService));
            if (descriptor != null)
                services.Remove(descriptor);

            // Đăng ký mock object vừa tạo ở trên
            services.AddScoped<IPropertyService>(_ => MockPropertyService.Object);
        });
    }
}