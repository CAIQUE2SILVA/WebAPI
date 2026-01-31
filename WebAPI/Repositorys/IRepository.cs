using WebAPI.Model.Base;

namespace WebAPI.Repositorys
{
    public interface IRepository<T> where T : BaseEntidy
    {
        List<T> FindAll();

        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);

        bool Exists(long id);
    }
}
