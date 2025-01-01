using Domain.Entities;
using Infrastructure.ApiResponse;

namespace Infrastructure.Services.Interface;

public interface IBarberService
{
    public Task<Response<List<Barber>>> GetBarbersAsync();
    public Task<Response<Barber>> GetBarberByIdAsync(int Id);
    public Task<Response<bool>> AddBarberAsync(Barber barber);
    public Task<Response<bool>> UpdateBarberAsync(Barber barber);
    public Task<Response<bool>> DeleteBarberAsync(int id);
}