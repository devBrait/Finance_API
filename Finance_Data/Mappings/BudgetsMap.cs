using Finance_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance_Data.Mappings;

public class BudgetsMap : IEntityTypeConfiguration<Budgets>
{
    public void Configure(EntityTypeBuilder<Budgets> builder)
    {
        builder.ToTable("Budgets");
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

        builder.Property(x => x.start_date)
            .IsRequired()
            .HasColumnType("timestamp with time zone");

        builder.Property(x => x.end_date)
            .IsRequired()
            .HasColumnType("timestamp with time zone");

        builder.Property(x => x.created_at)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}