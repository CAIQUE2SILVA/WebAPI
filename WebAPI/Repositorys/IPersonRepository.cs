using WebAPI.Model;

namespace WebAPI.Repositorys
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
