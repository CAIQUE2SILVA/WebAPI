
using Microsoft.EntityFrameworkCore;
using WebAPI.Model.Base;
using WebAPI.Model.Context;

namespace WebAPI.Repositorys.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntidy
    {
        private MSSQLContext _context;

        private DbSet<T> _dataset;
        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.Find(id);
        }

        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public T Update(T item)
        {
            var existingItem = _dataset.Find(item.Id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return item;
            }
            return null;
        }
        public void Delete(long id)
        {
            var existingItem = _dataset.Find(id);
            if (existingItem != null) return;

                _context.Remove(existingItem);
                _context.SaveChanges();
            
        }

        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);
        }


    }
}
