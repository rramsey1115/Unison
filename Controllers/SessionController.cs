using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unison.Data;
using Unison.Models.DTOs;

namespace Unison.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private UnisonDbContext _dbContext;

    public SessionController(UnisonDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        try
        {
            return Ok(_dbContext.Sessions
            .Include(s => s.Musician)
            .Include(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(act => act.Category)
            .OrderByDescending(s => s.DateCompleted)
            .Select(s => new SessionDTO
            {
                Id = s.Id,
                MusicianId = s.MusicianId,
                Musician = new UserProfileDTO
                {
                    Id = s.Musician.Id,
                    FirstName = s.Musician.FirstName,
                    LastName = s.Musician.LastName,
                    Address = s.Musician.Address,
                    Email = s.Musician.Email,
                    UserName = s.Musician.UserName,
                    Roles = s.Musician.Roles
                },
                DateCompleted = s.DateCompleted,
                Notes = s.Notes,
                SessionActivities = s.SessionActivities.Count > 0 ? s.SessionActivities.Select(sa => new SessionActivityDTO
                {
                    Id = sa.Id,
                    SessionId = sa.SessionId,
                    ActivityId = sa.ActivityId,
                    Activity = new ActivityObjDTO
                    {
                        Id = sa.Activity.Id,
                        Name = sa.Activity.Name,
                        Details = sa.Activity.Details,
                        CategoryId = sa.Activity.CategoryId,
                        Category = new CategoryDTO
                        {
                            Id = sa.Activity.Category.Id,
                            Name = sa.Activity.Category.Name,
                            Details = sa.Activity.Category.Details
                        }
                    }
                }).ToList() : null
            }).ToList()
            );
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

}