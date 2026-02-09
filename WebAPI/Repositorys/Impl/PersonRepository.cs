using WebAPI.Model;
using WebAPI.Model.Context;

namespace WebAPI.Repositorys.Impl
{
    public class PersonRepository(MSSQLContext context) 
        : GenericRepository<Person>(context), IPersonRepository
    {
        public Person Disable(long id)
        {
            var person= _context.Persons.Find(id);
            if (person == null) return null;
            person.Enabled = false;
            _context.SaveChanges();
            return person;
        }
    }
}
