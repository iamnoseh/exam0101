using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Domain.Entities;

public class Service
{
    public int Id { get; set; }
    [Required][StringLength(100)]
    public string? Name { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public bool IsActive { get; set; }
    
    public Appointment? AppoimentId { get; set; }
    public List<Appointment> Appointments { get; set; }
}