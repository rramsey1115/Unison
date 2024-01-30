using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace Unison.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AssignmentController : ControllerBase
{
    private UnisonDbContext _dbContext;


    public AssignmentController(UnisonDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {

        try
        {
            return Ok(_dbContext.Assignments
            .Include(a => a.Session).ThenInclude(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(ac => ac.Category)
            .Include(a => a.Teacher)
            .Include(a => a.Musician)
            .Select(a => new AssignmentDTO
            {
                Id = a.Id,
                TeacherId = a.TeacherId,
                Teacher = new UserProfileDTO
                {
                    Id = a.Teacher.Id,
                    FirstName = a.Teacher.FirstName,
                    LastName = a.Teacher.LastName
                },
                MusicianId = a.MusicianId,
                Musician = new UserProfileDTO
                {
                    Id = a.Musician.Id,
                    FirstName = a.Musician.FirstName,
                    LastName = a.Musician.LastName
                },
                SessionId = a.SessionId,
                Session = new SessionDTO
                {
                    Id = a.Session.Id,
                    MusicianId = a.Session.MusicianId,
                    DateCompleted = a.Session.DateCompleted,
                    Notes = a.Session.Notes,
                    SessionActivities = a.Session.SessionActivities.Select(sa => new SessionActivityDTO
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
                        },
                        Duration = sa.Duration
                    }).ToList()
                },
                DueDate = a.DueDate
            }).ToList()
            );
        }

        catch(Exception ex)
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
            Assignment a = _dbContext.Assignments
            .Include(a => a.Session).ThenInclude(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(ac => ac.Category)
            .Include(a => a.Teacher)
            .Include(a => a.Musician)
            .SingleOrDefault(a => a.Id == id);

            if (a == null)
            {
                return NotFound("No assignment contains matching id");
            }

            return Ok( new AssignmentDTO
            {
                Id = a.Id,
                TeacherId = a.TeacherId,
                Teacher = new UserProfileDTO
                {
                    Id = a.Teacher.Id,
                    FirstName = a.Teacher.FirstName,
                    LastName = a.Teacher.LastName
                },
                MusicianId = a.MusicianId,
                Musician = new UserProfileDTO
                {
                    Id = a.Musician.Id,
                    FirstName = a.Musician.FirstName,
                    LastName = a.Musician.LastName
                },
                SessionId = a.SessionId,
                Session = new SessionDTO
                {
                    Id = a.Session.Id,
                    MusicianId = a.Session.MusicianId,
                    DateCompleted = a.Session.DateCompleted,
                    Notes = a.Session.Notes,
                    SessionActivities = a.Session.SessionActivities.Select(sa => new SessionActivityDTO
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
                        },
                        Duration = sa.Duration
                    }).ToList()
                },
                DueDate = a.DueDate
            });
        }

        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }


     [HttpGet("musician/{id}")]
    // [Authorize]
    public IActionResult GetByMusicianId(int id)
    {
        try
        {
            List<Assignment> array = _dbContext.Assignments
            .Include(a => a.Session).ThenInclude(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(ac => ac.Category)
            .Include(a => a.Teacher)
            .Include(a => a.Musician)
            .OrderBy(a => a.Complete)
            .Where(a => a.MusicianId == id).ToList();

            if (array == null)
            {
                return NotFound("No assignment contains matching id");
            }

            return Ok(array.Select(a => new AssignmentDTO
            {
                Id = a.Id,
                TeacherId = a.TeacherId,
                Teacher = new UserProfileDTO
                {
                    Id = a.Teacher.Id,
                    FirstName = a.Teacher.FirstName,
                    LastName = a.Teacher.LastName
                },
                MusicianId = a.MusicianId,
                Musician = new UserProfileDTO
                {
                    Id = a.Musician.Id,
                    FirstName = a.Musician.FirstName,
                    LastName = a.Musician.LastName
                },
                SessionId = a.SessionId,
                Session = new SessionDTO
                {
                    Id = a.Session.Id,
                    MusicianId = a.Session.MusicianId,
                    DateCompleted = a.Session.DateCompleted,
                    Notes = a.Session.Notes,
                    SessionActivities = a.Session.SessionActivities.Select(sa => new SessionActivityDTO
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
                        },
                        Duration = sa.Duration
                    }).ToList()
                },
                DueDate = a.DueDate
            }).ToList()
            );
        }

        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

}