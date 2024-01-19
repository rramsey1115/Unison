using System.ComponentModel.DataAnnotations;

public class SessionActivity
{
    public int Id { get; set; }

    [Required]
    public int SessionId { get; set; }

    [Required]
    public int ActivityId { get; set; }

    [Required]
    public int Duration { get; set; }
}