using Finance_Core.Interfaces;
using Finance_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void DeleteRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    public async Task<T> GetByIdAsync(int id)
    {
        var transaction = await _context.Set<T>().FindAsync(id);

        return transaction ?? throw new Exception("Not found transaction with this id.");
    }
    public async Task<bool> SaveAsync() => (await _context.SaveChangesAsync()) > 0;

}
