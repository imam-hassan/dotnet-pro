using dotnet_pro.Data;
using dotnet_pro.Model;
using dotnet_pro.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


[ApiController]
[Route("/api/technicians")]

public class TechnicianController: ControllerBase
{
    private readonly AppDbContext _context;

    public TechnicianController(AppDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> CreateTechnician(Technician TechnicianCreateDto)
    {
      var val =await _context.Technicians.AnyAsync(u => u.PhoneNumber == TechnicianCreateDto.PhoneNumber);
      var EmailExist =await _context.Technicians.AnyAsync(u => u.Email == TechnicianCreateDto.Email);
        if (EmailExist ){
        return BadRequest("Email Has Been Taken");
      }
      if (val ){
        return BadRequest("Phone Number Has been taken");
      }
      var  tech = new Technician ()
        {
                FName= TechnicianCreateDto.FName,
                PhoneNumber= TechnicianCreateDto.PhoneNumber,
                Email = TechnicianCreateDto.Email,
                Address = TechnicianCreateDto.Address,
                DateOfEmployment= TechnicianCreateDto.DateOfEmployment,
                Skill = TechnicianCreateDto.Skill,
                ExperienceLevel = TechnicianCreateDto.ExperienceLevel,
                AvailabilityStatus = TechnicianCreateDto.AvailabilityStatus,
                Status = TechnicianCreateDto.Status
        };
         _context.Technicians.Add(tech);
         await _context.SaveChangesAsync();
         return Ok(tech);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTechnicians()
    {
        var technicains = await _context.Technicians
                               .Select(t=> new
                               {
                                      FullName = t.FName,
                      PhoneNumber = t.PhoneNumber,
                      Email = t.Email,
                      curentJobs = t.Assigments
                                    .Where(a => a.MaintenanceJob != null)
                                    .Select(a => new
                                    {
                                        JobTitle = a.MaintenanceJob.JobTitle, 
                                        PriorityStatus = a.MaintenanceJob.Priority,
                                        DateAssigned = a.DateAssigned
                                    })
                               }).ToListAsync();
                                
                            
        return Ok(technicains);
    }
[HttpGet("{id}")]
public async Task<IActionResult> GetTechnician(int id)
{
    var tech = await _context.Technicians
                  .Where(t => t.Id == id)
                  .Select(t => new
                  {
                      FullName = t.FName,
                      PhoneNumber = t.PhoneNumber,
                      Email = t.Email,
                      curentJobs = t.Assigments
                                    .Where(a => a.MaintenanceJob != null)
                                    .Select(a => new
                                    {
                                        JobTitle = a.MaintenanceJob.JobTitle, 
                                        PriorityStatus = a.MaintenanceJob.Priority,
                                        DateAssigned = a.DateAssigned
                                    }).ToList()
                  }).FirstOrDefaultAsync();

    if (tech == null)
    {
        return NotFound();
    }


    return Ok(tech);
}

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTechnician(int id, Technician technician)
    {
        var tech = await _context.Technicians.FindAsync(id);
        if (tech == null)
        {
            return BadRequest();
        }
        tech.FName = technician.FName;
        tech.PhoneNumber = technician.PhoneNumber;
        tech.Email = technician.Email;
        tech.Address= technician.Address;
        tech.DateOfEmployment=technician.DateOfEmployment;
        tech.Skill= technician.Skill;
        tech.ExperienceLevel= technician.ExperienceLevel;
        tech.AvailabilityStatus= technician.AvailabilityStatus;
        tech.Status= technician.Status;

        await _context.SaveChangesAsync();
        return Ok("Message: Updated Successfully");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnicians(int id)
    {
        var tech = _context.Technicians.Find(id);
        if (tech == null)
        {
            return BadRequest();
        }
        _context.Technicians.Remove(tech);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}