using System.ComponentModel.DataAnnotations;

namespace AppointmentAPI.DTOs;

public record ReservationDto
{
    [Required]
    public string ClientId { get; set; }
    [Required]
    public int VisitId { get; set; }
    [Required]
    public DateTime Date { get; set; }
}