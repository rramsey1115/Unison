using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models.DTOs;
using Microsoft.EntityFrameworkCore;
namespace Unison.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CommentController : ControllerBase
{
    private UnisonDbContext _dbContext;

    public CommentController(UnisonDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {

        try
        {
            return Ok(_dbContext.Comments
            .Include(c => c.Teacher)
            .Select(c => new CommentDTO
            {
                Id = c.Id,
                SessionId = c.SessionId,
                TeacherId = c.TeacherId,
                Teacher = new UserProfileDTO
                {
                    Id = c.Teacher.Id,
                    FirstName = c.Teacher.FirstName,
                    LastName = c.Teacher.LastName
                },
                Body = c.Body
            }).ToList()
            );
        }

        catch(Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

}