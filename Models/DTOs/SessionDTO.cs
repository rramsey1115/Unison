using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models.DTOs;

public class SessionDTO
{
    public int Id { get; set; }

    [Required]
    public int MusicianId { get; set; }

    [ForeignKey("MusicianId")]
    public UserProfileDTO Musician { get; set; }

    public DateTime? DateCompleted { get; set; }

    public string? Notes { get; set; }

    public List<SessionActivityDTO> SessionActivities { get; set; }

    public int Duration { 
        get {

            int res = 0;
            
            if(SessionActivities != null)
            {
                foreach(SessionActivityDTO sa in SessionActivities)
                {
                    res+= sa.Duration;
                }
            }

            return res;
        }
    }

}