using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unison.Models;

public class SessionActivity
{
    public int Id { get; set; }

    [Required]
    public int SessionId { get; set; }

    [Required]
    public int ActivityId { get; set; }

    [ForeignKey("ActivityId")]
    public ActivityObj? Activity { get; set; }

    [Required]
    public int Duration { get; set; }
}