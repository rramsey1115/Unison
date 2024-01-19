using System.ComponentModel.DataAnnotations;
namespace Unison.Models;

public class ActivityObj 
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Details { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}