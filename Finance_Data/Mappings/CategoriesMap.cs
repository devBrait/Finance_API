using Finance_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance_Data.Mappings;

public class CategoriesMap : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {

        builder.ToTable("Categories");
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
            .HasColumnType("timestamp");
    }
}
