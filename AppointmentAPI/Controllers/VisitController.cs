using AppointmentAPI.DTOs;
using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]

public class VisitController(VisitService service) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public ActionResult<List<Visit>> GetAll() =>
        service.GetAll().ToList();

    [HttpGet("{visitId:int}")]
    public ActionResult<Visit> Get(int visitId)
    {
        var visit = service.GetById(visitId);
        if (visit is null)
        {
            return NotFound();
        }

        return visit;
    }

    [HttpPost]
    public IActionResult Create(VisitDto visitDto)
    {
        var visit = new Visit()
        {
            Cost = visitDto.Cost,
            TimeLength = visitDto.TimeLength,
            Type = visitDto.Type
        };
        
        service.Create(visit);

        return CreatedAtAction(nameof(Get), new { visitId = visit.VisitId }, visit);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var visit = service.GetById(id);
        if (visit is null)
        {
            return NotFound();
        }
        
        service.Delete(id);
        
        return NoContent();
    }
    
    [HttpPut]
    public IActionResult Update(Visit visit)
    {
        var clientToUpdate = service.GetById(visit.VisitId);
        if (clientToUpdate is null)
            return BadRequest();
        
        service.Update(visit);

        return NoContent();
    }
}