using Microsoft.EntityFrameworkCore;
using AppointmentAPI.Models;

namespace AppointmentAPI.Data;

public class ReservationContext(DbContextOptions<ReservationContext> options) : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Visit> Visits => Set<Visit>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
}