global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using System.Reflection;
global using CQRSMediator.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<BookContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
//});

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<ProxyDataStorage>();

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
