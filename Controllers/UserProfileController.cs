using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unison.Data;
using Unison.Models;
using Unison.Models.DTOs;
namespace Unison.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private UnisonDbContext _dbContext;

    public UserProfileController(UnisonDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles
            .OrderBy(up => up.Id)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                FirstName = up.FirstName,
                LastName = up.LastName,
                Address = up.Address,
                IdentityUserId = up.IdentityUserId,
                TeacherId = up.TeacherId,
                UserName = up.IdentityUser.UserName
            })
        .ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Teacher")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .OrderBy(up => up.Id)
        .Select(up => new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            TeacherId = up.TeacherId,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        try
        {
            var up = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Include(up => up.Teacher)
            .SingleOrDefault(up => up.Id == id);

            if (up == null)
            {
                return NotFound("Id doesn't exist on a userProfile");
            }

            if(up.TeacherId > 0)
            {
                return Ok(new UserProfileDTO
                {
                    Id = up.Id,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Address = up.Address,
                    TeacherId = up.TeacherId,
                    Teacher = new UserProfileDTO
                    {
                        Id = up.Teacher.Id,
                        FirstName = up.Teacher.FirstName,
                        LastName = up.Teacher.LastName
                    },
                    IdentityUserId = up.IdentityUserId,
                    Email = up.IdentityUser.Email,
                    UserName = up.IdentityUser.UserName,
                    Roles = _dbContext.UserRoles
                        .Where(ur => ur.UserId == up.IdentityUserId)
                        .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                        .ToList()
                });
            }

            else
            {
                return Ok(new UserProfileDTO
                {
                    Id = up.Id,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Address = up.Address,
                    TeacherId = up.TeacherId,
                    IdentityUserId = up.IdentityUserId,
                    Email = up.IdentityUser.Email,
                    UserName = up.IdentityUser.UserName,
                    Roles = _dbContext.UserRoles
                        .Where(ur => ur.UserId == up.IdentityUserId)
                        .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                        .ToList()
                });
            }

        }

        catch (Exception ex)
        {
            return BadRequest($"Bad data {ex}");
        }
    }

    [HttpGet("teacher/{id}")]
    [Authorize(Roles = "Teacher")]
    public IActionResult GetTeacherStudents(int id)
    {
        try
        {
            List<UserProfile> found = _dbContext.UserProfiles
            .Include(u => u.IdentityUser)
            .Include(u => u.Teacher)
            .Where(u => u.TeacherId == id).ToList();

            return Ok(found.Select(f => new UserProfileDTO
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
                Address = f.Address,
                Email = f.IdentityUser.Email,
                UserName = f.IdentityUser.UserName,
                TeacherId = f.TeacherId,
                Teacher =  new UserProfileDTO {
                Id = f.Teacher.Id,
                FirstName = f.Teacher.FirstName,
                LastName = f.Teacher.LastName
                },
                IdentityUserId = f.IdentityUserId,
                Roles = _dbContext.UserRoles
                    .Where(ur => ur.UserId == f.IdentityUserId)
                    .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                    .ToList()
            }).ToList());
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }


    [HttpGet("musicians")]
    [Authorize(Roles = "Teacher")]
    public IActionResult GetMusicians()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Include(up => up.Teacher)
        .OrderBy(up => up.Id)
        .Select(up => new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            TeacherId = up.TeacherId,
            Teacher =  new UserProfileDTO {
                Id = up.Teacher.Id,
                FirstName = up.Teacher.FirstName,
                LastName = up.Teacher.LastName
            },
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }).Where(up => !up.Roles.Contains("Teacher")));
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateProfile(int id, UserProfile obj)
    {
        try
        {
            if(id != obj.Id)
            {
                return BadRequest("Id's do not match");
            }

            // return error if there are any empty or null values given
            if(string.IsNullOrWhiteSpace(obj.FirstName) || 
                string.IsNullOrWhiteSpace(obj.LastName) || 
                string.IsNullOrWhiteSpace(obj.Address) ||
                string.IsNullOrWhiteSpace(obj.Email) ||
                string.IsNullOrWhiteSpace(obj.UserName)
            )
            {
                return BadRequest("All input fields are required");
            }

            var found = _dbContext.UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

            if(found == null)
            {
                return BadRequest("No User found with given id");
            }

            found.FirstName = obj.FirstName;
            found.LastName = obj.LastName;
            found.Address = obj.Address;
            found.IdentityUser.Email = obj.Email;
            found.IdentityUser.UserName = obj.UserName;

            _dbContext.SaveChanges();

            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest($"Bad data sent: {ex}");
        }
    }

}