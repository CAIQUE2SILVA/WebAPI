using WebAPI.Configurantions;
using WebAPI.Services;
using WebAPI.Services.Impl;
using WebAPI.Repositorys.Impl;
using WebAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repositorys;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.AddSerilogLogging();

builder.Services.AddControllers();


builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);


builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IBookServices, BookSevicesImpl>();
builder.Services.AddScoped<IBookRepository, BoockRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
