using System.Net.Mime;
using System.Security.Cryptography;
using AppointmentAPI.DTOs;
using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]

public class ReservationController(ReservationService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Reservation>> GetAll() => 
        service.GetAll().ToList();

    [HttpGet("{reservationId}")]
    public ActionResult<Reservation> Get(string reservationId)
    {
        var reservation = service.GetById(reservationId);

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
        
        service.Create(reservation);
        
        return CreatedAtAction(nameof(Get), new { reservationId = reservation.ReservationId }, reservation);
    }

    [HttpDelete("{reservationId}")]
    public IActionResult Delete(string reservationId)
    {
        var reservation = service.GetById(reservationId);
        if (reservation is null)
            return NotFound();
        
        service.DeleteById(reservationId);

        return NoContent();
    }
    
    [HttpPut]
    public IActionResult Update(Reservation reservation)
    {
        var clientToUpdate = service.GetById(reservation.ReservationId);
        if (clientToUpdate is null)
            return BadRequest();
        
        service.Update(reservation);

        return NoContent();
    }
}
