using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Data;
using Infrastructure.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BarberService(DataContext context):IBarberService
{
    public async Task<Response<List<Barber>>> GetBarbersAsync()
    {
        var res =await context.Barbers.ToListAsync();
        return new Response<List<Barber>>(res);
    }

    public async Task<Response<Barber>> GetBarberByIdAsync(int Id)
    {
        var res = await context.Barbers.FirstOrDefaultAsync(b => b.Id == Id);
        return new Response<Barber>(res);
    }

    public async Task<Response<bool>> AddBarberAsync(Barber barber)
    {
        var effect =await context.Barbers.AddAsync(barber);
        return effect == null
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Barber not added")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> UpdateBarberAsync(Barber barber)
    {
        var s = await context.Barbers.FirstOrDefaultAsync(g => g.Id == barber.Id);

        if (s == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Barber not found");
        }
        s.FirstName = barber.FirstName;
        s.LastName = barber.LastName;
        s.Specialization = barber.Specialization;
        s.Status = barber.Status;
        s.EXperience = barber.EXperience;
        var effectedRows = await context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Barber not updated")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteBarberAsync(int id)
    {
       
        var s = await context.Barbers.FirstOrDefaultAsync(s => s.Id == id);

        if (s == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Barber not found");
        }
        context.Barbers.Remove(s);
        var effectedRows = await context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Barber not deleted")
            : new Response<bool>(true);
    }
}