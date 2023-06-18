using AutoMapper;
using DesafioMxM.Domain;
using DesafioMxM.Repositories;
using DesafioMxM.Repositories.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var mySqlUrl = Environment.GetEnvironmentVariable("MYSQL_URL");
var mySqlDatabase = Environment.GetEnvironmentVariable("MYSQLDATABASE");
var mySqlHost = Environment.GetEnvironmentVariable("MYSQLHOST");
var mySqlPassword = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
var mySqlPort = Environment.GetEnvironmentVariable("MYSQLPORT");
var mySqlUser = Environment.GetEnvironmentVariable("MYSQLUSER");

var connectionString = $"Server={mySqlHost};Port={mySqlPort};Database={mySqlDatabase};User Id={mySqlUser};Password={mySqlPassword};";


//var connectionString = builder.Configuration.GetConnectionString("MxMChallengeConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
options
.UseLazyLoadingProxies()
.UseMySql(
    connectionString: connectionString,
        serverVersion: ServerVersion.AutoDetect(connectionString))

);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(int.Parse(Environment.GetEnvironmentVariable("PORT"))); // Porta configurada aqui
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationContext>();
    context.Database.Migrate();

}

app.Run();
