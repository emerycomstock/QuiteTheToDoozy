using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoozy.Server.Common.Enums;

namespace ToDoozy.Server.Data.Entities
{
    public class ToDoEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public string Title { get; set; } = "PLACEHOLDER";

        [StringLength(2048, MinimumLength = 1)]
        public string? Description { get; set; }

        [Required]
        [EnumDataType(typeof(ToDoStatus))]
        public ToDoStatus Status { get; set; } = ToDoStatus.NotStarted;

        [Required]
        public int OwnerId { get; set; }

        // TODO: Do we want to force these to Unix epoch? Probably not worth it - remember to update docs
        [Required]
        public DateTime CreatedAt { get; set; }

        // TODO: Do we want to force these to Unix epoch? Probably not worth it - remember to update docs
        [Required]
        public DateTime UpdatedAt { get; set; }



        // Navigation property
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser<int>? Owner { get; set; }
    }
}
