using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using todolist_backend_senai.Domain;

namespace todolist_backend_senai.ClassMappings
{
    public class TodoTaskMap : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.ToTable("Tasks")
      .HasKey(task => task.Id);

            builder.Property(ex => ex.Status)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(ex => ex.Description)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(ex => ex.Section)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(ex => ex.Registrationdate)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.Property(ex => ex.Priority)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.HasOne(task => task.User)
                .WithMany(user => user.Tasks)
                .HasForeignKey(task => task.UserId);
        }
    }
}
