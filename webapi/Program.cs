using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;
using webapi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 28)));
}
);
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IPlatformsService, PlatformsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
