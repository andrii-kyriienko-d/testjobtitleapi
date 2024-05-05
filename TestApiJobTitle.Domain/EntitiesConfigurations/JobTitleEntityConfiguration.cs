using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApiJobTitle.Domain.Entities;

namespace TestApiJobTitle.Domain.EntitiesConfigurations;

public class JobTitleEntityConfiguration : IEntityTypeConfiguration<JobTitle>
{
    public void Configure(EntityTypeBuilder<JobTitle> builder)
    {
        builder.Property(entity => entity.Name).HasMaxLength(256);
    }
}