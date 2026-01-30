using WebAPI.Model;
using WebAPI.Repositorys;

namespace WebAPI.Services.Impl
{
    public class BookSevicesImpl : IBookServices
    {
        private IBookRepository _repository;
        public BookSevicesImpl(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
