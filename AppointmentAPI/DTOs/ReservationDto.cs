using System.ComponentModel.DataAnnotations;

namespace AppointmentAPI.DTOs;

public record ReservationDto
{
    [Required]
    public string ClientId { get; set; } = string.Empty;
    [Required]
    public int VisitId { get; set; }
    [Required]
    public DateTime Date { get; set; }
}