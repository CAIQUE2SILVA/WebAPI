using WebAPI.Model;
using WebAPI.Model.Context;

namespace WebAPI.Services.Impl
{
    public class PersonServicesImpl : IPersonServices

    {
        private MSSQLContext _context;

        public PersonServicesImpl(MSSQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }


        public Person Create(Person person)
        {
           _context.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person Update(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);
            if (existingPerson == null)
            {
                return null;
            }
            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            var existingPerson = _context.Persons.Find(id);
            if (existingPerson != null)
            {
                _context.Persons.Remove(existingPerson);
                _context.SaveChanges();
            }
            return;
        }

    }
}
