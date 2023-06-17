using AutoMapper;
using DesafioMxM.Domain;
using DesafioMxM.Repositories;
using DesafioMxM.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

var builder = WebApplication.CreateBuilder(args);

var mySqlUrl = Environment.GetEnvironmentVariable("MYSQL_URL");
var mySqlDatabase = Environment.GetEnvironmentVariable("MYSQLDATABASE");
var mySqlHost = Environment.GetEnvironmentVariable("MYSQLHOST");
var mySqlPassword = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
var mySqlPort = Environment.GetEnvironmentVariable("MYSQLPORT");
var mySqlUser = Environment.GetEnvironmentVariable("MYSQLUSER");

//var connectionString = builder.Configuration.GetConnectionString("MxMChallengeConnection");

var connectionString = $"Server={mySqlHost};Port={mySqlPort};Database={mySqlDatabase};User Id={mySqlUser};Password={mySqlPassword};";
//var connectionString = $"Server=localhost;Database=new2;User=root;Password=digimon3;";

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


//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == "OPTIONS")
//    {
//        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
//        context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
//        context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
//        context.Response.StatusCode = 200;
//    }
//    else
//    {
//        await next();
//    }

//});

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
