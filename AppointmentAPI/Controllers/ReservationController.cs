using System.Net.Mime;
using System.Security.Cryptography;
using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class ReservationController(ReservationService serviceInstance) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Reservation>> GetAll() => 
        serviceInstance.GetAll().ToList();

    [HttpGet("{reservationId}")]
    public ActionResult<Reservation> Get(string reservationId)
    {
        var reservation = serviceInstance.GetById(reservationId);

        if (reservation is null)
        {
            return NotFound();
        }

        return reservation;
    }

    [HttpPost]
    public IActionResult Create(ReservationDto reservationDto)
    {
        var reservation = new Reservation
        {
            ClientId = reservationDto.ClientId,
            VisitId = reservationDto.VisitId,
            Date = reservationDto.Date
        };
        
        serviceInstance.Create(reservation);
        
        return CreatedAtAction(nameof(Get), new { reservationId = reservation.ReservationId }, reservation);
    }

    [HttpDelete("{reservationId}")]
    public IActionResult Delete(string reservationId)
    {
        var reservation = serviceInstance.GetById(reservationId);
        if (reservation is null)
            return NotFound();
        
        serviceInstance.DeleteById(reservationId);

        return NoContent();
    }
}
