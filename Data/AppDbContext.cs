using SeacoastApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SeacoastApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<SalesUnit> SalesUnits { get; set; }
}