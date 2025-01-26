using System.ComponentModel.DataAnnotations;

namespace AppointmentAPI.DTOs;

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