using Finance_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance_Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.ToTable("Category");
        builder.HasKey(x => x.id);
        builder.Property(x => x.id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.name)
            .IsRequired()
            .HasColumnType("varchar(255)");

        builder.Property(x => x.type)
            .IsRequired()
            .HasConversion<int>()
            .HasColumnType("int");

        builder.Property(x => x.created_at)
            .IsRequired()
            .HasColumnType("timestamp with time zone");
    }
}
