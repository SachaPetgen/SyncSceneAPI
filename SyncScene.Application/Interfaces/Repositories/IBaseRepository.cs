using SyncScene.Domain.Models.Base;

namespace Application.Interfaces.Repositories;


public interface IBaseRepository<T> where T : BaseEntity
{

    Task<IEnumerable<T>> GetAll();
    Task<T?> Create(T entity);
    Task<T?> Update(T entity);
    Task Delete(T entity);

}