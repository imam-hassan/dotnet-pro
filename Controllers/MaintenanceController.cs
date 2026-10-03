using dotnet_pro.Data;
using dotnet_pro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_pro.Controllers;

[ApiController]
[Route("/api/maintenance-jobs")]
public class MaintenanceJobsController:ControllerBase
{
    private readonly AppDbContext _context;
    public MaintenanceJobsController(AppDbContext context)
    {
        _context=context;
    }
    [HttpGet]
    public async Task<IActionResult> GetMaintenances()
    {
        var maintenances = await _context.MaintenanceJobs.ToListAsync();
       
        return Ok(maintenances);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMaintenance(int id)
    {
       var maintenance = await _context.MaintenanceJobs.FindAsync(id);
       if (maintenance == null)
        {
            return BadRequest();
        }
        return Ok(maintenance);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMaintenance(MaintenanceJob maintenanceJob)
    {
         _context.MaintenanceJobs.Add(maintenanceJob);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetMaintenance), new {id = maintenanceJob.Id}, maintenanceJob);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaintenance(int id, MaintenanceJob updatedJob)
    {
        var  existingJob = await _context.MaintenanceJobs.FindAsync(id);
        if ( existingJob == null)
        {
            return NotFound();
        }
          existingJob.JobID = updatedJob.JobID;
          existingJob.JobTitle = updatedJob.JobTitle;
          existingJob.Description = updatedJob.Description;
          existingJob.JobType = updatedJob.JobType;
          existingJob.Priority = updatedJob.Priority;
          existingJob.DateReported = updatedJob.DateReported;
          existingJob.ScheduledDate = updatedJob.ScheduledDate;
          existingJob.CompletionDate = updatedJob.CompletionDate;
          existingJob.Status = updatedJob.Status;
          existingJob.Remarks = updatedJob.Remarks;
         
          await _context.SaveChangesAsync();
          return NoContent();
    } 

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMaintenance(int id)
    {
        var che = await _context.MaintenanceJobs.FindAsync(id);
        if (che == null)
        {
            return NotFound();
        }
        _context.MaintenanceJobs.Remove(che);
        await _context.SaveChangesAsync();
        return Ok("Deleted Successfully");
    }
}