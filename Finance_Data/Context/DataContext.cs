using Finance_Core.Entities;
using Finance_Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }

    public DbSet<Category> Category { get; set; }

    public DbSet<Transaction> Transaction { get; set; }

    public DbSet<Budget> Budget { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());

        modelBuilder.ApplyConfiguration(new CategoryMap());

        modelBuilder.ApplyConfiguration(new TransactionMap());

        modelBuilder.ApplyConfiguration(new BudgetMap());
    }
}

