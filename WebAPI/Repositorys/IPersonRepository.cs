using WebAPI.Model;

namespace WebAPI.Repositorys
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindWithPagedSearch(string page, string pageSize, string sortDirection, string name);
    }
}
