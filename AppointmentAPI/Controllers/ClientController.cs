using System.Security.Cryptography;
using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ClientController(ClientService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Client>> GetAll() =>
        service.GetAll().ToList();

    [HttpGet("{clientId}")]
    public ActionResult<Client> Get(string clientId)
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
        Client client = new Client
        {
            Name = clientDto.Name,
            Surname = clientDto.Surname,
            Email = clientDto.Email,
            PhoneNumber = clientDto.PhoneNumber
        };
        
        service.Create(client);

        return CreatedAtAction(nameof(Get), new {clientId = client.ClientId}, client);
    }
    
    

    [HttpDelete("{clientId}")]
    public IActionResult Delete(string clientId)
    {
        var client = service.GetById(clientId);
        if (client is null)
            return NotFound();
        
        service.DeleteById(clientId);

        return NoContent();
    }
} 