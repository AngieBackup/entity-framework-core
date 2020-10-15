using BdEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BdEntityFramework.Data.Repositories
{
  public class Repository<T> : IRepository<T> where T : Entity
  {
    private SchoolDbContext _context = null;
    private DbSet<T> table = null;

    public Repository(SchoolDbContext _context)
    {
      this._context = _context;
      table = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
      return table.ToList();
    }

    public T GetById(object id)
    {
      return table.Find(id);
    }

    public void Insert(T obj)
    {
      table.Add(obj);
    }

    public void Update(T obj)
    {
      table.Attach(obj);
      _context.Entry(obj).State = EntityState.Modified;
    }

    public void Delete(object id)
    {
      T existing = table.Find(id);
      table.Remove(existing);
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}