namespace DesafioMxM.Domain;

using DesafioMxM.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options)
    {

    }
}

