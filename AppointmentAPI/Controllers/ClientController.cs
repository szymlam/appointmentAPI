using System.Security.Cryptography;
using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ClientController : ControllerBase
{
    private readonly ClientService _serviceInstance;
    public ClientController(ClientService service)
    {
        _serviceInstance = service;
    }

    [HttpGet]
    public ActionResult<List<Client>> GetAll() =>
        _serviceInstance.GetAll().ToList();

    [HttpGet("{clientId}")]
    public ActionResult<Client> Get(string clientId)
    {
        var client = _serviceInstance.GetById(clientId);
        
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
            PhoneNumber = clientDto.PhoneNumber,
            ClientId = clientDto.Name[..Math.Min(clientDto.Name.Length, 3)] + clientDto.Surname[..Math.Min(clientDto.Surname.Length, 3)] + RandomNumberGenerator.GetHexString(4) 
        };
        
        _serviceInstance.Create(client);

        return CreatedAtAction(nameof(Get), new {clientId = client.ClientId}, client);
    }
    
    

    [HttpDelete("{clientId}")]
    public IActionResult Delete(string clientId)
    {
        var client = _serviceInstance.GetById(clientId);
        if (client is null)
            return NotFound();
        
        _serviceInstance.DeleteById(clientId);

        return NoContent();
    }
} 