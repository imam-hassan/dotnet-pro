using System.ComponentModel.DataAnnotations;

namespace dotnet_pro.Model;

public enum JobType
{
    PreventiveMaintenance,
    CorrectiveMaintenance,
    EquipmentInstallation,
    GeneratorMaintenance,
    BatteryReplacement,
    TowerInspection
}

public enum Priority
{
    Low,
    Medium,
    High,
    Critical
}

public enum Status
{
    Pending,
    Assigned,
    InProgress,
    Completed,
    Canceled
}

public class MaintenanceJob
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Job ID is required.")]
    public string JobID { get; set; } = string.Empty;

    [Required(ErrorMessage = "Job Title is required.")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "Job Title must be between 5 and 150 characters.")]
    public string JobTitle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [EnumDataType(typeof(JobType), ErrorMessage = "Invalid Job Type selected.")]
    public JobType JobType { get; set; } 

    [EnumDataType(typeof(Priority), ErrorMessage = "Invalid Priority level selected.")]
    public Priority Priority { get; set; }

    [Required(ErrorMessage = "Date Reported is required.")]
    public DateOnly? DateReported { get; set; } 

    public DateOnly? ScheduledDate { get; set; }

    public DateOnly? CompletionDate { get; set; }

    [EnumDataType(typeof(Status), ErrorMessage = "Invalid Status selected.")]
    public Status Status { get; set; }

    [Required(ErrorMessage = "Remarks are required.")]
    public string Remarks { get; set; } = string.Empty;
    public ICollection<Assign> Assigments{get; set;} = new HashSet<Assign>();
}
