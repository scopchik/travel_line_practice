using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;
public class Repository<T> : IRepository<T>
    where T : class
{
    public readonly TheaterDbContext _dbContext;

    public Repository( TheaterDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Delete( T item )
    {
        _dbContext.Set<T>().Remove( item );
        _dbContext.SaveChanges();
    }

    public List<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public void Save(  )
    {
        _dbContext.SaveChanges();
    }

    public void Create ( T item )
    {
        _dbContext.Set<T>().Add( item );
        _dbContext.SaveChanges();
    }
}
