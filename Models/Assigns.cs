namespace dotnet_pro.Model;
using System.ComponentModel.DataAnnotations;


public class Assign
{
    public int Id{get; set;}

    public int TechnicianId{get;set;}
    public Technician? Technician{get; set;}
    [Required]
    public DateTime DateAssigned { get; set; } = DateTime.UtcNow;

    public int MaintenanceJobId{get; set;}
    public MaintenanceJob? MaintenanceJob {get; set;}
}