using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unison.Data;

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


            )

        }
        catch (Exception ex)
        {
            return BadRequest($"{ex}");
        }
    }

}