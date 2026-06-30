using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [StringLength(64, MinimumLength = 1)]
    public string? Password { get; set; }
}