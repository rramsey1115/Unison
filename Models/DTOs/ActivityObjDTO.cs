using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Unison.Models.DTOs;

public class ActivityObjDTO 
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Details { get; set; }

    public int? CreatorId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]      
    public CategoryDTO Category { get; set; }

}