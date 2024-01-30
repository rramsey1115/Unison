using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Unison.Models;

public class Assignment
{
    public int Id { get; set; }

    [Required]
    public int MusicianId { get; set; }

    [ForeignKey("MusicianId")]
    public UserProfile? Musician { get; set; }

    [Required]
    public int TeacherId { get; set; }

    [ForeignKey("TeacherId")]
    public UserProfile? Teacher { get; set; }

    [Required]
    public int SessionId { get; set; }

    [ForeignKey("SessionId")]
    public Session? Session { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public bool Complete { 
        get
        {

            if(Session == null)
            {
                return false;
            }
            if (Session?.DateCompleted == null)
            {
                return false;
            }
            return true;
        }
    }
}