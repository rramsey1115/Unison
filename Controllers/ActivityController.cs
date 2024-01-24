using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Unison.Models;
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
    [Authorize]
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
                CreatorId = a.CreatorId,
                Category = new CategoryDTO
                {
                    Id = a.Category.Id,
                    Name = a.Category.Name,
                    Details = a.Category.Details
                }
            }).ToList()
            );
        }

        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

    [HttpGet("category/{id}")]
    [Authorize]
    public IActionResult GetByCategoryId(int id)
    {
        try
        {
            var array = _dbContext.Activities
            .Include(a => a.Category)
            .Where(a => a.CategoryId == id).ToList();

            if (array == null)
            {
                return NotFound("No activity matches given ActivityId");
            }

            return Ok(array.Select(a => new ActivityObjDTO
            {
                Id = a.Id,
                Name = a.Name,
                Details = a.Details,
                CategoryId = a.CategoryId,
                CreatorId = a.CreatorId,
                Category = new CategoryDTO
                {
                    Id = a.Category.Id,
                    Name = a.Category.Name,
                    Details = a.Category.Details
                }
            }).ToList()
            );
        }

        catch (Exception ex)
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
            var f = _dbContext.Activities.Include(a => a.Category).SingleOrDefault(a => a.Id == id);

            if(f == null)
            {
                return NotFound("No activity found with given id");
            }

            return Ok(new ActivityObjDTO
            {
                Id = f.Id,
                Name = f.Name,
                Details = f.Details,
                CategoryId = f.CategoryId,
                Category = new CategoryDTO
                {
                    Id = f.Category.Id,
                    Name = f.Category.Name,
                    Details = f.Category.Details
                }
            });
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }


    
    [HttpPost]
    // [Authorize]
    public IActionResult PostNewActivity(ActivityObj newActivity)
    {
        try
        {
            _dbContext.Activities.Add(newActivity);
            _dbContext.SaveChanges();
            return Created($"/api/activities/{newActivity.Id}", newActivity);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Data: {ex}");
        }
    }

    [HttpDelete("{id}")]
    // [Authorize]
    public IActionResult DeleteActivity(int id)
    {
        try
        {
            var found = _dbContext.Activities.SingleOrDefault(a => a.Id == id);
            if(found == null)
            {
                return NotFound("No activity found with matching id");
            }

            _dbContext.Activities.Remove(found);
            _dbContext.SaveChanges();

            return Ok();
        }

        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }
}