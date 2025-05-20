using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.DataAccess.Entities;
using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Surname)
                .IsRequired();

            builder.Property(b => b.Name)
                .HasMaxLength(User.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(b => b.Patronymic)
                .IsRequired();

            builder.Property(b => b.DateOfBirth)
                .IsRequired();

            builder.Property(b => b.Phone)
                .IsRequired();

            builder.Property(b => b.Email)
                .IsRequired();

            builder.Property(b => b.Login)
                .IsRequired();

            builder.Property(b => b.Password)
                .IsRequired();

            // Конфигурация внешних ключей
            builder.HasOne(a => a.Role)
                .WithMany(t => t.User)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Индексы для внешних ключей
            builder.HasIndex(a => a.RoleId);
        }
    }
}