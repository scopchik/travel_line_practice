using Domain.Entities;

namespace Domain.Repositories;
public interface IRepository <T>
    where T : class
{
    public List<T> GetAll();
    void Save( );
    void Delete( T item );
    void Create ( T item );
}
