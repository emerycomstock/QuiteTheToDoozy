using ToDoozy.Server.Common.Enums;
using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.API.DTOs
{
    public class PartialToDo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ToDoStatus? Status { get; set; }

        public static PartialToDo FromEntity(ToDoEntity entity)
        {
            return new PartialToDo
            {
                Id = entity.Id,
                Title = entity.Title,
                Status = entity.Status
            };
        }
    }
}
