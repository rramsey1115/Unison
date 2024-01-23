using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;
using Unison.Models;
using Unison.Models.DTOs;
namespace Unison.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoryController : ControllerBase
{
    private UnisonDbContext _dbContext;

    public CategoryController(UnisonDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {

        try
        {
            return Ok(_dbContext.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Details = c.Details
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
            Category c = _dbContext.Categories.SingleOrDefault(c => c.Id == id);

            if (c == null)
            {
                return NotFound("No activity matches given ActivityId");
            }

            return Ok(new Category
            {
                Id = c.Id,
                Name = c.Name,
                Details = c.Details
            });
        }

        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }


}
