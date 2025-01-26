using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentAPI.Models;

public class Reservation
{
    [MaxLength(50)]
    public string ReservationId { get; set; } = string.Empty;
    [Required]
    [ForeignKey("Client")]
    [MaxLength(50)]
    public string ClientId { get; set; } = string.Empty;
    [Required]
    [ForeignKey("Visit")]
    public int VisitId { get; set; }
    [Required]
    public DateTime Date { get; set; }
}