using DesafioMxM.Domain.Models;

namespace DesafioMxM.Repositories.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(long id);
    Task Create(T entity);

    Task Update(T entity);

    Task Delete(T entity);

}
