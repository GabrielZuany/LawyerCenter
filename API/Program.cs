using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using API.Infra.Repository;
using API.Repository.Interfaces;
using API.Infra;
using Renci.SshNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// PORT FORWARDING SETUP
string sshHost = "168.138.151.184";
string sshUsername = "ubuntu";
string sshKeyFilePath = "/home/zuany/Desktop/dev/auth/oracle/api/key";
string sshPassphrase = "select*from:Zuzu.pwd.2405";
string localHost = "localhost"; // Local host where the forwarded port will be available
int localPort = 5432; // Local port where the forwarded traffic will be received
string remoteHost = "localhost";
int remotePort = 5432; // Port on the remote host where the forwarded traffic will be sent

// Register the PortForwardingService with parameters
builder.Services.AddTransient(provider =>
{
    return new PortForwardingService(sshHost, sshUsername, sshKeyFilePath, sshPassphrase, localHost, localPort, remoteHost, remotePort);
});


builder.Services.AddDbContext<ConnectionContext>();
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

// Start the port forwarding service
var portForwardingService = app.Services.GetRequiredService<PortForwardingService>();
try
{
    portForwardingService.StartPortForwarding();
    Console.WriteLine("Port forwarding started successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error starting port forwarding: {ex.Message}");
    throw;
}

app.Run();
