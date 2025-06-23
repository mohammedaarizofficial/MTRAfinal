using Microsoft.EntityFrameworkCore;
using MTRA_Backend.Models;

Console.WriteLine("----STARTING PROGRAM.CS----");

var builder = WebApplication.CreateBuilder(args);

// Print connection string to verify it's being read
string connString = builder.Configuration.GetConnectionString("MtraDb");
Console.WriteLine("Loaded connection string: " + (connString == null ? "NULL" : connString));

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext with SQL Server
builder.Services.AddDbContext<MtraDbContext>(options =>
    options.UseSqlServer(connString) // Use the same string you printed
);

// Build the app
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
