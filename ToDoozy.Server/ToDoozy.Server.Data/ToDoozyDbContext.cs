using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoozy.Server.Data.Entities;

namespace ToDoozy.Server.Data
{
    public class ToDoozyDbContext : IdentityUserContext<IdentityUser<int>, int>
    {
        public ToDoozyDbContext(DbContextOptions<ToDoozyDbContext> options) : base(options) { }

        public DbSet<ToDoEntity> ToDos => Set<ToDoEntity>();
    }
}
