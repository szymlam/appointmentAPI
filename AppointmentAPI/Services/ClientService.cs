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
        
        context.Clients.Add(client);
        context.SaveChanges();

        return client;
    }

    public void AddReservation(int reservationId, string clientId)
    {
        var clientToUpdate = GetById(clientId);
        var reservationToAdd = context.Reservations.Find(reservationId);

        if (clientToUpdate is null || reservationToAdd is null)
        {
            throw new InvalidOperationException("Client or reservation doesn't exist");
        }

        if (clientToUpdate.Reservations.Count == 0)
        {
            clientToUpdate.Reservations = new List<Reservation>();
        }
        
        clientToUpdate.Reservations.Add(reservationToAdd);

        context.SaveChanges();
    }

    public void DeleteById(string id)
    {
        var clientToRemove = context.Clients.Find(id);
        
        if (clientToRemove == null) return;
        
        context.Clients.Remove(clientToRemove);
        context.SaveChanges();
    }
    
    
}