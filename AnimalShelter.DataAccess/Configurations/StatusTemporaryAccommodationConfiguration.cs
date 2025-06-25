using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Configurations
{
    public class StatusTemporaryAccommodationConfiguration : IEntityTypeConfiguration<StatusTemporaryAccommodationEntity>
    {
        public void Configure(EntityTypeBuilder<StatusTemporaryAccommodationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(StatusTemporaryAccommodation.MAX_NAME_LENGTH)
                .IsRequired();
        }
    }
}