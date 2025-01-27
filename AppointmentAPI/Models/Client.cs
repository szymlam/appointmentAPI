using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace AppointmentAPI.Models;

public class Client
{

    public string ClientId { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string Surname { get; set; } = string.Empty;
    [Phone]
    [MaxLength(15)]
    public string? PhoneNumber { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    
    
    [JsonIgnore]
    public ICollection<Reservation> Reservations { get; set; } = [];
    
}