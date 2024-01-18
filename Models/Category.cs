using System.ComponentModel.DataAnnotations;

public class Category 
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Details { get; set; }
}