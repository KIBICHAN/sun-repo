using ApartRent.Data;
using ApartRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartRent.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingController : ControllerBase{
    private readonly DataContext _context;

    public BuildingController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Building>>> GetAll(){
        var posts = await _context.Buildings
        .Select(b => new {b.BuildingId, b.BuildingName})
        .ToListAsync();
        return Ok(posts);
    }
}