namespace dotnet_pro.Model;

public class Assign
{
    public int Id{get; set;}

    public int TechnicianId{get;set;}
    public Technician? Technician{get; set;}

    public int MaintenanceJobId{get; set;}
    public MaintenanceJob? MaintenanceJob {get; set;}
}