using EventsMan.Application.Persistence;
using EventsMan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventsMan.Infrastructure.Repositories.Common;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    private readonly EventManDbContext _dbContext;

    public BaseRepository(EventManDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size)
    {
        return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }
}