using AnimalShelter.Core.Models;
using AnimalShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.DataAccess.Configurations
{
    public class StatusAdoptionConfiguration : IEntityTypeConfiguration<StatusAdoptionEntity>
    {
        public void Configure(EntityTypeBuilder<StatusAdoptionEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(StatusAdoption.MAX_NAME_LENGTH)
                .IsRequired();
        }
    }
}