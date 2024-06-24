using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using API.Infra.Repository;
using API.Repository.Interfaces;
using API.Infra;
using Renci.SshNet;
using API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConnectionContext>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<ILawyerRepository, LawyerRepository>();
builder.Services.AddTransient<ILawyerCategoryRepository, LawyerCategoryRepository>();
builder.Services.AddTransient<IClientLawyerRepository, ClientLawyerRepository>();

var app = builder.Build();

// Configure CORS policies
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000") // Replace with your frontend URL
           .AllowAnyHeader()
           .AllowAnyMethod();
});

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
