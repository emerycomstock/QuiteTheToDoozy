using Microsoft.EntityFrameworkCore;
using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.Data
{
    public class ToDoozyDbContext : DbContext
    {
        public ToDoozyDbContext(DbContextOptions<ToDoozyDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<ToDoEntity> ToDos => Set<ToDoEntity>();
    }
}
