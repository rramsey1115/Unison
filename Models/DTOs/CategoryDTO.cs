using System.ComponentModel.DataAnnotations;
namespace Unison.Models.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Details { get; set; }
}