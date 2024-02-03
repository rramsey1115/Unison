namespace Unison.Models.DTOs;

public class UserStatsDTO
{
    public int UserId { get; set; }
    public UserProfileDTO User { get; set; }
    public int CompletedAssignments { get; set; }
    public int CompletedSessions { get; set; }
    public int TotalTime { get; set; }
    public DateTime? LastSession { get; set; }
    public Category? TopCategory { get; set; }
    public ActivityObj? TopActivity { get; set; }
}