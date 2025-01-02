using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentAPI.Models;

public class Reservation
{
    public string ReservationId { get; set; }
    [ForeignKey("Client")]
    public string ClientId { get; set; }
    [ForeignKey("Visit")]
    public int VisitId { get; set; }
    public DateTime Date { get; set; }
    
}