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

    [HttpPost("post1")]
    public async Task<ActionResult<List<Owner>>> PostPost1(CreatePost post){
        Owner _owner = new Owner();
        _owner.Name = post.Name;
        _owner.Phone = post.Phone;
        _owner.Email = post.Email;

        _context.Owners.Add(_owner);

         await _context.SaveChangesAsync();
        return Ok(await _context.Owners.ToListAsync());
    }

    [HttpPost("post2")]
    public async Task<ActionResult<List<Apartment>>> PostPost2(CreatePost post){
        //_context.Posts.Add(post);

        Apartment _apartment = new Apartment();
        _apartment.Area = post.Area;
        _apartment.NumberOfBedroom = post.NumberOfBedroom;
        _apartment.NumberOfBathroom = post.NumberOfBathroom;
        _apartment.HouseDirection = post.HouseDirection;
        _apartment.BalconyDirection = post.BalconyDirection;
        _apartment.ApartmentImgUrl = post.ApartmentImgUrl;
        _apartment.BuildingId = post.BuildingId;

        _context.Apartments.Add(_apartment);

        await _context.SaveChangesAsync();
        return Ok(await _context.Apartments.ToListAsync());
    }

    [HttpPost("post3")]
    public async Task<ActionResult<List<Post>>> PostPost3(CreatePost post){
        
        var id2 = await _context.Apartments.OrderByDescending(a => a.ApartmentId).Select(a => a.ApartmentId).FirstOrDefaultAsync();
        var id3 = await _context.Owners.OrderByDescending(o => o.OwnerId).Select(o => o.OwnerId).FirstOrDefaultAsync();

        Post _post = new Post();
        _post.Title = post.Title;
        _post.Price = post.Price;
        _post.Description = post.Description;
        _post.DateCreate = post.DateCreate;
        _post.ApartmentId = Convert.ToInt32(id2);
        _post.PostStatusId = post.PostStatusId;
        _post.PostTypeId = post.PostTypeId;
        _post.OwnerId = Convert.ToInt32(id3);

        _context.Posts.Add(_post);

        await _context.SaveChangesAsync();
        return Ok(await _context.Posts.ToListAsync());
    }

    // [HttpGet("id2")]
    // public async Task<ActionResult<List<Apartment>>> Test123(){
    //     var id2 = await _context.Apartments.OrderByDescending(a => a.ApartmentId).Select(a => a.ApartmentId).FirstOrDefaultAsync();
    //     return Ok(id2);
    // }

    // [HttpGet("id3")]
    // public async Task<ActionResult<List<Owner>>> Test124(){
    //     var id3 = await _context.Owners.OrderByDescending(o => o.OwnerId).Select(o => o.OwnerId).FirstOrDefaultAsync();
    //     return Ok(id3);
    // }
}