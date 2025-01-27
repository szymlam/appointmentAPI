using AppointmentAPI.DTOs;
using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;


[Authorize]
[ApiController]
[Route("[controller]")]

public class ClientController(ClientService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Client>> GetAll() =>
        service.GetAll().ToList();

    [HttpGet("{clientId}")]
    public ActionResult<ClientDto> Get(string clientId)
    {
        var client = service.GetById(clientId);
        
        if (client is null)
        {
            return NotFound();
        }

        return client;
    }

    [HttpPost]
    public IActionResult CreateUser(ClientDto clientDto)
    {
        var client = new Client
        {
            Name = clientDto.Name,
            Surname = clientDto.Surname,
            Email = clientDto.Email ?? string.Empty,
            PhoneNumber = clientDto.PhoneNumber
        };
        
        service.Create(client);

        return CreatedAtAction(nameof(Get), new {clientId = client.ClientId}, client);
    }
    
    
    [Authorize(Roles="Admin")]
    [HttpDelete("{clientId}")]
    public IActionResult Delete(string clientId)
    {
        var client = service.GetById(clientId);
        if (client is null)
            return NotFound();
        
        service.DeleteById(clientId);

        return NoContent();
    }

    [HttpPut]
    public IActionResult Update(Client client)
    {
        var clientToUpdate = service.GetById(client.ClientId);
        if (clientToUpdate is null)
            return BadRequest();
        
        service.Update(client);

        return NoContent();
    }
} 