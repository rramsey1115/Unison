using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unison.Models.DTOs;

public class SessionActivityDTO
{
    public int Id { get; set; }

    public int SessionId { get; set; }

    [Required]
    public int ActivityId { get; set; }

    [ForeignKey("ActivityId")]
    public ActivityObjDTO Activity { get; set; }

    [Required]
    public int Duration { get; set; }
}