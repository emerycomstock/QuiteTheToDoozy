using ToDoozy.Server.Common.Enums;
using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.Data.Services
{
    public interface IToDoService
    {
        public Task<ToDoEntity> GetToDoById(int id, int userId);
        public Task<IEnumerable<ToDoEntity>> ListToDos(int page, int limit, string? searchQuery, IEnumerable<ToDoStatus>? statuses, int userId);
        public Task<ToDoEntity> CreateToDo(string? title, string? description, int userId);
        public Task<ToDoEntity> UpdateToDo(int id, string? title, string? description, ToDoStatus? status, int userId);
        public Task DeleteToDo(int id, int userId);
    }
}
