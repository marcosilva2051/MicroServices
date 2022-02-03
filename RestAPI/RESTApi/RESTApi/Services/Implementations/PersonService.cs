using Microsoft.EntityFrameworkCore;
using RESTApi.Model;

namespace RESTApi.Services.Implementations
{
    public class PersonService : IPerson
    {
        protected ApiDBContext _dbContext;

        public PersonService(ApiDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public Person Create(Person person)
        {
            _dbContext.Add(person);
            return person;
        }

        public void Delete(Person person)
        {
            _dbContext.Remove(person);
        }

        public List<Person> FindAll()
        {
            return _dbContext.Set<Person>().ToList();
        }

        public Person FindById(int id)
        {
           return _dbContext.Set<Person>().SingleOrDefault(x => x.Id == id);
           
        }

        public void Update(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            _dbContext.Update(person);

        }
    }
}
