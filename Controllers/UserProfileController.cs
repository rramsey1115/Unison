using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unison.Data;
using Unison.Models;
using Unison.Models.DTOs;

namespace GuiseppeJoes.Controllers;

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
                UserName = up.IdentityUser.UserName
            })
        .ToList());
    }

    [HttpGet("withroles")]
    // [Authorize(Roles = "Teacher")]
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
        var up = _dbContext
        .UserProfiles
        .Include(up => up.IdentityUser)
        .SingleOrDefault(up => up.Id == id);

        if (up == null)
        {
            return NotFound("Id doesn't exist on a userProfile");
        }

        return Ok(new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            TeacherId = up.TeacherId,
            IdentityUserId = up.IdentityUserId,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName
        }

        );
    }

    [HttpGet("teacher/{id}")]
    [Authorize(Roles = "Teacher")]
    public IActionResult GetTeacherStudents(int id)
    {
        try
        {
            List<UserProfile> found = _dbContext.UserProfiles
            .Include(u => u.IdentityUser)
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
}