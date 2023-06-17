using DesafioMxM.Domain;
using DesafioMxM.Domain.Models;
using DesafioMxM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioMxM.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : Entity
{

    protected readonly ApplicationContext _dbContext;

    public BaseRepository(ApplicationContext bankContext)
    {
        _dbContext = bankContext;
    }
    public async Task Create(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T> GetById(long id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }


    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public Task Update(T entity)
    {
        throw new NotImplementedException();
    }
    public Task Delete(T entity)
    {
        throw new NotImplementedException();
    }

}
