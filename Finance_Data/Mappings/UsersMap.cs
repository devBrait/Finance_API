using Finance_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance_Data.Mappings;

public class UsersMap : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {

        builder.ToTable("Users");
        builder.HasKey(x => x.id);
        builder.Property(x => x.id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.name)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(x => x.email)
            .IsRequired()
            .HasColumnType("varchar(255)");

        builder.Property(x => x.password)
            .IsRequired()
            .HasColumnType("varchar(255)");

        builder.Property(x => x.created_at)
            .HasColumnName("CreatedAt")
            .HasColumnType("timestamp");

        builder.Property(x => x.updated_at)
            .HasColumnName("UpdatedAt")
            .IsRequired(false)
            .HasColumnType("timestamp");
    }
}
