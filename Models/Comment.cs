using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models;

public class Comment
{
    public int Id { get; set; }

    [Required]
    public int SessionId { get; set; }

    [Required]
    public int TeacherId { get; set; }

    [ForeignKey("TeacherId")]
    public UserProfile Teacher { get; set; }

    [Required]
    public string Body { get; set; }
}