using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using API.Infra.Repository;
using API.Repository.Interfaces;
using API.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// var host = System.Environment.GetEnvironmentVariable("PGSQL_HOST");
// int port = int.Parse(System.Environment.GetEnvironmentVariable("PGSQL_PORT")!);
// var database = System.Environment.GetEnvironmentVariable("PGSQL_DB");
// var password = System.Environment.GetEnvironmentVariable("PGSQL_PWD");
// var username = System.Environment.GetEnvironmentVariable("PGSQL_USER");

// System.Console.WriteLine($"Host: {host}");
// System.Console.WriteLine($"Port: {port}");
// System.Console.WriteLine($"Database: {database}");
// System.Console.WriteLine($"Password: {password}");
// System.Console.WriteLine($"Username: {username}");

var host = "localhost";
int port = 5432;
var database = "lawyercenter";
var password = "minha_senha_forte_123";
var username = "lawyercenter_aka_ifood_advogado";

builder.Services.AddTransient<ConnectionContext>(s => new ConnectionContext(host, database, username, password, port));
builder.Services.AddTransient<ISystemUserRepository, SystemUserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
