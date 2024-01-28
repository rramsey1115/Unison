using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace Unison.Controllers;


[ApiController]
[Route("api/[controller]")]

public class FavoriteSessionController : ControllerBase
{
    private UnisonDbContext _dbContext;

    public FavoriteSessionController(UnisonDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult Get(int id)
    {
        try
        {
            var found = _dbContext.FavoriteSessions.Where(f => f.MusicianId == id);

            var result = found.Select(f => new FavoriteSessionDTO
            {
                Id = f.Id,
                SessionId = f.SessionId,
                MusicianId = f.MusicianId
            }).ToList();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post(FavoriteSession obj)
    {
        try
        {

            // makes sure the given foreign keys are ints > 0
            if(obj.SessionId <= 0 || obj.MusicianId <= 0)
            {
                return BadRequest("MusicianId and SessionId must be ints great than 0");
            }

            // finds if matching foreign key relationship already exists
            var matches = _dbContext.FavoriteSessions.Where(fav => fav.MusicianId == obj.MusicianId && fav.SessionId == obj.SessionId);
            if (matches.Any())
            {
                return BadRequest("This musician has already favorited this session");
            }
            
            if(obj.SessionId > 0 && obj.MusicianId > 0)
            {
                _dbContext.FavoriteSessions.Add(obj);
                _dbContext.SaveChanges();
                return Ok();
            }

            return BadRequest("int SessionId & int MusicianId required");
        }
        
        catch (Exception ex)
        {
            return BadRequest($"Bad Data: {ex}");
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        try
        {
            var found = _dbContext.FavoriteSessions.SingleOrDefault(fav => fav.Id == id);
            if (found == null)
            {
                return NotFound("No favorite session found with given id");
            }

            _dbContext.FavoriteSessions.Remove(found);
            _dbContext.SaveChanges();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }

}

