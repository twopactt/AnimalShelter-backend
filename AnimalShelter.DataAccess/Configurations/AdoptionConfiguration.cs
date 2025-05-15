using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.DataAccess.Entities;
using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Configurations
{
    public class AdoptionConfiguration : IEntityTypeConfiguration<AdoptionEntity>
    {
        public void Configure(EntityTypeBuilder<AdoptionEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.ApplicationDate)
                .IsRequired();

            builder.Property(b => b.ApplicationDate)
                .HasMaxLength(Adoption.MAX_NAME_LENGTH)
                .IsRequired();

            // Конфигурация внешних ключей
            builder.HasOne(a => a.User)
                .WithMany(t => t.Adoption)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Animal)
                .WithMany(s => s.Adoption)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Employee)
                .WithMany(h => h.Adoption)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Индексы для внешних ключей
            builder.HasIndex(a => a.UserId);
            builder.HasIndex(a => a.AnimalId);
            builder.HasIndex(a => a.EmployeeId);
        }
    }
}