using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_pro.Model;

public enum AvailableStatus
{
    Active,
    InActive
}

public enum Availability
{
    Available,       
    Busy,
    OnLeave
}

public enum Specialization
{
    Electrical,
    Network,
    Rf,
    Power_Systems,
    GeneratorMaintenance,
    TowerMaintenance 
}

public class Technician 
{
    public int Id { get; set; } 
    
    public string FName { get; set; } = "";
    

    public string PhoneNumber { get; set; } = string.Empty;
    

    public string Email { get; set; } = "";
    

    public string Address { get; set; } = "";
    
    public DateOnly DateOfEmployment { get; set; }
    
    public Specialization Skill { get; set; }
    
    public string ExperienceLevel { get; set; } = "";
    public Availability AvailabilityStatus { get; set; }

    public AvailableStatus Status { get; set; } = AvailableStatus.Active;
    public ICollection<Assign> Assigments{get; set;} = new HashSet<Assign> ();
}
