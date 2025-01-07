namespace AppointmentAPI.Data;

public static class DbInitializer
{
    public static void Initialize(ReservationContext context)
    {
        if (context.Clients.Any() && context.Visits.Any())
            return;
        
        
    }
}