using dotnet_pro.Data;
using dotnet_pro.Model;
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
    public async Task<IActionResult> CreateTechnician(Technician technician)
    {
      var  tech = new Technician ()
        {
                FName= technician.FName,
                PhoneNumber= technician.PhoneNumber,
                Email = technician.Email,
                Address = technician.Address,
                DateOfEmployment= technician.DateOfEmployment,
                Skill = technician.Skill,
                ExperienceLevel = technician.ExperienceLevel,
                AvailabilityStatus = technician.AvailabilityStatus,
                Status = technician.Status
        };
         _context.Technicians.Add(tech);
         await _context.SaveChangesAsync();
         return Ok(tech);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTechnicians()
    {
        var technicains = await _context.Technicians.ToListAsync();
        if (technicains == null)
        {
            return NotFound();
        }
        return Ok(technicains);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTechnician (int id)
    {
        var tech = await _context.Technicians.FindAsync(id);
        if (tech == null)
        {
            return BadRequest();
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