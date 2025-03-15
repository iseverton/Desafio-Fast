using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WorkshopManager.Api.Data.Context;
using WorkshopManager.Api.Repositories;
using WorkshopManager.Api.Repositories.Interfaces;
using WorkshopManager.Api.Services;
using WorkshopManager.Api.Services.Interfaces;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IWorkShopRepository, WorkShopRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IWorkShopService, WorkShopService>();

//autoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
