using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentAPI.Models;

public class Visit
{
    [Key]   
    public int VisitId { get; set; }
    [MaxLength(30)]
    public string Type { get; set; } = string.Empty;
    [Required]
    public float Cost { get; set; }
    [Required]
    public float TimeLength { get; set; }

    [JsonIgnore] 
    public ICollection<Reservation> Reservations { get; set; } = [];
}