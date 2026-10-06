using dotnet_pro.Data;
using dotnet_pro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_pro.Controllers;


[ApiController]
[Route("/api/assign")]
public class AssignController:ControllerBase
{
    private readonly AppDbContext _context;

    public AssignController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAssign(Assign assign)
    {
        _context.Assigments.Add(assign);
        await _context.SaveChangesAsync();


          return CreatedAtAction(nameof(GetAssign), new{id=assign.Id},assign);
    }
  
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssign(int id)
    {
        var assign = await _context.Assigments.FindAsync(id);
        if (assign== null)
        {
            return NotFound();
        }

        return Ok(assign);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssign(int id)
    {
        var ass = await _context.Assigments.FindAsync(id);
        if (ass == null)
        {
            return NotFound();
        }
        _context.Assigments.Remove(ass);
       await  _context.SaveChangesAsync();
       return Ok("Deleted Successfully");
    }
    
}