using System.ComponentModel.DataAnnotations;
namespace Unison.Models.DTOs;

public class ActivityObjDTO 
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Details { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public CategoryDTO Category { get; set; }

}