using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.DataAccess.Entities;
using AnimalShelter.Core.Models;

namespace AnimalShelter.DataAccess.Configurations
{
    public class TypeAnimalConfiguration : IEntityTypeConfiguration<TypeAnimalEntity>
    {
        public void Configure(EntityTypeBuilder<TypeAnimalEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(TypeAnimal.MAX_NAME_LENGTH)
                .IsRequired();
        }
    }
}