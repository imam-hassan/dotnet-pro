using Microsoft.EntityFrameworkCore;
using dotnet_pro.Model;

namespace dotnet_pro.Data;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {}

    public DbSet<Technician> Technicians {get; set;}
    public DbSet<Tower> Towers {get; set;}
    public DbSet<MaintenanceJob> MaintenanceJobs{get;set;}
    public DbSet<Assign> Assigments {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Assign>()
        .HasOne(a=> a.Technician)
        .WithMany(t=>t.Assigments)
        .HasForeignKey(a=> a.TechnicianId)
        .OnDelete(DeleteBehavior.Cascade); // delete a job remove its assigments

        modelBuilder.Entity<Assign>()
        .HasOne(a=>a.MaintenanceJob)
        .WithMany(m=> m.Assigments)
        .HasForeignKey(a=> a.MaintenanceJobId)
        .OnDelete(DeleteBehavior.Cascade); //deleting a job remove its Assigment
        // To make sure that a technician can not same job twice
        modelBuilder.Entity<Assign>()
        .HasIndex(a=> new {a.TechnicianId, a.MaintenanceJobId})
        .IsUnique();
    }
}