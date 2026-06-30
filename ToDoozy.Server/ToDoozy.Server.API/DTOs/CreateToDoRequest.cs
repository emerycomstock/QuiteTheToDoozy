using System.ComponentModel.DataAnnotations;

public class CreateToDoRequest
{
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string? Title { get; set; }

    [StringLength(2048, MinimumLength = 1)]
    public string? Description { get; set; }
}