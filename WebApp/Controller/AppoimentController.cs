using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class AppoimentController(IAppointmentService iservice)
{
    [HttpGet]
    public async Task<Response<List<Appointment>>> Appointments()
    {
        return await iservice.AppointmentsAsync();
    }

    [HttpPost]
    public async Task<Response<bool>> AddAppointment(Appointment appointment)
    {
        return await iservice.AddAppointmentAsync(appointment);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateAppointment(Appointment b)
    {
        return await iservice.UpdateAppointmentAsync(b);
    }

    [HttpDelete]
    public async Task<Response<bool>> DeleteAppointment(int id)
    {
        return await iservice.DeleteAppointmentAsync(id);
    }

    [HttpGet("[action]/{id}")]
    public async Task<Response<Appointment>> AppointmentsById(int id)
    {
        return await iservice.AppointmentByIdAsync(id);
    }
}