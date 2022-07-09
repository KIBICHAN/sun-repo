using ApartRent.Data;
using ApartRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartRent.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase{
    private readonly DataContext _context;

    public PostController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAll(){
        var posts = await _context.Posts
        .Include(p => p.Apartment)
        .ToListAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> Get(int id){
        var post = await _context.Posts
        .Include(p => p.PostStatus)
        .Include(p => p.PostType)
        .Include(p => p.Apartment)
        .ThenInclude(p => p!.Building)
        .Include(p => p.Owner).FirstOrDefaultAsync(p => p.PostId == id);
        return Ok(post);
    }

    [HttpGet("sta/{statusId}")]
    public async Task<ActionResult<List<Post>>> GetStatus(int statusId){
        var statuses = await _context.Posts
        .Where(p => p.PostStatusId == statusId)
        .Include(p => p.Apartment)
        .ToListAsync();
        return Ok(statuses);
    }

    [HttpGet("sear/{searchString}")]
    public async Task<ActionResult<List<Post>>> GetSearch(string searchString){
        var searchStrgs = await _context.Posts
        .Where(p => p.Title!.Contains(searchString))
        .Include(p => p.Apartment)
        .ToListAsync();
        return Ok(searchStrgs);
    }
}