using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

public class RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;  
    private readonly UserManager<IdentityUser> _userManager = userManager;
}