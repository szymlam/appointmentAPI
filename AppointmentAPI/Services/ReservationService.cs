using System.Security.Cryptography;
using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Services;

public class ReservationService(ReservationContext context)
{
    public IEnumerable<Reservation> GetAll()
    {
        return context.Reservations
            .AsNoTracking()
            .ToList();
    }
    
    public Reservation? GetById(string id)
    {
        return context.Reservations
            .AsNoTracking()
            .SingleOrDefault(c => c.ReservationId == id);
    }

    public Reservation Create(Reservation reservation)
    {
        reservation.ReservationId =
            BitConverter.ToString(
                MD5.HashData(
                    System.Text.Encoding.UTF8.GetBytes(
                        reservation.ClientId + reservation.VisitId + reservation.Date))).
                Replace("-", "");
        
        var client = context.Clients.Find(reservation.ClientId);
        if (client is null)
        {
            throw new Exception("No user found with this ID");
        }
        context.Reservations.Add(reservation);
        
        client.Reservations.Add(reservation);
        
        context.SaveChanges();

        return reservation;
    }
    

    public void DeleteById(string id)
    {
        var reservationToRemove = context.Reservations.Find(id);
        
        if (reservationToRemove == null) return;
        
        context.Reservations.Remove(reservationToRemove);
        context.SaveChanges();
    }
}