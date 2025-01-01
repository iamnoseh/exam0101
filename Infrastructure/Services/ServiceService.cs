using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Data;
using Infrastructure.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ServiceService(DataContext context): IServiceService
{
    public async Task<Response<List<Service>>> GetServicesAsync()
    {
        var res = await context.Services.ToListAsync();
        return new Response<List<Service>>(res);
    }

    public async Task<Response<Service>> GetServiceByIdAsync(int id)
    {
        var res = await context.Services.FirstOrDefaultAsync(s=>s.Id == id);
        return new Response<Service>(res);
    }

    public async Task<Response<bool>> AddServiceAsync(Service service)
    {
        var effect =await context.Services.AddAsync(service);
        return effect == null
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Service not added")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> UpdateServiceAsync(Service service)
    {
        var s = await context.Services.FirstOrDefaultAsync(g => g.Id == service.Id);

        if (s == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Service not found");
        }
       s.Name = service.Name;
       s.Description = service.Description;
       s.Price = service.Price;
       s.Duration = service.Duration;
       s.IsActive = service.IsActive;
       s.Category = service.Category;
        var effectedRows = await context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Service not updated")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteServiceAsync(int id)
    {
        var s = await context.Services.FirstOrDefaultAsync(s => s.Id == id);

        if (s == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Service not found");
        }
        context.Services.Remove(s);
        var effectedRows = await context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Service not deleted")
            : new Response<bool>(true);
    }
}