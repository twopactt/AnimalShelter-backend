using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.IsAdmin)
                .IsRequired();

            // Конфигурация внешних ключей
            builder.HasOne(a => a.User)
                .WithMany(t => t.Employee)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Индексы для внешних ключей
            builder.HasIndex(a => a.UserId);
        }
    }
}