using Finance_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance_Data.Mappings;

public class TransactionsMap : IEntityTypeConfiguration<Transactions>
{
    public void Configure(EntityTypeBuilder<Transactions> builder)
    {
        builder.ToTable("Transactions");
        builder.HasKey(x => x.id);
        builder.Property(x => x.id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.user_id)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(x => x.category_id)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(x => x.amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.date)
            .IsRequired()
            .HasColumnType("timestamp");

        builder.Property(x => x.description)
            .IsRequired()
            .HasColumnType("varchar(255)");

        builder.Property(x => x.created_at)
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(x => x.update_at)
            .HasColumnType("timestamp")
            .IsRequired(false);
    }
}