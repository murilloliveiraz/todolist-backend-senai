using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using todolist_backend_senai.ClassMappings;
using todolist_backend_senai.Domain;

namespace todolist_backend_senai.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TodoTaskMap());
            base.OnModelCreating(modelBuilder);
        }
        public string ConnectionString()
        {
            return "Host=localhost;Port=5432;Database=todolist;Username=postgres;Password=123456;";

        }
    }
}
