using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_pro.Model;

public enum TowerType
{
    Monopole,
    Lattice,
    Guyed
}

public enum CurrentStatus
{
    Active,
    UnderMaintenance,
    InActive
}

public class Tower
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Tower ID is required.")]
    [StringLength(50, ErrorMessage = "Tower ID cannot exceed 50 characters.")]
    public string TowerId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Site Name is required.")]
    [StringLength(200, ErrorMessage = "Site Name cannot exceed 200 characters.")]
    public string SiteName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(500, ErrorMessage = "Location cannot exceed 500 characters.")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "State is required.")]
    [StringLength(100, ErrorMessage = "State cannot exceed 100 characters.")]
    public string State { get; set; } = string.Empty;
    [Required(ErrorMessage = "Latitude is required.")]
    [Range(-90.0, 90.0, ErrorMessage = "Latitude must be between -90 and 90.")]
    public double Latitude { get; set; }

    [Required(ErrorMessage = "Longitude is required.")]
    [Range(-180.0, 180.0, ErrorMessage = "Longitude must be between -180 and 180.")]
    public double Longitude { get; set; }

    [Required(ErrorMessage = "Tower Type is required.")]
    [Range(0, 2, ErrorMessage = "Invalid Tower Type (Must be 0-2).")] 
    public TowerType TowerType { get; set; }
    [Required(ErrorMessage = "Tower Height is required.")]
    [Range(1.0, 500.0, ErrorMessage = "Height must be between 1 and 500 meters.")]
    public double TowerHeight { get; set; }

    [Required(ErrorMessage = "Installation Date is required.")]
    public DateTime InstallationDate { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [Range(0, 2, ErrorMessage = "Invalid Status (Must be 0-2).")] 
    public CurrentStatus Status { get; set; } = CurrentStatus.Active; 
}
