using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppointmentAPI.Models;

public class Visit
{
    [Key]   
    public int VisitId { get; set; }
    public string Type { get; set; }
    public float Cost { get; set; }
    public float TimeLength { get; set; }

    [JsonIgnore] 
    public ICollection<Reservation> Reservations { get; set; } = [];
}