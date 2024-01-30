using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models.DTOs;

public class AssignmentDTO
{
    public int Id { get; set; }

    [Required]
    public int MusicianId { get; set; }

    [ForeignKey("MusicianId")]
    public UserProfileDTO Musician { get; set; }

    [Required]
    public int TeacherId { get; set; }

    [ForeignKey("TeacherId")]
    public UserProfileDTO Teacher { get; set; }

    [Required]
    public int SessionId { get; set; }

    [ForeignKey("SessionId")]
    public SessionDTO Session { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public bool Complete { 
        get
        {
               return Session.DateCompleted != null;
        }
    }
}