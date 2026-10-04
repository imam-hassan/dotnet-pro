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
    
    [Required(ErrorMessage = "Full Name Is Required")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Full Name must be between 2 and 150 characters.")]
    public string FName { get; set; } = "";
    
    [Required(ErrorMessage = "Phone number is Required")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email Address Is Required!")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
    public string Email { get; set; } = "";
    
    [Required(ErrorMessage = "Home Address Is Required!!!")]
    [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
    public string Address { get; set; } = "";
    
    [Required(ErrorMessage = "Date Of Employment Is Required!!!")]
    public DateOnly DateOfEmployment { get; set; }
    
    [Required(ErrorMessage = "Specialization Is Required!!!")]
    [Range(0, 5, ErrorMessage = "You sent an invalid number for Specialization (Must be 0-5)")]
    public Specialization Skill { get; set; }
    
    [Required(ErrorMessage = "Experience Is Required!!!")]
    [StringLength(50, ErrorMessage = "Experience level text is too long (Max 50 characters).")]
    public string ExperienceLevel { get; set; } = "";
    
    [Required(ErrorMessage = "Availability is required")]
    [Range(0, 2, ErrorMessage = "You sent an invalid number for Availability (Must be 0-2)")]
    public Availability AvailabilityStatus { get; set; }
    
    [Required(ErrorMessage = "Available Status Is Required")]
    [Range(0, 1, ErrorMessage = "You sent an invalid number for Status (Must be 0-1)")]
    public AvailableStatus Status { get; set; } = AvailableStatus.Active;
    public ICollection<Assign> Assigments{get; set;} = new HashSet<Assign> ();
}
