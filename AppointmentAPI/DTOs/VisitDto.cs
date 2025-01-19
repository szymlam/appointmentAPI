using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppointmentAPI.Models;

public class VisitDto
{
    public string Type { get; set; }
    public float Cost { get; set; }
    public float TimeLength { get; set; }

}