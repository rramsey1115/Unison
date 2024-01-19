using System.ComponentModel.DataAnnotations;

namespace Unison.Models.DTOs;

public class SessionActivityDTO
{
    public int Id { get; set; }

    [Required]
    public int SessionId { get; set; }

    [Required]
    public int ActivityId { get; set; }

    [Required]
    public int Duration { get; set; }
}