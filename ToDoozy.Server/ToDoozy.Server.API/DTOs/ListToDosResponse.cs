using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.API.DTOs
{
    public class ListToDosResponse
    {
        public IEnumerable<PartialToDo> ToDos { get; set; } = Enumerable.Empty<PartialToDo>();

        public static ListToDosResponse FromEntities(IEnumerable<ToDoEntity> entities)
        {
            return new ListToDosResponse { ToDos = entities.Select(PartialToDo.FromEntity) };
        }
    }
}
