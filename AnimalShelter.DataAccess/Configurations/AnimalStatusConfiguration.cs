using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.DataAccess.Entities;
using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Configurations
{
    public class AnimalStatusConfiguration : IEntityTypeConfiguration<AnimalStatusEntity>
    {
        public void Configure(EntityTypeBuilder<AnimalStatusEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(AnimalStatus.MAX_NAME_LENGTH)
                .IsRequired();
        }
    }
}