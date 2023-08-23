using ClientAPI.Context;
using ClientAPI.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConn = builder.Configuration.GetConnectionString("DbString");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConn));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Teste", (string name) => { return Results.Ok($"Hello {name}"); });

app.MapTarefasEndpoints();

app.Run();