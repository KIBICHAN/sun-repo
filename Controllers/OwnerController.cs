using ApartRent.Data;
using ApartRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartRent.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase{

    // private readonly IConfiguration _config;

    // public OwnerController(IConfiguration config){
    //     _config = config;
    // }

    // [HttpGet]
    // public async Task<ActionResult<List<Owner>>> GetAll(){
    //     using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    //     var owners = await connection.QueryAsync<Owner>("select * from Owners");
    //     return Ok(owners);
    // }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Owner>> Get(int id){
    //     using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    //     var owner = await connection.QueryFirstAsync<Owner>("select * from Owners where OwnerId = @OwnerId", new { OwnerId = id});
    //     return Ok(owner);
    // }

    // [HttpPost]
    // public async Task<ActionResult<List<Owner>>> Post(Owner owner){
    //     using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    //     await connection.ExecuteAsync("insert into Owners ([Name], [Phone], [Email], [OwnerImgUrl]) values (@Name, @Phone, @Email, @OwnerImgUrl)", owner);
    //     return Ok(await SelectAll(connection));
    // }

    // [HttpPut]
    // public async Task<ActionResult<List<Owner>>> Put(Owner owner){
    //     using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    //     await connection.ExecuteAsync("update Owners set Name = @Name, Phone = @Phone, Email = @Email, OwnerImgUrl = @OwnerImgUrl where OwnerId = @OwnerId", owner);
    //     return Ok(await SelectAll(connection));
    // }

    // [HttpDelete("{id}")]
    // public async Task<ActionResult<List<Owner>>> Delete(int id){
    //     using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    //     await connection.ExecuteAsync("delete from Owners where OwnerId = @OwnerId", new { OwnerId = id});
    //     return Ok(await SelectAll(connection));
    // }

    // private static async Task<IEnumerable<Owner>> SelectAll(SqlConnection connection){
    //     return await connection.QueryAsync<Owner>("select * from Owners");
    // }

    private readonly DataContext _context;

    public OwnerController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Owner>>> Get(){
        return Ok(await _context.Owners.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Owner>> Get(int id){
        var owner = await _context.Owners.FindAsync(id);
        if(owner == null){
            return BadRequest("Owner is not found!");
        }
        return Ok(owner);
    }

    [HttpPost]
    public async Task<ActionResult<List<Owner>>> AddOwner(Owner owner){
        _context.Owners.Add(owner);
        await _context.SaveChangesAsync();

        return Ok(await _context.Owners.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<Owner>>> UpdateOwner(Owner request){
        var owner = await _context.Owners.FindAsync(request.OwnerId);
        if(owner == null){
            return BadRequest("Owner is not found!");
        }

        owner.Name = request.Name;
        owner.Phone = request.Phone;
        owner.Email = request.Email;
        owner.OwnerImgUrl = request.OwnerImgUrl;

        await _context.SaveChangesAsync();
        return Ok(await _context.Owners.ToListAsync());
    }

    [HttpDelete]
    public async Task<ActionResult<List<Owner>>> Delete(int id){
        var owner = await _context.Owners.FindAsync(id);
        if(owner == null){
            return BadRequest("Hero not found.");
        }

        _context.Owners.Remove(owner);
        await _context.SaveChangesAsync();

        return Ok(await _context.Owners.ToListAsync());
    }
}