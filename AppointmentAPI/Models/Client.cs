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
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    
    [JsonIgnore]
    public ICollection<Reservation> Reservations { get; } = [];

    public Client(string name, string surname, string phoneNumber, string email)
    {
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        Email = email;
        ClientId = name[..3] + surname[..3] + RandomNumberGenerator.GetHexString(4);
    }
}