using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unison.Data;
using Unison.Models;
using Unison.Models.DTOs;

namespace Unison.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private UnisonDbContext _dbContext;

    public StatsController(UnisonDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetStatsByUserId(int id)
    {
        try
        {
            // find user object
            var User = _dbContext.UserProfiles
            .Include(up => up.IdentityUser)
            .Include(up => up.Teacher).ThenInclude(t => t.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

            if(User == null)
            {
                return BadRequest("No User found with given UserId");
            }

            // find list of User sessions
            List<Session> UserSessions = _dbContext.Sessions
            .Include(s => s.SessionActivities).ThenInclude(sa => sa.Activity).ThenInclude(ac => ac.Category)
            .OrderByDescending(s => s.DateCompleted)
            .Where(s => s.MusicianId == User.Id).ToList();

            // find list of User assignments 
            List<Assignment> UserAssignments = _dbContext.Assignments.Include(a => a.Session).Where(a => a.MusicianId == User.Id).ToList();

            // int showing amount of total completed sessions
            int CompletedSessions = UserSessions.Count();

            // int showing amount of total completed assignments
            int CompletedAssignments = UserAssignments.Count();

            // int showing total amount of time spent practicing 
            var TotalTime = 0;
            foreach(Session s in UserSessions)
            {
                TotalTime += s.Duration;
            }

            // DateTime showing last practice session
            var FoundSession = UserSessions.FirstOrDefault(s => s.DateCompleted != null);

            DateTime? LastSession;
            if(FoundSession != null)
            {
                LastSession = FoundSession.DateCompleted;
            }
            else
            {
                LastSession = null;
            }

            // CategoryDTO showing most practiced category
            var categoryCounts = UserSessions
            .SelectMany(session => session.SessionActivities)
            .Select(sessionActivity => sessionActivity.Activity.Category)
            .GroupBy(category => category.Id)
            .Select(group => new
            {
                CategoryId = group.Key,
                Count = group.Count()
            })
            .OrderByDescending(result => result.Count)
            .FirstOrDefault();

            Category? TopCategory;

            if (categoryCounts != null)
            {
                TopCategory = _dbContext.Categories.SingleOrDefault(c => c.Id == categoryCounts.CategoryId);
            }
            else
            {
                TopCategory = null;
            }

            // ActivityObjDTO showing most practiced activity
            var activityCount = UserSessions
            .SelectMany(s => s.SessionActivities)
            .Select(sa => sa.Activity)
            .GroupBy(activity => activity.Id)
            .Select(group => new{
                ActivityId = group.Key,
                Count = group.Count()
            })
            .OrderByDescending(result => result.Count)
            .FirstOrDefault();

            ActivityObj? TopActivity;
            if(activityCount != null)
            {
                TopActivity = _dbContext.Activities.SingleOrDefault(a => a.Id == activityCount.ActivityId);
            }
            else
            {
                TopActivity = null;
            }

            // return UserStatsDTO
            return Ok(new UserStatsDTO 
            {
                UserId = User.Id,
                User = new UserProfileDTO
                {
                    Id = User.Id,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Address = User.Address,
                    IdentityUserId = User.IdentityUserId,
                    TeacherId = User.TeacherId,
                    UserName = User.IdentityUser.UserName,
                    Email = User.IdentityUser.Email,
                    Roles = _dbContext.UserRoles
                        .Where(ur => ur.UserId == User.IdentityUserId)
                        .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                        .ToList(),
                    Teacher = User.TeacherId > 0 ?  new UserProfileDTO
                    {
                        Id = User.Teacher.Id,
                        FirstName = User.Teacher.FirstName,
                        LastName = User.Teacher.LastName,
                        UserName = User.Teacher.IdentityUser.UserName,
                        Email = User.Teacher.IdentityUser.Email
                    }
                : null
                },
                CompletedAssignments = CompletedAssignments,
                CompletedSessions = CompletedSessions,
                TotalTime = TotalTime,
                LastSession = LastSession,
                TopCategory = TopCategory,
                TopActivity = TopActivity
            });

        }

        catch (Exception ex)
        {
            return BadRequest($"Bad data: {ex}");
        }
    }


}