using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;


[Route("[controller]")]
[ApiController]
public class VisitController(VisitService serviceInstance) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Visit>> GetAll() =>
        serviceInstance.GetAll().ToList();

    [HttpGet("{visitId:int}")]
    public ActionResult<Visit> Get(int visitId)
    {
        var visit = serviceInstance.GetById(visitId);
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
        
        serviceInstance.Create(visit);

        return CreatedAtAction(nameof(Get), new { visitId = visit.VisitId }, visit);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var visit = serviceInstance.GetById(id);
        if (visit is null)
        {
            return NotFound();
        }
        
        serviceInstance.Delete(id);
        
        return NoContent();
    }
}