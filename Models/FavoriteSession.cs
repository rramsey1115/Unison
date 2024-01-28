using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models;

public class FavoriteSession 
{
    public int Id { get; set; }

    [Required]
    public int SessionId { get; set; }

    [ForeignKey("SessionId")]
    public Session? Session { get; set; }

    [Required]
    public int MusicianId { get; set; }

    [ForeignKey("MusicianId")]
    public UserProfile? Musician { get; set; }
    
}