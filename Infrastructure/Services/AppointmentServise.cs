using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Data;
using Infrastructure.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AppointmentServise(DataContext context):IAppointmentService
{
    public async Task<Response<List<Appointment>>> AppointmentsAsync()
    {
        var res = await context.Appointments.ToListAsync();
        return new Response<List<Appointment>>(res);
    }

    public async Task<Response<Appointment>> AppointmentByIdAsync(int Id)
    {
        var res = await context.Appointments.FirstOrDefaultAsync(b => b.Id == Id);
        return new Response<Appointment>(res);
    }

    public async Task<Response<bool>> AddAppointmentAsync(Appointment appointment)
    {
        var effect =await context.Appointments.AddAsync(appointment);
        return effect == null
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Appointment not added")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> UpdateAppointmentAsync(Appointment appointment)
    {
        var s = await context.Appointments.FirstOrDefaultAsync(g => g.Id == appointment.Id);

        if (s == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Appointment not found");
        }
        s.Barber = appointment.Barber;
        s.Service = appointment.Service;
        s.Comment = appointment.Comment;
        s.AppointmentDate = appointment.AppointmentDate;
        s.Status = appointment.Status;
        s.ClientPhone = appointment.ClientPhone;
        s.ClientName = appointment.ClientName;
        s.CreatedAt = appointment.CreatedAt;
        s.BarberId = appointment.BarberId;
        s.ServiceId = appointment.ServiceId;
        s.StartTime = appointment.StartTime;
        var effectedRows = await context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Appointment not updated")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteAppointmentAsync(int id)
    {
        var s = await context.Appointments.FirstOrDefaultAsync(s => s.Id == id);

        if (s == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Appointment not found");
        }
        context.Appointments.Remove(s);
        var effectedRows = await context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Appointment not deleted")
            : new Response<bool>(true);
    }
}