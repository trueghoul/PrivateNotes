using Microsoft.EntityFrameworkCore;
using PrivateNotes.Entites;

namespace PrivateNotes.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected NotesDbContext _context;
    public GenericRepository(NotesDbContext context)
    {
        _context = context;
    }
    public void Create(TEntity item)
    {
        _context.Set<TEntity>().Add(item);
        _context.SaveChanges();
    }

    public TEntity FindById(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> Get()
    {
        return _context.Set<TEntity>().AsNoTracking().ToList();
    }

    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
    {
        return _context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
    }

    public void Remove(TEntity item)
    {
        _context.Set<TEntity>().Remove(item);
        _context.SaveChanges();
    }

    public void Update(TEntity item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
    }
}