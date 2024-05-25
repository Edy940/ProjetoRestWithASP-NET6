using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SQLServerContext _context;

        public PersonServiceImplementation(SQLServerContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            // Implementação do método de exclusão
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "EdWander",
                LastName = "Silva",
                Address = "São Paulo Capital",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
