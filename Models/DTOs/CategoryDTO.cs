using System.ComponentModel.DataAnnotations;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Details { get; set; }
}