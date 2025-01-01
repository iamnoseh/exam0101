using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    public int BarberId { get; set; }
    public Barber? Barber { get; set; }
    public DateTime AppointmentDate  { get; set; }
    public DateTime StartTime { get; set; }
    public string ClientName { get; set; }
    [Phone]
    public string ClientPhone { get; set; }
    public AppointmentStatus Status { get; set; }
    [StringLength(200)]
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}

