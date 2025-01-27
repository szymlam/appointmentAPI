using System.ComponentModel.DataAnnotations;

namespace AppointmentAPI.DTOs;

public class VisitDto
{
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public float Cost { get; set; }
    [Required]
    public float TimeLength { get; set; }

}