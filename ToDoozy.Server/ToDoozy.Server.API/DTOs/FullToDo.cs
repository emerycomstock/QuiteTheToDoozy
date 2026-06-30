using ToDoozy.Server.Common.Enums;
using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.API.DTOs
{
    public class FullToDo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ToDoStatus? Status { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static FullToDo FromEntity(ToDoEntity entity)
        {
            return new FullToDo
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Status = entity.Status,
                OwnerId = entity.OwnerId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
