using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class BarberController(IBarberService iservice)
{
    [HttpGet]
    public async Task<Response<List<Barber>>> GetBarbers()
    {
        return await iservice.GetBarbersAsync();
    }

    [HttpPost]
    public async Task<Response<bool>> PostBarber(Barber barber)
    {
        return await iservice.AddBarberAsync(barber);
    }

    [HttpPut]
    public async Task<Response<bool>> PutBarber(Barber barber)
    {
        return await iservice.UpdateBarberAsync(barber);
    }

    [HttpDelete]
    public async Task<Response<bool>> DeleteBarber(int id)
    {
        return await iservice.DeleteBarberAsync(id);
    }

    [HttpGet("[action]/{id}")]
    public async Task<Response<Barber>> GetBarbersById(int id)
    {
        return await iservice.GetBarberByIdAsync(id);
    }
}