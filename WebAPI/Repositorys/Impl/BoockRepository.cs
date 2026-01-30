using WebAPI.Model;
using WebAPI.Model.Context;

namespace WebAPI.Repositorys.Impl
{
    public class BoockRepository : IBookRepository
    {
        private MSSQLContext _context;

        public BoockRepository(MSSQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }
        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }
        public Book Update(Book book)
        {
            var result = _context.Books.FirstOrDefault(b => b.Id == book.Id);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public void Delete(long id)
        {
            var result = _context.Books.FirstOrDefault(b => b.Id == id);
            if (result != null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
        }


    }
}
