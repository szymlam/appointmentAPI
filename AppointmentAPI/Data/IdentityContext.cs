using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Data;

public class AuthenticationContext(DbContextOptions<AuthenticationContext> options) : IdentityDbContext<IdentityUser>(options)
{
    
}