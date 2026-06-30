using System.ComponentModel.DataAnnotations;

namespace ToDoozy.Server.Data.Entities
{
    public class UserEntity
    {
        [Key]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? HashedPassword { get; set; }

        // TODO: Do we want to force these to Unix epoch? Probably not worth it - remember to update docs
        [Required]
        public DateTime CreatedAt { get; set; }

        // TODO: Do we want to force these to Unix epoch? Probably not worth it - remember to update docs
        [Required]
        public DateTime UpdatedAt { get; set; }

        // TODO: Add "Role" property for forward extensibility later?
    }
}
