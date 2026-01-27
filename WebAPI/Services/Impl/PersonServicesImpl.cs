using WebAPI.Model;

namespace WebAPI.Services.Impl
{
    public class PersonServicesImpl : IPersonServices

    {


    public Person FindById(long id)
        {
            var person = MockPerson((int)id);
            return person;
        }
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }

        public Person Create(Person person)
        {
            return person;
        }
        public Person Update(Person person)
        {
            person.Id = new Random().Next(1, 1000);
            return person;
        }

        public void Delete(long id)
        {
            // No implementation needed for this example
        }

        private Person MockPerson(int i )
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FristName = "Caique " + i,
                LastName = "Silva " + i,
                Address = "São Paulo - SP - Brasil " + i,
                Gender = "Male "
            };
            return person;
        }



    }
}
