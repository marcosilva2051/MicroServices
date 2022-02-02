using RESTApi.Model;

namespace RESTApi.Services.Implementations
{
    public interface IPerson
    {
        Person Create(Person person);
        void Update(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        void Delete(Person person);

        void Commit();
    }
}
