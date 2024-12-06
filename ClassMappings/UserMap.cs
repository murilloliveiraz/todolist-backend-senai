using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using todolist_backend_senai.Domain;

namespace todolist_backend_senai.ClassMappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
      .HasKey(user => user.Id);

            builder.Property(user => user.Email)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(user => user.Nome)
            .HasColumnType("VARCHAR")
            .IsRequired();

        }
    }
}
