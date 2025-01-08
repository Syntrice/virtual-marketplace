using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualMarketplace.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core

var applicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDb");

if (applicationDbConnectionString == null)
{
    throw new InvalidOperationException("ApplicationDb connection string not found.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(applicationDbConnectionString));

// Configure Identity

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>(); // build in identity classes for now


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Auth Middleware

app.UseAuthentication();
app.UseAuthorization();

// MVC Middleware

app.MapControllers();

app.Run();