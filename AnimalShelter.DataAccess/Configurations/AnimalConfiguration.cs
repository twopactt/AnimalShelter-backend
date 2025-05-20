using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.DataAccess.Entities;
using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<AnimalEntity>
    {
        public void Configure(EntityTypeBuilder<AnimalEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(Animal.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(b => b.Gender)
                .IsRequired();

            builder.Property(b => b.Age)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Photo)
                .IsRequired();

            // Конфигурация внешних ключей
            builder.HasOne(a => a.TypeAnimal)
                .WithMany(t => t.Animal)
                .HasForeignKey(a => a.TypeAnimalId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.AnimalStatus)
                .WithMany(s => s.Animal)
                .HasForeignKey(a => a.AnimalStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Индексы для внешних ключей
            builder.HasIndex(a => a.TypeAnimalId);
            builder.HasIndex(a => a.AnimalStatusId);
        }
    }
}