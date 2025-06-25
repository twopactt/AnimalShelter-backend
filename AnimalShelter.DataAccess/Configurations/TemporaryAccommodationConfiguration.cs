using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.DataAccess.Configurations
{
    public class TemporaryAccommodationConfiguration : IEntityTypeConfiguration<TemporaryAccommodationEntity>
    {
        public void Configure(EntityTypeBuilder<TemporaryAccommodationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.DateAnimalCapture)
                .IsRequired();

            builder.Property(b => b.DateAnimalReturn)
                .IsRequired();

            // Конфигурация внешних ключей
            builder.HasOne(a => a.User)
                .WithMany(t => t.TemporaryAccommodation)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Animal)
                .WithMany(s => s.TemporaryAccommodation)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.StatusTemporaryAccommodation)
               .WithMany(s => s.TemporaryAccommodation)
               .HasForeignKey(a => a.StatusTemporaryAccommodationId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            // Индексы для внешних ключей
            builder.HasIndex(a => a.UserId);
            builder.HasIndex(a => a.AnimalId);
            builder.HasIndex(a => a.StatusTemporaryAccommodationId);
        }
    }
}