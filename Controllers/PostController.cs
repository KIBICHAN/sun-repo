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

    [HttpGet("sta/{statusId}")]
    public async Task<ActionResult<List<Post>>> GetStatus(int statusId){
        var statuses = await _context.Posts
        .Where(p => p.PostStatusId == statusId)
        .Include(p => p.Apartment)
        .ToListAsync();

        if(statuses == null){
            return BadRequest("Post not found.");
        }

        return Ok(statuses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> Get(int id){
        var post = await _context.Posts
        .Include(p => p.PostStatus)
        .Include(p => p.PostType)
        .Include(p => p.Apartment)
        .ThenInclude(p => p!.Building)
        .Include(p => p.Owner).FirstOrDefaultAsync(p => p.PostId == id);

        if(post == null){
            return BadRequest("Post not found.");
        }

        return Ok(post);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Post>> PutStatusDeactivate(int id, int status){
        var _post = await _context.Posts.FindAsync(id);
        if(_post == null){
            return BadRequest("Post not found!");
        }

        _post.PostStatusId = status;

        await _context.SaveChangesAsync();
        return Ok(_post);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Post>>> Delete(int id){
        var post = await _context.Posts
        .Where(p => p.PostId == id)
        .SingleOrDefaultAsync();

        var apart = await _context.Apartments
        .Where(a => a.ApartmentId == id)
        .SingleOrDefaultAsync();
        
        if(post == null){
            return BadRequest("Hero not found.");
        }
        if(apart == null){
            return BadRequest("Apartment not found.");
        }

        _context.Posts.Remove(post);
        _context.Apartments.Remove(apart);

        await _context.SaveChangesAsync();
        
        return Ok(await _context.Posts.ToListAsync());
    }
}