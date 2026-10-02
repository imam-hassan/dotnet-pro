

using dotnet_pro.Data;
using dotnet_pro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_pro.Controllers;

[ApiController]
[Route("api/tower")]
public class TowerController:ControllerBase
{
    private readonly AppDbContext _context;
    public TowerController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTower(int id)
    {
        var tow = await _context.Towers.FindAsync(id);
        if (tow == null)
        {
            return BadRequest();
        }
        return Ok(tow);
    }
    [HttpGet]
    public async Task<IActionResult> GetTowers()
    {
        var towers = await _context.Towers.ToListAsync();
        return Ok(towers);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTower(Tower tower)
    {
         _context.Towers.Add(tower);
         await _context.SaveChangesAsync();
         return Ok(tower);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> DeleteTower(int id, Tower tower)

    {
      var tow = await _context.Towers.FindAsync(id);
      if (tow == null)
        {
            return BadRequest();
        }
      
           tow.TowerId= tower.TowerId;
           tow.SiteName= tower.SiteName;
           tow.Location = tower.Location;
           tow.State = tower.State;
           tow.Latitude = tower.Latitude;
           tow.Longitude = tower.Longitude;
           tow.TowerType = tower.TowerType;
           tow.TowerHeight = tower.TowerHeight;
           tow.InstallationDate = tower.InstallationDate;
           tow.Status = tower.Status;

            _context.Towers.Update(tow);
            await _context.SaveChangesAsync();
            return Ok("Updated Success Fully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTower(int id)
    {
        var tow =await _context.Towers.FindAsync(id);
        if (tow == null)
        {
            return BadRequest();
        }
        _context.Towers.Remove(tow);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}