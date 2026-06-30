using ToDoozy.Server.Common.Enums;
using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.Data.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoozyDbContext _context;

        public ToDoService(ToDoozyDbContext context)
        {
            _context = context;
        }

        public Task<bool> CreateToDo(string? title, string? description, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToDo(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoEntity> GetToDoById(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoEntity>> ListToDos(int page, int limit, IEnumerable<ToDoStatus> statuses, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDo(int id, string? title, string? description, ToDoStatus? status, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
