using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace AppointmentAPI.Models;

public class Client
{
    
    public string ClientId { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [Required]
    [MaxLength(30)]
    public string Surname { get; set; }
    [Phone]
    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }
    
    [JsonIgnore]
    public ICollection<Reservation> Reservations { get; set; } = [];
    
}

public record ClientDto
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [Required]
    [MaxLength(30)]
    public string Surname { get; set; }
    [Phone]
    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }
}