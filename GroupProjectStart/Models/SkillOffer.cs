using System.ComponentModel.DataAnnotations;
namespace GroupProjectStart.Models;

public class SkillOffer
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    [Range(3, 100)]
    public string Title { get; set; } = string.Empty;
    [Range(3, 1000)]
    public string Description { get; set; } = string.Empty;
    [Range(3, 100)]
    public string Category { get; set; } = string.Empty;
    [Range(3, 100)]
    public string Location { get; set; } = string.Empty;
}
