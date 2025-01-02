using System.Text.Json.Serialization;

namespace AppointmentAPI.Models;

public class Visit
{
    
    public int VisitId { get; set; }
    public string Type { get; set; }
    public float Cost { get; set; }
    public float TimeLength { get; set; }

    [JsonIgnore]
    public ICollection<Reservation> Reservations;
}