using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models;

public class Session
{
    public int Id { get; set; }

    [Required]
    public int MusicianId { get; set; }

    [ForeignKey("MusicianId")]
    public UserProfile? Musician { get; set; }

    public DateTime? DateCompleted { get; set; }

    public string? Notes { get; set; }

    public List<SessionActivity> SessionActivities { get; set; }

    public int Duration { 
        get {

            int res = 0;

            if(SessionActivities != null)
            {
                foreach(SessionActivity sa in SessionActivities)
                {
                    res+= sa.Duration;
                }
            }

            return res;
        }
    }

}