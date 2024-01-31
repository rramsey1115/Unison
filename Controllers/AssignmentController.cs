using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public IActionResult Get()
    {

        try
        {
            return Ok(_dbContext.Assignments
            .Include(a => a.Session).ThenInclude(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(ac => ac.Category)
            .Include(a => a.Teacher)
            .Include(a => a.Musician)
            .OrderBy(a => a.Session.DateCompleted != null)
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
    [Authorize]
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
    [Authorize]
    public IActionResult GetByMusicianId(int id)
    {
        try
        {
            List<Assignment> array = _dbContext.Assignments
            .Include(a => a.Session).ThenInclude(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(ac => ac.Category)
            .Include(a => a.Teacher)
            .Include(a => a.Musician)
            .OrderBy(a => a.Session.DateCompleted != null)
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


    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public IActionResult NewAssignment(Assignment assignment)
    {
        try
        {
            // find highest Id in Sessions table... should be the newest one just created
            var found = _dbContext.Sessions.OrderByDescending(s => s.Id).First();
            
            if (found==null)
            {
                return BadRequest("No Session found with given SessionId");
            }

            // use found Session.Id to create assignment.Session obj;
            assignment.SessionId = found.Id;
            assignment.Session = found;

            // once the assignment has a SessionId & Session - add it to the database
            _dbContext.Assignments.Add(assignment);
            _dbContext.SaveChanges();

            // return the object created
            return Created($"/api/assignment/{assignment.Id}", assignment);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Data Send: {ex}");
        }
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Teacher")]
    public IActionResult DeleteByAssignmentId(int id)
    {
        try
        {
            var foundAssignment = _dbContext.Assignments.SingleOrDefault(a => a.Id == id);
            if (foundAssignment == null) 
            { 
                return NotFound("No assignment found with matching id");
            }
            
            var foundSession = _dbContext.Sessions.SingleOrDefault(s => s.Id == foundAssignment.SessionId);
            if (foundSession != null)
            {
                _dbContext.Sessions.Remove(foundSession);
                _dbContext.SaveChanges();
            }

            // _dbContext.Assignments.Remove(foundAssignment);
            // _dbContext.SaveChanges();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Data sent: {ex}");
        }
    }

}