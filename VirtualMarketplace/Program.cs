using Microsoft.EntityFrameworkCore;
using VirtualMarketplace.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var applicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDb");

if (applicationDbConnectionString == null)
{
    throw new InvalidOperationException("ApplicationDb connection string not found.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(applicationDbConnectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();