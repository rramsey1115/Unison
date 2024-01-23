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
    // [Authorize]
    public IActionResult Get()
    {
        try
        {
            return Ok(_dbContext.Sessions
            .Include(s => s.Musician).ThenInclude(m => m.Teacher)
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
                    Email = s.Musician.IdentityUser.Email,
                    Address = s.Musician.Address,
                    TeacherId = s.Musician.TeacherId,
                    IdentityUserId = s.Musician.IdentityUserId
                },
                DateCompleted = s.DateCompleted,
                Notes = s.Notes,
                SessionActivities = s.SessionActivities.Select(sa => new SessionActivityDTO
                {
                    Id = sa.Id,
                    SessionId = sa.SessionId,
                    Duration = sa.Duration,
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
                }).ToList()
            }).ToList()
            );
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }


    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetById(int id)
    {
        try
        {
            var s = _dbContext.Sessions
            .Include(s => s.Musician)
            .Include(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(a => a.Category)
            .SingleOrDefault(s => s.Id == id);

            if (s == null)
            {
                return NotFound("No session with matching SessionId");
            }

            return Ok(new SessionDTO 
            {
                Id = s.Id,
                MusicianId = s.MusicianId,
                Musician = new UserProfileDTO
                {
                    Id = s.Musician.Id,
                    FirstName = s.Musician.FirstName,
                    LastName = s.Musician.LastName,
                    Address = s.Musician.Address,
                    TeacherId = s.Musician.TeacherId,
                    IdentityUserId = s.Musician.IdentityUserId
                },
                DateCompleted = s.DateCompleted,
                Notes = s.Notes,
                SessionActivities = s.SessionActivities.Select(sa => new SessionActivityDTO
                {
                    Id = sa.Id,
                    SessionId = sa.SessionId,
                    Duration = sa.Duration,
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
                }).ToList()
            }
            );
        }

        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

    [HttpPost]
    [Authorize]
    public IActionResult PostNewSession(Session session)
    {
        try
        {
            int newId = _dbContext.Sessions.Count() + 1;
            session.Id = newId;
            session.SessionActivities.Select(sa => sa.SessionId = newId);
            _dbContext.Sessions.Add(session);
            _dbContext.SaveChanges();
            return Created($"/api/session/{session.Id}", session);
        }

        catch (Exception ex)
        {
            return BadRequest($"Bad data sent: {ex}");
        }
    }


}