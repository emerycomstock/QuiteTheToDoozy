using Microsoft.EntityFrameworkCore;
using ToDoozy.Server.Common.Enums;
using ToDoozy.Server.Common.Exceptions;
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

        /**
         * Retrieves a record from the DB, throws ResourceNotFoundException if no such resource is owned by the user.
         */
        public async Task<ToDoEntity> GetToDoById(int id, int userId)
        {
            var entity = await _context.ToDos.FindAsync(id);
            if (entity is null || entity.OwnerId != userId)
                throw new ResourceNotFoundException($"ToDo with id {id} not found for user {userId}.");

            return entity;
        }

        /**
         * Lists records in the DB, supports pagination, search query, and status-level filtering
         */
        public async Task<IEnumerable<ToDoEntity>> ListToDos(int page, int limit, string? searchQuery, IEnumerable<ToDoStatus>? statuses, int userId)
        {
            var validStatuses = ResolveValidStatuses(statuses);
            var nonNullQueryString = searchQuery ?? string.Empty;

            var entities = await _context.ToDos
                .Where(entity => 
                    entity.OwnerId == userId &&
                    validStatuses.Contains(entity.Status) &&
                    (
                        entity.Title.Contains(nonNullQueryString) || 
                        (entity.Description != null && entity.Description.Contains(nonNullQueryString))
                    ))
                .OrderBy(entity => entity.CreatedAt)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return entities;
        }

        /**
         * Creates a new record in the DB.
         */
        public async Task<ToDoEntity> CreateToDo(string? title, string? description, int userId)
        {
            var now = DateTime.UtcNow;

            // Create new record, defaulting to NotStarted status
            var newToDo = new ToDoEntity
            {
                Title = title,
                Description = description,
                Status = ToDoStatus.NotStarted,
                OwnerId = userId,
                CreatedAt = now,
                UpdatedAt = now
            };

            await _context.ToDos.AddAsync(newToDo);
            await _context.SaveChangesAsync();

            // Id is populated after SaveChanges
            return newToDo;
        }

        /**
         * Updates a record in the DB, throws ResourceNotFoundException if no such resource is owned by the user.
         */
        public async Task<ToDoEntity> UpdateToDo(int id, string? title, string? description, ToDoStatus? status, int userId)
        {
            var entity = await GetToDoById(id, userId);

            entity.Title = title ?? entity.Title;
            entity.Description = description ?? entity.Description;
            entity.Status = status ?? entity.Status;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return entity;
        }

        /**
         * Deletes a record from the DB, throws ResourceNotFoundException if no such resource is owned by the user.
         */
        public async Task DeleteToDo(int id, int userId)
        {
            var entity = await GetToDoById(id, userId);

            _context.ToDos.Remove(entity);
            _context.SaveChanges();
        }

        /**
         * Helper for resolving statuses as a list, converting no filter to all statuses.
         */
        private IList<ToDoStatus> ResolveValidStatuses(IEnumerable<ToDoStatus>? statuses)
        {
            if (statuses is null) return [ToDoStatus.NotStarted, ToDoStatus.InProgress, ToDoStatus.Completed, ToDoStatus.Abandoned];

            return statuses.ToList();
        }
    }
}
