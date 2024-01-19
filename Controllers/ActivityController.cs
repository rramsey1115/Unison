using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models.DTOs;
using Microsoft.EntityFrameworkCore;
namespace Unison.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ActivityController : ControllerBase
{
    private UnisonDbContext _dbContext;

    public ActivityController(UnisonDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {

        try
        {
            return Ok(_dbContext.Activities
            .Include(a => a.Category)
            .Select(a => new ActivityObjDTO
            {
                Id = a.Id,
                Name = a.Name,
                Details = a.Details,
                CategoryId = a.CategoryId,
                Category = new CategoryDTO
                {
                    Id = a.Category.Id,
                    Name = a.Category.Name,
                    Details = a.Category.Details
                }
            }).ToList()
            );
        }

        catch(Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

}