using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models.DTOs;

public class CommentDTO
{
    public int Id { get; set; }

    [Required]
    public int SessionId { get; set; }

    [Required]
    public int TeacherId { get; set; }

    [ForeignKey("TeacherId")]
    public UserProfileDTO Teacher { get; set; }

    [Required]
    public string Body { get; set; }
}