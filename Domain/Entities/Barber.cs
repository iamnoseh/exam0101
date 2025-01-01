using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Barber
{
    public int Id { get; set; }
    [Required][StringLength(50)]
    public string? FirstName { get; set; }
    [Required][StringLength(50)]
    public string LastName { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    public int EXperience { get; set; }
    public BarberStatus Status { get; set; }
    [StringLength(50)]
    public string Specialization  { get; set; }
    
    public int AppoimentId { get; set; }
    public IEnumerable<Appointment> Appointments { get; set; }
}