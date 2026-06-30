using ToDoozy.Server.Common.Enums;
using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.Data.Services
{
    public interface IToDoService
    {
        public Task<ToDoEntity> GetToDoById(int id, string userId);
        public Task<IEnumerable<ToDoEntity>> ListToDos(int page, int limit, IEnumerable<ToDoStatus> statuses, string userId);
        public Task<bool> CreateToDo(string? title, string? description, string userId);
        public Task<bool> UpdateToDo(int id, string? title, string? description, ToDoStatus? status, string userId);
        public Task<bool> DeleteToDo(int id, string userId);
    }
}
