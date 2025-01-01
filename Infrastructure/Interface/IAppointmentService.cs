using Domain.Entities;
using Infrastructure.ApiResponse;

namespace Infrastructure.Services.Interface;

public interface IAppointmentService
{
   
        public Task<Response<List<Appointment>>> AppointmentsAsync();
        public Task<Response<Appointment>> AppointmentByIdAsync(int Id);
        public Task<Response<bool>> AddAppointmentAsync(Appointment appointment);
        public Task<Response<bool>> UpdateAppointmentAsync(Appointment appointment);
        public Task<Response<bool>> DeleteAppointmentAsync(int id);
}