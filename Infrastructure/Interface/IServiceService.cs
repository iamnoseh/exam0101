using Domain.Entities;
using Infrastructure.ApiResponse;

namespace Infrastructure.Services.Interface;

public interface IServiceService
{
    public Task<Response<List<Service>>> GetServicesAsync();
    public Task<Response<Service>> GetServiceByIdAsync(int id);
    public Task<Response<bool>> AddServiceAsync(Service service);
    public Task<Response<bool>> UpdateServiceAsync(Service service);
    public Task<Response<bool>> DeleteServiceAsync(int id);
}