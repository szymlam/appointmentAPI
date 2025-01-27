using System.Text;
using AppointmentAPI;
using AppointmentAPI.Data;
using AppointmentAPI.Models;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationContext>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<ReservationContext>("Data Source=ReservationData.db");
builder.Services.AddDbContext<AuthenticationContext>(options =>
    options.UseSqlite("Data Source=AuthenticationData.db"));

builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<VisitService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }

    var user = await userManager.FindByEmailAsync("mikisz2005@gmail.com");
    //if (user is not null)
    //{
        await userManager.AddToRoleAsync(userManager.Users.First(u => u.Email=="mikisz2005@gmail.com"), "Admin");
    //}
}

app.MapIdentityApi<IdentityUser>();

app.CreateDbIfNotExists();

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();