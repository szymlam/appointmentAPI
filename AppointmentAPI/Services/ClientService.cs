using System.Security.Cryptography;
using AppointmentAPI.Data;
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
    
    public Client? GetById(string id)
    {
        return context.Clients
            .Include(c => c.Reservations)
            .AsNoTracking()
            .SingleOrDefault(c => c.ClientId == id);
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
    
    
}