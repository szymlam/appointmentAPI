using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Services;

public class VisitService(ReservationContext context)
{
    public IEnumerable<Visit> GetAll()
    {
        return context.Visits
            .AsNoTracking()
            .ToList();
    }

    public Visit? GetById(int id)
    {
        return context.Visits
            .Include(v => v.Reservations)
            .AsNoTracking()
            .SingleOrDefault(v => v.VisitId == id);
    }

    public Visit Create(Visit visit)
    {
        
        context.Visits.Add(visit);
        context.SaveChanges();
        
        return visit;
    }

    public void Delete(int id)
    {
        var visit = GetById(id);
        
        if (visit == null) return;
        
        context.Visits.Remove(visit);
        context.SaveChanges();
    }
    
    public void Update(Visit visit)
    {
        context.Entry(visit).State = EntityState.Modified;
        context.SaveChanges();
    }
}