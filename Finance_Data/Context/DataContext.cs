using Finance_Core.Entities;
using Finance_Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Users> Users { get; set; }

    public DbSet<Categories> Categories { get; set; }

    public DbSet<Transactions> Transactions { get; set; }

    public DbSet<Budgets> Budgets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersMap());

        modelBuilder.ApplyConfiguration(new CategoriesMap());

        modelBuilder.ApplyConfiguration(new TransactionsMap());

        modelBuilder.ApplyConfiguration(new BudgetsMap());
    }
}

