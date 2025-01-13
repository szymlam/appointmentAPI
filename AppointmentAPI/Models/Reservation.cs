using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentAPI.Models;

public class Reservation
{
    public string ReservationId { get; set; }
    [Required]
    [ForeignKey("Client")]
    public string ClientId { get; set; }
    [Required]
    [ForeignKey("Visit")]
    public int VisitId { get; set; }
    [Required]
    public DateTime Date { get; set; }
}

public record ReservationDto
{
    [Required]
    public string ClientId { get; set; }
    [Required]
    public int VisitId { get; set; }
    [Required]
    public DateTime Date { get; set; }
}