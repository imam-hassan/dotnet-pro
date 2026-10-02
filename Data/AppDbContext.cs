using Microsoft.EntityFrameworkCore;
using dotnet_pro.Model;

namespace dotnet_pro.Data;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {}

    public DbSet<Technician> Technicians {get; set;}
    public DbSet<Tower> Towers {get; set;}
}