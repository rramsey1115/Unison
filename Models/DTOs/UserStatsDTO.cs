namespace Unison.Models.DTOs;

public class UserStatsDTO
{
    public int UserId { get; set; }
    public int CompletedAssignments { get; set; }
    public int TotalSessions { get; set; }
    public int TotalTime { get; set; }
    public DateTime LastSession { get; set; }
    public CategoryDTO TopCategory { get; set; }
    public ActivityObjDTO TopActivity { get; set; }
}