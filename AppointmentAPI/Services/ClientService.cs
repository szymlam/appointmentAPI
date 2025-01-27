using System.Security.Cryptography;
using AppointmentAPI.Data;
using AppointmentAPI.DTOs;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Services;

public class ClientService(ReservationContext context)
{
    public IEnumerable<Client> GetAll()
    {
        return context.Clients
            .AsNoTracking()
            .ToList();
    }
    
    public ClientDto? GetById(string id)
    {
        var client = context.Clients
            .Include(c => c.Reservations)
            .AsNoTracking()
            .SingleOrDefault(c => c.ClientId == id);
        if (client is null)
            return null;

        return new ClientDto()
        {
            Email = client.Email,
            Name = client.Name,
            Surname = client.Surname,
            PhoneNumber = client.PhoneNumber
        };
    }

    public Client Create(Client client)
    {
        client.ClientId = client.Name[..Math.Min(client.Name.Length, 3)] +
                          client.Surname[..Math.Min(client.Surname.Length, 3)] + RandomNumberGenerator.GetHexString(4);
        
        context.Clients.Add(client);
        context.SaveChanges();

        return client;
    }
    

    public void DeleteById(string id)
    {
        var clientToRemove = context.Clients.Find(id);
        
        if (clientToRemove == null) return;
        
        context.Clients.Remove(clientToRemove);
        context.SaveChanges();
    }

    public void Update(Client client)
    {
        context.Entry(client).State = EntityState.Modified;
        context.SaveChanges();
    }
    
    
}