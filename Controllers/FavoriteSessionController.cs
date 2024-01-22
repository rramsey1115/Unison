using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models.DTOs;
using Microsoft.EntityFrameworkCore;
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

}

