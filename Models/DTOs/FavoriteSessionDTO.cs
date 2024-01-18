using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models.DTOs;

public class FavoriteSessionDTO
{
    public int Id { get; set; }

    [Required]
    public int SessionId { get; set; }

    [ForeignKey("SessionId")]
    public SessionDTO Session { get; set; }

    [Required]
    public int MusicianId { get; set; }

    [ForeignKey("MusicianId")]
    public UserProfileDTO Musician { get; set; }
}