using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class ServiceController(IServiceService iservice)
{
    [HttpGet]
    public async Task<Response<List<Service>>> GetServices()
    {
        return await iservice.GetServicesAsync();
    }

    [HttpPost]
    public async Task<Response<bool>> PostService(Service service)
    {
        return await iservice.AddServiceAsync(service);
    }

    [HttpPut]
    public async Task<Response<bool>> PutService(Service service)
    {
        return await iservice.UpdateServiceAsync(service);
    }

    [HttpDelete]
    public async Task<Response<bool>> DeleteService(int id)
    {
        return await iservice.DeleteServiceAsync(id);
    }

    [HttpGet("[action]/{id}")]
    public async Task<Response<Service>> GetServicesById(int id)
    {
        return await iservice.GetServiceByIdAsync(id);
    }
}